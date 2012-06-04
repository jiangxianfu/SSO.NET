using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SSOServerLibrary
{
    public class SSOController : ISSOController
    {
        HttpContext current = HttpContext.Current;
        public SSOController()
        {
        }
        public ISSOServer GetRequestSSOServer()
        {
            ISSOServer server = new SSOServer();
            string strToken = current.Request.QueryString["token"];
            SSOToken token = new SSOToken(strToken);
            server.Token = token;
            server.ReturnUrl = current.Request.QueryString["returnurl"];
            string siteid = current.Request.QueryString["siteid"];
            server.SiteId = siteid;
            if (string.IsNullOrEmpty(server.ReturnUrl) && !string.IsNullOrEmpty(siteid))
            {
                server.ReturnUrl = Sites.Instance.GetSite(siteid).HomePage;
            }
            return server;
        }
        public string GetResponseToken()
        {
            string uid = current.Session["uid"].ToString();
            TimeSpan timeout = new TimeSpan(DateTime.Now.Ticks);
            SSOToken token = new SSOToken();
            return token.GetToken();
        }
        public int CheckUser(string uid, string password, string siteid)
        {
            if (Sites.Instance.GetSite(siteid) == null)
            {
                return -2;
            }
            return Users.Instance.Validate(uid, password);
        }
        public bool CheckUser()
        {
            if (current.Session["uid"] != null)
            {
                return true;
            }
            return false;
        }
        public void Redirect(string returnUrl)
        {
            //2.跳转Url+token
            current.Response.Redirect(SSOHelper.GetUrl(returnUrl, "token", GetResponseToken()));
        }
        public void SignOn(string uid, string siteid, string returnUrl)
        {
           
            //1.保存用户id
            //2.跳转Url+token
            if (!string.IsNullOrEmpty(uid))
            {
                HttpContext.Current.Session["uid"] = uid;
                SSOServerState.Instance.Add(uid, siteid);
                Redirect(returnUrl);
            }
        }
        public void SignOut()
        {
            ISSOServer server = GetRequestSSOServer();
            current.Session.Remove("uid");
            SSOServerState.Instance.RemoveUser(server.Token.Uid);
            current.Response.Redirect(SSOConst.SignOnUrl);
        }
    }
}

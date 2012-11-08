using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SSOClientSDK
{
    /// <summary>
    /// 客户端代码
    /// </summary>
    public class SSOClient : ISSOClient
    {
        HttpContext current = HttpContext.Current;
        public string SiteId
        {
            get
            {
                return "1";
            }
        }

        public string HomePage
        {
            get
            {
                return "http://localhost:34391/default.aspx";
            }
        }
        public string LoginPage
        {
            get
            {
                return "http://localhost:34373/SignOn.aspx";
            }
        }
        public string Uid { get; set; }
        public string GetUid(string token)
        {
            return "";
        }
        public bool SignOn(out string exInfo)
        {
            exInfo = "";
            string token = current.Request.QueryString["token"];
            if (!CheckState(token))
            {
                string url = LoginPage + "?siteid=1&returnurl=" + current.Server.UrlEncode(HomePage);
                current.Response.Redirect(url);
            }
            return true;
        }
        public void SignOut()
        {

        }
        public bool CheckState(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                current.Session["uid"] = "steven";
            }
            if (current.Session["uid"] == null)
            {
                return false;
            }
            Uid = current.Session["uid"].ToString();
            return true;
        }
    }
}
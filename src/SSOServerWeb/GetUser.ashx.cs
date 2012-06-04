using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSOServerLibrary;

namespace SSOServerWeb
{
    /// <summary>
    /// Summary description for GetUser
    /// </summary>
    public class GetUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            SSOController ssoController = new SSOController();
            ISSOServer server = ssoController.GetRequestSSOServer();
            if (!string.IsNullOrEmpty(server.Token.Uid))
            {
                ISSOUser user = Users.Instance.GetUser(server.Token.Uid);
                context.Response.Write(user.ToString());
            }
            else
            {
                context.Response.Write("error");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
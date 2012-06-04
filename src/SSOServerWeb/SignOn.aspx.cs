using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSOServerLibrary;

namespace SSOServerWeb
{
    public partial class SignOn : System.Web.UI.Page
    {
        SSOController ssoController = new SSOController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string siteid = Request.QueryString["siteid"];
                if (string.IsNullOrEmpty(siteid))
                {
                    lblerror.Text = "请确保siteid参数是否正确";
                    return;
                }
                
                string returnUrl = "";
                if (ssoController.CheckUser())
                {
                    ISSOServer server = ssoController.GetRequestSSOServer();
                    ssoController.Redirect(returnUrl);
                }
            }
        }

        protected void btnSignOn_Click(object sender, EventArgs e)
        {
            lblerror.Text = "";
            string uid = this.txtUserName.Text.Trim();
            string pwd = this.txtPassword.Text.Trim();
            string siteid = Request.QueryString["siteid"];
            string returnUrl = Request.QueryString["returnurl"];
            if (string.IsNullOrEmpty(siteid))
            {
                lblerror.Text = "请确保siteid参数是否正确";
                return;
            }
            if (ssoController.CheckUser(uid, pwd, siteid) == 1)
            {
                ssoController.SignOn(uid, siteid, returnUrl);
            }
            else
            {
                lblerror.Text = "用户名或密码错误";
            }
        }
    }
}
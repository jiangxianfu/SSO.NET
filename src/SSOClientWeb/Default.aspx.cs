using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSOClientSDK;

namespace SSOClientWeb
{
    public partial class Default : System.Web.UI.Page
    {
        SSOClient client = new SSOClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string exInfo;

                if (!client.SignOn(out exInfo))
                {
                    lblUserId.Text = "错误:[" + exInfo + "]";
                    return;
                }
                lblUserId.Text = "欢迎[" + client.Uid + "]";
            }
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            client.SignOut();
        }
    }
}
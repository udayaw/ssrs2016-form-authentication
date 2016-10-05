using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormAuth
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            bool passwordVerified = AuthenticationUtilities.VerifyPassword(userName, password);
            if (passwordVerified)
            {
                FormsAuthentication.RedirectFromLoginPage(userName, false);
            }            
            else
            {
                pnlError.Visible = true;
                txtPassword.Text = "";
                txtUserName.Text = "";
            }

            

        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SecurityLib1;

namespace OfficeHours
{
    public partial class LogInForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (UserCaptcha1.IsCaptchaValid())
            {
                string xmlPath = Server.MapPath("~/SecurityLib1/UserData.xml");

                if (File.Exists(xmlPath))
                {

                    bool isValid = PasswordHasher.ValidateUser(txtUsername.Text, txtPassword.Text, xmlPath);

                    if (isValid)
                    {
                        Label3.Text = "Login successful!";
                    }

                    else
                    {
                        Label3.Text = "Invalid username or password.";
                    }
                }

                else {
                    Label3.Text = "User data file not found";
                }
                
            }
            else
            {
                Label3.Text = "Invalid Captcha. Try Again.";
            }
        }
    }
}
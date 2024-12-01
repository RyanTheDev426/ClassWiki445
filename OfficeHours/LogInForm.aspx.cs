using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                
            }
            else
            {
                Label3.Text = "Invalid Captcha. Try Again.";
            }
        }
    }
}
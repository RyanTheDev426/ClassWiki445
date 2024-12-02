using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OfficeHours
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                // Decrypt the cookie value
                string encTicket = Request.Cookies[FormsAuthentication.FormsCookieName].Value;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(encTicket);
                string userRole = ticket.UserData;
                // Perform actions based on user role
                if (userRole != "Staff")
                {
                    Response.Redirect("~/LogInForm.aspx");
                }
            }
            else
            {
                Response.Redirect("~/LogInForm.aspx");
            }
        }

        
    }
}
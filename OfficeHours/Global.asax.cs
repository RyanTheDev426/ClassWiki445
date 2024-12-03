using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace OfficeHours
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Creates a user cookie
            /*HttpCookie existingCookie = Request.Cookies["UserSession"]; 
            if (existingCookie == null)
            {
                // Initialize cookie
                HttpCookie userCookie = new HttpCookie("UserSession");

                userCookie["Username"] = "ThisUser"; //Setting up infrastructure for session.
                userCookie["LastLogin"] = DateTime.Now.ToString();

                userCookie.Expires = DateTime.Now.AddDays(7); // Cookie expires in a week

                Response.Cookies.Add(userCookie);
            }
            else
            {
                // Update the cookie
                existingCookie["LastLogin"] = DateTime.Now.ToString();


                existingCookie.Expires = DateTime.Now.AddDays(7); //reset expiration date

                // Update the cookie by adding it back to the response
                Response.Cookies.Add(existingCookie);
            }*/
        }
    }
}
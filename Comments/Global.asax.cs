using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Assignment5_AGon
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application["TotalComments"] = 0;
            Application["ActiveUsers"] = 0;
            Application["StartTime"] = DateTime.Now;
        }

        void Session_Start(object sender, EventArgs e) {
            Application.Lock();
            Application["ActiveUsers"] = (int)Application["ActiveUsers"] + 1;
            Application.UnLock();
        }

        void Session_End(object sender, EventArgs e) {
            Application.Lock();
            Application["ActiveUsers"] = (int)Application["ActiveUsers"] - 1;
            Application.UnLock();
        
        }

        void Application_BeginRequest(object sender, EventArgs e) { }

        void Application_Error(object sender, EventArgs e) { 
        
            Exception ex = Server.GetLastError();
        }
    }
}
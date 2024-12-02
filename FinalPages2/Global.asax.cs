using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace FinalPages2
{
    public class Global : HttpApplication
    {
        private static double numDiffReviews = 0;
        private static double diffAvg = 0;
        private static double numUseReviews = 0;
        private static double useAvg = 0;
        //CSE445Page myDef;
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            //myDef = new CSE445Page(numDiffReviews, diffAvg, numUseReviews, useAvg);
        }
        /*protected void Session_End(object sender, EventArgs e)
        {
            double[] revVals = myDef.getReviewVals();
            numDiffReviews = revVals[0];
            diffAvg = revVals[1];
            numUseReviews = revVals[2];
            useAvg = revVals[3];
            myDef.Dispose();
        }*/
    }
}
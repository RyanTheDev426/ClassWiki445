using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace TryitPageRating
{
    public class Global : System.Web.HttpApplication
    {
        private static double numDiffReviews = 0;
        private static double diffAvg = 0;
        private static double numUseReviews = 0;
        private static double useAvg = 0;
        Default myDef;
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            myDef = new Default(numDiffReviews, diffAvg, numUseReviews, useAvg);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_UpdateRequestCache(object sender, EventArgs e)
        {
        
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            double[] revVals = myDef.getReviewVals();
            numDiffReviews = revVals[0];
            diffAvg = revVals[1];
            numUseReviews = revVals[2];
            useAvg = revVals[3];
            myDef.Dispose();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
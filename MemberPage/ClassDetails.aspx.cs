using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemberPage
{
    public partial class ClassDetails : System.Web.UI.Page
    {
        private static double numDiffReviews = 0;
        private static double diffAvg = 0;
        private static double numUseReviews = 0;
        private static double useAvg = 0;
        private static string name = "";
        private static ClassDetails[] listofPages = null;



        public ClassDetails()
        {

        }
        public ClassDetails(double numDiff, double dAvg, double numUse, double uAvg, ClassDetails[] avgList)
        {

            numDiffReviews = numDiff;
            diffAvg = dAvg;
            numUseReviews = numUse;
            useAvg = uAvg;
            listofPages = avgList;
            for(int i = 0; i < listofPages.Length; i++)
            {

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            initializeRating();
            setPageTitleInfo();

        }

        private void setPageTitleInfo() //Just sets the value to CSE445 for now, needs to be able to set based on page name and all that.
        {
            ClassName.Text = "CSE445 Distributed Software Development"; //Replace these with fill in variables (Maybe as parameters?)
            ClassReq.Text = "Class Requirements: Computer Science BA, Computer Science BS, or Computer Systems Engineering BSE major; CSE 360 with C or better OR Computer Science and Engineering or Software Engineering graduate student OR Visiting University Student";
        }

        private void initializeRating() //Essentiall updates the current rating and information on page load.
        {
            UpdateNumReviews();
            // Check if a cookie exists
            HttpCookie existingCookie = Request.Cookies["UserSession"];
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
            }
        }

        protected void Button1_Click(object sender, EventArgs e) //Button for Difficulty Submission button.
        {
            string Rating = TextBox1.Text;
            double ratNum = 0;
            if (Rating.Length == 1)
            {
                ratNum = Convert.ToDouble(Rating);
                if (ratNum > 5 || ratNum < 1)
                {
                    return;
                }
            }
            else
            {
                return;
            }

            RatingReference1.Service1Client prxy = new RatingReference1.Service1Client();
            ratNum = prxy.GetRating(numDiffReviews, ratNum, diffAvg);
            diffAvg = Math.Round(ratNum, 2);
            numDiffReviews++;
            UpdateNumReviews();
        }
        protected void Button2_Click(object sender, EventArgs e) //Button for Usefulness Submission button.
        {
            string Rating = TextBox2.Text;
            double ratNum = 0;
            if (Rating.Length == 1)
            {
                ratNum = Convert.ToDouble(Rating);
                if (ratNum > 5 || ratNum < 1)
                {
                    return;
                }
            }
            else
            {
                return;
            }


            RatingReference1.Service1Client prxy = new RatingReference1.Service1Client();
            ratNum = prxy.GetRating(numUseReviews, ratNum, useAvg);
            useAvg = Math.Round(ratNum, 2);
            numUseReviews++;
            UpdateNumReviews();
        }

        public void UpdateNumReviews() //Updates the number of reviews and average.
        {
            DiffRatingLabel.Text = $"Difficulty Rating: {diffAvg}";
            DiffNumLabel.Text = $"Total Ratings: {numDiffReviews}";

            UseRatingLabel.Text = $"Usefulness Rating: {useAvg}";
            UseNumLabel.Text = $"Total Ratings: {numUseReviews}";
        }

        public double[] getReviewVals() //Used for storing session state short term without cookies if necessary.
        {
            double[] revList = new double[4];
            revList[0] = numDiffReviews;
            revList[1] = diffAvg;
            revList[2] = numUseReviews;
            revList[3] = useAvg;
            return revList;
        }
    }
}
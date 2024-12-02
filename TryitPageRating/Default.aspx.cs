using System;
using System.Web;

namespace TryitPageRating
{
    public partial class Default : System.Web.UI.Page
    {
        private static double numDiffReviews = 0;
        private static double diffAvg = 0;
        private static double numUseReviews = 0;
        private static double useAvg = 0;

        public Default()
        {

        }
        public Default(double numDiff, double dAvg, double numUse, double uAvg)
        {
            numDiffReviews = numDiff;
            diffAvg = dAvg;
            numUseReviews = numUse;
            useAvg = uAvg;
        }
        protected void Page_Load(object sender, EventArgs e)
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

            ServiceReference1.Service1Client prxy = new ServiceReference1.Service1Client();
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
                if(ratNum > 5 || ratNum < 1)
                {
                    return;
                }
            }
            else
            {
                return;
            }


            ServiceReference1.Service1Client prxy = new ServiceReference1.Service1Client();
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
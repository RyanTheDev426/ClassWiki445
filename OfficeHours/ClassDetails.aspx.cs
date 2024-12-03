// written by chaitra daggubati
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace OfficeHours
{
    public partial class ClassDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string className = Request.QueryString["class"];
                XmlDocument xmlDoc = new XmlDocument();
                string filePath = Server.MapPath("~/App_Data/Classes.xml");
                xmlDoc.Load(filePath);
                XmlNode rootNode = xmlDoc.DocumentElement;
                XmlNode targetClassNode = rootNode.SelectSingleNode("Class[Name='" + className + "']");

                if (targetClassNode != null)
                {
                    string name = targetClassNode.SelectSingleNode("Name").InnerText;
                    string professor = targetClassNode.SelectSingleNode("Professor").InnerText;
                    LabelClass.Text = name;
                    LabelProf.Text = professor;


                    XmlNode tasNode = targetClassNode.SelectSingleNode("TAs");
                    List<string> tas = new List<string>();
                    if (tasNode != null)
                    {
                        foreach (XmlNode taNode in tasNode.ChildNodes)
                        {
                            tas.Add(taNode.InnerText);
                        }
                    }
                    string taStr = string.Join(",", tas.ToArray());
                    LabelTAs.Text = taStr;

                    //call web service, process the response and display the office hours
                    ServiceReference1.OfficeHoursServiceSoapClient client = new ServiceReference1.OfficeHoursServiceSoapClient();
                    string OfficeHourxml = client.GetOfficeHours(professor);
                    XmlDocument officeHourDoc = new XmlDocument();
                    officeHourDoc.LoadXml(OfficeHourxml);
                    XmlNode officeHourNode = officeHourDoc.DocumentElement;
                    string profHours = officeHourNode.SelectSingleNode("ProfessorTime").InnerText;
                    string taHours = officeHourNode.SelectSingleNode("TATime").InnerText;
                    LabelOfficeHours.Text = profHours;
                    LabelTAHours.Text = taHours;

                    //Call web service, process the response and display the ratings.
                    RatingReference.RatingServiceSoapClient ratingClient = new RatingReference.RatingServiceSoapClient();
                    string ratingsXml = ratingClient.GetRating(name);
                    XmlDocument ratingsDoc = new XmlDocument();
                    ratingsDoc.LoadXml(ratingsXml);
                    XmlNode ratingsNode = ratingsDoc.DocumentElement;

                    string diffRating = ratingsNode.SelectSingleNode("DiffRating").InnerText; //Getting all of the rating values
                    string numDiffRating = ratingsNode.SelectSingleNode("numDiffRatings").InnerText;
                    string useRating = ratingsNode.SelectSingleNode("UseRating").InnerText;
                    string numUseRating = ratingsNode.SelectSingleNode("numUseRatings").InnerText;

                    LabelDRating.Text = "Difficulty Rating: " + diffRating; //Putting the rating values into the labels.
                    LabelNumDRatings.Text = "# of Difficulty Reviews: " + numDiffRating;
                    LabelURating.Text = "Usefulness Rating: " + useRating;
                    LabelNumURatings.Text = "# of Usefulness Reviews: " + numUseRating;

                }
                else
                {
                }
                
                LoadComments();
            }
        }

        protected void ButtonDiffInsert_Click(object sender, EventArgs e) //Response button for if a difficulty rating is submitted
        {
            string difficultyInput = txtDiffRating.Text;
            txtDiffRating.Text = "";
            RatingReference.RatingServiceSoapClient ratingClient = new RatingReference.RatingServiceSoapClient();
            ratingClient.AddRating(Convert.ToDouble(difficultyInput), LabelClass.Text, true, true);
            LabelDButtonConfirm.Text = "Rating Added!";
        }

        protected void ButtonUseInsert_Click(object sender, EventArgs e) //Response button for if a usefulness rating is submitted
        {
            string usefulnessInput = txtUseRating.Text;
            txtUseRating.Text = "";
            RatingReference.RatingServiceSoapClient ratingClient = new RatingReference.RatingServiceSoapClient();
            ratingClient.AddRating(Convert.ToDouble(usefulnessInput), LabelClass.Text, true, false);
            LabelUButtonConfirm.Text = "Rating Added!";
        }

        private void LoadComments() {

            CommentsReference.CommentsServiceSoapClient client =
                new CommentsReference.CommentsServiceSoapClient();
            var comments = client.GetComments(LabelClass.Text);
            CommentsGrid.DataSource = comments;
            CommentsGrid.DataBind();

        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CommentText.Text))
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    //Get username from authentication ticket
                    var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                    var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    string username = ticket.Name;

                    CommentsReference.CommentsServiceSoapClient client =
                        new CommentsReference.CommentsServiceSoapClient();

                    client.AddComment(
                        LabelClass.Text,
                        username,  //Use the username from the ticket
                        CommentText.Text
                    );

                    CommentText.Text = string.Empty;
                    LabelCommentConfirm.Text = "Comment Added!";
                    LoadComments();
                }
                else
                {
                    LabelCommentConfirm.Text = "Please log in to add comments.";
                }
            }
        }
    }
}
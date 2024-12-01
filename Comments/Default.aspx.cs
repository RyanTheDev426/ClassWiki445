using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SecurityLib1;

namespace Assignment5_AGon
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                if (Application["TotalComments"] == null)
                    Application["TotalComments"] = 0;

                if (Application["ActiveUsers"] == null)
                    Application["ActiveUsers"] = 0;


                UpdateGridView();

            }

        }

        //handler for comment button
        protected void Button3_Click(object sender, EventArgs e) {

            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) || 
                string.IsNullOrWhiteSpace(CommentToAddTextBox.Text) || 
                string.IsNullOrWhiteSpace(PageId.Text))
            {
                return;
            
            }

            CommentsService service = new CommentsService();
            bool result = service.AddComment(
                
                UsernameTextBox.Text,
                CommentToAddTextBox.Text,
                PageId.Text
            );

            if (result)
            {
                //clear textboxes
                UsernameTextBox.Text = string.Empty;
                CommentToAddTextBox.Text = string.Empty;
                //PageId.Text = string.Empty ;

                //update total comments
                Application["TotalComments"] = (int)Application["TotalComments"] + 1;

                ResultLabel.Text = "Comment added successfully!";
                ResultLabel.ForeColor = System.Drawing.Color.Green;

                UpdateGridView();
            }
            else {
                ResultLabel.Text = "Failure to add comment";
                ResultLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        //delete comments
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName == "DeleteComment") {
                try
                {
                    //split command arg
                    string[] args = e.CommandArgument.ToString().Split('|');
                    string dateposted = args[0];
                    string username = args[1];
                    string comment = args[2];

                    CommentsService service = new CommentsService();
                    bool result = service.DeleteComment(dateposted, username, comment);

                    if (result)
                    {
                        ResultLabel.Text = "Comment deleted!";
                        ResultLabel.ForeColor = System.Drawing.Color.Green;

                        //refresh grid with current page comments
                        if (!string.IsNullOrWhiteSpace(PageId.Text))
                        {
                            var comments = service.GetComments(PageId.Text);
                            GridView1.DataSource = comments;
                            GridView1.DataBind();
                        }
                    }

                    else
                    {
                        ResultLabel.Text = "Error deleting comment";
                        ResultLabel.ForeColor = System.Drawing.Color.Red;
                    }
                }

                catch (Exception ex) {
                
                    ResultLabel.Text = "Error: " + ex.Message;
                    ResultLabel.ForeColor= System.Drawing.Color.Red;
                }
            }
        }

        private void UpdateGridView() {
            if (!string.IsNullOrWhiteSpace(PageId.Text)) {
                CommentsService service = new CommentsService();
                var comments = service.GetComments(PageId.Text);

                //debug
                System.Diagnostics.Debug.WriteLine($"Retrieved {comments.Count} comments");

                GridView1.DataSource = comments;
                GridView1.DataBind();

                //debug
                ResultLabel.Text += $"(Found {comments.Count} comments)";
            
            }
        }

        protected void HashButton_Click(object sender, EventArgs e) {
            try
            {

                if (string.IsNullOrWhiteSpace(HashInput.Text))
                {

                    HashResult.Text = "Please enter text";
                    HashResult.ForeColor = System.Drawing.Color.Red;
                    return;

                }

                string hashedValue = PasswordHasher.HashString(HashInput.Text);
                HashResult.Text = "Hash: " + hashedValue;
                HashResult.ForeColor = System.Drawing.Color.Green;

            }
            catch (Exception ex) {
                HashResult.Text = "Error: " + ex.Message ;
                HashResult.ForeColor = System.Drawing.Color.Red;
            
            }
        
        }
    }
}
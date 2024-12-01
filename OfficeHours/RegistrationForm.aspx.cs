using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using SecurityLib1;

namespace OfficeHours
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e) {

            string username = txtUsername.Text.Trim();

            string password = txtPassword.Text.Trim();

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password)) {

                lblMessage.Text = "Username and Password cannot be empty.";
                return; 
            }

            string xmlPath = Server.MapPath("~/SecurityLib1/UserData.xml");

            //check if user already exists
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            XmlNode existingUser = doc.SelectSingleNode($"/Users/User[Username='{username}']");

            if (existingUser != null) {

                lblMessage.Text = "User already exists.";
                return;
            
            }

            //add new user
            XmlElement newUser = doc.CreateElement("User");
            XmlElement usernameElement = doc.CreateElement("Username");
            usernameElement.InnerText = username;
            XmlElement passwordElement = doc.CreateElement("Password");
            passwordElement.InnerText = PasswordHasher.HashString(password);

            newUser.AppendChild(usernameElement);
            newUser.AppendChild(passwordElement);

            doc.DocumentElement.AppendChild(newUser);
            doc.Save(xmlPath);

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Registration successful";
        }
    }
}
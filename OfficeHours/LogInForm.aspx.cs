﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SecurityLib1;
using System.Xml;
using System.Web.Security;

namespace OfficeHours
{
    public partial class LogInForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if user is already authenticated, redirect to default page
            if (User.Identity.IsAuthenticated) {

                Response.Redirect("~/Members/Default.aspx");
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (UserCaptcha1.IsCaptchaValid())
            {
                string xmlPath = Server.MapPath("~/SecurityLib1/UserData.xml");

                if (File.Exists(xmlPath))
                {

                    var (isValid, userRole) = PasswordHasher.ValidateUserAndGetRole(txtUsername.Text, txtPassword.Text, xmlPath);

                    if (isValid)
                    {

                        //get user role
                        //string userRole = GetUserRole(txtUsername.Text.Trim(), xmlPath);

                        //create authentication ticket
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(

                            1, txtUsername.Text.Trim(), DateTime.Now, DateTime.Now.AddMinutes(30), false, userRole
   
                        );

                        //encrypt the ticket and create the cookie
                        string encTicket = FormsAuthentication.Encrypt(ticket);

                        HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

                        Response.Cookies.Add(authCookie);

                        Label3.Text = "Login successful!";

                        //redirect based on role
                        if (userRole == "Staff") {

                            Response.Redirect("~/Staff/Default.aspx");
                        }

                        else
                        { 
                            //redirect to requested url or default page
                            string returnUrl = Request.QueryString["ReturnUrl"];

                            if (string.IsNullOrEmpty(returnUrl)) { returnUrl = "~/Members/Default.aspx"; }

                            Response.Redirect(returnUrl);
                        }
                    }

                    else
                    {
                        Label3.Text = "Invalid username or password.";
                    }
                }

                else {
                    Label3.Text = "User data file not found";
                }
                
            }
            else
            {
                Label3.Text = "Invalid Captcha. Try Again.";
            }
        }

        /*private string GetUserRole(string username, string xmlPath) {

            try
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(xmlPath);

                XmlNode userNode = doc.SelectSingleNode($"//User[Username='{username}']");
                if (userNode != null)
                {

                    XmlNode roleNode = userNode.SelectSingleNode("Role");

                    if (roleNode != null)
                    {

                        return roleNode.InnerText;
                    }

                    else {

                        //if no role is specified add it
                        XmlElement roleElement = doc.CreateElement("Role");
                        roleElement.InnerText = "Member";
                        userNode.AppendChild(roleElement);
                        doc.Save(xmlPath);
                        return "Member";

                    }

                }
            }
            catch (Exception ex) {
            
                System.Diagnostics.Debug.WriteLine($"Error getting user role: {ex.Message}");
            }

            return "Member";
        }*/
    }
}
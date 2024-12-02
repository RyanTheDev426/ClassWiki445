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
    public partial class StaffPage : System.Web.UI.Page    
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    // Decrypt the cookie value
                    string encTicket = Request.Cookies[FormsAuthentication.FormsCookieName].Value;
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(encTicket);
                    string userRole = ticket.UserData;
                    // Perform actions based on user role
                    if (userRole != "Staff")
                    {
                        Response.Redirect("~/LogInForm.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/LogInForm.aspx");
                }
                
                XmlDocument xmlDoc = new XmlDocument();
                string filePath = Server.MapPath("~/App_Data/Classes.xml");
                xmlDoc.Load(filePath);
                XmlNode rootNode = xmlDoc.DocumentElement;
                List<Class> classNames = new List<Class>();
                foreach (XmlNode classNode in rootNode.ChildNodes)
                {
                    XmlNode nameNode = classNode.SelectSingleNode("Name");
                    XmlNode professorNode = classNode.SelectSingleNode("Professor");
                    classNames.Add(new Class { Name = nameNode.InnerText, Professor = professorNode.InnerText });
                }
                ListView1.DataSource = classNames; ListView1.DataBind();
            }
        }

        protected void BtnAddClass_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/OfficeHours.aspx");
        }
    }    
}
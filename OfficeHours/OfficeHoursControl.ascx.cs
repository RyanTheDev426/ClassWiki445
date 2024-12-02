using SecurityLib1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace OfficeHours
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string className = txtClass.Text;
            string profName = txtprofName.Text;
            string taName = txttaName.Text;

            string xmlPath = Server.MapPath("~/App_Data/Classes.xml");

            //check if user already exists
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            XmlNode existingUser = doc.SelectSingleNode($"/Classes/Class[Name='{className}']");

            if (existingUser != null)
            {
                Label9.Text = "Class already exists.";
                return;
            }

            XmlElement newClass = doc.CreateElement("Class");
            XmlElement nameElement = doc.CreateElement("Name");
            nameElement.InnerText = className;
            XmlElement profElement = doc.CreateElement("Professor");
            profElement.InnerText = profName;

            XmlElement TasElement = doc.CreateElement("TAs");
            XmlElement taElement = doc.CreateElement("TA");
            taElement.InnerText = taName;
            TasElement.AppendChild(taElement);

            newClass.AppendChild(nameElement);
            newClass.AppendChild(profElement);
            newClass.AppendChild(TasElement);

            doc.DocumentElement.AppendChild(newClass);
            doc.Save(xmlPath);

            ServiceReference1.OfficeHoursServiceSoapClient client = new ServiceReference1.OfficeHoursServiceSoapClient();
            String result = client.AddOfficeHours(txtprofName.Text, txtprofTime.Text, txtprofLocation.Text, txttaName.Text, txttaTime.Text, txttaLocation.Text);
            Label9.Text = result.ToString();

            Response.Redirect("~/StaffPage.aspx");
        }
    }
}
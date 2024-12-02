using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace StaffPage
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

                    OfficeHoursServRef.OfficeHoursServiceSoapClient client = new OfficeHoursServRef.OfficeHoursServiceSoapClient();
                    string OfficeHourxml = client.GetOfficeHours(professor);
                    XmlDocument officeHourDoc = new XmlDocument();
                    officeHourDoc.LoadXml(OfficeHourxml);
                    XmlNode officeHourNode = officeHourDoc.DocumentElement;
                    string profHours = officeHourNode.SelectSingleNode("ProfessorTime").InnerText;
                    string taHours = officeHourNode.SelectSingleNode("TATime").InnerText;
                    LabelOfficeHours.Text = profHours;
                    LabelTAHours.Text = taHours;   
                   // Service1ref.Service1Client ratingClient = new Service1ref.Service1Client();
                   // ratingClient.GetData()
                }
                else
                {
                }
            }
        }

    }
}

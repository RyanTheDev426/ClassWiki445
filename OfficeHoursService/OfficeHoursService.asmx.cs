// written by chaitra daggubati
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Xml;

namespace taOfficeHours
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OfficeHoursService : System.Web.Services.WebService
    {

        [WebMethod]
        public String AddOfficeHours(String profName, String profTime, String profLocation, String taName, String taTime, String taLocation)
        {
            XmlDocument doc = new XmlDocument();
            string filePath = Server.MapPath("~/App_Data/officeHours.xml");
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                //Create a new XML document with the root element
                XmlElement root1 = doc.CreateElement("OfficeHours");
                doc.AppendChild(root1);
                doc.Save(filePath);
            }
            // Load the existing or newly created XML document
            doc.Load(filePath);
            // Get the root element
            XmlElement root = doc.DocumentElement;
            //Create a new user element
            XmlElement user = doc.CreateElement("OfficeHour");
            root.AppendChild(user); // Add name and age elements to the user element
            XmlElement pNameElement = doc.CreateElement("ProfessorName");
            pNameElement.InnerText = profName;
            user.AppendChild(pNameElement);
            XmlElement pTimeElement = doc.CreateElement("ProfessorTime");
            pTimeElement.InnerText = profTime;
            user.AppendChild(pTimeElement); // Save the modified XML document
            XmlElement pLocaElement = doc.CreateElement("ProfessorLocation");
            pLocaElement.InnerText = profLocation;
            user.AppendChild(pLocaElement);
            XmlElement tNameElement = doc.CreateElement("TAName");
            tNameElement.InnerText = taName;
            user.AppendChild(tNameElement);
            XmlElement tTimeElement = doc.CreateElement("TATime");
            tTimeElement.InnerText = taTime;
            user.AppendChild(tTimeElement);
            XmlElement tLocaElement = doc.CreateElement("TALocation");
            tLocaElement.InnerText = taLocation;
            user.AppendChild(tLocaElement);
            doc.Save(filePath);
            return "Office Hours Added.";
        }

        [WebMethod]
        public String GetOfficeHours(String profName)
        {
            XmlDocument doc = new XmlDocument();
            string filePath = Server.MapPath("~/App_Data/officeHours.xml");
            doc.Load(filePath);
            XmlNode rootNode = doc.DocumentElement;
            XmlNode targetClassNode = rootNode.SelectSingleNode("OfficeHour[ProfessorName='" + profName + "']");
            return targetClassNode.OuterXml;
        }
    }
}
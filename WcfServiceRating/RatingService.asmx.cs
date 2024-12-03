// Written by Ryan Orth
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Xml;

namespace WcfServiceRating
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class RatingService : System.Web.Services.WebService
    {
        [WebMethod]
        public String GetRating(string className) //Gets the current ratings for a class, and if they don't exist, makes a default page for them. (Written by Ryan Orth)
        {
            XmlDocument doc = new XmlDocument();
            string filePath = Server.MapPath("~/App_Data/classRatings.xml");
            if (!File.Exists(filePath))
            {
                // Initialize a new document with the root element
                XmlElement root = doc.CreateElement("classRatings");
                doc.AppendChild(root);
                doc.Save(filePath);
            }
            doc.Load(filePath);
            XmlElement rootNode = doc.DocumentElement;

            XmlNode targetClassNode = rootNode.SelectSingleNode($"Ratings[ClassName='{className}']");
            if (targetClassNode == null) //Making the class page, should it not exist.
            {
                // Add a new Ratings entry if not found
                XmlElement newEntry = doc.CreateElement("Ratings");

                XmlElement nameEntry = doc.CreateElement("ClassName");
                nameEntry.InnerText = className;
                newEntry.AppendChild(nameEntry);

                XmlElement numDiffRatings = doc.CreateElement("numDiffRatings");
                numDiffRatings.InnerText = "0";
                newEntry.AppendChild(numDiffRatings);

                XmlElement diffEntry = doc.CreateElement("DiffRating");
                diffEntry.InnerText = "0";
                newEntry.AppendChild(diffEntry);

                XmlElement numUseRatings = doc.CreateElement("numUseRatings");
                numUseRatings.InnerText = "0";
                newEntry.AppendChild(numUseRatings);

                XmlElement useEntry = doc.CreateElement("UseRating");
                useEntry.InnerText = "0";
                newEntry.AppendChild(useEntry);

                rootNode.AppendChild(newEntry);
                doc.Save(filePath);

                targetClassNode = newEntry; // Update reference
            }

            return targetClassNode.OuterXml;
        }

        [WebMethod]
        public void AddRating(double rating, string className, bool hasRatings, bool diffRating) //Adds ratings to the classRatings.xml file located in App_Data (Written by Ryan Orth)
        {
            if (rating < 0 || rating > 5)
            {
                return;
            }

            XmlDocument doc = new XmlDocument();
            string filePath = Server.MapPath("~/App_Data/classRatings.xml");
            XmlElement root;

            if (!File.Exists(filePath))
            {
                root = doc.CreateElement("classRatings");
                doc.AppendChild(root);
                doc.Save(filePath);
            }

            doc.Load(filePath);
            root = doc.DocumentElement;

            XmlNode targetClassNode = root.SelectSingleNode($"Ratings[ClassName='{className}']");
            if (targetClassNode == null)
            {
                // Add a new Ratings entry if not found
                targetClassNode = doc.CreateElement("Ratings");

                XmlElement nameEntry = doc.CreateElement("ClassName");
                nameEntry.InnerText = className;
                targetClassNode.AppendChild(nameEntry);

                XmlElement numDiffRatings = doc.CreateElement("numDiffRatings");
                numDiffRatings.InnerText = diffRating ? "1" : "0";
                targetClassNode.AppendChild(numDiffRatings);

                XmlElement diffEntry = doc.CreateElement("DiffRating");
                diffEntry.InnerText = diffRating ? rating.ToString() : "0";
                targetClassNode.AppendChild(diffEntry);

                XmlElement numUseRatings = doc.CreateElement("numUseRatings");
                numUseRatings.InnerText = diffRating ? "0" : "1";
                targetClassNode.AppendChild(numUseRatings);

                XmlElement useEntry = doc.CreateElement("UseRating");
                useEntry.InnerText = diffRating ? "0" : rating.ToString();
                targetClassNode.AppendChild(useEntry);

                root.AppendChild(targetClassNode);
            }
            else
            {
                // Update existing entry
                if (diffRating) //Depending on if it's a difficulty rating or a usefulness rating, it adds to the current whole and finds the average.
                {
                    XmlElement numDiffRatings = (XmlElement)targetClassNode.SelectSingleNode("numDiffRatings");
                    XmlElement diffEntry = (XmlElement)targetClassNode.SelectSingleNode("DiffRating");

                    int currentCount = int.Parse(numDiffRatings.InnerText);
                    double currentRating = double.Parse(diffEntry.InnerText);

                    numDiffRatings.InnerText = (currentCount + 1).ToString();
                    diffEntry.InnerText = ((currentCount * currentRating + rating) / (currentCount + 1)).ToString();
                }
                else
                {
                    XmlElement numUseRatings = (XmlElement)targetClassNode.SelectSingleNode("numUseRatings");
                    XmlElement useEntry = (XmlElement)targetClassNode.SelectSingleNode("UseRating");

                    int currentCount = int.Parse(numUseRatings.InnerText);
                    double currentRating = double.Parse(useEntry.InnerText);

                    numUseRatings.InnerText = (currentCount + 1).ToString();
                    useEntry.InnerText = ((currentCount * currentRating + rating) / (currentCount + 1)).ToString();
                }
            }

            doc.Save(filePath);
        }


    }
}

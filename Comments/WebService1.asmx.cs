using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Globalization;

namespace Assignment5_AGon
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CommentsService : System.Web.Services.WebService
    {
        private string xmlFilePath = HttpContext.Current.Server.MapPath("~/App_Data/Comments.xml");

        [WebMethod]
        public bool AddComment(string username, string comment, string pageId)
        {
            try
            {

                //create directory if it doesn't exist
                string dirPath = Path.GetDirectoryName(xmlFilePath);

                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                //create xml file if it doesn't exist
                if (!File.Exists(xmlFilePath))
                {
                    XmlWriter writer = XmlWriter.Create(xmlFilePath);
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Comments");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFilePath);

                XmlElement commentNode = doc.CreateElement("Comment");

                XmlElement userElement = doc.CreateElement("Username");
                userElement.InnerText = username;

                XmlElement contentElement = doc.CreateElement("Content");
                contentElement.InnerText = comment;

                XmlElement pageElement = doc.CreateElement("PageId");
                pageElement.InnerText = pageId;

                XmlElement dateElement = doc.CreateElement("Date");
                dateElement.InnerText = DateTime.Now.ToString();

                commentNode.AppendChild(userElement);
                commentNode.AppendChild(contentElement);
                commentNode.AppendChild(pageElement);
                commentNode.AppendChild(dateElement);

                doc.DocumentElement.AppendChild(commentNode);
                doc.Save(xmlFilePath);

                return true;
            }

            catch {
                return false;
            }
        }

        [WebMethod]
        public List<CommentData> GetComments(string pageId) {
        
            List<CommentData> comments = new List<CommentData>();

            if (File.Exists(xmlFilePath)) {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFilePath);

                XmlNodeList commentNodes = doc.SelectNodes("//Comment");

                foreach (XmlNode node in commentNodes) {
                    if (node["PageId"].InnerText == pageId) {
                        comments.Add(new CommentData
                        {
                            Username = node["Username"].InnerText,
                            Content = node["Content"].InnerText,
                            Date = DateTime.Parse(node["Date"].InnerText)

                        });
                    
                    }
                }
            }

            return comments;
        
        }

        [WebMethod]
        public bool DeleteComment(string datePosted, string username, string comment)
        {

            try {

                //debug
                System.Diagnostics.Debug.WriteLine($"Attempting to delete comment");

                if (File.Exists(xmlFilePath)) {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlFilePath);

                    //find and remove comment
                    //XmlNode nodeToDelete = doc.SelectSingleNode($"//Comment[Id='{commentId}");
                    XmlNodeList comments = doc.SelectNodes("//Comment");
                    System.Diagnostics.Debug.WriteLine($"Found {comments.Count} total comments");

                    XmlNode commentToDelete = null;
                    foreach (XmlNode node in comments) {

                        string nodeDate = node["Date"].InnerText;
                        string nodeUsername = node["Username"].InnerText;
                        string nodeContent = node["Content"].InnerText;

                        //debug
                        System.Diagnostics.Debug.WriteLine($"Checking comment:");

                        //DateTime sortedDate = DateTime.Parse(node["Date"].InnerText);
                        //DateTime passedDate = DateTime.Parse(datePosted);

                        if (nodeUsername == username &&
                            nodeContent == comment &&
                            nodeDate == datePosted) 
                        {
                            commentToDelete = node;
                            break;
                        }
                    }

                    if (commentToDelete != null)
                    {
                        commentToDelete.ParentNode.RemoveChild(commentToDelete);

                        doc.Save(xmlFilePath);

                        //debug
                        System.Diagnostics.Debug.WriteLine($"Comment deleted: {username} - {comment} - {datePosted}");

                        return true;
                    }
                    else {
                        System.Diagnostics.Debug.WriteLine($"Comment not found: {username} - {comment} - {datePosted}");

                    }
                }
                return false;
            }
            catch (Exception ex) {
                return false;
            }
        }
    }

    public class CommentData {
        
        public string Id { get; set; }
        public string Content { get; set; }
        public string Username { get; set; }
        public DateTime Date {  get; set; }
    }
}

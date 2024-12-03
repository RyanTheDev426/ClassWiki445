using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace Comments1
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
        private string xmlPath;

        public CommentsService()
        {
            xmlPath = HttpContext.Current.Server.MapPath("~/App_Data/Comments.xml");
        }

        [WebMethod]
        public List<CommentData> GetComments(string classId) {

            List<CommentData> comments = new List<CommentData>();

            if (!File.Exists(xmlPath)) { InitializeXml();  }

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);

            XmlNodeList commentNodes = doc.SelectNodes($"//Comment[ClassID='{classId}']");
            foreach (XmlNode node in commentNodes) {

                comments.Add(new CommentData
                {
                    ClassID = node["ClassID"].InnerText,
                    Username = node["Username"].InnerText,
                    Content = node["Content"].InnerText,
                    Timestamp = DateTime.Parse(node["Timestamp"].InnerText)
                });
            
            }

            return comments;
        
        }

        [WebMethod]
        public bool AddComment(string classId, string username, string content) {

            try 
            {
                if (!File.Exists(xmlPath)) { InitializeXml(); }

                XmlDocument doc = new XmlDocument();
                doc.Load(xmlPath);

                XmlElement comment = doc.CreateElement("Comment");

                XmlElement classIdElement = doc.CreateElement("ClassID");
                classIdElement.InnerText = classId;

                XmlElement userElement = doc.CreateElement("Username");
                userElement.InnerText = username;

                XmlElement contentElement = doc.CreateElement("Content");
                contentElement.InnerText = content;

                XmlElement timestampElement = doc.CreateElement("Timestamp");
                timestampElement.InnerText = DateTime.Now.ToString("o");

                comment.AppendChild(classIdElement);
                comment.AppendChild(userElement);
                comment.AppendChild(contentElement);
                comment.AppendChild(timestampElement);

                doc.DocumentElement.AppendChild(comment);
                doc.Save(xmlPath);

                return true;
            }
            catch { return false; }
        }

        private void InitializeXml() { 
            
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Comments");
            doc.AppendChild(root);

            string directory = Path.GetDirectoryName(xmlPath);
            if (!Directory.Exists(directory)) {
            
                Directory.CreateDirectory(directory);

            }

            doc.Save(xmlPath);
        
        }
    }

    public class CommentData { 
        
        public string ClassID {  get; set; }
        public string Username { get; set; }

        public string Content { get; set; }

        public DateTime Timestamp { get; set; }
    
    }
}

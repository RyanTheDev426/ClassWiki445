using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Optimization;
using System.IO;
using System.Xml;

namespace FinalPages
{
    public partial class Default : Page
    {
        private string xmlPath;
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlPath = Server.MapPath("~/App_Data/ClassList.xml");

            if (!IsPostBack) {

                LoadClasses();
            
            }
        }

        private void LoadClasses() {

            try
            {

                if (File.Exists(xmlPath))
                {

                    XDocument doc = XDocument.Load(xmlPath);

                    var classes = doc.Descendants("Class").Select(c => new ClassInfo
                    {

                        ClassID = c.Element("ClassID")?.Value,
                        ClassName = c.Element("ClassName")?.Value

                    }).ToList();

                    ClassRepeater.DataSource = classes;
                    ClassRepeater.DataBind();

                }

                else
                {

                    CreateDefaultClassList();
                    LoadClasses();

                }
            }

            catch (Exception ex) {

                System.Diagnostics.Debug.WriteLine($"Error loading classes: {ex.Message}");

            }
        
        }

        private void CreateDefaultClassList() {

            XDocument doc = new XDocument(
                new XElement("Classes",
                    new XElement("Class",
                        new XElement("ClassID", "CSE445"),
                        new XElement("ClassName", "CSE445")
                    ),
                    new XElement("Class",
                        new XElement("ClassID", "CSE310"),
                        new XElement("ClassName", "CSE310")
                    ),
                    new XElement("Class",
                        new XElement("ClassID", "CSE355"),
                        new XElement("ClassName", "CSE355")
                    )
                )
            );

            string directory = Path.GetDirectoryName( xmlPath );

            if (!Directory.Exists(directory)) { Directory.CreateDirectory(directory); }
            doc.Save(xmlPath);
        }

        protected void ClassList_ItemCommand(object source, RepeaterCommandEventArgs e) {

            if (e.CommandName == "ViewClass") {
                
                string classId = e.CommandArgument.ToString();

                Response.Redirect($"~/ClassDetails.aspx?id={classId}");

            }
        }
    }

    public class ClassInfo {
    
        public string ClassID {  get; set; }
        public string ClassName { get; set; }
    }
}
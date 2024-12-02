using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace StaffPage
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {              
                XmlDocument xmlDoc = new XmlDocument();
                string filePath = Server.MapPath("~/App_Data/Classes.xml");
                xmlDoc.Load(filePath);              
                XmlNode rootNode = xmlDoc.DocumentElement;             
                List<Class> classNames = new List<Class>();            
                foreach (XmlNode classNode in rootNode.ChildNodes) {
                  XmlNode nameNode = classNode.SelectSingleNode("Name");
                   XmlNode professorNode = classNode.SelectSingleNode("Professor");
                    classNames.Add(new Class { Name = nameNode.InnerText, Professor = professorNode.InnerText}); } 
                ListView1.DataSource = classNames; ListView1.DataBind(); }
            }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    public class Class { public string Name { get; set; } public string Professor { get; set; } }
}
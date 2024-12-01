using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OfficeHours
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.OfficeHoursServiceSoapClient client = new ServiceReference1.OfficeHoursServiceSoapClient();
            String result = client.AddOfficeHours(txtprofName.Text, txtprofTime.Text, txtprofLocation.Text, txttaName.Text, txttaTime.Text, txttaLocation.Text);
            Label9.Text = result.ToString();
        }
    }
}
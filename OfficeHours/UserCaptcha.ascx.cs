//written by chaitra daggubati 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OfficeHours
{
    public partial class UserCaptcha : System.Web.UI.UserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateMathQuestion();
            }
        }

        private void GenerateMathQuestion()
        {
            Random random = new Random();
            int num1 = random.Next(1, 10);
            int num2 = random.Next(1, 10);
            string operation = random.Next(2) == 0 ? "+" : "-";

            lblQuestion.Text = $"{num1} {operation} {num2} = ?";
            CorrectAnswer.Text = (operation == "+" ? num1 + num2 : num1 - num2).ToString();
        }

        public bool IsCaptchaValid()
        {
            return txtAnswer.Text == CorrectAnswer.Text;
        }
    }
}
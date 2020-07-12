using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hw04_Faber
{
    public partial class Calculate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DoMath();
        }

        private void DoMath()
        {
            string equation = Request.QueryString["equation"].ToString();
            string answer = "";
            double answerValue = 0;
            string[] nums = equation.Split(' ');
            double num1 = Convert.ToDouble(nums[0]);
            double num2 = Convert.ToDouble(nums[2]);
            char c = Convert.ToChar(nums[1]);

            if (c == 'a')
            {
                answerValue = num1 + num2;
                answer += num1.ToString() + " + " + num2.ToString() + " = " + answerValue;
            }

            else if (c == 's')
            {
                answerValue = num1 - num2;
                answer += num1.ToString() + " - " + num2.ToString() + " = " + answerValue;

            }

            else if (c == 'm')
            {
                answerValue = num1 * num2;
                answer += num1.ToString() + " * " + num2.ToString() + " = " + answerValue;
            }

            else
            {
                answerValue = num1 / num2;
                answer += num1.ToString() + " / " + num2.ToString() + " = " + answerValue;
            }

            Response.Write(answer);
            Response.End();
        }
    }
}
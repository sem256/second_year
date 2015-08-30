using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library_3;
using Library_4;

namespace ASP1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double x = 0, y = 0;
            x = Convert.ToDouble(TextBoxX.Text);
            y = Convert.ToDouble(TextBoxY.Text);

            KI3_Class_3 name = new KI3_Class_3();

            double rezult = 2 * KI3_Class_4.F4(x, y) + name.F3(x,y);
            Label3.Text = Convert.ToString(rezult);
        }
    }
}
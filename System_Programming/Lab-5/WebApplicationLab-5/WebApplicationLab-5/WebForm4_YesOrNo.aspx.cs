using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationLab_5
{
    public partial class WebForm4_YesOrNo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["YesOrNo"] == "Yes")
                Label1.Text = "РЕЄСТРАЦІЮ УСПІШНО ЗАВЕРШЕНО!";
            else
                Label1.Text = "ПОМИЛКА РЕЄСТРАЦІЇ!";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["YesOrNo"] == "Yes")
                Response.Redirect("WebForm5_Main.aspx");
            else
                Response.Redirect("WebForm1_Input.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;

namespace WebApplicationLab_5
{
    public partial class WebForm1_Input : System.Web.UI.Page
    {
        SqlConnection _connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/scripts/jquery-1.7.2.min.js",
            });
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Thread.Sleep(4000);
            Response.Redirect("WebForm2_Registration.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Thread.Sleep(4000);
            if (Page.IsValid)
            {
                Response.Redirect("WebForm5_Main.aspx");
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PeopleConnectionString"].ConnectionString;
            _connection = new SqlConnection(connectionString);
            _connection.Open();

            SqlDataReader reader = null;
            SqlCommand commandReadCompare = new SqlCommand("SELECT * FROM People", _connection);

            string result = string.Empty;

            reader = commandReadCompare.ExecuteReader();

            while (reader.Read())
            {
                if ((TextBox1.Text == Convert.ToString(reader["Login"]))&&(TextBox2.Text == Convert.ToString(reader["Password"])))
                {
                    args.IsValid = true;
                    Session["id"] = Convert.ToString(reader["id"]);
                    return;
                }
            }
            args.IsValid = false;

            _connection.Close();
        }
    }
}
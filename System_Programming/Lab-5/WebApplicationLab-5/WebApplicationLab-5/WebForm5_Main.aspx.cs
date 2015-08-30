using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplicationLab_5
{
    public partial class WebForm5_Main : System.Web.UI.Page
    {
        SqlConnection _connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                

                string connectionString = ConfigurationManager.ConnectionStrings["PeopleConnectionString"].ConnectionString;
                _connection = new SqlConnection(connectionString);
                _connection.Open();
                byte[] bytes = new byte[0];

                SqlDataReader reader = null;
                string idForPhoto = Convert.ToString(Session["id"]);
                SqlCommand commandRead = new SqlCommand("SELECT * FROM People where id=" + idForPhoto, _connection);

                string result = string.Empty;

                reader = commandRead.ExecuteReader();
                reader.Read();
                LabelName.Text = Convert.ToString(reader["Name"]);
                LabelSurName.Text = Convert.ToString(reader["SurName"]);
                LabelLogin.Text = Convert.ToString(reader["Login"]);
                LabelEmail.Text = Convert.ToString(reader["Email"]);

                bytes = new byte[((byte[])reader["Photo"]).Length];
                bytes = (byte[])reader["Photo"];

                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                Image1.ImageUrl = "data:image/png;base64," + base64String;
                Panel1.Visible = true;
                //_connection.Close();

            }
            catch (Exception)
            {
                //Response.Redirect("WebForm1_Input.aspx");
            }

        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            if (_connection != null && _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        protected void ButtonExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1_Input.aspx");
        }
    }
}
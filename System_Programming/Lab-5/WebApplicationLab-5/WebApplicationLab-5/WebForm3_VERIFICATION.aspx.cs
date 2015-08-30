using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;


namespace WebApplicationLab_5
{
    public partial class WebForm3_VERIFICATION : System.Web.UI.Page
    {
        SqlConnection _connection;
        int firstPassword;
        bool flag = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //HttpRequest q = Request;
                    //string v = q.QueryString["id"];
                    //Session["id"] = v;
                    Random rnd = new Random();

                    firstPassword = rnd.Next(0, 99999);
                    Session["Password"] = firstPassword;



                    //string connectionString = ConfigurationManager.ConnectionStrings["PeopleConnectionString"].ConnectionString;
                    //_connection = new SqlConnection(connectionString);
                    //_connection.Open();

                    //SqlDataReader reader = null;
                    //SqlCommand commandRead = new SqlCommand("SELECT Email FROM People where id=" + v, _connection);

                    //string result = string.Empty;

                    //reader = commandRead.ExecuteReader();
                    //reader.Read();
                    //result = Convert.ToString(reader["Email"]);

                    //Label3.Text = result;
                    string email = Convert.ToString(Session["Email"]);
                    MailMain(email, firstPassword);

                    //_connection.Close();
                }
            }
            catch (Exception)
            {
                //Response.Redirect("WebForm1_Input.aspx");
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if ((Session["YesOrNo"] != "Yes")&&(flag == true))
                DeleteDB();
            if (_connection != null && _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }
        protected void DeleteDB()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PeopleConnectionString"].ConnectionString;
            _connection = new SqlConnection(connectionString);
            _connection.Open();

            string idForPhoto = Convert.ToString(Session["id"]);

            SqlCommand command = new SqlCommand("DELETE FROM People WHERE ID=" + idForPhoto, _connection);
            command.ExecuteNonQuery();

            _connection.Close();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            DeleteDB();
            Response.Redirect("WebForm2_VERIFICATION.aspx");
        }

        protected void MailMain(string mailTo, int fPassword)
        {
            string body = " (" + Convert.ToString(DateTime.Now) + " Web site)";

            SendToEmail("smtp.gmail.com", "motia256@gmail.com", "mobssmobss", mailTo, "Password", "Password: " + fPassword + body);
        }

        protected void SendToEmail(string smtpServer, string from, string password, string mailto, string caption, string message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;

                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            int ee = 0;
            if (Session["Password"] != null)
                ee = Convert.ToInt32(Session["Password"]);

            if (Int32.TryParse(TextBox1.Text, out i))
                if (ee == i)
                {
                    Session["YesOrNo"] = "Yes";
                    flag = true;
                }
                else
                {
                    Session["YesOrNo"] = "No";
                    DeleteDB();
                }
            else
            {
                Session["YesOrNo"] = "No";
                DeleteDB();
            }

            Response.Redirect("WebForm4_YesOrNo.aspx");
        }
    }
}
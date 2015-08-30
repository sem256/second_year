using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


namespace WebApplicationLab_5
{
    public partial class WebForm2_Registration : System.Web.UI.Page
    {
        SqlConnection _connection;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/scripts/jquery-1.7.2.min.js",

            });
            try
            {
                if (!IsPostBack)
                {
                    for (int i = 1; i <= 6; i++)// заполнение курс
                        DropDownList1.Items.Insert(i, i + " -  курс");

                    DropDownList2.Items.Insert(0, "Механіко-математичний");
                    DropDownList2.Items.Insert(1, "Радіофізичний");
                    DropDownList2.Items.Insert(2, "Геологічний");
                    DropDownList2.Items.Insert(3, "Історичний");
                    DropDownList2.Items.Insert(4, "Філософський");

                    DropDownList3.Items.Insert(0, "Наукова бібліотека");
                    DropDownList3.Items.Insert(0, "Ботанічний сад");
                    DropDownList3.Items.Insert(0, "Інформаційно-обчислювальний центр");
                    DropDownList3.Items.Insert(0, "Ректорат");
                }

                DropDownList1.Enabled = false;
                DropDownList3.Enabled = false;

                string connectionString = ConfigurationManager.ConnectionStrings["PeopleConnectionString"].ConnectionString;
                _connection = new SqlConnection(connectionString);
                _connection.Open();
            }
            catch (Exception)
            {
                Response.Redirect("WebForm1_Input.aspx");
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (_connection != null && _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }


        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox2.Enabled = true;
            CheckBox3.Enabled = true;
            DropDownList1.Enabled = false;
            DropDownList2.Enabled = true;
            DropDownList3.Enabled = false;
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox2.Enabled = false;
            CheckBox3.Enabled = false;
            DropDownList1.Enabled = true;
            DropDownList2.Enabled = true;
            DropDownList3.Enabled = false;
        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox2.Enabled = true;
            CheckBox3.Enabled = false;
            DropDownList1.Enabled = false;
            DropDownList2.Enabled = false;
            DropDownList3.Enabled = true;
        }
        
        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["PeopleConnectionString"].ConnectionString;
                    _connection = new SqlConnection(connectionString);
                    _connection.Open();

                    byte[] bytes = (byte[])Session["Image"];

                    string radiobutton;
                    if (RadioButton1.Checked)
                        radiobutton = "Студент";
                    else
                        if (RadioButton2.Checked)
                            radiobutton = "Викладач";
                        else
                            radiobutton = "Навчально-допоміжний персонал";
                    SqlCommand command = new SqlCommand("INSERT INTO People (Name, SurName, Login, Email, Password, Status, MasterOfSports, Doctorate, PhD, Сourse, Faculty, BusinessUnit, Photo)" +
                        "VALUES(@Name, @SurName, @Login, @Email, @Password, @Status, @MasterOfSports, @Doctorate, @PhD, @Сourse, @Faculty, @BusinessUnit, @Photo)", _connection);
                    command.Parameters.AddWithValue("Name", TextBox1.Text);
                    command.Parameters.AddWithValue("SurName", TextBox2.Text);
                    command.Parameters.AddWithValue("Login", TextBox3.Text);
                    command.Parameters.AddWithValue("Email", TextBox4.Text);
                    command.Parameters.AddWithValue("Password", TextBox5.Text);
                    command.Parameters.AddWithValue("Status", radiobutton);

                    if (CheckBox1.Checked)
                        command.Parameters.AddWithValue("MasterOfSports", 1);
                    else
                        command.Parameters.AddWithValue("MasterOfSports", 0);
                    if (CheckBox3.Checked)
                        command.Parameters.AddWithValue("Doctorate", 1);
                    else
                        command.Parameters.AddWithValue("Doctorate", 0);
                    if (CheckBox2.Checked)
                        command.Parameters.AddWithValue("PhD", 1);
                    else
                        command.Parameters.AddWithValue("PhD", 0);

                    if (DropDownList1.Enabled)
                        command.Parameters.AddWithValue("Сourse", DropDownList1.SelectedItem.ToString());
                    else
                        command.Parameters.AddWithValue("Сourse", "");
                    if (DropDownList2.Enabled)
                        command.Parameters.AddWithValue("Faculty", DropDownList2.SelectedItem.ToString());
                    else
                        command.Parameters.AddWithValue("Faculty", "");
                    if (DropDownList3.Enabled)
                        command.Parameters.AddWithValue("BusinessUnit", DropDownList3.SelectedItem.ToString());
                    else
                        command.Parameters.AddWithValue("BusinessUnit", "");


                    Session["Email"] = TextBox4.Text;
                    command.Parameters.AddWithValue("Photo", bytes);//photo

                    command.ExecuteNonQuery();

                    // ---------------------------------------------------------------------------------вивод на экран из БД значений
                    SqlDataReader reader = null;
                    SqlCommand commandRead = new SqlCommand("SELECT * FROM People", _connection);

                    string result = string.Empty;

                    reader = commandRead.ExecuteReader();

                    while (reader.Read())
                        result = Convert.ToString(reader["FunctionName"]);

                    Session["id"] = result;

                    Response.Redirect("WebForm3_VERIFICATION.aspx");
                }

            }
            catch (Exception eee)
            {
               
            }
        }
        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebForm1_Input.aspx", true);
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (FileUpload1.HasFile)
            {
                Stream fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                Session["Image"] = bytes;
                System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(fs);
                if (UploadedImage.PhysicalDimension.Width >= 100 && UploadedImage.PhysicalDimension.Width <= 200)
                    if (UploadedImage.PhysicalDimension.Height >= 150 && UploadedImage.PhysicalDimension.Height <= 300)
                    {
                        args.IsValid = true;
                    }
                    else
                        args.IsValid = false;
                else
                    args.IsValid = false;
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlDataReader reader = null;
            SqlCommand commandReadCompare = new SqlCommand("SELECT Login FROM People", _connection);

            string result = string.Empty;

            reader = commandReadCompare.ExecuteReader();

            while (reader.Read())
            {
                result = Convert.ToString(reader["Login"]);
                if (TextBox3.Text == result)
                {
                    args.IsValid = false;
                    return;
                }
            }
            args.IsValid = true;
            _connection.Close();
        }
    }
}
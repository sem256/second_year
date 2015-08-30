using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace Lab_2
{
    public partial class Form1 : Form
    {
        string connectionString = "server=10.0.66.223; port=3306; database=Hospital; user=root; password=456786789054321; CharSet=cp1251;";
        string command;
        bool created = false;
        Form nextPage;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!created)
            {
                nextPage = new disease(this);
                created = true;
            }
            nextPage.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private static bool checkedName(string name)
        {
            Regex R = new Regex("^[a-zA-Zа-яА-Я][a-zA-Zа-яА-Я0-9-_\\.]{1,20}$");
            Match M = R.Match(name);
            return M.Success;
        }
        private static bool checkedData(string birth)
        {
            Regex R = new Regex("[0-9]{4}");
            Match M = R.Match(birth);
            return M.Success;
        }
        private void run_query_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if ((radioButtonGet.Checked) && (checkBoxID.Checked))
            {
                command = "select * from Hospital_Patients where ID = " + textBoxID.Text;
                flag = true;
            }
            if ((radioButtonGet.Checked) && (checkBoxDisease.Checked))
            {
                command = "select * from Hospital_Patients where Hvoroba_ID = (select ID from Infectious_Diseases where Name='" + comboBoxDisease.Text + "')";
                flag = true;
            }
            if ((radioButtonGet.Checked) && (checkBoxDisease.Checked) && (checkBoxID.Checked))
            {
                command = "select * from Hospital_Patients where ID = " + textBoxID.Text + " and Hvoroba_ID = (select ID from Infectious_Diseases where Name='" + comboBoxDisease.Text + "')";
                flag = true;
            }
            if (radioButtonAdd.Checked)
            {
                if ((!checkedName(textBoxName.Text)) || (!checkedName(textBoxSurName.Text)) || (!checkedName(textBoxMiddleName.Text)))
                    MessageBox.Show("с ограничением 2-20 символов, которыми могут быть буквы и цифры, первый символ обязательно буква");
                else if (!checkedData(textBoxBirth.Text)) MessageBox.Show("YYYY");
                //else if (comboBoxDisease.Enabled) MessageBox.Show("Виберіть Хворобу паціента");
                else
                {
                    //flag = true;
                    command = "insert Hospital_Patients (FirstName, MiddleName, SurName, Hvoroba_ID, BirthYear) values ('" + textBoxName.Text + "'" + "," + "'" + textBoxMiddleName.Text
                        + "'" + "," + "'" + textBoxSurName.Text + "'" + "," + "(select ID from Infectious_Diseases where Name='" + comboBoxDisease.Text + "')" + "," + "'" + textBoxBirth.Text + "');";
                    MessageBox.Show("Хворий додан до таблиці");
                }
            }

            if ((radioButtonDelete.Checked) && (checkBoxID.Checked))
            {
                command = "delete from Hospital_Patients where ID = " + textBoxID.Text;
                //MessageBox.Show("Видалено паціента " + textBoxID.Text);
            }
            if ((radioButtonDelete.Checked) && (checkBoxDisease.Checked))
            {
                command = "delete from Hospital_Patients where Hvoroba_ID = (select ID from Infectious_Diseases where Name='" + comboBoxDisease.Text + "')";
                //MessageBox.Show("Видалено паціенти які " + comboBoxDisease.Text);
            }
            if ((radioButtonDelete.Checked) && (checkBoxDisease.Checked) && (checkBoxID.Checked))
            {
                command = "delete from Hospital_Patients where ID = " + textBoxID.Text + "and Hvoroba_ID = (select ID from Infectious_Diseases where Name='" + comboBoxDisease.Text + "')";
                //MessageBox.Show("Видалено паціента " + textBoxID.Text);
            }
            if (radioButtonUpdate.Checked)
            {
                command = "update Hospital_Patients set FirstName = '"+textBoxName.Text+"',"+" MiddleName = '"+textBoxMiddleName.Text+"',"+" SurName = '"+textBoxSurName.Text+"',"+
                    " Hvoroba_ID  = (select ID from Infectious_Diseases where Name='" + comboBoxDisease.Text + "'), BirthYear = '"+textBoxBirth.Text+"' where ID = "+textBoxID.Text;
            }

            try
            {
                DataSet data = new DataSet();
                MySqlDataAdapter add = new MySqlDataAdapter(command, connectionString);
                add.Fill(data);
                if (flag) dataGridView1.DataSource = data.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public void diseaseList()
        {
            DataSet data = new DataSet();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter add = new MySqlDataAdapter("select * from Infectious_Diseases", connectionString);
                add.Fill(data);
            }
            comboBoxDisease.Items.Clear();

            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                comboBoxDisease.Items.Add(data.Tables[0].Rows[i][1]);
        }

        private void comboBoxDisease_Click(object sender, EventArgs e)
        {
            diseaseList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxID.Enabled = false;

            int number=0, count=0;
            bool t = false, d = false;
            DataSet data = new DataSet();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter add = new MySqlDataAdapter("select * from Infectious_Diseases", connectionString);
                add.Fill(data);
            }
            while ((number < 2) && (data.Tables[0].Rows.Count > count))
            {
                if ((data.Tables[0].Rows[count][1].ToString()=="Туберкульоз")&&(data.Tables[0].Rows[count][2].ToString() == "Збудник - палочка Коха"))
                {
                    number++;
                    t = true;
                }
                if ((data.Tables[0].Rows[count][1].ToString() == "Дифтерія") && (data.Tables[0].Rows[count][2].ToString() == "Небезпечна дитяча хвороба"))
                {
                    number++;
                    d = true;
                }
                count++;
            }
            if (!t)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlDataAdapter add = new MySqlDataAdapter("insert Infectious_Diseases (Name, Description) values ('Туберкульоз','Збудник - палочка Коха')", connectionString);
                    add.Fill(data);
                }
            }
            if (!d)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlDataAdapter add = new MySqlDataAdapter("insert Infectious_Diseases (Name, Description) values ('Дифтерія','Небезпечна дитяча хвороба')", connectionString);
                    add.Fill(data);
                }
            }
        }

        private void radioButtonGet_CheckedChanged(object sender, EventArgs e)
        {
            textBoxID.Enabled = false;
            comboBoxDisease.Enabled = false;
            textBoxName.Enabled = false;
            textBoxMiddleName.Enabled = false;
            textBoxSurName.Enabled = false;
            textBoxBirth.Enabled = false;
            checkBoxDisease.Enabled = true;
            checkBoxID.Enabled = true;

        }

        private void checkBoxDisease_CheckedChanged(object sender, EventArgs e)
        {
            if ((radioButtonGet.Checked) || (radioButtonDelete.Checked))
            {
                textBoxID.Enabled = false;
                comboBoxDisease.Enabled = false;
                textBoxName.Enabled = false;
                textBoxMiddleName.Enabled = false;
                textBoxSurName.Enabled = false;
                textBoxBirth.Enabled = false;

                if (checkBoxDisease.Checked)
                {
                    textBoxID.Enabled = false;
                    comboBoxDisease.Enabled = true;
                }
                else
                {
                    if (!checkBoxID.Checked)
                    {
                        textBoxID.Enabled = false;
                        comboBoxDisease.Enabled = false;
                    }
                    else textBoxID.Enabled = true;
                }
                if ((checkBoxDisease.Checked) && (checkBoxID.Checked))
                {
                    textBoxID.Enabled = true;
                    comboBoxDisease.Enabled = true;
                }
            }
        }

        private void checkBoxID_CheckedChanged(object sender, EventArgs e)
        {
            if ((radioButtonGet.Checked) || (radioButtonDelete.Checked))
            {
                textBoxID.Enabled = false;
                comboBoxDisease.Enabled = false;
                textBoxName.Enabled = false;
                textBoxMiddleName.Enabled = false;
                textBoxSurName.Enabled = false;
                textBoxBirth.Enabled = false;

                if (checkBoxID.Checked)
                {
                    textBoxID.Enabled = true;
                    comboBoxDisease.Enabled = false;
                }
                else
                {
                    if (!checkBoxDisease.Checked)
                    {
                        textBoxID.Enabled = false;
                        comboBoxDisease.Enabled = false;
                    }
                    else comboBoxDisease.Enabled = true;
                }
                if ((checkBoxDisease.Checked) && (checkBoxID.Checked))
                {
                    textBoxID.Enabled = true;
                    comboBoxDisease.Enabled = true;
                }
            }
        }

        private void radioButtonAdd_CheckedChanged(object sender, EventArgs e)
        {
            textBoxID.Enabled = false;
            comboBoxDisease.Enabled = true;
            textBoxName.Enabled = true;
            textBoxMiddleName.Enabled = true;
            textBoxSurName.Enabled = true;
            textBoxBirth.Enabled = true;
            checkBoxDisease.Enabled = false;
            checkBoxID.Enabled = false;
        }

        private void radioButtonUpdate_CheckedChanged(object sender, EventArgs e)
        {
            textBoxID.Enabled = true;
            comboBoxDisease.Enabled = true;
            textBoxName.Enabled = true;
            textBoxMiddleName.Enabled = true;
            textBoxSurName.Enabled = true;
            textBoxBirth.Enabled = true;
            checkBoxDisease.Enabled = false;
            checkBoxID.Enabled = false;
        }

        private void radioButtonDelete_CheckedChanged(object sender, EventArgs e)
        {
            textBoxID.Enabled = false;
            comboBoxDisease.Enabled = false;
            textBoxName.Enabled = false;
            textBoxMiddleName.Enabled = false;
            textBoxSurName.Enabled = false;
            textBoxBirth.Enabled = false;
            checkBoxDisease.Enabled = true;
            checkBoxID.Enabled = true;
        }
    }
}
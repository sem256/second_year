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
    public partial class disease : Form
    {
        Form form;
        string connectionString = "server=10.0.66.223; port=3306; database=Hospital; user=root; password=456786789054321; CharSet=cp1251;";
        string command;
        

        public disease()
        {
            InitializeComponent();
        }

        public disease(Form1 page)
        {
            this.form = page;
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxID.Enabled = false;
            textBoxName.Enabled = false;
            textBoxDescription.Enabled = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            form.Show();
        }

        private void disease_Load(object sender, EventArgs e)
        {
            textBoxID.Enabled = false;
            textBoxName.Enabled = true;
            textBoxDescription.Enabled = true;
        }

        private void radioButtonAddD_CheckedChanged(object sender, EventArgs e)
        {
            textBoxID.Enabled = false;
            textBoxName.Enabled = true;
            textBoxDescription.Enabled = true;
        }
        private static bool checkedName(string name)
        {
            Regex R = new Regex("^[a-zA-ZіІёЁа-яА-Я][a-zA-ZіІа-яА-Я0-9-_\\.]{1,20}$");
            Match M = R.Match(name);
            return M.Success;
        }
        private void radioButtonUpdate_CheckedChanged(object sender, EventArgs e)
        {
            textBoxID.Enabled = true;
            textBoxName.Enabled = true;
            textBoxDescription.Enabled = true;
        }

        private void radioButtonDeleteD_CheckedChanged(object sender, EventArgs e)
        {
            textBoxID.Enabled = true;
            textBoxName.Enabled = false;
            textBoxDescription.Enabled = false;
        }

        private void run_query_Click(object sender, EventArgs e)
        {
            bool flag = false, good = false;

            if (radioButtonAllDisease.Checked)
            {
                flag = true;
                good = true;
                command = "select * from Infectious_Diseases";
            }
            if (radioButtonAddD.Checked)
            {
                if ((checkedName(textBoxName.Text)) && (checkedName(textBoxDescription.Text)))
                {
                    good = true;
                    command = "insert Infectious_Diseases (Name, Description) values ('" + textBoxName.Text + "','" + textBoxDescription.Text + "')";
                    MessageBox.Show("Додано: " + textBoxName.Text);
                }
                else MessageBox.Show("с ограничением 2-20 символов, которыми могут быть буквы и цифры, первый символ обязательно буква");
            }

            if (radioButtonUpdate.Checked)
            {
                if ((checkedName(textBoxName.Text)) && (checkedName(textBoxDescription.Text)))
                {
                    good = true;
                    command = "update Infectious_Diseases set Name = '" + textBoxName.Text + "', Description = '" + textBoxDescription.Text + "' where ID = " + textBoxID.Text;
                    MessageBox.Show("Оновлення виконано");
                }
            }
            if (radioButtonDeleteD.Checked)
            {
                good = true;
                command = "delete from Infectious_Diseases where ID = " + textBoxID.Text;
                MessageBox.Show("Видалено паціента " + textBoxID.Text);
            }
            try
            {
                if (good)
                {
                    DataSet data = new DataSet();
                    MySqlDataAdapter add = new MySqlDataAdapter(command, connectionString);
                    add.Fill(data);
                    if (flag) dataGridView1.DataSource = data.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("");
            }
        }
    }
}

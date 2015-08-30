using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace WindowsFormsPart_2
{
    public partial class Form1 : Form
    {
        string nameAcaunt = "";
        public Form1()
        {
            InitializeComponent();
            button2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectQuery query = new SelectQuery("select * from win32_useraccount");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection allVolumes = searcher.Get();
            int count = 0;
            richTextBox1.Text = "";
            foreach (ManagementObject oneVolume in allVolumes)
            {
                richTextBox1.Text += oneVolume["name"] + "\n";
                if (count == 1)
                    nameAcaunt = oneVolume["name"].ToString();
                count++;
            }
            textBox1.Text = nameAcaunt;
            textBox2.Text = "Professor";
            button2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string AccountName = textBox1.Text,
                newNameForAccount = textBox2.Text;
            
            ManagementObject theInstance = new ManagementObject("root\\CIMv2", "Win32_UserAccount.Domain='" + Environment.MachineName + "',Name='" + AccountName + "'", null);

            ManagementBaseObject inputParams = theInstance.GetMethodParameters("Rename");
            inputParams.SetPropertyValue("Name", newNameForAccount);
            ManagementBaseObject outParams = theInstance.InvokeMethod("Rename", inputParams, null);
            button2.Hide();
        }
    }
}
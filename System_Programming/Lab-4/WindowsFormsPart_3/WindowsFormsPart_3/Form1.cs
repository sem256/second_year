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
using System.Diagnostics;

namespace WindowsFormsPart_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ManagementScope S = new ManagementScope(@"\\.\ROOT\cimv2");
            SelectQuery query = new SelectQuery("select * from win32_logicaldisk"); //where DriveType=4

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(S, query);
            ManagementObjectCollection allVolumes = searcher.Get();
            richTextBox1.Clear();
            foreach (ManagementObject oneVolume in allVolumes)
            {
                richTextBox1.Text += oneVolume["name"].ToString() + "\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("CMD.exe", "/C net use " + textBox1.Text + ": /delete");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplicationWCF.ServiceReference1;
using System.ServiceModel.Security;

namespace WindowsFormsApplicationWCF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Service1Client s = new Service1Client())
            {
                dataGridView1.DataSource = s.GetAllWorkers();
            }
        }

        private void buttonF4_Click(object sender, EventArgs e)
        {
            using (Service1Client s = new Service1Client())
            {
                string text = textBox1.Text;
                double x;
                if (double.TryParse(text, out x))
                {
                    double answeer = s.F4_WCF(x);
                    ANSWER.Text = answeer.ToString();
                }
                else
                    ANSWER.Text = "error";

            }
        }

        private void buttonGetWorkerByID_Click(object sender, EventArgs e)
        {
            using (Service1Client s = new Service1Client())
            {
                string text = textBox1.Text;
                int x;
                if (int.TryParse(text, out x))
                    dataGridView1.DataSource = s.GetWorkerByID(x);
                else
                    ANSWER.Text = "error";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplicationPart2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ServiceReference1.Service1Client s = new ServiceReference1.Service1Client("HTTP-Anon"))
            {
                label1.Text = s.MyIPAddress();
                if (s.IsLoginFree(textBoxA.Text))
                    labelA2.Text = "true";
                else
                    labelA2.Text = "false";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ServiceReference1.Service1Client s = new ServiceReference1.Service1Client("HTTPS-Anon"))
            {
                labelB.Text = s.MyIPAddress();
                if (s.IsLoginFree(textBoxB.Text))
                    labelB2.Text = "true";
                else
                    labelB2.Text = "false";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (ServiceReference1.Service1Client s = new ServiceReference1.Service1Client("HTTPP-Anon"))
            {
                labelС.Text = s.MyIPAddress();
                if (s.IsLoginFree(textBoxC.Text))
                    labelC2.Text = "true";
                else
                    labelC2.Text = "false";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (ServiceReference1.Service1Client s = new ServiceReference1.Service1Client("HTTPSP-Anon"))
            {
                labelD.Text = s.MyIPAddress();
                if (s.IsLoginFree(textBoxD.Text))
                    labelD2.Text = "true";
                else
                    labelD2.Text = "false";
            }
        }
        private void labelC2_Click(object sender, EventArgs e)
        {

        }
    }
}

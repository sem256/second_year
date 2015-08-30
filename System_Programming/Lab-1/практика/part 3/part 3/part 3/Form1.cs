using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace part_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime day1 = new DateTime(2015, 03, 23);

            //DateTime day2 = new DateTime(2015, 03, 23);
            DateTime day2 = DateTime.Now;
            label4.Text = Convert.ToString(day2);
            int diff = ((TimeSpan)(day2 - day1)).Days;
            //MessageBox.Show(diff.ToString());

            decimal y;
            y = (decimal)Math.Sin((Math.PI / 182.5) * diff);
            if (y >= 0)
            {
                y = y * 50 + 50;
                y = decimal.Round(y, 3);
            }
            else
            {
                y = (1 + y) * 50 ;
                y = decimal.Round(y, 3);
            }
            label1.Text = y.ToString() + "%";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

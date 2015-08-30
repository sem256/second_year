using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace part_2
{
    public partial class Form1 : Form
    {
        public float myGrowth;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void OK_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            if (!float.TryParse(s, out myGrowth))
            {
                textBox1.Text = "185";
                MessageBox.Show("Зріст введено не вірно! Повтріть будь ласка)", "Помилка");
            }
            else
            {
                new Form2(myGrowth).Show();
                this.Hide();
            }
        }
    }
}

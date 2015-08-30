using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace part_2
{
    public partial class Form2 : Form
    {
        float myWeight;
        float f2myGrowth;

        public Form2()
        {
            InitializeComponent();
        }
        public Form2(float myGrowth)
        {
            InitializeComponent();

            f2myGrowth = myGrowth;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            if (!float.TryParse(s, out myWeight))
            {
                
                textBox1.Text = "80";
                MessageBox.Show("Вагу введено не вірно! Повтріть будь ласка)", "Помилка");
            }
            else
            {
                new Form3(myWeight, f2myGrowth).Show();
                this.Hide();
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }
    }
}

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
    public partial class Form3 : Form
    {
        float f3myWeight;
        float f3myGrowth;
 
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(float myWeight, float f2myGrowth) 
        {
            InitializeComponent();

            f3myWeight = myWeight;
            f3myGrowth = f2myGrowth;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10000;
            timer1.Enabled = true;
            button1.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float result = f3myGrowth / f3myWeight;
            lable1.Text = "";
            if ((result >= 1.8) && (result <= 4))
            {
                label1.Text = "У Вас спортивна фігура, так тримати!";
            }
            if (result < 1.8)
            {
                label1.Text = "У вас надмірна вага, займайтесь спортом!";
            }
            if (result > 4 )
            {
                label1.Text = "У вас дистрофія, більше їжте!";
            }
            button1.Show();
            OK.Hide();
            this.Text = "РЕЗУЛЬТАТ ОБЧИСЛЕННЯ:";
        }

        private void OK_Click(object sender, EventArgs e)
        {
            lable1.Text = "ОБЧИСЛЕННЯ СКАСОВАНЕ КОРИСТУВАЧЕМ";
            timer2.Interval = 5000;
            timer2.Enabled = true;
            OK.Hide();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lable1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

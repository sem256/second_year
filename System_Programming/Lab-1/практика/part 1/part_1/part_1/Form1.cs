using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace part_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamWriter F = new StreamWriter(@"E:\уроки\сисПрога\Lab-4\a.txt"))
            {
                F.WriteLine("Work");
            }
            //var result = MessageBox.Show("Чи їли ви на сніданок морковку?", "ПИТАННЯ НА ЗАСИПКУ:", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            //switch (result) 
            //{
            //    case DialogResult.Yes:
            //        MessageBox.Show("Правильно! Морковка дуже корисна!", "Добре", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        break;
            //    case DialogResult.No:
            //        MessageBox.Show("Дуже прикро:((,\nНаступного разу не забудьте про морковку!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        break;
            //    case DialogResult.Cancel:
            //        MessageBox.Show("Ви ухилились від запитання! Якщо ви не будете їсти морковку, ...", "Ухилення від запитання", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        break;
            //}
            //Application.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Xml;

namespace WindowsFormsTest_1
{
    public partial class Form1 : Form
    {
        static string pathToXml = @"XMLClient.xml";
        protected string Answer;

        public Form1()
        {
            InitializeComponent();
        }

        private void B1_Click(object sender, EventArgs e)
        {
            createXML();
        }
        public void createXML()
        {
            string pathToXml = @"XMLClient.xml";
            XmlTextWriter textWritter = new XmlTextWriter(pathToXml, Encoding.GetEncoding(1251));
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("path");
            textWritter.WriteEndElement();
            textWritter.Close();

            XmlDocument document = new XmlDocument();
            document.Load(pathToXml);
            XmlNode element = document.CreateElement("name");
            document.DocumentElement.AppendChild(element); // указываем родителя

            XmlNode subElement1 = document.CreateElement("name_directory"); // даём имя
            if (textBoxForName.Text != "")
                subElement1.InnerText = @textBoxForName.Text;
            else
                subElement1.InnerText = @"E:\уроки\сисПрога\Lab-4"; // и значение
            element.AppendChild(subElement1); // и указываем кому принадлежит

            XmlNode subElement2 = document.CreateElement("type");
            if (radioButton1.Checked)
                subElement2.InnerText = "file";
            else
                subElement2.InnerText = "directory";

            element.AppendChild(subElement2);
            XmlNode subElement3 = document.CreateElement("short_name");
            if (textBoxForShortName.Text != "")
                subElement3.InnerText = @textBoxForShortName.Text;
            else
                subElement3.InnerText = "Source_Code1.txt";
            element.AppendChild(subElement3);

            document.Save(pathToXml);
            Speaking(pathToXml);
        }
        public void Speaking(string XmlPath)
        {
            string F = File.ReadAllText(XmlPath, Encoding.GetEncoding(1251));
            byte[] M = Encoding.GetEncoding(1251).GetBytes(F);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("10.0.66.201"), 40000);
            byte[] bytes = new byte[1000000];

            using (Socket S = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                S.Connect(ipEndPoint);
                S.Send(M);

                int bytesRec = S.Receive(bytes);
                Answer = Encoding.GetEncoding(1251).GetString(bytes, 0, bytesRec);
                WriteRequest(Answer);
                if (AnalaseAnswerXML())
                {
                    var result = MessageBox.Show(AnalaseXML(true), "ПИТАННЯ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        AddInformationToXML("yes");
                        string F2 = File.ReadAllText(XmlPath, Encoding.GetEncoding(1251));
                        byte[] M2 = Encoding.GetEncoding(1251).GetBytes(F2);
                        S.Send(M2);
                    }
                }
                else
                {
                    MessageBox.Show(AnalaseXML(false));
                }
            }
        }
        private static void AddInformationToXML(string statusName)
        {
            XmlDocument document = new XmlDocument();
            document.Load(pathToXml);
            XmlNode element = document.CreateElement("document");
            document.DocumentElement.AppendChild(element); // указываем родителя

            XmlNode subElement1 = document.CreateElement("create"); // даём имя
            subElement1.InnerText = statusName; // и значение
            element.AppendChild(subElement1); // и указываем кому принадлежит
            document.Save(pathToXml);
        }
        private static string AnalaseXML(bool flag)
        {
            string message = "";
            XmlDocument D = new XmlDocument();
            D.Load(pathToXml);
            XmlNode nodeNameDirectory = D.DocumentElement.SelectSingleNode("/path/name/name_directory");
            XmlNode nodeShortName = D.DocumentElement.SelectSingleNode("/path/name/short_name");

            if (flag)
            {
                message = "В батьківському каталозі: " + nodeNameDirectory.InnerText + "\nФайл/Каталог: " +
                    nodeShortName.InnerText + " не існує.\nMожемо створити.";
            }
            else
            {
                message = "В батьківському каталозі " + nodeNameDirectory.InnerText + " файл/каталог " +
                    nodeShortName.InnerText + " вже існує.";
            }
            return message;
        }
        private static bool AnalaseAnswerXML()
        {
            XmlDocument D = new XmlDocument();
            D.Load(pathToXml);
            XmlNode nodeAnswerStatus = D.DocumentElement.SelectSingleNode("/path/answer/status");
            if (nodeAnswerStatus.InnerText == "exists")
                return true; // создаем файл
            else
                return false;// не создаем файл

        }
        private static void WriteRequest(string z)
        {
            using (StreamWriter F = new StreamWriter(pathToXml, false, Encoding.GetEncoding(1251)))
            {
                F.WriteLine(z);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml;

namespace WindowsServiceInstalShield
{
    public partial class Service1 : ServiceBase
    {
        static Thread T;
        static bool mustStop;
        static string pathToXMLFileExchanger = @"XMLServer.XML";

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //File.Create(@"E:\уроки\сисПрога\Lab-4\ssss.txt");
            //using (StreamWriter F = new StreamWriter(@"E:\уроки\сисПрога\Lab-4\ssss.txt"))
            //{
            //    F.WriteLine("start");
            //}
            T = new Thread(WorkerThread);
            T.Start();
            
        }

        protected override void OnStop()
        {
            if ((T != null) && (T.IsAlive))
            {
                mustStop = true;
            }
        }

        static void WorkerThread()
        {
            while (!mustStop)
            {
                IPAddress IP = IPAddress.Parse("10.0.66.201");
                IPEndPoint ipEndPoint = new IPEndPoint(IP, 40000);
                Socket S = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    S.Bind(ipEndPoint);
                    S.Listen(10);
                    while (true)
                    {
                        using (Socket H = S.Accept())
                        {
                            IPEndPoint L = new IPEndPoint(IP, 0);
                            EndPoint R = (EndPoint)(L);
                            byte[] D = new byte[10000];
                            int Receive = H.ReceiveFrom(D, ref R);
                            string Request = Encoding.GetEncoding(1251).GetString(D, 0, Receive);
                            WriteRequest(Request);
                            //using (StreamWriter F = new StreamWriter(@"E:\уроки\сисПрога\Lab-4\ssss.txt"))
                            //{
                            //    F.WriteLine(Request);
                            //}


                            if (AnalaseXMLFirstRequest())
                            { // нет деректории нужно сделать
                                AddInformationToXML("exists");
                                string W = File.ReadAllText(pathToXMLFileExchanger, Encoding.GetEncoding(1251));
                                byte[] M = Encoding.GetEncoding(1251).GetBytes(W);
                                H.Send(M);

                                int bytesRec = H.Receive(D);
                                string Answer = Encoding.GetEncoding(1251).GetString(D, 0, bytesRec);
                                WriteRequest(Answer);

                                XmlDocument DocXML = new XmlDocument();
                                DocXML.Load(pathToXMLFileExchanger);
                                XmlNode nodeDocCreate = DocXML.DocumentElement.SelectSingleNode("/path/document/create");

                                if (nodeDocCreate.InnerText == "yes")
                                    CreateDirectory();
                                H.Shutdown(SocketShutdown.Both);
                            }
                            else
                            {// есть дериктория или файл не льзя создать
                                AddInformationToXML("does not exists");
                                string W = File.ReadAllText(pathToXMLFileExchanger, Encoding.GetEncoding(1251));
                                byte[] M = Encoding.GetEncoding(1251).GetBytes(W);
                                H.Send(M);
                                H.Shutdown(SocketShutdown.Both);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    WriteRequest(e.Message);
                }
            }
        }
        private static void AddInformationToXML(string statusName)
        {
            XmlDocument document = new XmlDocument();
            document.Load(pathToXMLFileExchanger);
            XmlNode element = document.CreateElement("answer");
            document.DocumentElement.AppendChild(element); // указываем родителя

            XmlNode subElement1 = document.CreateElement("status"); // даём имя
            subElement1.InnerText = statusName; // и значение
            element.AppendChild(subElement1); // и указываем кому принадлежит
            document.Save(pathToXMLFileExchanger);
        }

        private static bool AnalaseXMLFirstRequest()
        {
            XmlDocument D = new XmlDocument();
            D.Load(pathToXMLFileExchanger);
            XmlNode nodeNameDirectory = D.DocumentElement.SelectSingleNode("/path/name/name_directory");
            XmlNode nodeType = D.DocumentElement.SelectSingleNode("/path/name/type");
            XmlNode nodeShortName = D.DocumentElement.SelectSingleNode("/path/name/short_name");

            if (AnalaseDirectory(nodeNameDirectory.InnerText, nodeType.InnerText, nodeShortName.InnerText))
                return true; // нет деректории нужно сделать
            else
                return false; // есть дериктория или файл нельзя создать
        }
        private static void CreateDirectory()
        {
            XmlDocument D = new XmlDocument();
            D.Load(pathToXMLFileExchanger);
            XmlNode nodeNameDirectory = D.DocumentElement.SelectSingleNode("/path/name/name_directory");
            XmlNode nodeType = D.DocumentElement.SelectSingleNode("/path/name/type");
            XmlNode nodeShortName = D.DocumentElement.SelectSingleNode("/path/name/short_name");

            if (nodeType.InnerText == "file")
            {
                if (!Directory.Exists(nodeNameDirectory.InnerText))
                    Directory.CreateDirectory(nodeNameDirectory.InnerText);
                using (File.Create(nodeNameDirectory.InnerText + "\\" + nodeShortName.InnerText)) { }
            }
            else
            {
                Directory.CreateDirectory(nodeNameDirectory.InnerText + "\\" + nodeShortName.InnerText);
            }
        }

        private static bool AnalaseDirectory(string name_directory, string type, string short_name)
        {
            string pathToDirectory = @name_directory,
                shortFileName = short_name;
            if (type == "file")
            {
                if (!File.Exists(pathToDirectory + "\\" + shortFileName))
                    return true;
                else
                    return false;
            }
            if (type == "directory")
            {
                if (!Directory.Exists(pathToDirectory + "\\" + shortFileName))
                    return true;
                else
                    return false;
            }
            return false;
        }
        private static void WriteRequest(string z)
        {
            using (StreamWriter F = new StreamWriter(pathToXMLFileExchanger, false, Encoding.GetEncoding(1251)))
            {
                F.WriteLine(z);
            }
        }
    }
}

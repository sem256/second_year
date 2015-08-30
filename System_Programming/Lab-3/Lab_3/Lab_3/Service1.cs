using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;

namespace Lab_3
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        static readonly string w = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Task_Queue\\Parameters";
        protected override void OnStart(string[] args)
        {
            Regedit();
            AddLog("start");
            AddLog(" Regedit start Work in on start");
            
        }

        protected override void OnStop()
        {
            AddLog("stop");
        }

        public static void Regedit()
        {
            AddLog("Regedit start Work");
            Registry.SetValue(w, "test", 50, RegistryValueKind.DWord);
            AddLog("Regedit Work");
        }

        public static void AddLog(string log)
        {
            string nameFile = @"E:\уроки\сисПрога\Lab-3\Lab_3",
                textFile, nameToWrite;
            
            if (!Directory.Exists(nameFile))
            {
                Directory.CreateDirectory(nameFile);
                using (File.Create(nameFile + "\\TaskQueue_18-11-2013.log")) { }

                using (StreamWriter writeFile = new StreamWriter(nameFile + "\\TaskQueue_18-11-2013.log"))
                {
                    nameToWrite = DateTime.Now.ToString() + log;
                    writeFile.WriteLine(nameToWrite);
                }
            }
            else
            {
                if (!File.Exists(nameFile + "\\TaskQueue_18-11-2013.log"))
                {
                    using (File.Create(nameFile + "\\TaskQueue_18-11-2013.log")) { }
                }

                using (StreamReader readFile = new StreamReader(nameFile + "\\TaskQueue_18-11-2013.log")) { textFile = readFile.ReadToEnd(); }
                using (StreamWriter writeFile = new StreamWriter(nameFile + "\\TaskQueue_18-11-2013.log"))
                {
                    nameToWrite = textFile + "\n" + DateTime.Now.ToString() + log;
                    writeFile.WriteLine(nameToWrite);
                }
            }

        }
    }
}

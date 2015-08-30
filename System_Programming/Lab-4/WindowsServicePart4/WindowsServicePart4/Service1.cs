using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.IO;

namespace WindowsServicePart4
{
    public partial class Service1 : ServiceBase
    {
        static string path = @"E:\уроки\сисПрога\Lab-4\Laba-4.log";
        ManagementEventWatcher w1;
        ManagementEventWatcher w2;
        ManagementEventWatcher w3;
        ManagementEventWatcher w4;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WqlEventQuery q1 = new WqlEventQuery("select * from __instanceCreationEvent WITHIN 1 WHERE TargetInstance ISA 'win32_share' and TargetInstance.name = 'Pop-Music' ");
            w1 = new ManagementEventWatcher(q1);
            w1.EventArrived += new EventArrivedEventHandler(WriteStarted);

            WqlEventQuery q2 = new WqlEventQuery("select * from __instanceDeletionEvent WITHIN 1 WHERE TargetInstance ISA 'win32_share' and TargetInstance.name = 'Pop-Music' ");
            w2 = new ManagementEventWatcher(q2);
            w2.EventArrived += new EventArrivedEventHandler(WriteFinished);

            WqlEventQuery q3 = new WqlEventQuery("SELECT * FROM RegistryKeyChangeEvent WHERE Hive = 'HKEY_LOCAL_MACHINE'" + @" AND KeyPath = 'SOFTWARE\\LAB4'");
            w3 = new ManagementEventWatcher(q3);
            w3.EventArrived += new EventArrivedEventHandler(OnRegChanged);

            WqlEventQuery q4 = new WqlEventQuery("Select * From __InstanceOperationEvent Within 2 Where TargetInstance Isa 'CIM_DataFile' And TargetInstance.Drive='C:' And " + @"TargetInstance.Path='\\Lab4\\test\\'");
            w4 = new ManagementEventWatcher(q4);
            w4.EventArrived += new EventArrivedEventHandler(OnFolderChanged);

            w1.Start();
            w2.Start();
            w3.Start();
            w4.Start();
        }

        protected override void OnStop()
        {
            w1.Stop();
            w2.Stop();
            w3.Stop();
            w4.Stop();
        }
        private static void WriteStarted(object source, EventArrivedEventArgs e)
        {
            string textFile = "";
            if (!File.Exists(path))
                using (File.Create(path)) { }
            using (StreamReader readFile = new StreamReader(path)) { textFile = readFile.ReadToEnd(); }
            using (StreamWriter F = new StreamWriter(path))
            {
                F.WriteLine(textFile + "\n" + DateTime.Now + " Delete");
            }
        }

        private static void WriteFinished(object source, EventArrivedEventArgs e)
        {
            string textFile = "";
            if (!File.Exists(path))
                using (File.Create(path)) { }
            using (StreamReader readFile = new StreamReader(path)) { textFile = readFile.ReadToEnd(); }
            using (StreamWriter F = new StreamWriter(path))
            {
                F.WriteLine(textFile + "\n" + DateTime.Now + "Create ");
            }
        }

        private static void OnRegChanged(object source, EventArrivedEventArgs e)
        {
            string textFile = "";
            if (!File.Exists(path))
                using (File.Create(path)) { }
            using (StreamReader readFile = new StreamReader(path)) { textFile = readFile.ReadToEnd(); }
            using (StreamWriter F = new StreamWriter(path))
            {
                F.WriteLine(textFile + "\n" + DateTime.Now + " HKEY_LOCAL_MACHINE\\Software\\LABA4 changed");
            }
        }

        private static void OnFolderChanged(object source, EventArrivedEventArgs e)
        {
            string textFile = "";
            if (!File.Exists(path))
                using (File.Create(path)) { }
            using (StreamReader readFile = new StreamReader(path)) { textFile = readFile.ReadToEnd(); }
            using (StreamWriter F = new StreamWriter(path))
            {
                F.WriteLine(textFile + "\n" + DateTime.Now + " TEST changed");
            }
        }
    }
}

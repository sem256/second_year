using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Management;
using Microsoft.Win32;



namespace ConsoleTestAplication
{
    class Program
    {
        static string path = @"E:\уроки\сисПрога\Lab-4\Laba-4.log";

        static void Main(string[] args)
        {
            ManagementEventWatcher w1;
            ManagementEventWatcher w2;
            ManagementEventWatcher w3;
            ManagementEventWatcher w4;

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

            System.Threading.Thread.Sleep(300000);
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

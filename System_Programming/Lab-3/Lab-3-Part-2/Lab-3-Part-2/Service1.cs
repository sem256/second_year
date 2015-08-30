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
using System.Timers;
using System.Text.RegularExpressions;


namespace Lab_3_Part_2
{
    public partial class Service1 : ServiceBase
    {
        static readonly string w = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Task_Queue\\Parameters";
        static List<string> ColectionForTHSecond = new List<string>();
        static int yStart = (int)Registry.GetValue(w, "Task_Execution_Quantity", 1),
            y = yStart,
            time = (int)Registry.GetValue(w, "Task_Execution_Duration", 60);

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            AddLog(" Start");
            AddRegedit();
            CreateSomeRegistry();
            System.Threading.Thread THFirst = new System.Threading.Thread(ThreadMain1);
            THFirst.Start();
            System.Threading.Thread THSecond = new System.Threading.Thread(ThreadMain2);
            THSecond.Start();
        }

        protected override void OnStop()
        {
            AddLog(" Stop");
        }

        public static void ThreadMain1()
        {
            int timePeriod = (int)Registry.GetValue(w, "Task_Claim_Check_Period", 30);
            Timer t1 = new Timer(timePeriod * 1000);
            t1.Elapsed += new ElapsedEventHandler(Cycle1);
            t1.Enabled = true;
        }
        public static void ThreadMain2()
        {
            int timePeriod2 = 2;
            Timer t2 = new Timer(timePeriod2 * 1000);
            t2.Elapsed += new ElapsedEventHandler(Cycle2);
            t2.Enabled = true;
        }
        public static void Cycle2(object source, ElapsedEventArgs e)
        {
            int prozent, numberOfI,delta;
            string[] values = new string[0];
            string s;// назва таску
            string[] splitForProgress;

            RegistryKey gh = Registry.LocalMachine.OpenSubKey(@"Software\Task_Queue");
            values = gh.GetValueNames();
            delta = 200 / time;
            for (int i = 0; i < values.Length; i++)
            {
                if ((y > 0) && (values[i].IndexOf("Queued") > -1))
                {
                    using (RegistryKey rK = Registry.LocalMachine.CreateSubKey(@"Software\Task_Queue\"))
                    {
                        s = values[i].Substring(0, 9);
                        rK.DeleteValue(values[i]);
                        rK.SetValue(s + "-[" + new string('.', 20) + "]-In progress - 0 % completed", "", RegistryValueKind.String);
                    }
                    y--;
                }
                if (values[i].IndexOf("progress") > -1)
                {
                    splitForProgress = values[i].Split(' ');
                    prozent = Int32.Parse(splitForProgress[3]) + delta;
                    if (prozent <= 100)
                    {
                        using (RegistryKey rK = Registry.LocalMachine.CreateSubKey(@"Software\Task_Queue\"))
                        {
                            s = values[i].Substring(0, 9);
                            rK.DeleteValue(values[i]);
                            numberOfI = (prozent * 20) / 100;
                            Console.WriteLine(numberOfI.ToString());
                            rK.SetValue(s + "-[" + new string('I', numberOfI) + new string('.', 20 - numberOfI) + "]-In progress - " + prozent + " % completed", "", RegistryValueKind.String);
                        }
                    }
                    else
                    {
                        if (Int32.Parse(splitForProgress[3]) < 100)
                        {
                            using (RegistryKey rK = Registry.LocalMachine.CreateSubKey(@"Software\Task_Queue\"))
                            {
                                s = values[i].Substring(0, 9);
                                rK.DeleteValue(values[i]);
                                rK.SetValue(s + "-[" + new string('I', 20) + "]-In progress - 100 % completed", "", RegistryValueKind.String);
                            }
                        }
                        else
                        {
                            using (RegistryKey rK = Registry.LocalMachine.CreateSubKey(@"Software\Task_Queue\"))
                            {
                                s = values[i].Substring(0, 9);
                                rK.DeleteValue(values[i]);
                                rK.SetValue(s + "-[IIIIIIIIIIIIIIIIIIII]-COMPLETED", "", RegistryValueKind.String);
                                string text = "Задача " + s + " успішно ВИКОНАНА!";
                                AddTextInLog(text);
                            }
                            if (y <= yStart)
                                y++;
                        }

                    }
                }
            }
        }
        public static void Cycle1(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("work first threading part 2");
            string[] names = new string[0];
            RegistryKey gh = Registry.LocalMachine.OpenSubKey(@"Software\Task_Queue\Claims");
            names = gh.GetValueNames();
            Regex etalon = new Regex("Task_[0-9]{4}");
            string text;

            ColectionForTHSecond.Clear();
            for (int i = 0; i < names.Length; i++)
            {
                if (etalon.IsMatch(names[i]))
                {
                    ColectionForTHSecond.Add(names[i]);
                }
                else
                {
                    text = "ПОМИЛКА розміщення заявки " + names[i] + " Некоректний синтаксис ...";
                    AddTextInLog(text);
                    BadTask(names[i]);
                }

            }
            ColectionForTHSecond.Sort();
            text = "Задача " + ColectionForTHSecond.First() + " успішно прийнята в обробку...";
            AddTextInLog(text);
            GoodTask(ColectionForTHSecond.First());
        }

        public static void GoodTask(string name)
        {
            using (RegistryKey rK = Registry.LocalMachine.CreateSubKey(@"Software\Task_Queue\"))
            {
                rK.SetValue(name + "-[....................]-Queued", "", RegistryValueKind.String);
            }
            using (RegistryKey rK = Registry.LocalMachine.CreateSubKey(@"Software\Task_Queue\Claims"))
            {
                rK.DeleteValue(name);
            }
        }

        public static void BadTask(string name)
        {
            using (RegistryKey rK = Registry.LocalMachine.CreateSubKey(@"Software\Task_Queue\Claims"))
            {
                rK.DeleteValue(name);
            }
        }
        public static void AddRegedit()
        {
            using (RegistryKey rK = Registry.LocalMachine.CreateSubKey(@"Software\Task_Queue\Claims"))
            {
                rK.SetValue("Task_0245", "", RegistryValueKind.String);
                rK.SetValue("Task_0255", "", RegistryValueKind.String);
                rK.SetValue("Task_0218", "", RegistryValueKind.String);
                rK.SetValue("Task_0212", "", RegistryValueKind.String);
                rK.SetValue("Task_0213", "", RegistryValueKind.String);
                rK.SetValue("Task_0214", "", RegistryValueKind.String);
                rK.SetValue("Tasccccccck_0214", "", RegistryValueKind.String);
            }
        }
        public static void CreateSomeRegistry()
        {
            if (Registry.GetValue(w, "Task_Execution_Duration", null) == null)
                Registry.SetValue(w, "Task_Execution_Duration", 60, RegistryValueKind.DWord);

            if (Registry.GetValue(w, "Task_Claim_Check_Period", null) == null)
                Registry.SetValue(w, "Task_Claim_Check_Period", 30, RegistryValueKind.DWord);

            if (Registry.GetValue(w, "Task_Execution_Quantity", null) == null)
                Registry.SetValue(w, "Task_Execution_Quantity", 2, RegistryValueKind.DWord);
        }

        public static void AddTextInLog(string text)// можна не змінювати для переносу
        {
            string textFile;
            using (StreamReader readFile = new StreamReader(@"E:\уроки\сисПрога\Lab-3\Lab-3-Part-2\TaskQueue_18-11-2013.log")) { textFile = readFile.ReadToEnd(); }
            using (StreamWriter writeFile = new StreamWriter(@"E:\уроки\сисПрога\Lab-3\Lab-3-Part-2\TaskQueue_18-11-2013.log"))
            {
                writeFile.WriteLine(textFile + "\n ------------" +
                    DateTime.Now.ToString() + "--------------" + "\n" + text);
            }
        }
        public static void AddLog(string log)
        {
            string nameFile = @"E:\уроки\сисПрога\Lab-3\Lab-3-Part-2",
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
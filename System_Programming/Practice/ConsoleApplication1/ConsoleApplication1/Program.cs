using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections.ObjectModel;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number;
                WriteAllFunction();
                while (!Int32.TryParse(Console.ReadLine(), out number))
                    WriteAllFunction();
                while (number != 0)
                {
                    switch (number)
                    {
                        case 1://Get-Service
                            {
                                Collection<PSObject> PSO = GetService("");
                                foreach (PSObject R in PSO)
                                {
                                    Console.Write(R.Members["Name"].Value);
                                    Console.Write("  is   ");
                                    Console.WriteLine(R.Members["Status"].Value);
                                }
                            }
                            break;
                        case 2: Console.WriteLine(GetService("").Count);//(Get-Service).Count
                            break;
                        case 3://Get-Service | ft -AutoSize
                            {
                                Collection<PSObject> PSO = GetService("");
                                int addSpace,
                                    longesrWord = LongestWord(PSO);
                                foreach (PSObject R in PSO)
                                {
                                    addSpace = longesrWord - R.Members["Name"].Value.ToString().Length;
                                    Console.Write(R.Members["Name"].Value + new string(' ', addSpace));
                                    Console.Write("  is   ");
                                    Console.WriteLine(R.Members["Status"].Value);
                                }

                            }
                            break;
                        case 4://Get-Service -name Dns* | ft -AutoSize
                            {
                                //string name = Console.ReadLine();
                                Collection<PSObject> PSO = GetService("Dns*");
                                int addSpace,
                                    longesrWord = LongestWord(PSO);
                                foreach (PSObject R in PSO)
                                {
                                    addSpace = longesrWord - R.Members["Name"].Value.ToString().Length;
                                    Console.Write(R.Members["Name"].Value + new string(' ', addSpace));
                                    Console.Write("  is   ");
                                    Console.WriteLine(R.Members["Status"].Value);
                                }
                            }
                            break;
                    }
                    WriteAllFunction();
                    while (!Int32.TryParse(Console.ReadLine(), out number))
                        WriteAllFunction();
                }
                Console.WriteLine("Exit");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        public static void WriteAllFunction()
        {
            Console.WriteLine("\n1 -  Get-Service");
            Console.WriteLine("2 - (Get-Service).Count");
            Console.WriteLine("3 - Get-Service | ft -AutoSize");
            Console.WriteLine("4 - Get-Service -name Dns*| ft -AutoSize");
            Console.WriteLine("0 - Exit \n");
        }
        public static Collection<PSObject> GetService(string name)
        {
            var script = "Get-Service";
            if (name != "")
                script = "Get-Service -name " + name;
            PowerShell ps = PowerShell.Create().AddScript(script);
            return ps.Invoke();
        }

        public static int LongestWord(Collection<PSObject> collection)
        { 
            int length = 0, 
                etalon = 0;
            foreach (PSObject R in collection)
            {
                length = R.Members["Name"].Value.ToString().Length;
                if (etalon < length)
                    etalon = length;
            }
            return etalon;
        }
    }
}

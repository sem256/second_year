using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace part_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            using (RegistryKey readKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion"))
            {
                i = (int)readKey.GetValue("InstallDate");
            }
            DateTime date = new DateTime(1970,01,01);
            date = date.AddSeconds(i);
            Console.WriteLine(date);
            Console.ReadKey();
        }
    }
}

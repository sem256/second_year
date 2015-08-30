using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace part_10
{
    class Program
    {
        static void Main(string[] args)
        {
            using (RegistryKey rK = Registry.CurrentUser.CreateSubKey(@"HKLM\Software\Matvienko"))
            {
                rK.SetValue("P5", new string[] { "Я -", "- студент", "кафедри", "Комп'ютерної інженерії!" }, RegistryValueKind.MultiString);
            }
        }
    }
}
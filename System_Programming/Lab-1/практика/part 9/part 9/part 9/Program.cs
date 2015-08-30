using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;

namespace part_9
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (RegistryKey rK = Registry.LocalMachine.CreateSubKey("Software\\Matvienko2"))
            //{
            //    rK.SetValue("P1", "KI2-Student", RegistryValueKind.String);
            //    rK.SetValue("P2", new byte[] { 0x2A, 0x4B, 0xCE, 0xDF }, RegistryValueKind.Binary);
            //    rK.SetValue("P3", 0x2A4BCEDF, RegistryValueKind.DWord);
            //    rK.SetValue("P4", 409611231, RegistryValueKind.DWord);
            //}
            using (RegistryKey rK = Registry.LocalMachine.CreateSubKey("Software\\Task_Queue\\Parameters"))
            {
                rK.SetValue("Task_Execution_Duration", 60, RegistryValueKind.DWord);
            }
        }
    }
}
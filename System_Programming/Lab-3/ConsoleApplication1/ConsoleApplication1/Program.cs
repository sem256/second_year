using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex etalonQueued = new Regex("Task_[0-9]{4}-.[[.]]{20}.]-Queued");
            string names = "Task_0245-[....................]-Queued";
            string name = "Task_0245";
            if (name.IndexOf("Queued") > -1)
            {
                Console.WriteLine("good");
                Console.ReadKey();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library_3;

namespace ConsoleApplicationTest
{
    class Program
    {
        public double Test()
        { 
            KI3_Class_3 name = new KI3_Class_3();
            return name.F3(2, 3);
        }

        static void Main(string[] args)
        {
            Program m = new Program();
            Console.WriteLine(m.Test());
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library_2;

namespace Library_4
{
    public class KI3_Class_4
    {
        public static double F4(double x, double y)
        {
            KI3_Class_2 s = new KI3_Class_2();
            return 2 * s.F2(x, y) - 3;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library_1;

namespace Library_2
{
    public class KI3_Class_2
    {
        public double F2(double x, double y)
        {
            return 2*KI3_Class_1.F1(x,y) - 5;
        }
    }
}

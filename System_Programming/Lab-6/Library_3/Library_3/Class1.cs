using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library_2;

namespace Library_3
{
    public class KI3_Class_3 : KI3_Class_2
    {
        public double F3(double x, double y)
        {
            return F2(x, y) * F2(x, y);
        }
    }
}

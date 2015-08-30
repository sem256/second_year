using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace part_5
{
    class Program
    {
        static private void SaveHtml(string html)
        {
            using (StreamWriter f = new StreamWriter(@"E:\уроки\сисПрога\Lab-1\практика\part_5\ce.html"))
            {
                f.Write(html);
            }
        }
        static void Main(string[] args)
        {
            HttpWebRequest R = (HttpWebRequest)WebRequest.Create("http://ce.univ.kiev.ua");
            HttpWebResponse P = (HttpWebResponse)R.GetResponse();
            var S = P.GetResponseStream();
            var reader = new StreamReader(S);
            string html = "";
            int rowCount = 0;
            while (!reader.EndOfStream)
            {
                rowCount++;
                html += reader.ReadLine();
            }
            P.Close();
            Console.WriteLine();
            SaveHtml(html);
            Console.WriteLine("Кількість рядочків: " + rowCount);
            System.Diagnostics.Process.Start("http://ce.univ.kiev.ua/");
            Console.ReadKey();
        }
    }
}

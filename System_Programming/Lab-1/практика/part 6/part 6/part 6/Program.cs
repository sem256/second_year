using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
//using System.Web;

namespace part_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string wayToFile = @"E:\уроки\сисПрога\Lab-1\практика\part 6\register.txt",
                wayToNewFile = @"E:\уроки\сисПрога\Lab-1\практика\part 6\newRegister.txt";
           if (!File.Exists(wayToFile)) { File.Delete(wayToFile); }
           if (!File.Exists(wayToNewFile)) { File.Delete(wayToNewFile); }

            WebClient web = new WebClient();
            web.DownloadFile("http://mail.univ.net.ua/register.txt", wayToFile);

            using (new FileStream(@"E:\уроки\сисПрога\Lab-1\практика\part 6\register1.txt", FileMode.Create)) { }
            using (File.Create(wayToNewFile)) { }


            using (StreamReader readerFile = new StreamReader(wayToFile))
            {
                using (StreamWriter writeFile = new StreamWriter(wayToNewFile))
                {
                    string s;
                    while (!readerFile.EndOfStream)
                    {
                        s = readerFile.ReadLine();
                        if ((!s.Contains("#")))
                        {
                            if (s.Contains("command")) { writeFile.WriteLine("=================COMMAND=================="); }
                            else
                            {
                                if (s.IndexOf("example", StringComparison.OrdinalIgnoreCase) >= 0 )
                                {
                                    //string[] array = s.Split(' ');
                                    //s = "";
                                    //for (int i = 0; i < array.Length; i++)
                                    //{
                                    //    if (array[i] == "example") { array[i] = ""; }
                                    //    s = s + " " + array[i];
                                    //}
                                    //writeFile.WriteLine(s);
                                }
                                else
                                {
                                    writeFile.WriteLine(s);
                                }
                            }
                        }
                        else
                        {
                            if (s[0] != '#') { writeFile.WriteLine(s); }
                        }
                    }
                    // Console.ReadKey();
                }
            }

        }
    }
}

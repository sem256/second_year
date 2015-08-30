using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace part_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameFile = @"E:\уроки\сисПрога\Lab-1\практика\part 7\KI",
                textFile, nameToWrite;

            if (!Directory.Exists(nameFile))
            {
                Directory.CreateDirectory(nameFile);
                using (File.Create(nameFile + "\\Anninkov.log")) { }

                using (StreamWriter writeFile = new StreamWriter(nameFile + "\\Anninkov.log"))
                {
                    nameToWrite = DateTime.Now.ToString() + " Комп'ютер успішно завантажено!";
                    writeFile.WriteLine(nameToWrite);
                }
            }
            else
            {
                if (!File.Exists(nameFile + "\\Anninkov.log"))
                {
                    using (File.Create(nameFile + "\\Anninkov.log")) { }
                }
                
                using (StreamReader readFile = new StreamReader(nameFile + "\\Anninkov.log")) { textFile = readFile.ReadToEnd(); }
                using (StreamWriter writeFile = new StreamWriter(nameFile + "\\Anninkov.log"))
                {
                    nameToWrite = textFile + "\n" + DateTime.Now.ToString() + " Комп'ютер успішно завантажено!";
                    writeFile.WriteLine(nameToWrite);
                }
            }
        }
    }
}

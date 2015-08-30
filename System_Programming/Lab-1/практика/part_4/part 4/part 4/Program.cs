using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace part_4
{
    class Program
    {
        public static void SendMail(string smtpServer, string from, string password, string mailto, string caption, string message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;

                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                //mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть email і тему через пробіл");
            string emailTitle = Console.ReadLine();
            string[] words = emailTitle.Split(' ');
            while(!words[0].Contains("@"))
            {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("Текст був введений не вірно повторіть будь ласка спробу");
                Console.WriteLine("Введіть email і тему через пробіл");
                emailTitle = Console.ReadLine();
                words = emailTitle.Split(' ');
            }
            while (words.Length < 2) 
            {
                Console.WriteLine("Текст був введений не вірно повторіть будь ласка спробу");
                Console.WriteLine("Введіть email і тему через пробіл");
                emailTitle = Console.ReadLine();
                words = emailTitle.Split(' ');
            }
            string body = Convert.ToString(DateTime.Now) + " Matvienko " + "Alexander";
            //string myEmail = "motia256@gmail.com";
            SendMail("smtp.gmail.com", "motia256@gmail.com", "mobssmobss", words[0], words[1], body);
        }
    }
}
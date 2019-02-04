using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SmtpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Host: ");
            string host = Console.ReadLine();
            Console.Write("SmtpUser: ");
            string smtpUser = Console.ReadLine();
            Console.Write("SmtpPassword: ");
            string smtpPassword = Console.ReadLine();
            Console.Write("SenderEmail: ");
            string senderEmail = Console.ReadLine();
            Console.Write("Receiver: ");
            string receiverEmail = Console.ReadLine();

            SmtpClient client = new SmtpClient(host)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(smtpUser, smtpPassword)
            };

            MailMessage message = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = "Hello World!",
                Body = "This is a test email :)"
            };

            try
            {
                client.Send(message);
                Console.WriteLine("Sent!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}

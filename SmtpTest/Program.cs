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
            Console.Write("SenderEmail: ");
            string senderEmail = Console.ReadLine();
            Console.Write("SenderPassword: ");
            string senderPassword = Console.ReadLine();
            Console.Write("Receiver: ");
            string receiver = Console.ReadLine();

            SmtpClient client = new SmtpClient(host)
            {
                Port = 587,
                Credentials = new NetworkCredential(senderEmail, senderPassword)
            };

            MailMessage message = new MailMessage(senderEmail, receiver)
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

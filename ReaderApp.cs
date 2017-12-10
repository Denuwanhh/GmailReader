using System;
using System.Collections.Generic;

namespace GmailReader
{
    class ReaderApp
    {
        static void Main(string[] args)
        {
            //Insert your user name and password
            MailController mailCon = new MailController("usernam@gmail.com", "password");
            List<Mail> mailList = mailCon.GetAllMails();
            foreach (Mail temp in mailList) {
                Console.WriteLine("Title : " + temp.Title);
                Console.WriteLine("From : " + temp.AuthorName);
                Console.WriteLine("Email : " + temp.AuthorEmail);
                Console.WriteLine("Issued Date : " + temp.IssuedDate);
                Console.WriteLine("Summary : " + temp.Summary);                
            }
            Console.ReadKey();
        }
    }
}

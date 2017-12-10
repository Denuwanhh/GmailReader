using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;

namespace GmailReader
{
    class MailController
    {
        List<Mail> Mails = new List<Mail>();
        private string userName;
        private string password;

        public MailController(string username, string password)
        {
            this.userName = username;
            this.password = password;
        }

        public List<Mail> GetAllMails()
        {
            WebClient objclient = new WebClient();
            string response = null;
            XmlDocument xdoc = new XmlDocument();

            try
            {
                objclient.Credentials = new NetworkCredential(userName, password);
                response = Encoding.UTF8.GetString(objclient.DownloadData("https://mail.google.com/mail/feed/atom"));
                response = response.Replace("<feed version=\"0.3\" xmlns=\"http://purl.org/atom/ns#\">", "<feed>");
                xdoc.LoadXml(response);
                foreach (XmlNode xmlNode in xdoc.SelectNodes("feed/entry"))
                {
                    Mail mail = new Mail();
                    mail.AuthorName = xmlNode.SelectSingleNode("author/name").InnerText;
                    mail.AuthorName = xmlNode.SelectSingleNode("author/email").InnerText;
                    mail.Title = xmlNode.SelectSingleNode("title").InnerText;
                    mail.Summary = xmlNode.SelectSingleNode("summary").InnerText;
                    mail.IssuedDate = xmlNode.SelectSingleNode("issued").InnerText;

                    Mails.Add(mail);
                }
                return Mails;
            }
            catch(System.Exception ex)
            {
                return null;
            }
        }

    }
}

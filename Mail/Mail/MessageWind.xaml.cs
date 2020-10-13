using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mail
{
    /// <summary>
    /// Логика взаимодействия для MessageWind.xaml
    /// </summary>
    public partial class MessageWind : Window
    {
        public string login { get; set; }
        public string passwd { get; set; }
        public MessageWind()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (btnSend.Content.ToString() == "OK")
                this.Close();
            else
            {
               Task.Run(()=> SendEmailAsync(login, passwd,tbDateOrTo.Text,tbHead.Text,tbText.Text));
               this.Close();
            }
        }
        private async Task SendEmailAsync(string login,string passw, string toto, string head,string text)
        {
            MailAddress from = new MailAddress(login,"Tom" );
            MailAddress to = new MailAddress(toto);
            MailMessage m = new MailMessage(from, to);
            m.Subject = head;
            m.Body = text;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(login, passw);
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }
    }
}

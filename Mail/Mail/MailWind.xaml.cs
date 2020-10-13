using MailKit;
using MailKit.Net.Imap;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для MailWind.xaml
    /// </summary>
    public partial class MailWind : Window
    {
        public string login { get; set; }
        public string passwd { get; set; }

        static ImapClient imap = new ImapClient();
        ObservableCollection<UserMessage> userMessages = new ObservableCollection<UserMessage>();
        public MailWind()
        {
            InitializeComponent();
            lbItem.ItemsSource = userMessages;
        }
        private static async Task<IMailFolder> EmailAsync(string login, string pass)
        {
            await imap.ConnectAsync("imap.gmail.com", 993, true);
            await imap.AuthenticateAsync(login, pass);
           
            // if (imap.IsAuthenticated)
            var inbox = imap.Inbox;
            return inbox;

        }
        public async void RefreshAsync()
        {
            IMailFolder inbox = await Task.Run(() => EmailAsync(login, passwd));
            inbox.Open(FolderAccess.ReadOnly);
            progress.Visibility= Visibility.Visible;
            progress.Maximum = inbox.Count;
            try
            {
                for (int i = inbox.Count - 1; i >= 0; i--)
                {
                    MimeMessage message = await inbox.GetMessageAsync(i);
                    userMessages.Add(new UserMessage { Date = message.Date, Name = message.From.Mailboxes.First().Name, Subj = message.Subject ,Text= message.TextBody});
                    progress.Value++;
                }
                progress.Value = 0;
                progress.Visibility = Visibility.Hidden;
            }
            catch { }
            await imap.DisconnectAsync(true);
        }
        private void btnNewMs_Click(object sender, RoutedEventArgs e)
        {
            MessageWind messageWind = new MessageWind();
            messageWind.login = login;
            messageWind.passwd = passwd;
            messageWind.lbDate.Content = "Send to email";
            messageWind.btnSend.Content = "Send";
            messageWind.Show();
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            userMessages.Clear();
            RefreshAsync();
        }

        private void lbItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((sender as ListView).SelectedIndex != -1)
            {
                MessageWind messageWind = new MessageWind();
                messageWind.btnSend.Content = "OK";
                messageWind.lbDate.Content = "Date";
                messageWind.tbDateOrTo.Text = userMessages[(sender as ListView).SelectedIndex].Date.ToString();
                messageWind.tbFrom.Text = userMessages[(sender as ListView).SelectedIndex].Name;
                messageWind.tbHead.Text = userMessages[(sender as ListView).SelectedIndex].Subj;
                messageWind.tbText.Text = userMessages[(sender as ListView).SelectedIndex].Text;
                messageWind.Show();
            }
        }
       

    }
}


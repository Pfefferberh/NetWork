using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Work_with_API.View
{
    /// <summary>
    /// Логика взаимодействия для Window.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public StudentWindow()
        {
            InitializeComponent();

            Task t1 = new Task(Music);
           
            t1.Start();

        }


        private static void Music()
        {
            var player = new MediaPlayer();
            player.MediaFailed += (s, e) => MessageBox.Show("Error");
            player.Open(new Uri("John Williams - Prologue.mp3", UriKind.RelativeOrAbsolute));
            player.Play();
        }
    }
}

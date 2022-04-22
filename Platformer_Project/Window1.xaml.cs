using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Platformer_Project
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private MediaPlayer mediaPlayer;
        public Window1()
        {
            
    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            Close();
            Window2 window2 = new Window2();
            window2.InitializeComponent();
            window2.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            Close();
            Window3 level1 = new Window3();
            level1.InitializeComponent();
            level1.ShowDialog();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void loaded(object sender, RoutedEventArgs e)
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"../../Assets/Music/Menu/A_City_Without_Sleep.mp3", UriKind.Relative));
            mediaPlayer.Play();
        }
    }
}

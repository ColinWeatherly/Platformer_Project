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
        Class2 mediaPlayer = new Class2();
        public Window1()
        {
            
    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.menuStop();
            Close();
            Window2 window2 = new Window2();
            window2.InitializeComponent();
            window2.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mediaPlayer.menuStop();
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
            mediaPlayer.musicMenu();
        }
    }
}

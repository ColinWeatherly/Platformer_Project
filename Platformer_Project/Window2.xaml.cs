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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
            Window3 window3 = new Window3();
            window3.InitializeComponent();
            window3.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
            Window4 window4 = new Window4();
            window4.InitializeComponent();
            window4.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Close();
            Window5 window5 = new Window5();
            window5.InitializeComponent();
            window5.ShowDialog();
        }
    }
}

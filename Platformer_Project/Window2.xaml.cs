/* Name: Blade Johnson, Colin Weatherly
 * Date: 4/28/2022
 * File: Window2.xaml.cs
 * IDE: Visual Studio 2019
 * Description: Creates the buttons and functionality for the level select window.
 */

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

        // creates and launches a new level 1 upon clicking the level 1 button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // closes this window
            Close();
            // creates new window and runs it
            Window3 window3 = new Window3();
            window3.InitializeComponent();
            window3.ShowDialog();
        }

        // creates and launches a new level 2 upon clicking the level 2 button
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // closes this window
            Close();
            // creates new window and runs it
            Window4 window4 = new Window4();
            window4.InitializeComponent();
            window4.ShowDialog();
        }

        // creates and launches a new level 3 upon clicking the level 3 button
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // closes this window
            Close();
            // creates new window and runs it
            Window5 window5 = new Window5();
            window5.InitializeComponent();
            window5.ShowDialog();
        }
    }
}

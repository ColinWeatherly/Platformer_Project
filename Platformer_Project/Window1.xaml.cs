/* Name: Blade Johnson, Colin Weatherly
 * Date: 4/28/2022
 * File: Window1.xaml.cs
 * IDE: Visual Studio 2019
 * Description: Creates the buttons and functionality for the title screen window.
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        // creates a new Music player
        MusicClass mediaPlayer = new MusicClass();
        public Window1()
        {
            
        }

        // loads the level select upon clicking its button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // stops the music
            mediaPlayer.menuStop();
            // closes this window
            Close();
            // creates and runs a new instance of the level select
            // window
            Window2 window2 = new Window2();
            window2.InitializeComponent();
            window2.ShowDialog();
        }

        // loads the first level upon clicking the start game button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // stops the music
            mediaPlayer.menuStop();
            // closes this window
            Close();
            // creates and runs a new instance of level 1
            Window3 level1 = new Window3();
            level1.InitializeComponent();
            level1.ShowDialog();        
        }

        // closes the game when clicking the quit button
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // loads the correct music on the title screen
        private void loaded(object sender, RoutedEventArgs e)
        {
            mediaPlayer.musicMenu();
        }
    }
}

/* Name: Blade Johnson, Colin Weatherly
 * Date: 4/28/2022
 * File: QuitDecorator.cs
 * IDE: Visual Studio 2019
 * Description: Decorates the Quit button to display a Quit message
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
using System.Windows.Threading;

namespace Platformer_Project
{
    public class QuitDecorator : Button
    {
        private Button button;

        // Decorates the quit button to display a message
        public QuitDecorator(Button b)
        {
            button = b;
            MessageBox.Show("Thanks for playing!");
        }
    }
}

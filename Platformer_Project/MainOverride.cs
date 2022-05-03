/* Name: Blade Johnson, Colin Weatherly
 * Date: 4/28/2022
 * File: MainOverride.cs
 * IDE: Visual Studio 2019
 * Description: Houses main. Upon the program starting up, this
 *              acts as the startup object.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Platformer_Project
{
    internal class MainOverride
    {
        [STAThread]
        public static void Main()
        {
            // Creates an instance of the title screen
            // and runs it
            Window1 window1 = new Window1();
            window1.InitializeComponent();
            window1.ShowDialog();
        }
     }
}

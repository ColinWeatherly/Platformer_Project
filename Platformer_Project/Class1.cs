using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Platformer_Project
{
    internal class Class1
    {
        [STAThread]
        public static void Main()
        {
            Window1 window1 = new Window1();
            window1.InitializeComponent();
            window1.ShowDialog();
        }
     }
}

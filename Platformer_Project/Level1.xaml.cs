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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Platformer_Project
{
    /// <summary>
    /// Interaction logic for Level1.xaml
    /// </summary>
    public partial class Level1 : Window
    {
        Player player;
        Surface left_wall;
        public Level1()
        {
            InitializeComponent();
            Level_1_Canvas.Focus();

            player = new Player(20, 20, 50, 20);

            Rectangle rect = new Rectangle();
            rect.Width = 50;
            rect.Height = 600;

            left_wall = new Surface(rect, player);
        }
    }
}

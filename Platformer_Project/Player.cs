using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows;

namespace Platformer_Project
{
    class Player
    {
        Rectangle PlayerRect;
        Player(double x, double y, int height, int width)
        {
            PlayerRect = new Rectangle();
            PlayerRect.Fill = Brushes.Blue;
            PlayerRect.Height = height;
            PlayerRect.Width = width;
            Canvas.SetTop(PlayerRect, y);
            Canvas.SetLeft(PlayerRect, x);
            PlayerRect.AddHandler(UIElement.KeyDownEvent, new KeyEventHandler(keyisdown), true);
        }

        void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                Canvas.SetLeft(PlayerRect, Canvas.GetLeft(PlayerRect) - 5);
            }
            if (e.Key == Key.Right)
            {
                Canvas.SetLeft(PlayerRect, Canvas.GetLeft(PlayerRect) + 5);
            }
        }
    }
}

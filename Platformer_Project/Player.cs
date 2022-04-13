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
    public class Player
    {
        public Rectangle PlayerRect;
        DispatcherTimer dtClockTime = new DispatcherTimer();
        bool left;
        bool right;
        public Player(double x, double y, int height, int width)
        {
            PlayerRect = new Rectangle();
            PlayerRect.Fill = Brushes.Blue;
            PlayerRect.Height = height;
            PlayerRect.Width = width;
            Canvas.SetTop(PlayerRect, y);
            Canvas.SetLeft(PlayerRect, x);
            PlayerRect.AddHandler(UIElement.KeyDownEvent, new KeyEventHandler(keyisdown), true);
            PlayerRect.AddHandler(UIElement.KeyUpEvent, new KeyEventHandler(keyisup), true);

            dtClockTime.Tick += dtClockTime_Tick;
            dtClockTime.Interval = TimeSpan.FromMilliseconds(5); //in Hour, Minutes, Second.
            dtClockTime.Start();
        }

        void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                left = true;
            }
            if (e.Key == Key.Right)
            {
                right = true;
            }
        }

        void keyisup(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                left = false;
            }
            if (e.Key == Key.Right)
            {
                right = false;
            }
        }

        private void dtClockTime_Tick(object sender, EventArgs e)
        {
            if (left)
            {
                Canvas.SetLeft(PlayerRect, Canvas.GetLeft(PlayerRect) - 1);
            }
            
            if (right)
            {
                Canvas.SetLeft(PlayerRect, Canvas.GetLeft(PlayerRect) + 1);
            }
        }
    }
}

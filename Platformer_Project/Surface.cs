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
    public class Surface : Collision
    {
        Rectangle Hitbox;
        Player PlayerObject;
        DispatcherTimer dtClockTime = new DispatcherTimer();
        public Surface(Rectangle rectangle, Player player)
        {
            Hitbox = rectangle;
            PlayerObject = player;

            dtClockTime.Tick += dtClockTime_Tick;
            dtClockTime.Interval = TimeSpan.FromMilliseconds(5); //in Hour, Minutes, Second.
            dtClockTime.Start();
        }
        private void dtClockTime_Tick(object sender, EventArgs e)
        {
            if (Canvas.GetRight(PlayerObject.PlayerRect) == Canvas.GetLeft(Hitbox))
            {
                Canvas.SetLeft(PlayerObject.PlayerRect, Canvas.GetLeft(PlayerObject.PlayerRect) - 1);
            }

            if (Canvas.GetLeft(PlayerObject.PlayerRect) == Canvas.GetRight(Hitbox))
            {
                Canvas.SetRight(PlayerObject.PlayerRect, Canvas.GetRight(PlayerObject.PlayerRect) + 1);
            }
        }
    }
}

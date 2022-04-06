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
    class Surface : Collision
    {
        Rectangle Hitbox;
        Surface(Rectangle rectangle)
        {
            Hitbox = rectangle;
        }
        Rectangle Collision.left_collision(Rectangle player)
        {
            if (Canvas.GetRight(player) == Canvas.GetLeft(Hitbox))
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - 1);
            }
            return player;
        }
        Rectangle Collision.right_collision(Rectangle player)
        {
            if (Canvas.GetLeft(player) == Canvas.GetRight(Hitbox))
            {
                Canvas.SetRight(player, Canvas.GetRight(player) + 1);
            }
            return player;
        }
        Rectangle Collision.top_collision(Rectangle player)
        {
            return player;
        }
        Rectangle Collision.bottom_collision(Rectangle player)
        {
            return player;
        }
    }
}

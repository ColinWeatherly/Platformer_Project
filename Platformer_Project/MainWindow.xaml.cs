﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dtClockTime = new DispatcherTimer();
        bool goleft = false;
        bool goright = false;
        bool jumping = false;
        bool grounded = false;
        bool wallJumpLeft = false;
        bool wallJumpRight = false;
        bool wallBounce = false;

        int jumpSpeed = 10;
        int force = 30;

        Rect playerHitBox;
        Rect groundHitBox;
        Rect wallHitBoxLeft;
        Rect wallHitBoxRight;

        Rect wallHitBoxLeft2;
        Rect wallHitBoxRight2;

        public MainWindow()
        {
            InitializeComponent();
            MyCanvas.Focus();
            
            dtClockTime.Tick += dtClockTime_Tick;
            dtClockTime.Interval = TimeSpan.FromMilliseconds(5); //in Hour, Minutes, Second.
            

            dtClockTime.Start();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Left && wallBounce == false)
            {
                goleft = true;
            }
            if(e.Key == Key.Right && wallBounce == false)
            {
                goright = true;
            }
            if (e.Key == Key.X && jumping == true)
            {
                wallBounce = true;
                
            }
            if (e.Key == Key.Z && jumping == false && grounded == true || e.Key == Key.Z && jumping == false && wallJumpRight == true || e.Key == Key.Z && jumping == false && wallJumpLeft == true)
            {
                grounded = false;
                jumping = true;
                wallJumpRight = false;
                wallJumpLeft = false;
                force = 30;
                jumpSpeed = -12;
                Canvas.SetTop(Player, Canvas.GetTop(Player) - jumpSpeed);
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    goleft = false;
                    break;
                case Key.Right:
                    goright = false;
                    break;
            }
            
            /*if(e.Key == Key.Z && jumping == false && grounded == true || e.Key == Key.Z && jumping == false && wallJumpRight == true || e.Key == Key.Z && jumping == false && wallJumpLeft == true)
            {
                grounded = false;
                jumping = true;
                wallJumpRight = false;
                wallJumpLeft = false;
                force = 20;
                jumpSpeed = -12;
                Canvas.SetTop(Player, Canvas.GetTop(Player) - jumpSpeed);
            }*/
        }
        private void dtClockTime_Tick(object sender, EventArgs e)
        {
            double x = Canvas.GetLeft(Player);
            double y = Canvas.GetTop(Player);

            Canvas.SetTop(Player, y + jumpSpeed);

            

            if (goleft)
            {
               Canvas.SetLeft(Player, x - 5);
            }

            if (goright)
            {
                Canvas.SetLeft(Player, x + 5);
            }

            playerHitBox = new Rect(x, y, Player.Width, Player.Height);
            groundHitBox = new Rect(Canvas.GetLeft(ground), Canvas.GetTop(ground), ground.Width - 15, ground.Height - 10);
            wallHitBoxRight = new Rect(Canvas.GetLeft(wall), Canvas.GetTop(wall), wall.Width, wall.Height - 10);
            wallHitBoxLeft = new Rect(Canvas.GetLeft(wall2) + wall2.ActualWidth, Canvas.GetTop(wall2), wall2.Width, wall2.Height - 10);

            wallHitBoxRight2 = new Rect(Canvas.GetLeft(wall3), Canvas.GetTop(wall3), wall3.Width, wall3.Height - 10);
            wallHitBoxLeft2 = new Rect(Canvas.GetLeft(wall3) + wall3.ActualWidth, Canvas.GetTop(wall3), wall3.Width, wall3.Height - 10);

            if (playerHitBox.IntersectsWith(groundHitBox))
            {
                if (jumping == false)
                {
                    Canvas.SetTop(Player, Canvas.GetTop(ground) - Player.Height);
                    grounded = true;
                }
                wallBounce = false;
            }

            if (playerHitBox.IntersectsWith(wallHitBoxRight))
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(wall) - (Player.Width + 1));
                wallJumpRight = true;
                wallBounce = false;
            }

            if (playerHitBox.IntersectsWith(wallHitBoxLeft))
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(wall2) + wall2.Width + 10);
                wallJumpLeft = true;
                //wallBounce = false;
            }

            if (playerHitBox.IntersectsWith(wallHitBoxLeft2))
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(wall3) + wall3.Width + 10);
                wallJumpLeft = true;
                //wallBounce = false;
            }

            if (playerHitBox.IntersectsWith(wallHitBoxRight2))
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(wall3) - (Player.Width + 1));
                wallJumpLeft = true;
               // wallBounce = false;
            }

            if (wallBounce == true && wallJumpLeft == true || wallBounce == true && wallJumpRight == true)
            {
                if(wallJumpLeft == true)
                {
                    Canvas.SetLeft(Player, x + 20);
                }
                if(wallJumpRight == true)
                {
                    Canvas.SetLeft(Player, x - 20);
                }
                
                
            }

            if(jumping)
            {
                jumpSpeed = -9;

                force -= 2;
            }
            else
            {
                jumpSpeed = 12;
            }

            if (force < 0 && wallJumpLeft == false || force < 0 && wallJumpRight == false)
            {
                jumping = false;
                //wallBounce = false;
            }
        }
    }
}

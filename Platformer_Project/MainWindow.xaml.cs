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
        bool wallJump = false;
        bool wallBounce = false;

        int jumpSpeed = 10;
        int force = 20;

        Rect playerHitBox;
        Rect groundHitBox;
        Rect wallHitBox;

        public MainWindow()
        {
            InitializeComponent();
            MyCanvas.Focus();
            
            dtClockTime.Tick += dtClockTime_Tick;
            dtClockTime.Interval = TimeSpan.FromMilliseconds(10); //in Hour, Minutes, Second.
            

            dtClockTime.Start();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    goleft = true;
                    break;
                case Key.Right:
                    goright = true;
                    break;
                
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
                //case Key.Space:
                    //jumping = true;
                    //force = 15;
                    //jumpSpeed = -12;
                   // break;
            }
            if(e.Key == Key.Space && jumping == false && grounded == true || wallJump == true)
            {
                grounded = false;
                jumping = true;
                wallJump = false;
                force = 20;
                jumpSpeed = -12;
                Canvas.SetTop(Player, Canvas.GetTop(Player) - jumpSpeed);
            }
            if(e.Key == Key.Space && jumping == true)
            {
                wallBounce = true;
            }
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
            wallHitBox = new Rect(Canvas.GetLeft(wall), Canvas.GetTop(wall), wall.Width, wall.Height - 10);

            if (playerHitBox.IntersectsWith(groundHitBox))
            {
                if (jumping == false)
                {
                    Canvas.SetTop(Player, Canvas.GetTop(ground) - Player.Height);
                    grounded = true;
                }
            }

            if (playerHitBox.IntersectsWith(wallHitBox))
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(wall) - (Player.Width + 1));
                wallJump = true;
                
            }

            if(wallBounce == true && wallJump == true)
            {
                Canvas.SetLeft(Player, x + 20);
                wallBounce = false;
            }

            if(jumping)
            {
                jumpSpeed = -9;

                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }

            if(force < 0)
            {
                jumping = false;
            }
        }
    }
}

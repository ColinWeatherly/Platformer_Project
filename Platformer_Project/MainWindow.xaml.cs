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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dtClockTime = new DispatcherTimer();
        DispatcherTimer slideCharger = new DispatcherTimer();
        bool goleft = false;
        bool goright = false;
        bool noleft = false;
        bool noright = false;
        bool jumping = false;
        bool grounded = false;
        bool wallJumpLeft = false;
        bool wallJumpRight = false;
        bool slide = false;

        int jumpSpeed = 8;
        int speed = 6;
        int force = 10;
        int slideSpeed = 2;
        int slideForce = 25;
        int slideCharge = 2;

       Rect playerHitBox;
        Rect groundHitBox;
        Rect wallHitBoxLeft;
        Rect wallHitBoxRight;

        Rect wallHitBoxLeft2;
        Rect wallHitBoxRight2;

        Rect wallHitBoxRight3;
        Rect wallHitBoxLeft3;

        Rect groundHitBox2;
        Rect groundHitBox3;

        Rect goalHitBox;
        public MainWindow()
        {
            InitializeComponent();
            MyCanvas.Focus();
            
            dtClockTime.Tick += dtClockTime_Tick;
            dtClockTime.Interval = TimeSpan.FromMilliseconds(5);

            slideCharger.Tick += slideCharger_Tick;
            slideCharger.Interval = TimeSpan.FromSeconds(2);

            dtClockTime.Start();
            slideCharger.Start();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left && noleft == false)
            {
                goleft = true;
                goright = false;
                noright = false;
            }
            if(e.Key == Key.Right && noright == false)
            {
                goright = true;
                goleft = false;
                noleft = false;
            }
            if (e.Key == Key.X && noright == false && noleft == false && slideCharge != 0)
            {
                slide = true;
                slideForce = 25;
                slideCharge -= 1;
            }
            if (e.Key == Key.Z && jumping == false && grounded == true || e.Key == Key.Z && jumping == false && wallJumpRight == true || e.Key == Key.Z && jumping == false && wallJumpLeft == true)
            {
                
                    grounded = false;
                    wallJumpLeft = false;
                wallJumpRight = false;
                    jumping = true;
                    force = 10;
                    jumpSpeed = 8;
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
        private void slideCharger_Tick(object sender, EventArgs e)
        {
            if(slideCharge == 0)
            {
                slideCharge += 2;
            }
        }
        private void dtClockTime_Tick(object sender, EventArgs e)
        {

                Canvas.SetTop(Player, Canvas.GetTop(Player) + jumpSpeed);


            if (goleft)
            {
               Canvas.SetLeft(Player, Canvas.GetLeft(Player) - speed);
            }

            if (goright)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + speed);
            }

            if(slide && goleft)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - (speed * slideSpeed));
            }

            if(slide && goright)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + (speed * slideSpeed));
            }
            playerHitBox = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.Width, Player.Height);
            groundHitBox = new Rect(Canvas.GetLeft(ground), Canvas.GetTop(ground), ground.Width - 15, ground.Height - 10);
            wallHitBoxRight = new Rect(Canvas.GetLeft(wall), Canvas.GetTop(wall), wall.Width, wall.Height - 10);
            wallHitBoxLeft = new Rect(Canvas.GetLeft(wall2), Canvas.GetTop(wall2), wall2.Width, wall2.Height - 10);

            wallHitBoxRight2 = new Rect(Canvas.GetLeft(wall3), Canvas.GetTop(wall3), wall3.Width, wall3.Height);
            wallHitBoxLeft2 = new Rect(Canvas.GetLeft(wall3), Canvas.GetTop(wall3), wall3.Width, wall3.Height);

            wallHitBoxRight3 = new Rect(Canvas.GetLeft(wall4), Canvas.GetTop(wall4), wall4.Width, wall4.Height);
            wallHitBoxLeft3 = new Rect(Canvas.GetLeft(wall4), Canvas.GetTop(wall4), wall4.Width, wall4.Height);

            groundHitBox2 = new Rect(Canvas.GetLeft(ground2), Canvas.GetTop(ground2), ground2.Width, ground2.Height);
            groundHitBox3 = new Rect(Canvas.GetLeft(ground3), Canvas.GetTop(ground3), ground3.Width, ground3.Height);

            goalHitBox = new Rect(Canvas.GetLeft(goal), Canvas.GetTop(goal), goal.Width, goal.Height);

            if (playerHitBox.IntersectsWith(groundHitBox))
            {
                if (jumping == false)
                {
                    Canvas.SetTop(Player, Canvas.GetTop(ground) - Player.Height);
                    grounded = true;
                }
                force = 30;
            }

            if (playerHitBox.IntersectsWith(groundHitBox2))
            {
                if (jumping == false)
                {
                    Canvas.SetTop(Player, Canvas.GetTop(ground2) - Player.Height);
                    grounded = true;
                }
                force = 30;
            }

            if (playerHitBox.IntersectsWith(groundHitBox3))
            {
                if (jumping == false)
                {
                    Canvas.SetTop(Player, Canvas.GetTop(ground3) - Player.Height);
                    grounded = true;
                }
                force = 30;
            }

            if (playerHitBox.IntersectsWith(wallHitBoxRight) && goright == true)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + 1);
                noright = true;
                goright = false;
                wallJumpRight = true;
                wallJumpLeft = false;

            }

            if (playerHitBox.IntersectsWith(wallHitBoxLeft) && goleft == true)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + 1);
                noleft = true;
                goleft = false;
                wallJumpLeft = true;
                wallJumpRight = false;

                
            }

            if (playerHitBox.IntersectsWith(wallHitBoxLeft2) && goleft == true)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + 1);
                noleft = true;
                goleft = false;
                wallJumpLeft = true;
                wallJumpRight = false;

                
            }



            if (playerHitBox.IntersectsWith(wallHitBoxRight2) && goright == true)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - 1);
                noright = true;
                goright = false;
                wallJumpRight = true;
                wallJumpLeft = false;
                
            }

            if (playerHitBox.IntersectsWith(wallHitBoxRight3) && goright == true)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - 1);
                noright = true;
                goright = false;
                wallJumpRight = true;
                wallJumpLeft = false;

            }

            if (playerHitBox.IntersectsWith(wallHitBoxLeft3) && goleft == true)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + 1);
                noleft = true;
                goleft = false;
                wallJumpLeft = true;
                wallJumpRight = false;


            }

            if (playerHitBox.IntersectsWith(goalHitBox))
            {
                Close();
                Window1 window1 = new Window1();
                window1.InitializeComponent();
                window1.ShowDialog();
            }


            if (jumping == true && force < 0)
            {
                jumping = false;
            }
            if(jumping == true)
            {
                jumpSpeed = -8;
                force -= 1;
            }
            else
            {
                jumpSpeed = 8;
            }
            if(slide == true && slideForce < 0)
            {
                slide = false;
            }
            if(slide == true)
            {
                slideForce -= 2;
            }
        }
    }
}

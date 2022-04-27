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
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Platformer_Project
{
    /// <summary>
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
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
        double xSpawn;
        double ySpawn;
        Rect playerHitBox;

        DispatcherTimer dtClockTime = new DispatcherTimer();
        DispatcherTimer slideCharger = new DispatcherTimer();

        MusicClass mediaPlayer = new MusicClass();
        ImageBrush playerIMG = new ImageBrush();

        public Window5()
        {
            InitializeComponent();
        }

        private void loaded(object sender, RoutedEventArgs e)
        {
            mediaPlayer.musicLevel();
            MyCanvas.Focus();
            
            dtClockTime.Tick += dtClockTime_Tick;
            dtClockTime.Interval = TimeSpan.FromMilliseconds(5);

            slideCharger.Tick += slideCharger_Tick;
            slideCharger.Interval = TimeSpan.FromSeconds(2);

            dtClockTime.Start();
            slideCharger.Start();

            playerIMG.ImageSource = new BitmapImage(new Uri(@"../../Assets/Character/SpriteRight.png", UriKind.Relative));
            Player.Fill = playerIMG;
            xSpawn = Canvas.GetLeft(Player);
            ySpawn = Canvas.GetTop(Player);
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left && noleft == false)
            {
                goleft = true;
                goright = false;
                noright = false;
                playerIMG.ImageSource = new BitmapImage(new Uri(@"../../Assets/Character/SpriteLeft.png", UriKind.Relative));
                Player.Fill = playerIMG;
            }
            if(e.Key == Key.Right && noright == false)
            {
                goright = true;
                goleft = false;
                noleft = false;
                playerIMG.ImageSource = new BitmapImage(new Uri(@"../../Assets/Character/SpriteRight.png", UriKind.Relative));
                Player.Fill = playerIMG;
            }
            if (e.Key == Key.X && noright == false && noleft == false && slideCharge != 0)
            {
                slide = true;
                slideForce = 25;
                slideCharge -= 1;
                ImageBrush playerIMG = new ImageBrush();
                playerIMG.ImageSource = new BitmapImage(new Uri(@"../../Assets/Character/Dash1.png", UriKind.Relative));
                Player.Fill = playerIMG;
                Player.Height = Player.Height / 2;
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
        }

        private void slideCharger_Tick(object sender, EventArgs e)
        {
            if (slideCharge == 0)
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

            foreach(var x in MyCanvas.Children.OfType<Rectangle>())
            {   
                Rect hitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                
                if((string)x.Tag == "ground")
                {
                    if (playerHitBox.IntersectsWith(hitBox))
                    {
                        if (jumping == false)
                        {
                            Canvas.SetTop(Player, Canvas.GetTop(x) - Player.Height);
                            grounded = true;
                        }
                        force = 30;
                    }
                }

                if((string)x.Tag == "leftWall")
                {
                    if (playerHitBox.IntersectsWith(hitBox) && goleft == true)
                    {
                        Canvas.SetLeft(Player, Canvas.GetLeft(Player) + 1);
                        //noleft = true;
                        goleft = false;
                        wallJumpLeft = true;
                        wallJumpRight = false;
                    }
                }

                if((string)x.Tag == "rightWall")
                {
                    if (playerHitBox.IntersectsWith(hitBox) && goright == true)
                    {
                        Canvas.SetLeft(Player, Canvas.GetLeft(Player) + 1);
                        //noright = true;
                        goright = false;
                        wallJumpRight = true;
                        wallJumpLeft = false;
                    }
                }

                if((string)x.Tag == "goal")
                {
                    if (playerHitBox.IntersectsWith(hitBox))
                    {
                        mediaPlayer.levelStop();
                        Close();
                        Window1 startMenu = new Window1();
                        startMenu.InitializeComponent();
                        startMenu.ShowDialog();
                    }
                }

                if((string)x.Tag == "ceiling")
                {
                    if (playerHitBox.IntersectsWith(hitBox))
                    {
                        force = -1;
                    }
                }

                if((string)x.Tag == "death")
                {
                    if (playerHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetLeft(Player, xSpawn);
                        Canvas.SetTop(Player, ySpawn);
                    }
                }
            }

            if (jumping == true && force < 0)
            {
                jumping = false;
            }
            if (jumping == true)
            {
                jumpSpeed = -9;
                force -= 1;
            }
            else
            {
                jumpSpeed = 8;
            }
            if (slide == true && slideForce < 0)
            {
                slide = false;
                if (goright)
                {
                    ImageBrush playerIMG = new ImageBrush();
                    playerIMG.ImageSource = new BitmapImage(new Uri(@"../../Assets/Character/SpriteRight.png", UriKind.Relative));
                    Player.Fill = playerIMG;
                }
                if (goleft)
                {
                    ImageBrush playerIMG = new ImageBrush();
                    playerIMG.ImageSource = new BitmapImage(new Uri(@"../../Assets/Character/SpriteLeft.png", UriKind.Relative));
                    Player.Fill = playerIMG;
                }
                Player.Height = Player.Height * 2;
            }
            if (slide == true)
            {
                slideForce -= 2;
            }
        }
    }
}

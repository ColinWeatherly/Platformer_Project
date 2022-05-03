/* Name: Blade Johnson, Colin Weatherly
 * Date: 4/28/2022
 * File: Window5.xaml.cs
 * IDE: Visual Studio 2019
 * Description: Handles player functionality and object functionality for Level 3.
 */

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
        // booleans that handle the state of the player character's
        // movement
        bool goleft = false;
        bool goright = false;
        bool noleft = false;
        bool noright = false;
        bool jumping = false;
        bool grounded = false;
        bool wallJumpLeft = false;
        bool wallJumpRight = false;
        bool slide = false;

        // initial values for movement speeds
        int jumpSpeed = 8;
        int speed = 6;
        int force = 10;
        int slideSpeed = 2;
        int slideForce = 25;
        int slideCharge = 2;

        // used to hold the player's location at spawn
        double xSpawn;
        double ySpawn;

        // the hitbox of the player object
        Rect playerHitBox;

        // timers to allow for movement and restrict use of the slide
        DispatcherTimer dtClockTime = new DispatcherTimer();
        DispatcherTimer slideCharger = new DispatcherTimer();

        // creates a new media player
        MusicClass mediaPlayer = new MusicClass();

        // makes a new ImageBrush object
        ImageBrush playerIMG = new ImageBrush();

        public Window5()
        {
            InitializeComponent();
        }

        // loads level-related objects on startup
        private void loaded(object sender, RoutedEventArgs e)
        {
            // plays the level music
            mediaPlayer.musicLevel();
            MyCanvas.Focus();

            // ties the tick to a specific function and sets the
            // interval speed
            dtClockTime.Tick += dtClockTime_Tick;
            dtClockTime.Interval = TimeSpan.FromMilliseconds(5);

            // ties the tick to a specific function and sets the
            // interval speed
            slideCharger.Tick += slideCharger_Tick;
            slideCharger.Interval = TimeSpan.FromSeconds(2);

            // starts the timers
            dtClockTime.Start();
            slideCharger.Start();

            // loads the player graphic
            playerIMG.ImageSource = new BitmapImage(new Uri(@"../../Assets/Character/SpriteRight.png", UriKind.Relative));
            Player.Fill = playerIMG;

            // grabs the player spawn location
            xSpawn = Canvas.GetLeft(Player);
            ySpawn = Canvas.GetTop(Player);
        }

        // handles movement when a key is pressed down
        private void keyisdown(object sender, KeyEventArgs e)
        {
            // if left is pressed, player goes left, graphic is updated
            if (e.Key == Key.Left && noleft == false)
            {
                goleft = true;
                goright = false;
                noright = false;
                playerIMG.ImageSource = new BitmapImage(new Uri(@"../../Assets/Character/SpriteLeft.png", UriKind.Relative));
                Player.Fill = playerIMG;
            }
            // if right is pressed, player goes right, graphic is updated
            if (e.Key == Key.Right && noright == false)
            {
                goright = true;
                goleft = false;
                noleft = false;
                playerIMG.ImageSource = new BitmapImage(new Uri(@"../../Assets/Character/SpriteRight.png", UriKind.Relative));
                Player.Fill = playerIMG;
            }
            // if x is pressed, player slides, the appropriate booleans/variables are updated
            // graphic is updated
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
            // if z is pressed, player jumps, the appropriate booleans/variables are updated
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

        // handles movement when keys are released
        private void keyisup(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                // stops movement when the left or right keys are released
                case Key.Left:
                    goleft = false;
                    break;
                case Key.Right:
                    goright = false;
                    break;
            }
        }

        // updates the slide to become available again if the charge
        // is at zero on any given tick
        private void slideCharger_Tick(object sender, EventArgs e)
        {
            if (slideCharge == 0)
            {
                slideCharge += 2;
            }
        }

        // updates the player character every timer tick
        private void dtClockTime_Tick(object sender, EventArgs e)
        {
            // updates the character's y position every tick
            Canvas.SetTop(Player, Canvas.GetTop(Player) + jumpSpeed);

            // if appropriate, handles the character's leftward movement for a tick
            if (goleft)
            {
               Canvas.SetLeft(Player, Canvas.GetLeft(Player) - speed);
            }

            // if appropriate, handles the character's rightward movement for a tick
            if (goright)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + speed);
            }

            // if appropriate, handles left-slide movement
            if (slide && goleft)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - (speed * slideSpeed));
            }

            // if appropriate, handles right-slide movement
            if (slide && goright)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + (speed * slideSpeed));
            }

            // sets the player's hitbox
            playerHitBox = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.Width, Player.Height);

            // handles surface collision between the player and a surface
            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
                // creates a new surface hitbox
                Rect hitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                // handles collision for ground rectangles
                if ((string)x.Tag == "ground")
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

                // handles collision for left walls
                if ((string)x.Tag == "leftWall")
                {
                    if (playerHitBox.IntersectsWith(hitBox) && goleft == true)
                    {
                        Canvas.SetLeft(Player, Canvas.GetLeft(Player) + 1);
                        goleft = false;
                        wallJumpLeft = true;
                        wallJumpRight = false;
                    }
                }

                // handles collision for right walls
                if ((string)x.Tag == "rightWall")
                {
                    if (playerHitBox.IntersectsWith(hitBox) && goright == true)
                    {
                        Canvas.SetLeft(Player, Canvas.GetLeft(Player) + 1);
                        goright = false;
                        wallJumpRight = true;
                        wallJumpLeft = false;
                    }
                }

                // handles collision for the goal object
                if ((string)x.Tag == "goal")
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

                // handles collision for ceiling objects
                if ((string)x.Tag == "ceiling")
                {
                    if (playerHitBox.IntersectsWith(hitBox))
                    {
                        force = -1;
                    }
                }

                // handles collision for the death plane
                if ((string)x.Tag == "death")
                {
                    if (playerHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetLeft(Player, xSpawn);
                        Canvas.SetTop(Player, ySpawn);
                    }
                }
            }

            // handles the jumping mechanics and gravity
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

            // updates the player graphics upon sliding
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

            // subtracts 2 from slideForce upon sliding
            if (slide == true)
            {
                slideForce -= 2;
            }
        }
    }
}

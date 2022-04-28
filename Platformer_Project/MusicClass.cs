/* Name: Blade Johnson, Colin Weatherly
 * Date: 4/28/2022
 * File: MusicClass.cs
 * IDE: Visual Studio 2019
 * Description: Handles the functionalities of the music players to be used in
 *              screens and levels.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace Platformer_Project
{
    
    public class MusicClass
    {
        // create level and menu media players
        private MediaPlayer menuPlayer;
        private MediaPlayer levelPlayer;

        // create a new menu player and load the menu music
        public void musicMenu()
        {
            menuPlayer = new MediaPlayer();
            menuPlayer.Open(new Uri(@"../../Assets/Music/Menu/A_City_Without_Sleep.mp3", UriKind.Relative));
            menuPlayer.Play();
        }

        // stop the menu player
        public void menuStop()
        {
            menuPlayer.Stop();
        }

        // restart the music upon the media ending
        private void Media_Ended(object sender, EventArgs e)
        {
            menuPlayer.Position = TimeSpan.Zero;
            menuPlayer.Play();
        }

        // create a new level player and load the level music
        public void musicLevel()
        {
            levelPlayer = new MediaPlayer();
            levelPlayer.Open(new Uri(@"../../Assets/Music/Level/Neon_Prison.mp3", UriKind.Relative));
            levelPlayer.Play();
        }

        // stop the level player
        public void levelStop()
        {
            levelPlayer.Stop();
        }
    }
}

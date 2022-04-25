using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace Platformer_Project
{
    
    public class Class2
    {
        private MediaPlayer menuPlayer;
        private MediaPlayer levelPlayer;
        public void musicMenu()
        {
            menuPlayer = new MediaPlayer();
            menuPlayer.Open(new Uri(@"../../Assets/Music/Menu/A_City_Without_Sleep.mp3", UriKind.Relative));
            menuPlayer.Play();
        }
        public void menuStop()
        {
            menuPlayer.Stop();
        }
        public void musicLevel()
        {
            levelPlayer = new MediaPlayer();
            levelPlayer.Open(new Uri(@"../../Assets/Music/Level/Neon_Prison.mp3", UriKind.Relative));
            levelPlayer.Play();
        }
        public void levelStop()
        {
            levelPlayer.Stop();
        }
    }
}

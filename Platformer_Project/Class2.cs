using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace Platformer_Project
{
    
    public partial class Class2
    {
        private MediaPlayer mediaPlayer;
        public void moosic()
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"../../Assets/Music/Menu/A_City_Without_Sleep.mp3", UriKind.Relative));
            mediaPlayer.Play();
        }
    }
}

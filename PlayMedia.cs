using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Playback;
using Windows.Media.Core;
using Windows.Storage;
using System.Runtime.InteropServices;

namespace MusicApp
{
    class PlayMedia
    {
         
        public static void PlayMusic()
        {
            MediaPlayer m1 = new MediaPlayer();

            m1.Source = MediaSource.CreateFromUri(new Uri("ms-appx:////Ssmple1.mp4"));
            m1.Play();
        }

    }
    
}

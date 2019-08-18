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




        // StorageFolder f = Windows.ApplicationModel.Package.Current.InstalledLocation;
        // f = await f.GetFolderAsync("MyFolder");
        // StorageFile sf = await f.GetFileAsync("MyFile.mp3");
        //  PlayMusic.SetSource(await sf.OpenAsync(FileAccessMode.Read), sf.ContentType);
        //     PlayMusic.Play();

    }
    
}

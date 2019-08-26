using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MusicApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Media : Page
    {
        private MediaPlayer m1;

        public Media()
        {
            this.InitializeComponent();
            m1 = new MediaPlayer();
            mediaPlayer.SetMediaPlayer(m1);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var music = (Music)e.Parameter;

            m1.Source = MediaSource.CreateFromUri(new System.Uri($"ms-appx:///{music.MusicId}.mp3"));
            m1.Play();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            m1.Pause();
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}

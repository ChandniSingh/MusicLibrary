using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class AlbumPage : Page
    {
        private Music album;

        public AlbumPage()
        {
            this.InitializeComponent();
        }

        // TASK - Add a button to save the album and call Library.AddAlbum from there
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var selectedAlbum = (Music) e.Parameter;
            this.AlbumName.Text = selectedAlbum.Title;

            this.album = selectedAlbum;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        // TASK - We will open the media player here. Once, we get the song location or id
        private void Songs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddSong_Click(object sender, RoutedEventArgs e)
        {
            if (!AddSongPopUp.IsOpen) { AddSongPopUp.IsOpen = true; }
        }

        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            // if the Popup is open, then close it 
            if (AddSongPopUp.IsOpen) { AddSongPopUp.IsOpen = false; }
        }

        // TASK - Get the Song information from the UI and call save song method on album
        // HINT - Create a private variable to store the Album from the OnNavigateMethod, then call AddSong method on that album
        private void SavePopupClicked(object sender, RoutedEventArgs e)
        {
            // if the Popup is open, then close it 
            if (AddSongPopUp.IsOpen) {
                album.AddSong(this.AddSongName.Text);

                AddSongPopUp.IsOpen = false;
            }
        }
    }
}

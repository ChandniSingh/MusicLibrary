using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp
{
    class Library
    {
        static int lastAlbumId = 0;

        static bool initialized = false;
        
        private static List<Music> AllMusic = new List<Music>();

        // TASK - Fetch artist name and thumbnail from the UI and store in the Album object
        public async static Task AddAlbum(string albumname, string thumbnail)
        {
            var album = new Music
            {
                Title = albumname,
                MusicId = lastAlbumId,
                Thumbnail = thumbnail
            };

            lastAlbumId++;

            await FileHelper.WriteTextFileAsync("albums.txt", album.ToString());

            AllMusic.Add(album);
        }

        public async static Task<IEnumerable<Music>> GetAllMusic()
        {
            // Load from file
            if (!initialized)
            {
                // Read file
                await LoadMusicFromFileAsync();
                initialized = true;
            }

            return AllMusic;
        }

        public async static Task<ICollection<Music>> LoadMusicFromFileAsync()
        {
            var content = await FileHelper.ReadTextFileAsync("albums.txt");
            var lines = content.Split('\r', '\n');
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                var lineParts = line.Split(',');
                var album = new Music
                {
                    MusicId = Convert.ToInt32(lineParts[0]),
                    Title = lineParts[1],
                    Thumbnail=lineParts[2]
                };
               
                AllMusic.Add(album);

                lastAlbumId = Math.Max(lastAlbumId, album.MusicId + 1);
            }

            return AllMusic;
        }

        public Music GetMusic(int id)
        {
            var album = AllMusic.SingleOrDefault(s => s.MusicId == id);
            return album;
        }
    }
}

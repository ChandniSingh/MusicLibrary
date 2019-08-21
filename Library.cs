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
        
        private static List<Album> AllAlbums = new List<Album>();

        public async static Task AddAlbum(string albumname)
        {
            var album = new Album();
            album.AlbumName = albumname;
            album.AlbumId = lastAlbumId;

            lastAlbumId++;

            await FileHelper.WriteTextFileAsync("albums.txt", album.ToString());

            AllAlbums.Add(album);
        }

        public async static Task<IEnumerable<Album>> GetAllAlbums()
        {
            // Load from file
            if (!initialized)
            {
                // Read file
                await LoadAlbumsFromFileAsync();
                initialized = true;
            }

            return AllAlbums;
        }
        public async static Task<ICollection<Album>> LoadAlbumsFromFileAsync()
        {
            var content = await FileHelper.ReadTextFileAsync("albums.txt");
            var lines = content.Split('\r', '\n');
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                var lineParts = line.Split(',');
                var album = new Album
                {
                    AlbumId = Convert.ToInt32(lineParts[0]),
                    AlbumName = lineParts[1]
                };
               
                AllAlbums.Add(album);

                lastAlbumId = Math.Max(lastAlbumId, album.AlbumId + 1);
            }

            return AllAlbums;
        }

        public Album GetAlbum(int id)
        {
            var album = AllAlbums.SingleOrDefault(s => s.AlbumId == id);
            return album;
        }

    }
}

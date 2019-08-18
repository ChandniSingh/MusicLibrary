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
        
        private static List<Album> AllAlbums = new List<Album>();

        public void AddAlbum(string albumname)
        {
            var album = new Album();
            album.AlbumName = albumname;
            album.AlbumId = lastAlbumId;


            lastAlbumId++;
            AllAlbums.Add(album);

        }
        public IEnumerable<Album> GetAllAlbums()
        {
            return AllAlbums;
        }
        public Album GetAlbum(int id)
        {
            var album = AllAlbums.SingleOrDefault(s => s.AlbumId == id);
            return album;
        }

    }
}

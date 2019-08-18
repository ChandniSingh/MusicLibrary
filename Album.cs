using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp
{
    class Album
    {

        static int lastSongId = 0;
        
        public int AlbumId { get; set; }
        public string Thumbnail { get; set; }

        public string AlbumName { get; set; }
        public List<Song> Songs { get; set; }

        

        public  void AddSong(string name)
        {
            var s1 = new Song
            {
                SongId = lastSongId,
                SongName = name
            };
            Songs.Add(s1);
            lastSongId++;
            
        }

        public IEnumerable<Song> GetAllSongs()
        {
            return Songs;
        }

        public Song GetSong(int id)
        {
           return  Songs.SingleOrDefault(s => s.SongId == id);
           
        }
    }
}

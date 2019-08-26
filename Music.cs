using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp
{
    class Music
    {

        static int lastSongId = 0;
        
        public int MusicId { get; set; }

        public string Thumbnail { get; set; }

        public string Title { get; set; }

        private List<Song> Songs { get; set; }

        public Music()
        {
            this.Songs = new List<Song>();
        }

        // TODO : Album should contain Songs
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

        public override string ToString()
        {
            return $"{this.MusicId},{this.Title},{this.Thumbnail}";
        }
    }
}

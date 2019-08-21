using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp
{
    class Music
    {
        private const string TEXT_FILE_NAME = "Music.txt";
        public String Title { get; set; }
        public String Genre { get; set; }


        public async static void WriteMusic(Music music)
        {
            var MusicData = $"{music.Title}, {music.Genre}";

            await FileHelper.WriteTextFileAsync(TEXT_FILE_NAME, MusicData);

        }

    }
}

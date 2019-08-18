using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace MusicApp
{
    public static class FileHelper
    {
        static async public void WriteTextFile(string filename, string content)
        {
            var textFile = await GetFile(filename);

            var textStream = await textFile.OpenAsync(FileAccessMode.ReadWrite);

            var textWriter = new DataWriter(textStream);
            textWriter.WriteString(content);
            await textWriter.StoreAsync();
        }

        public static async Task<StorageFile> GetFile(string filename)
        {
            var storageFolder = ApplicationData.Current.LocalFolder;
            return await storageFolder.CreateFileAsync(filename,
                 CreationCollisionOption.OpenIfExists);
        }
    }
}

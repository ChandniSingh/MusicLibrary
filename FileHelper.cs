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
        public async static Task WriteTextFileAsync(string filename,
            string content)
        {
            var storageFolder = ApplicationData.Current.LocalFolder;
            var textFile = await storageFolder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
            var textstream = await textFile.OpenAsync(FileAccessMode.ReadWrite);

            using (var outputStream = textstream.GetOutputStreamAt(textstream.Size))
            {
                using (var dataWriter = new DataWriter(outputStream))
                {
                    dataWriter.WriteString(content + "\r\n");
                    await dataWriter.StoreAsync();
                }
            }

            textstream.Dispose();
        }

        public static async Task<StorageFile> GetFile(string filename)
        {
            var storageFolder = ApplicationData.Current.LocalFolder;
            return await storageFolder.CreateFileAsync(filename,
                 CreationCollisionOption.OpenIfExists);
        }

        public async static Task<string> ReadTextFileAsync(string filename)
        {
            var storageFolder = ApplicationData.Current.LocalFolder;
            var textFile = await storageFolder.GetFileAsync(filename);
            var textStream = await textFile.OpenReadAsync();

            var textReader = new DataReader(textStream);

            var textLength = textStream.Size;
            await textReader.LoadAsync((uint)textLength);
            return textReader.ReadString((uint)textLength);



        }
    }
}

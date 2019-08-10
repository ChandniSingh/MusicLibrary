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
        static async public void WriteTextFile(string filename,string content)
        {
            var storageFolder = ApplicationData.Current.LocalFolder;

          var textFile= await storageFolder.CreateFileAsync(filename, 
               CreationCollisionOption.OpenIfExists);

           var textStream = await textFile.OpenAsync(FileAccessMode.ReadWrite);

            var textWriter = new DataWriter(textStream);
            textWriter.WriteString(content);
          await textWriter.StoreAsync();


                

        }
    }
}

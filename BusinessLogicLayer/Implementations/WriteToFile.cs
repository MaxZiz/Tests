using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLogicLayer.Implementations
{
    public class WriteToFile : IWriteable
    {
        private const string pathOfFolder = @"C\Users\User\";
        static WriteToFile()
        {
            if (!Directory.Exists(pathOfFolder))
            {
                Directory.CreateDirectory(pathOfFolder);
            }
        }

        public async Task Write(string text, string fileName)
        {
            string path = pathOfFolder+fileName;
            if(!File.Exists(path))
            {
                using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] buffer = Encoding.Default.GetBytes(text);
                    await fstream.WriteAsync(buffer, 0, buffer.Length);
                }
            }           
        }

    }
}

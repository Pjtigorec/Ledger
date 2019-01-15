using Microsoft.Win32;
using SpamServices.Models;
using System;
using System.IO;

namespace SpamServices
{
    public class Service1 : ISpamService
    {
        public Spam GetSpam()
        {
            Spam spam = null;
            Random random = new Random();
            int number = random.Next(1, 4);
            string path = Path.GetFullPath(@"Images\"+ number +".jpg");

            using (var fileStream = File.OpenRead(path))
            {
                var result = new byte[fileStream.Length];

                fileStream.Read(result, 0, result.Length);

                var classes = Registry.ClassesRoot;

                var fileClass = classes.OpenSubKey(Path.GetExtension(fileStream.Name));

                spam = new Spam
                {
                    Image = result,
                    Type = fileClass.GetValue("Content type").ToString()
                };
            }

            return spam;
        }
    }
}

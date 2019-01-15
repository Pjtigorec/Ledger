using Microsoft.Win32;
using SpamServices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SpamServices
{
    public class SpamServices : ISpamServices
    {
        public Spam GetSpam()
        {
            Spam spam = null;

            using (var fileStream = File.OpenRead(@"~\Images\1.jpg"))
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

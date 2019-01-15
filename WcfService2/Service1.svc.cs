using Microsoft.Win32;
using SpamServices;
using SpamServices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : ISpamServices
    {
        public Spam GetSpam()
        {
            //Spam spam = null;

            //using (var fileStream = File.OpenRead(@"~\Images\1.jpg"))
            //{
            //    var result = new byte[fileStream.Length];

            //    fileStream.Read(result, 0, result.Length);

            //    var classes = Registry.ClassesRoot;

            //    var fileClass = classes.OpenSubKey(Path.GetExtension(fileStream.Name));

            //    spam = new Spam
            //    {
            //        Image = result,
            //        Type = fileClass.GetValue("Content type").ToString()
            //    };
            //}

            string path = @"D:\1.jpg";

            return new Spam {
                Image = File.ReadAllBytes(path),
                   Type = Path.GetExtension(path)
            };
        }
    }
}

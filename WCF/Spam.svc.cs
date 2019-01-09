using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF
{
    public class Spam : ISpam
    {
        public byte[] GetImage()
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] array = (byte[])_imageConverter.ConvertTo("~Images/first", typeof(byte[]));
            return array;
        }
    }
}

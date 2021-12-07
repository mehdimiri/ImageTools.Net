using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace ImageTools.Net.Tools
{
    public static class Helper
    {
        public static MemoryStream ToMemoryStream(this Bitmap b)
        {
            MemoryStream ms = new MemoryStream();
            b.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms;
        }

        public static Stream ToStream(this Image image)
        {
            var stream = new System.IO.MemoryStream();
            image.Save(stream, image.RawFormat);
            stream.Position = 0;
            return stream;
        }

        public static ImageCodecInfo GetImageCodecInfo(string ext)
        {
            int j;

            ImageCodecInfo[] encoders;

            encoders = ImageCodecInfo.GetImageEncoders();

            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].FilenameExtension.ToLower().Contains(ext.ToLower()))
                    return encoders[j];
            }
            return null;
        }

        public Image Base64ToImage(string base64string)
        {

                  byte[] bytes = Convert.FromBase64String(base64string);

                 Image image;
                 using (MemoryStream ms = new MemoryStream(bytes))
                  {
                    image = Image.FromStream(ms);
                    }

              return image;
        }

         public static string FromImage(Image val)
         {
            MemoryStream stream = new MemoryStream();
           try
           {
             val.Save(stream, val.RawFormat);
           }
           catch (ArgumentNullException)
           {
             val.Save(stream, ImageFormat.Bmp);
           }
          return Convert.ToBase64String(stream.GetBuffer());
         }

             public static byte[] getBytesFromImage(Image im)
            {
            MemoryStream ms = new MemoryStream();

            im.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
            }
    }
}

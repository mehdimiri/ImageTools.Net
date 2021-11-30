using ImageTools.Net.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
namespace ImageTools.Net
{
    public static class ImageResize
    {
        public static Stream Resize(this Stream stream, int width, int height)
        {
            using (Image img = Image.FromStream(stream))
            {
                using (Bitmap bitmap = new Bitmap(img, width, height))
                {
                    return Helper.ToMemoryStream(bitmap);
                }
            }
        }
    }
}

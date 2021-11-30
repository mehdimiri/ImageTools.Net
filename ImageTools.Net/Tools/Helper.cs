using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace ImageTools.Net.Tools
{
    static class Helper
    {
        public static MemoryStream ToMemoryStream(this Bitmap b)
        {
            MemoryStream ms = new MemoryStream();
            b.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms;
        }
    }
}

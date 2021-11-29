using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageTools.Net
{
    public static class Save
    {
        public static void SaveAs(this Stream stream,string path)
        {
            using (Image img = Image.FromStream(stream))
            {
                img.Save(path);
            }
        }
    }
}

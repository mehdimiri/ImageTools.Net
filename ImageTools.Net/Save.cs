using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageTools.Net
{
    public static class Save
    {
        public static void SaveAs(this Stream stream, string path)
        {
            using (stream)
            {
                using (Image img = Image.FromStream(stream))
                {
                    //img.Save();
                }
            }
        }

        public static void SaveAs(this Image img, string path)
        {
            using (img)
            {
                img.SaveAs();
            }
        }
    }
}

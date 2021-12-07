using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ImageTools.Net.Tools;

namespace ImageTools.Net
{
    public static class Save
    {
        public static void SaveAs(this Stream stream, string path, int quality = 100)
        {
            using (Image img = Image.FromStream(stream))
            {
                using (var objEncoderParameters = new EncoderParameters(1))
                {
                    var objEncoder = Encoder.Quality;
                    using (var objEncoderParameter = new EncoderParameter(objEncoder, (long)quality))
                    {
                        objEncoderParameters.Param[0] = objEncoderParameter;

                        using (img)
                        {
                            var dotIndex = path.LastIndexOf('.');
                            var ext = path.Substring(dotIndex, path.Length - dotIndex - 1);
                            var myImageCodecInfo = Helper.GetImageCodecInfo(ext);
                            img.Save(path, myImageCodecInfo, objEncoderParameters);
                        }
                    }
                }

            }
        }

    }
}

﻿using System;
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
    }
}

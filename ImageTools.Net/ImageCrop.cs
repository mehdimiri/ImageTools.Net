using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using ImageTools.Net.Tools;

namespace ImageTools.Net
{
    public static class ImageCrop
    {
        public static Stream Crop(this Stream stream, int width, int height)
        {
            Bitmap sourceImage = new Bitmap(stream);
            using (Bitmap objBitmap = new Bitmap(width, height))
            {
                objBitmap.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);
                using (Graphics objGraphics = Graphics.FromImage(objBitmap))
                {
                    objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    objGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    objGraphics.DrawImage(sourceImage, 0, 0, width, height);
                    return Helper.ToMemoryStream(objBitmap);
                }
            }
        }
    }
}

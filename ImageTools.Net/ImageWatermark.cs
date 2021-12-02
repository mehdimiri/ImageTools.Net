using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using ImageTools.Net.Tools;

namespace ImageTools.Net
{
    public static class ImageWatermark
    {
        public static Stream AddImageWatermark(this Stream stream, string imageWatermarkPath)
        {
            using (System.Drawing.Image watermark = System.Drawing.Image.FromFile(imageWatermarkPath))
            {
                using (System.Drawing.Image targetImg = System.Drawing.Image.FromStream(stream))
                {
                    using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(targetImg))
                    {
                        var destX = 20;
                        var destY = (targetImg.Height - watermark.Height) - 20;

                        g.DrawImage(watermark, new System.Drawing.Rectangle(destX,
                                    destY,
                                    watermark.Width,
                                    watermark.Height));
                        return targetImg.ToStream();
                    }
                }
            }
        }
    }
}

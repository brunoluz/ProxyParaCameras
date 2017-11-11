using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace ProxyParaCameras2.Models
{
    public static class ImageExtensions
    {
        public static MemoryStream WriteDateTimeAndConvertToMemoryStream(this Image image, WriteImageOptions imageOptions)
        {
            using (Bitmap bitmap = new Bitmap(image))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    if (imageOptions == WriteImageOptions.Yes)
                        graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), new Font("Arial", 14f, FontStyle.Bold), SystemBrushes.MenuHighlight, (PointF)new Point(400, 450));

                    MemoryStream stream = new MemoryStream();
                    bitmap.Save(stream, ImageFormat.Jpeg);
                    stream.Seek(0L, SeekOrigin.Begin);
                    return stream;
                }
            }
        }
    }
}
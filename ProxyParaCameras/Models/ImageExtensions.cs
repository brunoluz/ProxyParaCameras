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
        public static MemoryStream WriteImageToMemoryStream(this Image image)
        {
            using (Bitmap bitmap = new Bitmap(image))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    MemoryStream stream = new MemoryStream();
                    bitmap.Save(stream, ImageFormat.Jpeg);
                    stream.Seek(0L, SeekOrigin.Begin);
                    return stream;
                }
            }
        }
    }
}
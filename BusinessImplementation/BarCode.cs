using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace BusinessImplementation
{
    public class BarCode
    {
        public string GetDataFromBase64(string base64)
        {
            var img = LoadImage(base64);

            return BarcodeCommon.Common.CheckImageForBarcode(img);
        }

        private Image LoadImage(string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            return image;
        }
    }
}

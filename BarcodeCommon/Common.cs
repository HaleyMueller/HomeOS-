using System;
using System.Drawing;
using System.IO;

namespace BarcodeCommon
{
    public static class Common
    {
        public static void Test()
        {
            var img = GetBarcodeFromString("boobies");

            img.Save("tempBarcode.jpg");

            var bitmap = new System.Drawing.Bitmap(img);

            var coreCompatReader = new ZXing.Windows.Compatibility.BarcodeReader();
            var coreCompatResult = coreCompatReader.Decode(bitmap);
        }

        public static Image GetBarcodeFromString(string content)
        {
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            var img = b.Encode(BarcodeLib.TYPE.CODE128, content, System.Drawing.Color.Black, System.Drawing.Color.White, 290, 120);

            return img;
        }

        public static string CheckImageForBarcode(Image image)
        {
            var bitmap = new System.Drawing.Bitmap(image);

            var coreCompatReader = new ZXing.Windows.Compatibility.BarcodeReader();
            var coreCompatResult = coreCompatReader.Decode(bitmap);

            if (coreCompatResult == null)
            {
                return "";
            }

            return coreCompatResult.Text;
        }
    }
}

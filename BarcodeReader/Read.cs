using System;
using System.Drawing;
using ZXing;

namespace BarcodeReaderCommon
{
    public static class Read
    {
        public static void Test()
        {
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            var img = b.Encode(BarcodeLib.TYPE.CODE128, "038000356216", Color.Black, Color.White, 290, 120);

            img.Save("tempBarcode.jpg");

            var bitmap = new Bitmap(img);
            bitmap.Save("tempBitmap.jpg");

            ZXing.BarcodeReader barcodeReader = new ZXing.BarcodeReader();
            var s = barcodeReader.Decode(bitmap);
        }
    }
}

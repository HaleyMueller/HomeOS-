using System;

namespace BarcodeCore
{
    public class Common
    {
        public static void Test()
        {
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            var img = b.Encode(BarcodeLib.TYPE.CODE128, "038000356216", Color.Black, Color.White, 290, 120);

            img.Save("tempBarcode.jpg");

            var bitmap = new Bitmap(img);
            bitmap.Save("tempBitmap.jpg");

            // create a barcode reader instance
            IBarcodeReader reader = new ZXing.BarcodeReader();
            // load a bitmap
            // detect and decode the barcode inside the bitmap
            LuminanceSource luminanceSource = new
            var result = reader.Decode(bitmap);
            // do something with the result
            if (result != null)
            {
                txtDecoderType.Text = result.BarcodeFormat.ToString();
                txtDecoderContent.Text = result.Text;
            }
        }
    }
}

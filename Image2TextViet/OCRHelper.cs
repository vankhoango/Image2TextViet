using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image2Text
{
    public static class OCRHelper
    {
        public static string ExtractTextFromImage(Bitmap bitmap)
        {
            /*
            var ocrPath = @"./tessdata"; // Make sure this folder has vie.traineddata

            using var engine = new TesseractEngine(ocrPath, "vie", EngineMode.Default);
            using var pix = PixConverter.ToPix(bitmap);
            using var page = engine.Process(pix);

            return page.GetText().Trim();
            */
            return "Hello";
        }
    }
}

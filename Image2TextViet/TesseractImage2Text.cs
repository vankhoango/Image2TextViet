/******************************************************************************
 * File:        TesseractImage2Text.cs
 * Project:     Image2TextViet
 * Author:      Khoa Ngo
 * Created:     2025-04-21
 *
 * License:     MIT
 ******************************************************************************/
using Tesseract;

namespace Image2TextViet
{
    internal class TesseractImage2Text
    {
        private const string DataFile = "vie.traineddata";
        
        private static string GetDataFolder()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            appDataPath = Path.Combine(appDataPath, ".Image2TextViet");
            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }
            var languageFilePath = Path.Combine(appDataPath, DataFile);
            if (!File.Exists(languageFilePath))
            {
                //Copy language file
                string sourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DataFile);
                File.Copy(sourceFile, languageFilePath, overwrite: true);
            }
            return appDataPath;
        }

        public static void ExtractTextFromImage(Bitmap bitmap)
        {
            var dataPath = GetDataFolder();
            using (var ocrEngine = new TesseractEngine(dataPath, "vie"))
            {
                using (var page = ocrEngine.Process(bitmap))
                {
                    var text = page.GetText();
                    if (text != null)
                    {
                        string fixedText = text.Replace("\r\n", "\n").Replace("\n", "\r\n");                     
                        TextDialog dialog = new TextDialog();
                        dialog.setContent(fixedText);
                        dialog.ShowDialog();
                    }
                }
            }
        }
    }
}

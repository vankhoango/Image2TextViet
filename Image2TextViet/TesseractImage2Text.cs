using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

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

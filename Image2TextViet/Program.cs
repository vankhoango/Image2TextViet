/******************************************************************************
 * File:        Program.cs
 * Project:     Image2TextViet
 * Author:      Khoa Ngo
 * Created:     2025-04-21
 *
 * License:     MIT
 ******************************************************************************/

namespace Image2TextViet
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TrayApp());
        }
    }
}
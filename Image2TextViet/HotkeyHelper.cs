/******************************************************************************
 * File:        HotkeyHelper.cs
 * Project:     Image2TextViet
 * Author:      Khoa Ngo
 * Created:     2025-04-21
 *
 * License:     MIT
 ******************************************************************************/

namespace Image2TextViet
{
    internal class HotkeyHelper
    {
        public static Keys Hotkey;
        public static bool Ctrl;
        public static bool Shift;
        public static bool Alt;

        public static void LoadHotkey()
        {
            string hotkeyString = Properties.Settings.Default.Hotkey;
            if (string.IsNullOrEmpty(hotkeyString))
            {
                hotkeyString = "Ctrl+Shift+S"; // fallback default
            }

            var parts = hotkeyString.Split('+');
            Ctrl = parts.Contains("Ctrl", StringComparer.OrdinalIgnoreCase);
            Shift = parts.Contains("Shift", StringComparer.OrdinalIgnoreCase);
            Alt = parts.Contains("Alt", StringComparer.OrdinalIgnoreCase);
            Hotkey = (Keys)Enum.Parse(typeof(Keys), parts.Last(), true);                                    
        }

        public static void SaveHotkey(Keys key, bool ctrl, bool shift, bool alt)
        {
            string hotkeyString = "";
            if (ctrl) hotkeyString += "Ctrl+";
            if (shift) hotkeyString += "Shift+";
            if (alt) hotkeyString += "Alt+";
            hotkeyString += key.ToString();

            Properties.Settings.Default.Hotkey = hotkeyString;
            Properties.Settings.Default.Save();

            LoadHotkey(); // update current values
        }

        public static string GetHotkeyText()
        {
            string text = "";
            if (Ctrl) text += "Ctrl+";
            if (Shift) text += "Shift+";
            if (Alt) text += "Alt+";
            text += Hotkey.ToString();
            return text;
        }
    }
}

using System.Runtime.InteropServices;

namespace Image2Text
{
    public class GlobalHotkey
    {
        public const int WM_HOTKEY_MSG_ID = 0x0312;

        private int id;
        private IntPtr handle;
        private int modifier;
        private Keys key;

        public GlobalHotkey(Modifiers modifier, Keys key, Form form)
        {
            this.modifier = (int)modifier;
            this.key = key;
            this.handle = form.Handle;
            this.id = GetHashCode();
        }

        public bool Register() => RegisterHotKey(handle, id, modifier, (int)key);
        public bool Unregister() => UnregisterHotKey(handle, id);

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }

    [Flags]
    public enum Modifiers
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }
}


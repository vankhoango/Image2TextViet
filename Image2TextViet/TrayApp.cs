/******************************************************************************
 * File:        TrayApp.cs
 * Project:     Image2TextViet
 * Author:      Khoa Ngo
 * Created:     2025-04-21
 *
 * License:     MIT
 ******************************************************************************/
namespace Image2TextViet
{
    public class TrayApp : Form
    {
        private NotifyIcon trayIcon;
        private GlobalHotkey hotkey;

        public TrayApp()
        {
            trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Visible = true,
                Text = "Image2Text Viet",
                ContextMenuStrip = new ContextMenuStrip()
            };
            trayIcon.Icon = new Icon("text2imageviet.ico");
            trayIcon.Visible = true;
            trayIcon.Text = "Text2Image Viet";

            HotkeyHelper.LoadHotkey();
            var contextMenu = new ContextMenuStrip();
            var setHotkeyItem = new ToolStripMenuItem($"Đổi phím tắt ({HotkeyHelper.GetHotkeyText()})");
            setHotkeyItem.Click += (s, e) => ShowHotkeyDialog();

            var exitItem = new ToolStripMenuItem("Thoát Image2Text Viet");
            exitItem.Click += (s, e) =>
            {
                hotkey?.Unregister();
                Application.Exit();
            };

            contextMenu.Items.Add(setHotkeyItem);
            contextMenu.Items.Add(exitItem);

            trayIcon.ContextMenuStrip = contextMenu;

            hotkey = new GlobalHotkey(Modifiers.Control | Modifiers.Shift, Keys.S, this);
            hotkey.Register();            
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == GlobalHotkey.WM_HOTKEY_MSG_ID)
            {
                BeginInvoke(new Action(() =>
                {
                    Console.WriteLine("*** Starting capture...");
                    StartSnipping();
                }));
            }

            base.WndProc(ref m);
        }

        public void StartSnipping()
        {
            ScreenSnipper snipper = new ScreenSnipper();
            if (snipper.Snip() == DialogResult.OK)
            {
                var img = snipper.CapturedImage;
                if (img != null)
                {                    
                    TesseractImage2Text.ExtractTextFromImage(img);
                }                
            } 
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Hide(); // hides the window immediately after it's shown
        }

        private void ShowHotkeyDialog()
        {
            using (var dialog = new HotkeyDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    hotkey?.Unregister(); // Unregister old hotkey
                    hotkey = new GlobalHotkey(dialog.SelectedModifiers, dialog.SelectedKey, this);
                    hotkey.Register();
                }
            }
        }
    }
}

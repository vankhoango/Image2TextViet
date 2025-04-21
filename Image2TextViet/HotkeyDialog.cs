using Image2TextViet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image2TextViet
{
    public partial class HotkeyDialog : Form
    {
        public Keys SelectedKey { get; private set; }
        public Modifiers SelectedModifiers { get; private set; }

        private ComboBox keyBox;
        private CheckBox ctrlBox, altBox, shiftBox;
        private Button okButton;

        public HotkeyDialog()
        {
            this.Text = "Đổi phím tắt";
            this.Width = 300;
            this.Height = 200;
            this.Padding = new Padding(10);
            this.FormBorderStyle = FormBorderStyle.FixedDialog; 
            this.MaximizeBox = false;                           
            this.MinimizeBox = false;

            // Panel container to control layout and spacing
            var panel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 5,
                ColumnCount = 1,
                AutoSize = true,
            };
            panel.RowStyles.Clear();
            for (int i = 0; i < 5; i++)
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            ctrlBox = new CheckBox { Text = "Ctrl", AutoSize = true };
            altBox = new CheckBox { Text = "Alt", AutoSize = true };
            shiftBox = new CheckBox { Text = "Shift", AutoSize = true };

            keyBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Top
            };
            keyBox.Items.AddRange(Enum.GetNames(typeof(Keys)));

            okButton = new Button
            {
                Text = "OK",
                Dock = DockStyle.Bottom,
                Height = 30
            };
            okButton.Click += (s, e) =>
            {
                SelectedModifiers = 0;
                if (ctrlBox.Checked) SelectedModifiers |= Modifiers.Control;
                if (altBox.Checked) SelectedModifiers |= Modifiers.Alt;
                if (shiftBox.Checked) SelectedModifiers |= Modifiers.Shift;

                if (keyBox.SelectedItem != null)
                    SelectedKey = (Keys)Enum.Parse(typeof(Keys), keyBox.SelectedItem.ToString());

                HotkeyHelper.SaveHotkey(SelectedKey,
                                        ctrl: ctrlBox.Checked,
                                        shift: shiftBox.Checked,
                                        alt: altBox.Checked);

                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            // Load current hotkey
            HotkeyHelper.LoadHotkey();

            // Set UI to reflect saved hotkey
            ctrlBox.Checked = HotkeyHelper.Ctrl;
            altBox.Checked = HotkeyHelper.Alt;
            shiftBox.Checked = HotkeyHelper.Shift;
            keyBox.SelectedItem = HotkeyHelper.Hotkey.ToString();

            // Add controls to panel in proper order
            panel.Controls.Add(ctrlBox);
            panel.Controls.Add(altBox);
            panel.Controls.Add(shiftBox);
            panel.Controls.Add(keyBox);
            panel.Controls.Add(okButton);

            this.Controls.Add(panel);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HotkeyDialog
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "HotkeyDialog";
            this.ResumeLayout(false);

        }
    }

}

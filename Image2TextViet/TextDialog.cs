/******************************************************************************
 * File:        TextDialog.cs
 * Project:     Image2TextViet
 * Author:      Khoa Ngo
 * Created:     2025-04-21
 *
 * License:     MIT
 ******************************************************************************/

namespace Image2TextViet
{
    public partial class TextDialog : Form
    {
        public TextDialog()
        {
            InitializeComponent();         
        }

        private void buttonCopyClose_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox.Text);
            this.Close();
        }
    }
}

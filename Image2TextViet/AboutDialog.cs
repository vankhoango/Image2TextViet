/******************************************************************************
 * File:        AboutDialog.cs
 * Project:     Image2TextViet
 * Author:      Khoa Ngo
 * Created:     2025-04-21
 *
 * License:     MIT
 ******************************************************************************/

using System.Diagnostics;
using System.Reflection;

namespace Image2TextViet
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();            
            string version = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
            labelVersion.Text = "Version " + version;
        }

        private void AboutDialog_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string target = linkLabel.Text;
            if (!string.IsNullOrEmpty(target))
            {
                try
                {
                    System.Diagnostics.Process.Start(new ProcessStartInfo
                    {
                        FileName = target,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {                    
                }
            }
        }
    }
}

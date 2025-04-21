namespace Image2TextViet
{
    partial class TextDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextDialog));
            this.buttonCopyClose = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCopyClose
            // 
            this.buttonCopyClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonCopyClose.Location = new System.Drawing.Point(0, 462);
            this.buttonCopyClose.Name = "buttonCopyClose";
            this.buttonCopyClose.Size = new System.Drawing.Size(860, 32);
            this.buttonCopyClose.TabIndex = 1;
            this.buttonCopyClose.Text = "Copy và Đóng";
            this.buttonCopyClose.UseVisualStyleBackColor = true;
            this.buttonCopyClose.Click += new System.EventHandler(this.buttonCopyClose_Click);
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox.Location = new System.Drawing.Point(0, 0);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(860, 462);
            this.textBox.TabIndex = 2;
            // 
            // TextDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 494);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.buttonCopyClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TextDialog";
            this.Text = "Image2Text Viet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void setContent(String text)
        {
            textBox.Text = text;
        }

        #endregion

        private TextBox textBox;
        private Button buttonCopyClose;
    }
}
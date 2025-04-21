/******************************************************************************
 * File:        ScreenSnipper.cs
 * Project:     Image2TextViet
 * Author:      Khoa Ngo
 * Created:     2025-04-21
 *
 * License:     MIT
 ******************************************************************************/

namespace Image2TextViet
{
    public class ScreenSnipper : Form, IDisposable
    {
        private Point _startPoint;
        private Rectangle _selection;
        private bool _selecting;
        private Bitmap _screenshot;
        public Bitmap CapturedImage { get; private set; }

        public ScreenSnipper()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;
            this.TopMost = true;
            this.Cursor = Cursors.Cross;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) this.Close();
            };

            _screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(_screenshot))
            {
                g.CopyFromScreen(Point.Empty, Point.Empty, _screenshot.Size);
            }

            this.MouseDown += OnMouseDown;
            this.MouseMove += OnMouseMove;
            this.MouseUp += OnMouseUp;
            this.Paint += OnPaint;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            _startPoint = e.Location;
            _selecting = true;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_selecting)
            {
                _selection = new Rectangle(
                    Math.Min(_startPoint.X, e.X),
                    Math.Min(_startPoint.Y, e.Y),
                    Math.Abs(_startPoint.X - e.X),
                    Math.Abs(_startPoint.Y - e.Y)
                );
                this.Invalidate();
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            _selecting = false;
            if (_selection.Width > 0 && _selection.Height > 0)
            {
                CapturedImage = new Bitmap(_selection.Width, _selection.Height);
                using (Graphics g = Graphics.FromImage(CapturedImage))
                {
                    g.DrawImage(_screenshot, 0, 0, _selection, GraphicsUnit.Pixel);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(_screenshot, Point.Empty);

            using (Brush overlayBrush = new SolidBrush(Color.FromArgb(120, 0, 0, 0)))
            {
                e.Graphics.FillRectangle(overlayBrush, this.ClientRectangle);
            }

            if (_selecting)
            {
                e.Graphics.DrawImage(_screenshot, _selection, _selection, GraphicsUnit.Pixel);

                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, _selection);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _screenshot?.Dispose();
                CapturedImage?.Dispose();
            }

            base.Dispose(disposing);
        }

        public DialogResult Snip()
        {
            this.ShowDialog();
            return this.DialogResult;
        }
    }
}

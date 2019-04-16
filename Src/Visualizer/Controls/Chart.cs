using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Visualizer.Controls
{
    public partial class Chart : UserControl
    {
        Queue<float> values = new Queue<float>();

        protected Timer RefreshTimer { get; }

        public Chart()
        {
            InitializeComponent();
            RefreshTimer = new Timer();
            RefreshTimer.Tick += (s, e) => Invalidate();
            RefreshTimer.Interval = 100;
            RefreshTimer.Enabled = true;

            DoubleBuffered = true;

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                AddValue(10f);
                AddValue(15f);
                AddValue(50f);
                AddValue(40f);
                AddValue(13f);
                AddValue(9f);
            }
        }

        public void AddValue(double value) => AddValue((float)value);

        public void AddValue(float value)
        {
            values.Enqueue(value);

            if (values.Count > Width / 2)
                values.Dequeue();
        }

        public void Reset() => values.Clear();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(BackColor);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            DrawValues(e.Graphics);
        }

        private void DrawValues(Graphics graphics)
        {
            if (values.Count < 2)
                return;

            const float topMarginPercent = 0.1f;

            var current = values.ToArray();

            var max = current.Max();
            var hMul = (1f - topMarginPercent) * ClientSize.Height / max;
            var xAdd = 1f * Width / (values.Count - 1);

            var invert = ClientSize.Height;

            using (var pen = new Pen(ForeColor))
            {
                for (int i = 1; i < values.Count; i++)
                {
                    graphics.DrawLine(pen,
                                      (i - 1) * xAdd,
                                      invert - current[i - 1] * hMul,
                                      i * xAdd,
                                      invert - current[i] * hMul);
                }
            }

            using (var br = new SolidBrush(Color.FromArgb(192, BackColor)))
            {
                var size = graphics.MeasureString("MMM: 0.00", Font);
                graphics.FillRectangle(br, new RectangleF(0, 0, size.Width, size.Height * 3));
            }

            graphics.DrawString(String.Format("Min: {0:0.00}", values.Min()), Font, Brushes.OrangeRed, new PointF(0, 0));
            graphics.DrawString(String.Format("Avg: {0:0.00}", values.Average()), Font, Brushes.OrangeRed, new PointF(0, Font.Height));
            graphics.DrawString(String.Format("Max: {0:0.00}", values.Max()), Font, Brushes.OrangeRed, new PointF(0, Font.Height * 2));
        }
    }
}

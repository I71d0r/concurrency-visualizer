﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WorkplaceEngine.Contract;
using WorkplaceEngine.Execution;

namespace Visualizer.Controls
{
    public partial class WorkProgressControl : UserControl
    {
        readonly Color[] colors;
        Snapshot snapshot;

        const int threadSpacing = 80;

        public WorkProgressControl()
        {
            InitializeComponent();
            DoubleBuffered = true;

            var cc = new ColorConverter();
            var parse = new Func<string, Color>((c) => (Color)cc.ConvertFromString(c));

            colors = new Color[]
            {
                parse("#e6194b"), parse("#3cb44b"), parse("#ffe119"), parse("#4363d8"), parse("#f58231"),
                parse("#911eb4"), parse("#46f0f0"), parse("#f032e6"), parse("#bcf60c"), parse("#fabebe"),
                parse("#008080"), parse("#e6beff"), parse("#9a6324"), parse("#fffac8"), parse("#800000"),
                parse("#aaffc3"), parse("#808000"), parse("#ffd8b1"), parse("#000075"), parse("#808080"),
                parse("#000000")
            };
        }

        /// <summary>
        /// Updates the displayed data with a new set
        /// </summary>
        /// <param name="snapshot">Work state snapshot</param>
        public void SetData(Snapshot snapshot)
        {
            this.snapshot = snapshot;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(Color.FromArgb(64, 64, 64));

            if (snapshot == null)
                return;

            var theadColors = GetThreadColors(snapshot.Threads);

            DrawWorkItems(e.Graphics, theadColors);
            DrawThreads(e.Graphics, theadColors);
        }

        private Dictionary<int, Color> GetThreadColors(ThreadInfo[] threads)
        {
            var colors = new Dictionary<int, Color>();

            foreach (var ti in threads)
            {
                if (!colors.ContainsKey(ti.ThreadId))
                {
                    colors[ti.ThreadId] = GetColor(ti.ThreadId);
                }
            }

            return colors;
        }

        private void DrawWorkItems(Graphics graphics, Dictionary<int, Color> threadColors)
        {
            var xMax = Width - threadSpacing;
            var wuX = 0.25 * xMax / snapshot.State.Max(i => i.Total); // 4 largest items on the row
            var xLeft = xMax;
            var x = 0f;
            var y = 0f;

            var itemHeight = Math.Min(16f, 1f * ClientSize.Height / GetRowCountItems());

            foreach (var item in snapshot.State)
            {
                if (Math.Round(xLeft / wuX) < item.Total)
                {
                    x = 0;
                    xLeft = xMax;
                    y += itemHeight;
                }

                var xp = (int)(item.Total * wuX);

                var progressColors = item.WorkThreadIds.Select(tid => threadColors[tid]).ToArray();

                DrawWorkItem(graphics,
                             x,
                             y,
                             xp,
                             itemHeight,
                             Color.LightGray,
                             progressColors,
                             Math.Min(1f, 1f * item.Progess / item.Total));

                x += xp;
                xLeft -= xp;
            }
        }

        private int GetRowCountItems()
        {
            var xMax = Width - threadSpacing;
            var wuX = 0.25 * xMax / snapshot.State.Max(i => i.Total); // 4 largest items on the row
            var xLeft = xMax;
            var x = 0;
            var rowCount = 1;

            foreach (var item in snapshot.State)
            {
                if (Math.Round(xLeft / wuX) < item.Total)
                {
                    x = 0;
                    xLeft = xMax;
                    rowCount++;
                }

                var xp = (int)(item.Total * wuX);

                x += xp;
                xLeft -= xp;
            }

            return rowCount;
        }

        private void DrawThreads(Graphics graphics, Dictionary<int, Color> theadColors)
        {
            const int itemHeight = 20;
            var x = Width - threadSpacing + 10;
            var y = 20;

            graphics.DrawString("Thread", Font, Brushes.WhiteSmoke, x, 3);

            var activeThreads = new HashSet<int>(snapshot.Threads.Where(t => t.ActivelyUsed).Select(t => t.ThreadId));

            using (var passivePen = new Pen(Color.Brown, 2f))
            {
                using (var activePen = new Pen(Color.LightGreen, 2f))
                {
                    foreach (var kvp in theadColors)
                    {
                        using (var brush = new SolidBrush(kvp.Value))
                        {
                            graphics.FillRectangle(brush, x + 5, y, 10, 10);
                            graphics.DrawRectangle(activeThreads.Contains(kvp.Key) ? activePen : passivePen, x + 5, y, 10, 10);
                            graphics.DrawString(kvp.Key.ToString(), Font, Brushes.WhiteSmoke, x + 20, y - 2);

                            y += itemHeight;
                        }
                    }
                }
            }
        }

        private void DrawWorkItem(Graphics graphics,
                                  float x,
                                  float y,
                                  float width,
                                  float height,
                                  Color fillColor,
                                  Color[] progessColors,
                                  float progress)
        {
            var pr = 1f * progress * width;

            if (progessColors.Length > 0)
            {
                var cc = 1f * pr / progessColors.Length;

                for (int i = 0; i < progessColors.Length; i++)
                {
                    using (var brush = new SolidBrush(progessColors[i]))
                    {
                        graphics.FillRectangle(brush, new RectangleF(x + i * cc + 1, y, cc, height));
                    }
                }
            }

            using (var brush = new SolidBrush(fillColor))
            {
                graphics.FillRectangle(brush, new RectangleF(x + pr + 1, y, width - pr, height));
            }

            graphics.DrawRectangles(Pens.Black, new RectangleF[] { new RectangleF(x, y, width, height) });
        }

        private Color GetColor(int index) => colors[index % colors.Length];
    }
}

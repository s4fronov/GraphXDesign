using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    public abstract class IBrush
    {
        public int BrushSize { get; set; }
        public Color BrushColor { get; set; }

        abstract public void DrawDot(Bitmap bmp, int x, int y);
        abstract public void DrawLine(Bitmap bmp, int x1, int y1, int x2, int y2, bool drawFirstDot = false);
        public void SetPixel(Bitmap bmp, int x, int y, Color color)
        {
            if (x >= 0 && x < bmp.Width)
                if (y >= 0 && y < bmp.Height)
                    bmp.SetPixel(x, y, color);
        }
    }
}

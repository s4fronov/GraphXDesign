using System;
using System.Drawing;

namespace GraphXDesign
{
    public abstract class IBrush:ICloneable
    {
        public int BrushSize { get; set; }
        public Color BrushColor { get; set; }

        abstract public void DrawDot(BitmapWrap bmp, int x, int y);
        abstract public void DrawLine(BitmapWrap bmp, int x1, int y1, int x2, int y2, bool drawFirstDot = false);
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

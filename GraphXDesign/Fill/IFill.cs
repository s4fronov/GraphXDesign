using System;
using System.Drawing;

namespace GraphXDesign
{
    public abstract class IFill:ICloneable
    {
        public IFill (IFill fill)
        {
            this.FillColor = fill.FillColor;
        }
        public IFill(Color color)
        {
            this.FillColor = color;
        }
        public IFill() { }

        public Color FillColor { get; set; }
        public abstract void Fill(BitmapWrap bmp, Point point);
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    public class BitmapWrap:ICloneable
    {
        public Bitmap Bmp { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public BitmapWrap() { }
        public BitmapWrap(int width, int height)
        {
            Bmp = new Bitmap(width, height);
            Width = width;
            Height = height;
        }

        public Color GetPixel(int x, int y)
        {
            if (x >= 0 && x < Bmp.Width)
                if (y >= 0 && y < Bmp.Height)
                    return Bmp.GetPixel(x, y);
            return Color.Transparent;
        }

        public void SetPixel(int x, int y, Color color)
        {
            if (x >= 0 && x < Bmp.Width)
                if (y >= 0 && y < Bmp.Height)
                    Bmp.SetPixel(x, y, color);
        }

        public object Clone()
        {
            BitmapWrap bitmapWrap = new BitmapWrap();
            bitmapWrap.Bmp = (Bitmap)Bmp.Clone();
            return bitmapWrap;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    public class Dot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public Color Colour { get; set; }

        public Dot(int x, int y, int size, Color colour)
        {
            X = x;
            Y = y;
            Size = size;
            Colour = colour;
        }

        public void Draw(Bitmap bmp, IBrush brush)
        {
            brush.Draw(bmp, X, Y, Size, Colour);
        }
    }
}

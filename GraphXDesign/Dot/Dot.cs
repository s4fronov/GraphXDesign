using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    abstract class Dot
    {
        int X { get; set; }
        int Y { get; set; }
        int Size { get; set; }
        Color Colour { get; set; }

        public Dot(int x, int y, int size, Color colour)
        {
            X = x;
            Y = y;
            Size = size;
            Colour = colour;
        }

        abstract public void Draw(Bitmap bmp);
    }
}

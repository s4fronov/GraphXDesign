using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    public class Line
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public int Size { get; set; }
        public Color Colour { get; set; }

        public Line(int x1, int y1, int x2, int y2, int size, Color colour)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            Size = size;
            Colour = colour;
        }

        //пока не соединяет точки, просто прорисовывает обе
        public void Draw(Bitmap bmp, IBrush brush)
        {
            Dot A = new Dot(X1, Y1, Size, Colour);
            Dot B = new Dot(X2, Y2, Size, Colour);
            A.Draw(bmp, brush);
            B.Draw(bmp, brush);
        }
    }
}

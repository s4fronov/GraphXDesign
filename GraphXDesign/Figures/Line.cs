using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    public class Line:IFigure
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public IBrush Brush { get; set; }


        public Line(int x1, int y1, int x2, int y2, IBrush brush)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            Brush = brush;
        }

        public void Draw()
        {
            Brush.DrawLine(X1, Y1, X2, Y2);
            Brush.DrawDot(X2, Y2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    public class Square : IFigure
    {
        public int X1 { get; set ; }
        public int Y1 { get ; set ; }
        public int X2 { get ; set ; }
        public int Y2 { get ; set ; }
        public int Xl { get; set; }
        public int Yl { get; set; }
        public int Xr { get; set; }
        public int Yr { get; set; }
        public int Xd { get; set; }
        public int Yd { get; set; }
        public IBrush Brush { get ; set ; }

        public Square(int x1, int y1, int x2, int y2, IBrush brush)
        {
            if (x2 > x1)
            {
                X1 = x1;
                Y1 = y1;
                X2 = x2;
                Y2 = y2;
                Xd = x1+ Math.Abs(y1 - y2);
                Yd = y2;
                Xl = x1;
                Yl = y2;
                Xr = x1+Math.Abs(y1 - y2);
                Yr = y1;
            }
            else
            {
                X1 = x1;
                Y1 = y1;
                X2 = x2;
                Y2 = y2;
                Xd = x1-Math.Abs(y1 - y2);
                Yd = y2;
                Xl = x1 - Math.Abs(y1 - y2);
                Yl = y1;
                Xr = x1;
                Yr = y2;
            }
            Brush = brush;
        }
        public void DrawSquare(int x1, int y1, int x2, int y2)
        {
            Brush.DrawLine(X1, Y1, Xl, Yl, true);
            Brush.DrawLine(Xl, Yl, Xd, Yd);
            Brush.DrawLine(Xd, Yd, Xr, Yr);
            Brush.DrawLine(Xr, Yr, X1, Y1);
        }
        public void Draw()
        {
            DrawSquare(X1, Y1, Xl, Yl);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    public class Rectangle : IFigure
    {
        public int X1 { get; set ; }
        public int Y1 { get ; set ; }
        public int X2 { get ; set ; }
        public int Y2 { get ; set ; }
        public int Xl { get; set; }
        public int Yl { get; set; }
        public int Xr { get; set; }
        public int Yr { get; set; }
        public IBrush Brush { get ; set ; }

        public Rectangle(int x1, int y1, int x2, int y2, IBrush brush)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            Xl = x1;
            Yl = y2;
            Xr = x2;
            Yr = y1;
            Brush = brush;
        }
        public void DrawRectangle(Bitmap bmp, int x1, int y1, int x2, int y2)
        {
            Brush.DrawLine(bmp, X1, Y1, Xl, Yl);
            Brush.DrawLine(bmp, X1, Y1, Xr, Yr);
            Brush.DrawLine(bmp, X2, Y2, Xl, Yl);
            Brush.DrawLine(bmp, X2, Y2, Xr, Yr);
        }
        public void Draw(Bitmap bmp)
        {
            DrawRectangle(bmp, X1, Y1, Xl, Yl);
        }
    }
}

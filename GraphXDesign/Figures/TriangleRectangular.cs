using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    class TriangleRectangular:IFigure
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public int Xl { get; set; }
        public int Yl { get; set; }
        

        public IBrush Brush { get; set; }


        public TriangleRectangular(int x1, int y1, int x2, int y2, IBrush brush)
        {

            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            Xl = x1;
            Yl = y2;
            
           
            Brush = brush;
        }



        public void DrawTriangleRectangular(Canvas canvas, int x1, int y1, int x2, int y2)
        {

            Brush.DrawLine(canvas, X1, Y1, X2, Y2, true);
            Brush.DrawLine(canvas, X2, Y2, Xl, Yl);
            Brush.DrawLine(canvas, Xl, Yl, X1, Y1);
        }


        public void Draw(Canvas canvas)
        {
            DrawTriangleRectangular(canvas, X1, Y1, X2, Y2);
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace GraphXDesign
{
    class Trianglesamesizes:IFigure
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public int Xl { get; set; }
        public int Yl { get; set; }
        public IBrush Brush { get; set; }


        public Trianglesamesizes(int x1, int y1, int x2, int y2, IBrush brush)
        {
            if (x2 >= x1)
            {

                X1 = x1;
                Y1 = y1;
                X2 = x2;
                Y2 = y2;
                            
                Xl = x2- 2*Math.Abs(x2-x1);
                Yl = y2;
                Brush = brush; 
               
            }
            else
            {
                X1 = x1;
                Y1 = y1;
                X2 = x2;
                Y2 = y2;

                Xl = x2 + 2 * Math.Abs(x2 - x1);
                Yl = y2;
                Brush = brush;
            }

        }
        

        public void DrawTrianglesamesizes(Canvas canvas, int x1, int y1, int x2, int y2)
        {
            if (x2 >= x1)
            {

                Brush.DrawLine(canvas, X1, Y1, X2, Y2);
                Brush.DrawLine(canvas, X1, Y1, Xl, Yl);
                Brush.DrawLine(canvas, Xl, Yl, X2, Y2);
            }
            else
            {
                Brush.DrawLine(canvas, X1, Y1, X2, Y2);
                Brush.DrawLine(canvas, X1, Y1, Xl, Yl);
                Brush.DrawLine(canvas, Xl, Yl, X2, Y2);
            }

        }
        
        public void Draw(Canvas canvas)
            {
                DrawTrianglesamesizes(canvas, X1, Y1, X2, Y2);
            }
        
    }
}

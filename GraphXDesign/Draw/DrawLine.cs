using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    class Drawline
    {
        public Point begin;
        public Point end;
        public IBrush brush;
        public bool drawFirstDot;

        public Drawline(int x1, int y1, int x2, int y2, IBrush brush, bool drawFirstDot)
        {
            begin.X = x1;
            begin.Y = y1;
            end.X = x2;
            end.Y = y2;
            this.brush = brush;
            this.drawFirstDot = drawFirstDot;
        }

        public void Draw(AbstractCanvas canvas)
        {
            canvas.Bmp.Lock();

            brush.DrawLine(canvas.Bmp, begin.X, begin.Y, end.X, end.Y, drawFirstDot);

            canvas.Bmp.Unlock();
        }
    }
}

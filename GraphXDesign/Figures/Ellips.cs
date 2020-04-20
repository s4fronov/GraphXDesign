using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    public class Ellips : IFigure
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        int xd;
        int yd;
        public IBrush Brush { get; set; }

        public Ellips(int x1, int y1, int x2, int y2, IBrush brush)
        {

            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;

            Brush = brush;
        }

        public void DrawEllips(int x1, int y1, int x2, int y2)
        {
            List<Tuple<int, int>> dotList = new List<Tuple<int, int>>();
            int n = 360;
            int delx;
            int dely;
            if (x2 >= x1)
            {
                delx = Math.Abs(x1 - x2);
                dely = Math.Abs(y1 - y2);
            }
            else
            {
                delx = Math.Abs(x2 - x1);
                dely = Math.Abs(y2 - y1);
            }
            double r = Math.Sqrt(Math.Pow(delx, 2) + Math.Pow(dely, 2));
            for (int i = 1; i <= n + 1; i++)
            {
                double angle = Math.PI * 2 / n * i;
                    //xd = Convert.ToInt32(Math.Cos(angle) * delx - Math.Sin(angle) * dely + x1); // круг
                    //yd = Convert.ToInt32(Math.Cos(angle) * dely + Math.Sin(angle) * delx + y1);
                    xd = Convert.ToInt32((delx * Math.Cos(angle) + x1)); // эллипс
                    yd = Convert.ToInt32((dely * Math.Sin(angle) + y1));
                
                dotList.Add(new Tuple<int, int>(xd, yd));
            }
            for (int i = 1; i < dotList.Count; i++)
            {
                Brush.DrawLine(dotList[i - 1].Item1, dotList[i - 1].Item2, dotList[i].Item1, dotList[i].Item2);
            }
        }

        public void Draw()
        {
            DrawEllips(X1, Y1, X2, Y2);
        }
    }
}

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
        public override void Createdotlist(int x1, int y1, int x2, int y2)
        {
            dotlist = new List<Point>(); 
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
            for (int i = 1; i <= 50; i++)
            {
                double angle = Math.PI * 2 / 50 * i;
                   int xd = Convert.ToInt32((delx * Math.Cos(angle) + x1)); // эллипс
                   int yd = Convert.ToInt32((dely * Math.Sin(angle) + y1));
                dotlist.Add(new Point(xd, yd));
            }
        }
    }
}

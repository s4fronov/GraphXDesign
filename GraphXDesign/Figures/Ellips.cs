using System;
using System.Collections.Generic;
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
        protected override void CreateCorners(int x1, int y1, int x2, int y2)
        {
            int leftX, rightX;
            int topY, bottomY;
            if (x1 < x2)
            {
                leftX = x1 - (x2 - x1);
                rightX = x2;
            }
            else
            {
                leftX = x2;
                rightX = x1 + (x1 - x2);
            }
            if (y1 < y2)
            {
                topY = y1 - (y2 - y1);
                bottomY = y2;
            }
            else
            {
                topY = y2;
                bottomY = y1 + (y1 - y1);
            }
            cornerTopLeft = new Point(leftX, topY);
            cornerBottomRight = new Point(rightX, bottomY);
        }
    }
}

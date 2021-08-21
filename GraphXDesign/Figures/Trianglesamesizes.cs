using System;
using System.Collections.Generic;
using System.Drawing;


namespace GraphXDesign
{
    public class Trianglesamesizes:IFigure
    {
        public override void Createdotlist(int x1, int y1, int x2, int y2)
        {
            dotlist = new List<Point>();
            dotlist.Add(new Point(x1, y1));
            dotlist.Add(new Point(x2, y2));
            if (x2 >= x1)
            {
                dotlist.Add(new Point(x2 - 2 * Math.Abs(x2 - x1), y2));
            }
            else
            {
                dotlist.Add(new Point(x2 + 2 * Math.Abs(x2 - x1), y2));
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
                topY = y1;
                bottomY = y2;
            }
            else
            {
                topY = y2;
                bottomY = y1;
            }
            cornerTopLeft = new Point(leftX, topY);
            cornerBottomRight = new Point(rightX, bottomY);
            cornerBottomLeft = new Point(leftX, bottomY);
            cornerTopRight = new Point(rightX, topY);
        }
    }
}

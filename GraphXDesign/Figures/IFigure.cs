using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
   public abstract class IFigure
    {
        public List <Point> dotlist;
        public Point center;
        public Point cornerTopLeft;
        public Point cornerBottomRight;
        public void Create(int x1, int y1, int x2, int y2)
        {
            Createdotlist(x1, y1, x2, y2);
            CreateCorners(x1, y1, x2, y2);
            CreateCenter();
        }
        public abstract void Createdotlist(int x1, int y1, int x2, int y2);
        protected virtual void CreateCorners(int x1, int y1, int x2, int y2)
        {
            int leftX, rightX;
            int topY, bottomY;
            if (x1 < x2)
            {
                leftX = x1;
                rightX = x2;
            }
            else
            {
                leftX = x2;
                rightX = x1;
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
        }
        protected virtual void CreateCenter()
        {
            center = new Point();
            center.X = (cornerTopLeft.X + cornerBottomRight.X) / 2;
            center.Y = (cornerTopLeft.Y + cornerBottomRight.Y) / 2;
        }
    }
}

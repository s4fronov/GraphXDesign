using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
   public abstract class IFigure:ICloneable
    {
        public List <Point> dotlist;
        public Point center;
        public Point cornerTopLeft;
        public Point cornerBottomRight;
        public void Create(int x1, int y1, int x2, int y2)
        {
            dotlist = new List<Point>();
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

        public bool IsInside(Point point)
        {
            /*if (cornerTopLeft.X <= point.X && point.X <= cornerBottomRight.X &&
                cornerTopLeft.Y <= point.Y && point.Y <= cornerBottomRight.Y)
                return true;*/

            int intersectCount = 0;
            for (int i = 0; i < dotlist.Count; i++)
            {
                int i1 = i;
                int i2 = (i < dotlist.Count - 1) ? (i + 1) : 0;
                if (LineSegmentAndHorizontalRayIntersect(dotlist[i1], dotlist[i2], point))
                    intersectCount++;
            }

            if (intersectCount % 2 == 1)
                return true;
            else
                return false;

            //local function
            bool LineSegmentAndHorizontalRayIntersect(Point lineStart, Point lineEnd, Point rayStart)
            {
                //горизонтальная линия
                if (lineStart.Y == lineEnd.Y)
                {
                    if (lineStart.Y == rayStart.Y)
                        return true;
                    return false;
                }

                double x;
                double y = (double)rayStart.Y;
                double y1 = (double)lineStart.Y;
                double y2 = (double)lineEnd.Y;
                double x1 = (double)lineStart.X;
                double x2 = (double)lineEnd.X;

                if (lineStart.Y < lineEnd.Y && lineStart.Y < rayStart.Y && rayStart.Y <= lineEnd.Y ||
                    lineStart.Y > lineEnd.Y && lineStart.Y > rayStart.Y && rayStart.Y >= lineEnd.Y)
                {
                    //х пересечения луча с отрезком
                    x = (y - y1) / (y2 - y1) * (x2 - x1) + x1;
                    if (x > rayStart.X)
                        return true;
                    else
                        return false;
                }

                return false;
            }
        }

        public void MoveFigure(int dx, int dy)
        {
            for(int i = 0; i < dotlist.Count; i++)
            {
                dotlist[i] = new Point(dotlist[i].X + dx, dotlist[i].Y + dy);
            }
            center = new Point(center.X + dx, center.Y + dy);
            cornerTopLeft = new Point(cornerTopLeft.X + dx, cornerTopLeft.Y + dy);
            cornerBottomRight = new Point(cornerBottomRight.X + dx, cornerBottomRight.Y + dy);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    public abstract class IFigure : ICloneable
    {
        public List<Point> dotlist;
        public Point center;
        public Point cornerTopLeft;
        public Point cornerBottomRight;
        public Point cornerBottomLeft;
        public Point cornerTopRight;
        public Point farthestpoint;
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
            cornerBottomLeft = new Point(leftX, bottomY);
            cornerTopRight = new Point(rightX, topY);
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
            for (int i = 0; i < dotlist.Count; i++)
            {
                dotlist[i] = new Point(dotlist[i].X + dx, dotlist[i].Y + dy);
            }
            center = new Point(center.X + dx, center.Y + dy);
        }

        public void ChangeSizeFigure(int dx, int dy)
        {
           // double k = 0;
            double  leftX = cornerTopLeft.X;
            double rightX = cornerBottomRight.X;
            double topY = cornerTopLeft.Y;
            double bottomY = cornerBottomRight.Y;

            for (int i = 0; i < dotlist.Count; i++)
            {
                
                 dotlist[i] = new Point((int)(dotlist[i].X + dx * (dotlist[i].X - leftX) / (rightX - leftX)),(int)( dotlist[i].Y + dy * (dotlist[i].Y - topY) / (bottomY - topY)));
            }
                     
               cornerBottomRight.X += dx;
               cornerBottomRight.Y += dy;
               cornerBottomLeft.Y += dy;
               cornerTopRight.X += dx;

        }
        //{
        //    int index = -1;
        //    Point location = new Point();
        //    location.X = x;
        //    location.Y = y;

        //    for (int i = dotlist.Count; i < index; i--)

        //    {
        //        dotlist[i] = new Point(dotlist[i].X + dx, dotlist[i].Y + dy);
        //    }

        //    for (int i = 0; i < index; i++)

        //    {
        //        dotlist[i] = new Point(dotlist[i].X + dx, dotlist[i].Y + dy);
        //    }
        //    center = new Point(center.X + dx, center.Y + dy);
        //    cornerTopLeft = new Point(cornerTopLeft.X + dx, cornerTopLeft.Y + dy);
        //    cornerBottomRight = new Point(cornerBottomRight.X + dx, cornerBottomRight.Y + dy);

        //}

        public int Findfarthestpoint(int x, int y)

        {
            int index = 0;
            double lenghtmax = 0;
            Point farthestpoint = new Point();
            Point location = new Point();
            location.X = x;
            location.Y = y;
            farthestpoint = dotlist[0];
            lenghtmax = Math.Sqrt((x - dotlist[0].X) * (x - dotlist[0].X) + (y - dotlist[0].Y) * (y - dotlist[0].Y));
            for (int i = 0; i < dotlist.Count; i++)
            {
                int lenght = (int)(Math.Sqrt((x - dotlist[i].X) * (x - dotlist[i].X) + (y - dotlist[i].Y) * (y - dotlist[i].Y)));
                if (lenght > lenghtmax)
                {
                    lenghtmax = lenght;
                    farthestpoint = new Point(dotlist[i].X, dotlist[i].X);
                    index = i;
                }
            }
            return index;


        }

        public object Clone()
        {
            return MemberwiseClone();
        }
        public void Turn()
        {
            double angle = (45 * Math.PI) / 180;
            for (int i = 0; i < dotlist.Count; i++)
            {
                Point result = new Point();
                result.X = (int)(Math.Round(Math.Cos(angle) * (dotlist[i].X - center.X) - Math.Sin(angle) * (dotlist[i].Y - center.Y) + center.X));
                result.Y = (int)(Math.Round(Math.Sin(angle) * (dotlist[i].X - center.X) + Math.Cos(angle) * (dotlist[i].Y - center.Y) + center.Y));
                dotlist[i] = result;
            }
        }

        public void ChangeCorners()

        {
            int leftX, rightX;
            int topY, bottomY;
            bottomY = dotlist[0].Y; // максимальное
            rightX = dotlist[0].X;  // максимальное
            leftX = dotlist[0].X;// минимальное
            topY = dotlist[0].Y;// минимальное
            for (int i = 1; i < dotlist.Count; i++)

            {
                if (bottomY < dotlist[i].Y)
                {
                    bottomY = dotlist[i].Y;
                }
                if (rightX < dotlist[i].X)
                {
                    rightX = dotlist[i].X;
                }

                if (topY > dotlist[i].Y)
                {
                    topY = dotlist[i].Y;
                }
                if (leftX > dotlist[i].X)
                {
                    leftX = dotlist[i].X;
                }
                               
            }
            cornerTopLeft = new Point(leftX, topY);
            cornerBottomRight = new Point(rightX, bottomY);
            cornerBottomLeft = new Point(leftX, bottomY);
            cornerTopRight = new Point(rightX, topY);
        }
    }
}

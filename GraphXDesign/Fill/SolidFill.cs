using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    class SolidFill:IFill
    {
        public Color FillColor { get; set; }
        public void Fill(Bitmap bmp, Point startingPoint)
        {
            Color startingColor = bmp.GetPixel(startingPoint.X, startingPoint.Y);
            if (startingColor.ToArgb() == FillColor.ToArgb())
                return;

            Point point = startingPoint;

            Queue<Point> pointsToCheck = new Queue<Point>();
            pointsToCheck.Enqueue(point);

            while (pointsToCheck.Count > 0)
            {
                point = new Point(pointsToCheck.Peek().X, pointsToCheck.Peek().Y);
                pointsToCheck.Dequeue();
                if (point.X > 0 && bmp.GetPixel(point.X - 1, point.Y).ToArgb() == startingColor.ToArgb())
                {
                    bmp.SetPixel(point.X - 1, point.Y, FillColor);
                    pointsToCheck.Enqueue(new Point(point.X - 1, point.Y));
                }
                if (point.X < bmp.Width - 1 && bmp.GetPixel(point.X + 1, point.Y).ToArgb() == startingColor.ToArgb())
                {
                    bmp.SetPixel(point.X + 1, point.Y, FillColor);
                    pointsToCheck.Enqueue(new Point(point.X + 1, point.Y));
                }
                if (point.Y > 0 && bmp.GetPixel(point.X, point.Y - 1).ToArgb() == startingColor.ToArgb())
                {
                    bmp.SetPixel(point.X, point.Y - 1, FillColor);
                    pointsToCheck.Enqueue(new Point(point.X, point.Y - 1));
                }
                if (point.Y < bmp.Height - 1 && bmp.GetPixel(point.X, point.Y + 1).ToArgb() == startingColor.ToArgb())
                {
                    bmp.SetPixel(point.X, point.Y + 1, FillColor);
                    pointsToCheck.Enqueue(new Point(point.X, point.Y + 1));
                }
            }
        }
    }
}

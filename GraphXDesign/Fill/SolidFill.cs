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
        public void Fill(Point startingPoint)
        {
            Color startingColor = Canvas.GetCanvas.GetPixel(startingPoint.X, startingPoint.Y);
            if (startingColor.ToArgb() == FillColor.ToArgb())
                return;

            Point point = startingPoint;

            Queue<Point> pointsToCheck = new Queue<Point>();
            pointsToCheck.Enqueue(point);

            while (pointsToCheck.Count > 0)
            {
                point = new Point(pointsToCheck.Peek().X, pointsToCheck.Peek().Y);
                pointsToCheck.Dequeue();
                if (startingPoint.X > 0 && Canvas.GetCanvas.GetPixel(point.X - 1, point.Y).ToArgb() == startingColor.ToArgb())
                {
                    Canvas.GetCanvas.SetPixel(point.X - 1, point.Y, FillColor);
                    pointsToCheck.Enqueue(new Point(point.X - 1, point.Y));
                }
                if (startingPoint.X < Canvas.GetCanvas.Width - 1 && Canvas.GetCanvas.GetPixel(point.X + 1, point.Y).ToArgb() == startingColor.ToArgb())
                {
                    Canvas.GetCanvas.SetPixel(point.X + 1, point.Y, FillColor);
                    pointsToCheck.Enqueue(new Point(point.X + 1, point.Y));
                }
                if (startingPoint.Y > 0 && Canvas.GetCanvas.GetPixel(point.X, point.Y - 1).ToArgb() == startingColor.ToArgb())
                {
                    Canvas.GetCanvas.SetPixel(point.X, point.Y - 1, FillColor);
                    pointsToCheck.Enqueue(new Point(point.X, point.Y - 1));
                }
                if (startingPoint.Y < Canvas.GetCanvas.Height - 1 && Canvas.GetCanvas.GetPixel(point.X, point.Y + 1).ToArgb() == startingColor.ToArgb())
                {
                    Canvas.GetCanvas.SetPixel(point.X, point.Y + 1, FillColor);
                    pointsToCheck.Enqueue(new Point(point.X, point.Y + 1));
                }
            }
        }
    }
}

using System.Collections.Generic;
using System.Drawing;

namespace GraphXDesign
{
    public class TriangleRectangular:IFigure
    {
        public override void Createdotlist(int x1, int y1, int x2, int y2)
        {
            dotlist = new List<Point>();
            dotlist.Add(new Point(x1, y1));
            dotlist.Add(new Point(x2, y2));
            dotlist.Add(new Point(x1, y2));
        }
        protected override void CreateCenter()
        {
            center = new Point();
            center.X = ((cornerTopLeft.X + cornerBottomRight.X) / 2 + dotlist[2].X) / 2;
            center.Y = ((cornerTopLeft.Y + cornerBottomRight.Y) / 2 + dotlist[2].Y) / 2;
        }
    }
}


using System.Collections.Generic;
using System.Drawing;

namespace GraphXDesign
{
    public class Line:IFigure
    {
        public override void Createdotlist(int x1, int y1, int x2, int y2)
        {
            dotlist = new List<Point>();
            dotlist.Add(new Point(x1, y1));
            dotlist.Add(new Point(x2, y2));
        }
    }
}

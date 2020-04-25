using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    public class Square : IFigure
    {
        public override void Createdotlist(int x1, int y1, int x2, int y2)
        {
            dotlist = new List<Point>();
            dotlist.Add(new Point(x1, y1));
            if (x2 > x1)
            {
                dotlist.Add(new Point(x1 + Math.Abs(y1 - y2), y1));                
                dotlist.Add(new Point(x1 + Math.Abs(y1 - y2), y2));
                dotlist.Add(new Point(x1, y2));
            }
            else
            {
                dotlist.Add(new Point(x1, y2));
                dotlist.Add(new Point(x1 - Math.Abs(y1 - y2), y2));
                dotlist.Add(new Point(x1 - Math.Abs(y1 - y2), y1));
            }
        }
    }
}

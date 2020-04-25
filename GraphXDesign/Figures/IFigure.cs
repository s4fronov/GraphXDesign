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
        public void Create(int x1, int y1, int x2, int y2)
        {
            Createdotlist(x1, y1, x2, y2);
            CreateCenter(x1, y1, x2, y2);
        }
        abstract public void Createdotlist(int x1, int y1, int x2, int y2);
        void CreateCenter(int x1, int y1, int x2, int y2)
        {
            center = new Point();
            center.X = (x1 + x2) / 2;
            center.Y = (y1 + y2) / 2;
        }
    }
}

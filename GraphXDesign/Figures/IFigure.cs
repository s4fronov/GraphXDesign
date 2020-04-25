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
        abstract public void Createdotlist(int x1, int y1, int x2, int y2);
    }
}

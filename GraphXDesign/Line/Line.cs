using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign.Line
{
    public class Line
    {
        public Dot A { get; set; }
        public Dot B { get; set; }

        public Line(Dot a, Dot b)
        {
            A = a;
            B = b;
        }

        //пока не соединяет точки, просто прорисовывает обе
        public void Draw(Bitmap bmp)
        {
            A.Draw(bmp);
            B.Draw(bmp);
        }
    }
}

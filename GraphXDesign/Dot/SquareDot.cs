using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    class SquareDot:Dot
    {
        public SquareDot(int x, int y, int size, Color colour) : base(x, y, size, colour) { }

        public override void Draw(Bitmap bmp)
        {
            throw new NotImplementedException();
        }
    }
}

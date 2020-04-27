using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    class NoFill:IFill
    {
        public NoFill(IFill fill) : base(fill) { }
        public NoFill(Color color) : base(color) { }

        public NoFill() { }

        public override void Fill(BitmapWrap bmp, Point point)
        {
            //ничего не делаем
            return;
        }
    }
}

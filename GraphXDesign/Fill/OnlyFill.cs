using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    class OnlyFill:SolidFill
    {
        public OnlyFill(IFill fill) : base(fill) { }
        public OnlyFill(Color color) : base(color) { }
    }
}

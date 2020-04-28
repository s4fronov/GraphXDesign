using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphXDesign
{
    public abstract class AbstractCanvas
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public BitmapWrap Bmp { get; set; }
        public BitmapWrap Cache { get; set; }
    }
}

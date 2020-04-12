using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{ 
    public interface IBrush
    {
        void Draw(Bitmap bmp, int x, int y, int size, Color color);
    }
}

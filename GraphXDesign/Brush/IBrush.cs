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
        int BrushSize { get; set; }
        Color BrushColor { get; set; }
        void DrawDot(Bitmap bmp, int x, int y);
        void DrawLine(Bitmap bmp, int x1, int y1, int x2, int y2);
    }
}

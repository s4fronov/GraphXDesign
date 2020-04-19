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
        void DrawDot(Canvas canvas, int x, int y);
        void DrawLine(Canvas canvas, int x1, int y1, int x2, int y2, bool drawFirstDot = true);
    }
}

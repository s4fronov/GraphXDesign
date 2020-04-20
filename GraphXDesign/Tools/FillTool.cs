using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphXDesign
{
    class FillTool:ITool
    {
        public void MouseDown(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e)
        {
            canvas.Fill(e.X, e.Y, brush.BrushColor);
            canvas.WriteToPictureBox(sheet);
        }
        public void MouseDoubleClick(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e)
        { }
        public void MouseMove(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e) { return;  }
        public void MouseUp(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e) { return; }
    }
}

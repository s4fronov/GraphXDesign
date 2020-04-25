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
        public void MouseDown(PictureBox sheet, IBrush brush, MouseEventArgs e)
        {
            Canvas.GetCanvas.Fill(e.X, e.Y, brush.BrushColor);
            Canvas.GetCanvas.WriteToPictureBox(sheet);
        }
        public void MouseDoubleClick(PictureBox sheet, IBrush brush, MouseEventArgs e)
        { }
        public void MouseMove(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e) { return;  }
        public void MouseUp(PictureBox sheet, IBrush brush, MouseEventArgs e) { return; }
    }
}

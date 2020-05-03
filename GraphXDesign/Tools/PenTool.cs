using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GraphXDesign
{
    public class PenTool:ITool
    {
        bool cursorActive { get; set; }
        int x1, y1, x2, y2;
        public PenTool() 
        {
            cursorActive = false;
        }
        public void MouseDown(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            cursorActive = true;
            x1 = e.X;
            y1 = e.Y;
            Drawline drawer = new Drawline(x1, y1, x1, y1, brush, true);
            drawer.Draw(Canvas.GetCanvas);
            Canvas.GetCanvas.WriteToPictureBox(sheet);
        }
        public void MouseMove(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            if (cursorActive == true)
            {
                x2 = e.X;
                y2 = e.Y;
                Drawline drawer = new Drawline(x1, y1, x2, y2, brush, false);
                drawer.Draw(Canvas.GetCanvas);
                x1 = x2;
                y1 = y2;
                Canvas.GetCanvas.WriteToPictureBox(sheet);
            }
        }
        public void MouseUp(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            cursorActive = false;
            x2 = e.X;
            y2 = e.Y;
        }
        public void MouseDoubleClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e) { }
        public void MouseClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e) { }
    }
}

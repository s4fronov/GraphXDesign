using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GraphXDesign
{
    public class LineTool: ITool
    {
        bool cursorActive;
        int x1, y1, x2, y2;

        public LineTool()
        {
            cursorActive = false;
        }

        public void MouseDown(PictureBox sheet, IBrush brush, MouseEventArgs e)
        {
            Canvas.GetCanvas.SaveToCache();
            cursorActive = true;
            x1 = e.X;
            y1 = e.Y;
            brush.DrawDot(x1, y1);
            Canvas.GetCanvas.WriteToPictureBox(sheet);
        }
        public void MouseMove(PictureBox sheet, IBrush brush, MouseEventArgs e)
        {
            if (cursorActive == true)
            {
                Canvas.GetCanvas.LoadFromCache();
                x2 = e.X;
                y2 = e.Y;
                brush.DrawLine(x1, y1, x2, y2, true);
                brush.DrawDot(x2, y2);
                Canvas.GetCanvas.WriteToPictureBox(sheet);
            }
        }
        public void MouseUp(PictureBox sheet, IBrush brush, MouseEventArgs e)
        {
            cursorActive = false;
            x2 = e.X;
            y2 = e.Y;
            Canvas.GetCanvas.WriteToPictureBox(sheet);
        }
        public void MouseDoubleClick(PictureBox sheet, IBrush brush, MouseEventArgs e)
        { }
    }
}

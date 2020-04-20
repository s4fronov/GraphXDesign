using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GraphXDesign
{
    public class CircleTool : ITool
    {
        bool cursorActive;
        int x1, y1, x2, y2;

        public CircleTool()
        {
            cursorActive = false;
        }

        public void MouseDown(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e)
        {
            canvas.SaveToCache();
            cursorActive = true;
            x1 = e.X;
            y1 = e.Y;
            x2 = e.X;
            y2 = e.Y;
            canvas.WriteToPictureBox(sheet);
        }

        public void MouseMove(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e)
        {
            Circle circle = new Circle(x1, y1, x2, y2, brush);
            if (cursorActive == true)
            {
                canvas.LoadFromCache();
                x2 = e.X;
                y2 = e.Y;
                circle.Draw(canvas);
                canvas.WriteToPictureBox(sheet);
            }
        }

        public void MouseUp(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e)
        {
            cursorActive = false;
            x2 = e.X;
            y2 = e.Y;
            canvas.WriteToPictureBox(sheet);
        }
        public void MouseDoubleClick(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e)
        {        }
    }
}

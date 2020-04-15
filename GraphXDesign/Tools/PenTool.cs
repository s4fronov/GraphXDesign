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
        //какие то штуки, которые нужны для конкретного инструмента
        bool cursorActive;
        int x1, y1, x2, y2;

        public PenTool()
        {
            cursorActive = false; 
        }

        //весь код для рисования формы перенесен сюда полностью
        public void MouseDown(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e)
        {
            cursorActive = true;
            x1 = e.X;
            y1 = e.Y;
            brush.DrawDot(canvas, e.X, e.Y);
            canvas.WriteToPictureBox(sheet);
        }
        public void MouseMove(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e)
        {
            if (cursorActive == true)
            {
                x2 = e.X;
                y2 = e.Y;
                brush.DrawLine(canvas, x1, y1, x2, y2);
                x1 = x2;
                y1 = y2;
                canvas.WriteToPictureBox(sheet);
            }
        }
        public void MouseUp(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e)
        {
            cursorActive = false;
            x2 = e.X;
            y2 = e.Y;
        }
    }
}

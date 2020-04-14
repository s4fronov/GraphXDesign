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
        public void MouseDown(PictureBox sheet, Bitmap bmp, IBrush brush, MouseEventArgs e)
        {
            cursorActive = true;
            x1 = e.X;
            y1 = e.Y;
            brush.DrawDot(bmp, e.X, e.Y);
            sheet.Image = bmp;
        }
        public void MouseMove(PictureBox sheet, Bitmap bmp, IBrush brush, MouseEventArgs e)
        {
            if (cursorActive == true)
            {
                x2 = e.X;
                y2 = e.Y;
                brush.DrawLine(bmp, x1, y1, x2, y2);
                x1 = x2;
                y1 = y2;
                sheet.Image = bmp;
            }
        }
        public void MouseUp(PictureBox sheet, Bitmap bmp, IBrush brush, MouseEventArgs e)
        {
            cursorActive = false;
            x2 = e.X;
            y2 = e.Y;
        }
    }
}

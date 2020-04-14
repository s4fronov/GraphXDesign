using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GraphXDesign
{
    public class SquareTool : ITool
    {
        bool cursorActive;
        int x1, y1, x2, y2;
        Bitmap tmp;

        public SquareTool()
        {
            cursorActive = false;
        }

        //весь код для рисования формы перенесен сюда полностью
        public void MouseDown(PictureBox sheet, Bitmap bmp, IBrush brush, MouseEventArgs e)
        {
            cursorActive = true;
            x1 = e.X;
            y1 = e.Y;
            x2 = e.X;
            y2 = e.Y;
            sheet.Image = bmp;
        }
        public void MouseMove(PictureBox sheet, Bitmap bmp, IBrush brush, MouseEventArgs e)
        {
            Square square = new Square(x1, y1, x2, y2, brush);
            if (cursorActive == true)
            {
                tmp = new Bitmap(bmp);
                x2 = e.X;
                y2 = e.Y;
                square.DrawSquare(bmp, x1, y1, x2, y2);
                sheet.Image = tmp;
            }

        }
        public void MouseUp(PictureBox sheet, Bitmap bmp, IBrush brush, MouseEventArgs e)
        {
            cursorActive = false;
            x2 = e.X;
            y2 = e.Y;
            sheet.Image = tmp;
        }

    }
}

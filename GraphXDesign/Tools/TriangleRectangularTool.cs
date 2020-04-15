using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace GraphXDesign
{
    class TriangleRectangularTool:ITool
    {
        bool cursorActive;
        int x1, y1, x2, y2;

        public TriangleRectangularTool()
        {
            cursorActive = false;
        }

        //весь код для рисования формы перенесен сюда полностью
        public void MouseDown(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e)
        {
            canvas.SaveToCache();
            cursorActive = true;
            x1 = e.X;
            y1 = e.Y;
            x2 = e.X;
            y2 = e.Y;
            sheet.Image = canvas.Bmp;
        }
        public void MouseMove(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e)
        {
            TriangleRectangular triangle2 = new TriangleRectangular(x1, y1, x2, y2, brush);
            if (cursorActive == true)
            {
                canvas.LoadFromCache();
                x2 = e.X;
                y2 = e.Y;
                triangle2.DrawTriangleRectangular(canvas.Bmp, x1, y1, x2, y2); ;
                sheet.Image = canvas.Bmp;
            }
        }
        public void MouseUp(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e)
        {
            cursorActive = false;
            x2 = e.X;
            y2 = e.Y;
            sheet.Image = canvas.Bmp;
        }
    }

}

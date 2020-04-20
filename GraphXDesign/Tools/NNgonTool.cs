using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GraphXDesign
{
    public class NNgonTool : ITool
    {
        bool cursorActive, gon;
        int x0, y0, x1, y1, x2, y2;
        List<Tuple<int, int>> dotList = new List<Tuple<int, int>>();
        public NNgonTool()
        {
            cursorActive = false;
            gon = false;
        }

        public void MouseDown(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e)
        {
            canvas.SaveToCache();
            cursorActive = true;
            if (gon == false)
            {
                x1 = e.X;
                y1 = e.Y;
                gon = true;
                x0 = x1;
                y0 = y1;
            }
            else
            {
                x1 = x2;
                y1 = y2;
            }
            //brush.DrawDot(canvas, x1, y1);
            brush.DrawLine(canvas, x1, y1, e.X, e.Y, true);
            canvas.WriteToPictureBox(sheet);
        }
        public void MouseMove(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e)
        {
            if (cursorActive == true)
            {
                canvas.LoadFromCache();
                x2 = e.X;
                y2 = e.Y;
                dotList.Add(new Tuple<int, int>(x2, y2));
                brush.DrawLine(canvas, x1, y1, x2, y2, true);
                // brush.DrawDot(canvas, x2, y2);
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
        {
            cursorActive = false;
            x2 = e.X;
            y2 = e.Y;
            brush.DrawLine(canvas, x0, y0, x2, y2, true);
            canvas.WriteToPictureBox(sheet);
            gon = false;
        }
    }
}

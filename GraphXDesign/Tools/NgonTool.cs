using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GraphXDesign
{
    public class NgonTool:ITool
    {
        bool cursorActive;
        int x1, y1, x2, y2, n;
        public NgonTool(int n)
        {
            cursorActive = false;
            this.n = n;
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
            N_gon ngon = new N_gon(x1, y1, x2, y2,n, brush);
            if (cursorActive == true)
            {
                canvas.LoadFromCache();
                x2 = e.X;
                y2 = e.Y;
                ngon.Draw(canvas);
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
    }
}

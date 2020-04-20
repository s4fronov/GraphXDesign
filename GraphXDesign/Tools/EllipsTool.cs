using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GraphXDesign
{
    public class EllipsTool : ITool
    {
        bool cursorActive;
        int x1, y1, x2, y2;

        public EllipsTool()
        {
            cursorActive = false;
        }

        public void MouseDown(PictureBox sheet, IBrush brush, MouseEventArgs e)
        {
            Canvas.GetCanvas.SaveToCache();
            cursorActive = true;
            x1 = e.X;
            y1 = e.Y;
            x2 = e.X;
            y2 = e.Y;
            Canvas.GetCanvas.WriteToPictureBox(sheet);
        }

        public void MouseMove(PictureBox sheet, IBrush brush, MouseEventArgs e)
        {
            Ellips ellips = new Ellips(x1, y1, x2, y2, brush);
            if (cursorActive == true)
            {
                Canvas.GetCanvas.LoadFromCache();
                x2 = e.X;
                y2 = e.Y;
                ellips.Draw();
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

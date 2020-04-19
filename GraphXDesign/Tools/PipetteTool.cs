using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GraphXDesign
{
    public class PipetteTool : ITool
    {
        Bitmap bmp;
        bool cursorActive;

        public void MouseDown(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e)
        {
            cursorActive = true;
            bmp = new Bitmap(sheet.Image.Width, sheet.Image.Height);
            sheet.DrawToBitmap(bmp, sheet.ClientRectangle);
        }

        public void MouseMove(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e)
        {
            if (cursorActive == true)
            {
                brush.BrushColor = bmp.GetPixel(e.X, e.Y);
            }
        }

        public void MouseUp(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e)
        {
            cursorActive = false;
        }
    }
}

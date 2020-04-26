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
        bool cursorActive;
        public void MouseDown(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            cursorActive = true;
            sheet.DrawToBitmap(Canvas.GetCanvas.Bmp, sheet.ClientRectangle);
            brush.BrushColor = Canvas.GetCanvas.GetPixel(e.X, e.Y);
        }
        public void MouseMove(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            if (cursorActive == true)
            {
                brush.BrushColor = Canvas.GetCanvas.GetPixel(e.X, e.Y);
            }
        }
        public void MouseUp(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            cursorActive = false;
        }
        public void MouseDoubleClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        { }
    }
}

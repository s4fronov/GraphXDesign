using System.Windows.Forms;

namespace GraphXDesign
{
    public class PipetteTool : ITool
    {
        bool cursorActive;
        public void MouseDown(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            cursorActive = true;
            sheet.DrawToBitmap(Canvas.GetCanvas.Bmp.Bmp, sheet.ClientRectangle);
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
        public void MouseDoubleClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e) { }
        public void MouseClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e) { }
    }
}

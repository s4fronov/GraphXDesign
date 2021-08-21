using System.Windows.Forms;

namespace GraphXDesign
{
    class FillTool:ITool
    {
        AbstractCanvas canvas;

        public FillTool(AbstractCanvas canvas)
        {
            this.canvas = canvas;
        }

        public void MouseDown(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            if (canvas == Canvas.GetCanvas)
            {
                Canvas.GetCanvas.Fill(e.X, e.Y, brush.BrushColor);
                Canvas.GetCanvas.WriteToPictureBox(sheet);
            }
            }
        public void MouseDoubleClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        { }
        public void MouseMove(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e) { }
        public void MouseUp(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e) { }
        public void MouseClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e) { }
    }
}

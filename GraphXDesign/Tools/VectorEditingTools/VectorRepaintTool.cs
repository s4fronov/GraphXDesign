using System.Windows.Forms;

namespace GraphXDesign
{
    public class VectorRepaintTool : ITool
    {
        bool cursorActive;
        VectorCanvas canvas;
        Drawfigure activeFigure;
        public IFigure figure;
        public IBrush brush;
        public IFill fill;
        public VectorRepaintTool()
        {
            cursorActive = false;
            canvas = VectorCanvas.GetCanvas;
            activeFigure = null;
            //this.figure = (IFigure)figure.Clone();
            //this.brush = (IBrush)brush.Clone();
            //this.fill = (IFill)fill.Clone();
        }
        public void MouseDown(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            foreach (Drawfigure f in canvas.figures)
            {
                if (f.figure.IsInside(e.Location))
                {
                    activeFigure = f;
                    cursorActive = true;
                    canvas.RenderExceptFigure(activeFigure);
                    canvas.SaveToCache();

                }
            }
        }
        public void MouseMove(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {

        }
        public void MouseUp(PictureBox sheet, IBrush brushFig, IFill fillFig, MouseEventArgs e)
        {
            activeFigure.brush = (IBrush)brushFig.Clone();
            activeFigure.fill = (IFill)fillFig.Clone();
            cursorActive = false;
            canvas.Render();
            canvas.WriteToPictureBox(sheet);
        }
        public void MouseDoubleClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e) { }
        public void MouseClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e) { }
    }
}

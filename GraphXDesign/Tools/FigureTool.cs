using System.Windows.Forms;

namespace GraphXDesign
{
    public class FigureTool:ITool
    {
        IFigure figure;
        IFigure figureTmp;
        AbstractCanvas canvas;

        bool cursorActive;
        int x1, y1, x2, y2;

        public FigureTool(IFigure figure, AbstractCanvas canvas)
        {
            this.figure = figure;
            figureTmp = (IFigure)this.figure.Clone();
            this.canvas = canvas;
            cursorActive = false;
        }
        public void MouseDown(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            canvas.SaveToCache();
            cursorActive = true;
            x1 = e.X;
            y1 = e.Y;
            x2 = e.X;
            y2 = e.Y;
            canvas.WriteToPictureBox(sheet);
        }
        public void MouseMove(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            figure.Create(x1, y1, x2, y2);
            figureTmp.Create(x1, y1, x2, y2);
            if (cursorActive == true)
            {
                canvas.LoadFromCache();
                x2 = e.X;
                y2 = e.Y;
                IFill tmpFill = new NoFill();
                IBrush tmpBrush;
                if (fill is OnlyFill)
                    tmpBrush = new SquareBrush(1, fill.FillColor);
                else
                    tmpBrush = brush;
                Drawfigure drawer = new Drawfigure(figure, tmpBrush, tmpFill);
                Drawfigure drawerTmp = new Drawfigure(figureTmp, tmpBrush, tmpFill);
                drawer.Draw(canvas);
                canvas.WriteToPictureBox(sheet);
            }
        }
        public void MouseUp(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {

            cursorActive = false;
            x2 = e.X;
            y2 = e.Y;
            Drawfigure drawer = new Drawfigure(figure, brush, fill);
            Drawfigure drawerTmp = new Drawfigure(figureTmp, brush, fill);
            if (canvas is VectorCanvas)
            {
                VectorCanvas.GetCanvas.figures.Add(drawer);
                VectorCanvas.GetCanvas.figuresTmp.Add(drawerTmp);
            }
            drawer.Draw(canvas);
            canvas.WriteToPictureBox(sheet);
        }
        public void MouseDoubleClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e) { }
        public void MouseClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GraphXDesign
{
    public class FigureTool:ITool
    {
        IFigure figure;
        bool cursorActive;
        int x1, y1, x2, y2;

        public FigureTool(IFigure figure)
        {
            this.figure = figure;
            cursorActive = false;
        }
        public void MouseDown(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            Canvas.GetCanvas.SaveToCache();
            cursorActive = true;
            x1 = e.X;
            y1 = e.Y;
            x2 = e.X;
            y2 = e.Y;
            Canvas.GetCanvas.WriteToPictureBox(sheet);
        }
        public void MouseMove(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            figure.Create(x1, y1, x2, y2);
            if (cursorActive == true)
            {
                Canvas.GetCanvas.LoadFromCache();
                x2 = e.X;
                y2 = e.Y;
                IFill tmpFill = new NoFill();
                IBrush tmpBrush;
                if (fill is OnlyFill)
                    tmpBrush = new SquareBrush(1, fill.FillColor);
                else
                    tmpBrush = brush;
                Drawfigure drawer = new Drawfigure(figure, tmpBrush, tmpFill);
                drawer.Draw();
                Canvas.GetCanvas.WriteToPictureBox(sheet);
            }
        }
        public void MouseUp(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {

            cursorActive = false;
            x2 = e.X;
            y2 = e.Y;
            Drawfigure drawer = new Drawfigure(figure, brush, fill);
            drawer.Draw();
            Canvas.GetCanvas.WriteToPictureBox(sheet);
        }
        public void MouseDoubleClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        { }
    }
}

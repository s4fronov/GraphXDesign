using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GraphXDesign
{
    class VectorFigureMoveTool:ITool
    {
        bool cursorActive;
        VectorCanvas canvas;
        Drawfigure activeFigure;
        Point tmpPoint;
        int dx, dy;

        public VectorFigureMoveTool()
        {
            cursorActive = false;
            canvas = VectorCanvas.GetCanvas;
            activeFigure = null;
        }
        public void MouseDown(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            foreach(Drawfigure f in canvas.figures)
            {
                if (f.figure.IsInside(e.Location))
                {
                    activeFigure = f;
                    cursorActive = true;
                    canvas.RenderExceptFigure(activeFigure);
                    canvas.SaveToCache();
                    tmpPoint = e.Location;
                }
            }
        }
        public void MouseMove(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            if (cursorActive)
            {
                canvas.LoadFromCache();
                dx = e.X - tmpPoint.X;
                dy = e.Y - tmpPoint.Y;
                activeFigure.figure.MoveFigure(dx, dy);
                tmpPoint = e.Location;
                activeFigure.Draw(canvas);
                canvas.WriteToPictureBox(sheet);
            }
        }
        public void MouseUp(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            cursorActive = false;
            canvas.Render();
        }
        public void MouseDoubleClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        { }
    }
}

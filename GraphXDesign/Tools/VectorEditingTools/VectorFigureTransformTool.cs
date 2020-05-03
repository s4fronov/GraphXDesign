using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GraphXDesign
{
    class VectorFigureTransformTool : ITool
    {
        bool cursorActive;
        VectorCanvas canvas;
        Drawfigure activeFigure;
        int tmpIndex;

        public VectorFigureTransformTool()
        {
            cursorActive = false;
            canvas = VectorCanvas.GetCanvas;
            activeFigure = null;
        }
        public void MouseDown(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            cursorActive = true;
            for (int i = -10; i <= 10; i++)
            {
                for (int j = -10; j <= 10; j++)
                {
                    Point p = new Point(e.X + i, e.Y + j);
                    activeFigure = canvas.FindFigureByPoint(p);
                    if (activeFigure != null)
                    {
                        tmpIndex = canvas.FindPointByPoint(p);
                        break;
                    }
                }
                if (activeFigure != null)
                {
                    break;
                }
            }

            //для дабл клика(добавления вершин)
            if (activeFigure == null)
            {
                cursorActive = false;
                foreach (Drawfigure f in canvas.figures)
                {
                    if (f.figure.IsInside(e.Location))
                    {
                        activeFigure = f;
                    }
                }
            }
            //---------

            canvas.RenderExceptFigure(activeFigure);
            canvas.SaveToCache();
        }
        public void MouseMove(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            if (cursorActive)
            {
                if (activeFigure != null)
                {
                    canvas.LoadFromCache();
                    activeFigure.figure.dotlist[tmpIndex] = e.Location;
                    activeFigure.Draw(canvas);
                    canvas.PointChangeMode(sheet);
                    canvas.WriteToPictureBox(sheet);

                }
            }
        }
        public void MouseUp(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            cursorActive = false;
            canvas.PointChangeMode(sheet);
            canvas.WriteToPictureBox(sheet);
            
        }
        public void MouseDoubleClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            if (activeFigure != null)
            {
                canvas.LoadFromCache();

                //если попали по точке удаляем точку
                //если нет, пытаемся добавить точку на грань
                if (!activeFigure.figure.DeleteApproximatePoint(e.Location, 10))
                    activeFigure.figure.AddPoint(e.Location, 10);

                activeFigure.Draw(canvas);
                canvas.PointChangeMode(sheet);
                canvas.WriteToPictureBox(sheet);
            }
        }
    }
}

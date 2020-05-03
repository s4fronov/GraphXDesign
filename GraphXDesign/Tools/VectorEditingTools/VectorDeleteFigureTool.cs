using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GraphXDesign
{
    public class VectorDeleteFigureTool: ITool
    {
        bool cursorActive;
        VectorCanvas canvas;
        Drawfigure activeFigure;
        public VectorDeleteFigureTool()
        {
            cursorActive = false;
            canvas = VectorCanvas.GetCanvas;
            activeFigure = null;
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
            canvas.figures.Remove(activeFigure);
            canvas.Render();
        }
        public void MouseMove(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e) { }
        public void MouseUp(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            cursorActive = false;
            canvas.Render();
            canvas.WriteToPictureBox(sheet);
        }
        public void MouseDoubleClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e) { }
        public void MouseClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e) { }
    }
}

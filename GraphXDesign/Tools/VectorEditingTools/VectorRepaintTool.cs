using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GraphXDesign
{
    public class VectorRepaintTool : ITool
    {
        bool cursorActive;
        VectorCanvas canvas;
        Drawfigure activeFigure;
        public VectorRepaintTool()
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
        }
        public void MouseMove(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {

        }
        public void MouseUp(PictureBox sheet, IBrush brushFig, IFill fillFig, MouseEventArgs e)
        {
            activeFigure.brush.BrushColor = brushFig.BrushColor;
            activeFigure.brush.BrushSize = brushFig.BrushSize;
            activeFigure.fill = fillFig;
            cursorActive = false;
            canvas.Render();
            canvas.WriteToPictureBox(sheet);
        }
        public void MouseDoubleClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e) { }
        public void MouseClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e) { }
    }
}

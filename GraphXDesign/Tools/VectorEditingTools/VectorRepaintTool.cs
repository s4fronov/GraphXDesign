using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GraphXDesign
{
    public class VectorRepaintTool:ITool
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
            public void MouseDown(PictureBox sheet, IBrush brushFig, IFill fillFig, MouseEventArgs e)
            {
                foreach (Drawfigure f in canvas.figures)
                {
                    if (f.figure.IsInside(e.Location))
                    {
                        activeFigure = f;
                        cursorActive = true;
                        canvas.RenderExceptFigure(activeFigure);
                        canvas.SaveToCache();
                    f.brush.BrushColor = brushFig.BrushColor;
                    f.brush.BrushSize = brushFig.BrushSize;
                    f.fill = fillFig;
                    }
                }
            }
            public void MouseMove(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
            {
               
            }
            public void MouseUp(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
            {
                cursorActive = false;
                canvas.Render();
                canvas.WriteToPictureBox(sheet);
            }
            public void MouseDoubleClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
            { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GraphXDesign
{
     class VectorFigureOriginalStateTool : ITool
    {
        bool cursorActive;
        VectorCanvas canvas;
        Drawfigure activeFigure;
        int index;
        public VectorFigureOriginalStateTool()
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
                    index = canvas.figures.IndexOf(f);
                    cursorActive = true;
                    canvas.SaveToCache();
                    
                }
               
            }
        }
        public void MouseMove(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
        }
        public void MouseUp(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            cursorActive = false;
            canvas.figures.RemoveAt(index);
            canvas.figures.Insert(index, canvas.figuresTmp[index]);
            canvas.Render();
            canvas.WriteToPictureBox(sheet);
        }
        public void MouseDoubleClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
        }
    }
}

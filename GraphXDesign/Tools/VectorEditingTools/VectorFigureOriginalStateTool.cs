﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GraphXDesign
{
<<<<<<< HEAD
    class VectorFigureOriginalStateTool : ITool
=======
     class VectorFigureOriginalStateTool : ITool
>>>>>>> NewTestCase
    {
        bool cursorActive;
        VectorCanvas canvas;
        Drawfigure activeFigure;
<<<<<<< HEAD
        Drawfigure activeFigureTmp;
=======
>>>>>>> NewTestCase
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
<<<<<<< HEAD
                {
                    activeFigure = f;
                    index = canvas.figures.IndexOf(activeFigure);
                    activeFigureTmp = canvas.figuresTmp[index];
                    for (int i = 0; i < activeFigure.figure.dotlist.Count; i++)
                    {
                        activeFigure.figure.dotlist[i] = activeFigureTmp.figure.dotlist[i];
                    }
                    activeFigure.brush = activeFigureTmp.brush;
                    activeFigure.fill = activeFigureTmp.fill;
                    cursorActive = true;
                    canvas.SaveToCache();

                }

=======
                {  
                    index = canvas.figures.IndexOf(f);
                    cursorActive = true;
                    canvas.SaveToCache();
                    
                }
               
>>>>>>> NewTestCase
            }
        }
        public void MouseMove(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
        }
        public void MouseUp(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            cursorActive = false;
<<<<<<< HEAD
=======
            canvas.figures.RemoveAt(index);
            canvas.figures.Insert(index, canvas.figuresTmp[index]);
>>>>>>> NewTestCase
            canvas.Render();
            canvas.WriteToPictureBox(sheet);
        }
        public void MouseDoubleClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
        }
<<<<<<< HEAD
        public void MouseClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
        }
=======
>>>>>>> NewTestCase
    }
}

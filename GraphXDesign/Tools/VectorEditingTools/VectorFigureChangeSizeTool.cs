﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GraphXDesign
{
    class VectorFigureChangeSizeTool : ITool
    {
        bool cursorActive;
        VectorCanvas canvas;
        Drawfigure activeFigure;
        Point tmpPoint;
        string activecorner;
       
        int dx, dy;
        bool havecorners = false;
        // Point farthest;

        public VectorFigureChangeSizeTool()
        {
            cursorActive = false;
            canvas = VectorCanvas.GetCanvas;
            activeFigure = null;
        }
        public void MouseDown(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            if (havecorners == true)
            {
                if ((Math.Abs(e.Location.X - activeFigure.figure.cornerBottomRight.X) < 5) && (Math.Abs(e.Location.Y - activeFigure.figure.cornerBottomRight.Y) < 5 ))                 {
                    cursorActive = true;
                    activecorner = "cornerBottomRight";
                }
                if ((Math.Abs(e.Location.X - activeFigure.figure.cornerBottomLeft.X) < 5) && (Math.Abs(e.Location.Y - activeFigure.figure.cornerBottomLeft.Y) < 5))
                {
                    cursorActive = true;
                    activecorner = "cornerBottomLeft";
                }
                if ((Math.Abs(e.Location.X - activeFigure.figure.cornerTopLeft.X) < 5) && (Math.Abs(e.Location.Y - activeFigure.figure.cornerTopLeft.Y) < 5))
                {
                    cursorActive = true;
                    activecorner = "cornerTopLeft";
                }
                if ((Math.Abs(e.Location.X - activeFigure.figure.cornerTopRight.X) < 5) && (Math.Abs(e.Location.Y - activeFigure.figure.cornerTopRight.Y) < 5))
                {
                    cursorActive = true;
                    activecorner = "cornerTopRight";
                }

            }
            tmpPoint = e.Location;


        }
        public void MouseMove(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {
            if (cursorActive)
            {
                if (activeFigure != null)
                {
                    canvas.LoadFromCache();
                    dx = e.X - tmpPoint.X;
                    dy = e.Y - tmpPoint.Y;
                    activeFigure.figure.ChangeSizeFigure(dx, dy,activecorner);
                                                                          
                    tmpPoint = e.Location;
                    activeFigure.Draw(canvas);
                    canvas.PointChangeModeofrectangle(sheet, activeFigure);
                    canvas.WriteToPictureBox(sheet);
                   


                }
            }
        }
        public void MouseUp(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
        {

            if (activeFigure != null)
            {
                cursorActive = false;
                canvas.Render();
                canvas.PointChangeModeofrectangle(sheet, activeFigure);
                canvas.WriteToPictureBox(sheet);
            }
        }
        public void MouseDoubleClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e)
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
            activeFigure.figure.ChangeCorners();

            if (activeFigure != null)
            {
                canvas.PointChangeModeofrectangle(sheet, activeFigure);
            }
            havecorners = true;

        }
}   }  
    



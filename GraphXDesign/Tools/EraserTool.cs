﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GraphXDesign
{
    public class EraserTool : PenTool, ITool
    {
        bool cursorActive;
        int x1, y1, x2, y2;
        Color color;
        public EraserTool() 
        {
            cursorActive = false;
        }
        public void MouseDown(PictureBox sheet, IBrush brush, MouseEventArgs e)
        {
            color = brush.BrushColor;
            brush.BrushColor = sheet.BackColor;
            cursorActive = true;
            x1 = e.X;
            y1 = e.Y;
            brush.DrawDot(e.X, e.Y);
            Canvas.GetCanvas.WriteToPictureBox(sheet);
        }
        public void MouseMove(PictureBox sheet, IBrush brush, MouseEventArgs e)
        {
            if (cursorActive == true)
            {
                x2 = e.X;
                y2 = e.Y;
                brush.DrawLine(x1, y1, x2, y2, false);
                x1 = x2;
                y1 = y2;
                Canvas.GetCanvas.WriteToPictureBox(sheet);
            }
        }
        public void MouseUp(PictureBox sheet, IBrush brush, MouseEventArgs e)
        {
            cursorActive = false;
            brush.BrushColor = color;
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GraphXDesign
{
    public interface ITool
    {       

        void MouseDown(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e);
        void MouseMove(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e);
        void MouseUp(PictureBox sheet, Canvas canvas, IBrush brush, MouseEventArgs e);
    }
}
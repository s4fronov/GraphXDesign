using System;
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
        void MouseDown(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e);
        void MouseMove(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e);
        void MouseUp(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e);
        void MouseDoubleClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e);
    }
}

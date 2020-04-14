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
        /*
         * на вход методам пока что подаем пикчербокс, чтоб присваивать его имаджу битмап,
         * сам битмап, кисть и mouseargs
         * думаю когда холст сделаем, может быть по другому будет
         * + может быть другие ивенты появятся
         */
       

        void MouseDown(PictureBox sheet, Bitmap bmp, IBrush brush, MouseEventArgs e);
        void MouseMove(PictureBox sheet, Bitmap bmp, IBrush brush, MouseEventArgs e);
        void MouseUp(PictureBox sheet, Bitmap bmp, IBrush brush, MouseEventArgs e);
    }
}

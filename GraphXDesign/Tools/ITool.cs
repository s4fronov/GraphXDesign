using System.Windows.Forms;

namespace GraphXDesign
{
    public interface ITool
    {       
        void MouseDown(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e);
        void MouseMove(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e);
        void MouseUp(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e);
        void MouseDoubleClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e);
        void MouseClick(PictureBox sheet, IBrush brush, IFill fill, MouseEventArgs e);
    }
}

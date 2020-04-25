using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    public interface IFill
    {
        Color FillColor { get; set; }
        void Fill(Point point);
    }
}

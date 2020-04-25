using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign.Fill
{
    class NoFill
    {
        public Color FillColor { get; set; }
        public void Fill(Point point)
        {
            //ничего не делаем
            return;
        }
    }
}

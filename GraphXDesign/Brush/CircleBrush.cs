using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphXDesign
{
    public class CircleBrush : IBrush
    {
        public int BrushSize { get; set; }
        public Color BrushColor { get; set; }
        public CircleBrush(int size, Color color)
        {
            BrushSize = size;
            BrushColor = color;
        }
        public CircleBrush(IBrush brush)
        {
            BrushSize = brush.BrushSize;
            BrushColor = brush.BrushColor;
        }
        public void DrawDot(Canvas canvas, int x, int y)
        {
            //x1 y1 левый верхний угол
            //x2 y2 правый нижний
            int x1 = x - BrushSize / 2;
            int x2 = x1 + BrushSize - 1;
            int y1 = y - BrushSize / 2;
            int y2 = y1 + BrushSize - 1;

            //координаты центра
            double xCenter = (x1 + x2) / (double)2;
            double yCenter = (y1 + y2) / (double)2;

            double radius = BrushSize / (double)2;
            //заполняем с проверкой на расстояние от центра
            for (int i = x1; i <= x2; i++)
            {
                for (int j = y1; j <= y2; j++)
                {
                    if ((i - xCenter) * (i - xCenter) + (j - yCenter) * (j - yCenter) <= radius * radius)
                        canvas.SetPixel(i, j, BrushColor);
                }
            }
        }
        public void DrawLine(Canvas canvas, int x1, int y1, int x2, int y2, bool drawFirstDot = true)
        {
            PathCalculator lineCalc = new PathCalculator();
            List<Tuple<int, int>> dotList = lineCalc.CalculateLinePath(x1, y1, x2, y2);

            for (int i = 0; i < dotList.Count; i++)
                DrawDot(canvas, dotList[i].Item1, dotList[i].Item2);
        }
    }
}

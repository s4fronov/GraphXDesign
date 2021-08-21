using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;

namespace GraphXDesign
{
    public class SquareBrush:IBrush
    {
        [JsonConstructor]
        public SquareBrush(int size, Color color)
        {
            BrushSize = size;
            BrushColor = color;
        }
        public SquareBrush(IBrush brush)
        {
            BrushSize = brush.BrushSize;
            BrushColor = brush.BrushColor;
        }

        public override void DrawDot(BitmapWrap bmp, int x, int y)
        {
            //x1 y1 левый верхний угол
            //x2 y2 правый нижний
            int x1 = x - BrushSize / 2;
            int x2 = x1 + BrushSize - 1;
            int y1 = y - BrushSize / 2;
            int y2 = y1 + BrushSize - 1;

            //заполняем
            for (int i = x1; i <= x2; i++)
            {
                for (int j = y1; j <= y2; j++)
                {
                    bmp.SetPixel(i, j, BrushColor);
                }
            }
        }

        public override void DrawLine(BitmapWrap bmp, int x1, int y1, int x2, int y2, bool drawFirstDot = false)
        {
            PathCalculator lineCalc = new PathCalculator();
            List<Tuple<int, int>> dotList = lineCalc.CalculateLinePath(x1, y1, x2, y2);

            if (drawFirstDot)
                DrawDot(bmp, dotList[0].Item1, dotList[0].Item2);

            for (int i = 1; i < dotList.Count; i++)
            {
                if (dotList[i].Item1 < dotList[i - 1].Item1)
                    DrawDotBorder(bmp, dotList[i].Item1, dotList[i].Item2, Direction.Left);
                if (dotList[i].Item1 > dotList[i - 1].Item1)
                    DrawDotBorder(bmp, dotList[i].Item1, dotList[i].Item2, Direction.Right);
                if (dotList[i].Item2 < dotList[i - 1].Item2)
                    DrawDotBorder(bmp, dotList[i].Item1, dotList[i].Item2, Direction.Up);
                if (dotList[i].Item2 > dotList[i - 1].Item2)
                    DrawDotBorder(bmp, dotList[i].Item1, dotList[i].Item2, Direction.Down);
            }
        }

        enum Direction { Up, Down, Left, Right }
        private void DrawDotBorder(BitmapWrap bmp, int x, int y, Direction direction)
        {
            int x1 = x - BrushSize / 2;
            int x2 = x1 + BrushSize - 1;
            int y1 = y - BrushSize / 2;
            int y2 = y1 + BrushSize - 1;

            if (direction == Direction.Up)
                for (int i = x1; i <= x2; i++)
                {
                    bmp.SetPixel(i, y1, BrushColor);
                }

            if (direction == Direction.Down)
                for (int i = x1; i <= x2; i++)
                {
                    bmp.SetPixel(i, y2, BrushColor);
                }

            if (direction == Direction.Left)
                for (int j = y1; j <= y2; j++)
                {
                    bmp.SetPixel(x1, j, BrushColor);
                }

            if (direction == Direction.Right)
                for (int j = y1; j <= y2; j++)
                {
                    bmp.SetPixel(x2, j, BrushColor);
                }
        }
    }
}

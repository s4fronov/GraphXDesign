using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphXDesign
{
    public partial class Form : System.Windows.Forms.Form
    {
        Color paintColor1;
        Color paintColor2;
        int brushSize;
        int n;
        IBrush brush;
        ITool tool;
        ITool toolTmp;
        int option; // 0 - круг, 1 - квадрат
        bool expandActive;
        bool cursorActive;
        private Point MouseHook;
        Canvas canvas;

        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            hideSubMenu();
            startProgram();
            panelBrush.Visible = false;
            panelLine.Visible = false;
            panelFigure.Visible = false;
            pictureBoxSheet.SizeMode = PictureBoxSizeMode.Normal;
            paintColor1 = palette1.BackColor;
            paintColor2 = palette2.BackColor;
            pictureBoxSheet.Image = null;
            pictureBoxSheet.BackColor = Color.White;
            brushSize = 5;
            numericUpDown1.Value = 5;
            expandActive = false;
            cursorActive = false;
            brush = new CircleBrush(brushSize, paintColor1);
            tool = new PenTool();
        }

        private void startProgram()
        {
            canvas = new Canvas(pictureBoxSheet.Width, pictureBoxSheet.Height);
        }

        // Методы меню

        private void hideSubMenu()
        {
            if (panelBrush.Visible == true)
            { panelBrush.Visible = false; }
            if (panelLine.Visible == true)
            { panelLine.Visible = false; }
            if (panelFigure.Visible == true)
            { panelFigure.Visible = false; }
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void showOptMenu()
        {
            if (!(tool is NgonTool))
                panelAngles.Visible = false;
            brush = new CircleBrush(brush);
        }

            // Методы верхней панели и ее объектов

            private void panelProgram_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
        }

        private void imageCollapse_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void imageExpand_Click(object sender, EventArgs e)
        {
            if (expandActive == false)
            {
                this.WindowState = FormWindowState.Maximized;
                this.TopMost = true;
                expandActive = true;
                groupBoxMenu.Height = 2000;
            }
            else if (expandActive == true)
            {
                this.WindowState = FormWindowState.Normal;
                expandActive = false;
            }
        }

        private void imageExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Методы панели настроек рисунка

        public void palette1_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            { palette1.BackColor = colorDialog1.Color; }
            brush.BrushColor = palette1.BackColor;
        }

        private void palette2_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            { palette2.BackColor = colorDialog1.Color; }
            paintColor2 = palette2.BackColor;
        }

        private void pictureBoxPipette_Click(object sender, EventArgs e)
        {
            tool = new PipetteTool();
            option = 0;
        }

        private void panelResizeSheet_MouseDown(object sender, MouseEventArgs e)
        {
            if (cursorActive == false)
            {
                MouseHook = e.Location;
                cursorActive = true;
            }
        }

        private void panelResizeSheet_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                panelResizeSheet.Location += (Size)e.Location;
                pictureBoxSheet.Size += (Size)e.Location;
            }
        }

        private void panelResizeSheet_MouseUp(object sender, MouseEventArgs e)
        {
            if (cursorActive == true)
            {
                pictureBoxSheet.Size += (Size)e.Location;
                startProgram();
                pictureBoxSheet.DrawToBitmap(canvas.Bmp, pictureBoxSheet.ClientRectangle);
                cursorActive = false;
            }
        }

        // Методы панели инструментов

        private void buttonBrush_Click(object sender, EventArgs e)
        {
            showSubMenu(panelBrush);
        }

        private void buttonBrushDot_Click(object sender, EventArgs e)
        {
            tool = new PenTool();
            showOptMenu();
            brush = new CircleBrush(brush);
            brush.BrushColor = palette1.BackColor;
            option = 0;
        }

        private void buttonBrushSquare_Click(object sender, EventArgs e)
        {
            tool = new PenTool();
            showOptMenu();
            brush = new SquareBrush(brush);
            brush.BrushColor = palette1.BackColor;
            option = 0;
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            showSubMenu(panelLine);
        }

        private void buttonLineDot_Click(object sender, EventArgs e)
        {
            tool = new LineTool();
            showOptMenu();
            brush = new CircleBrush(brush);
            option = 0;
        }

        private void buttonLineSquare_Click(object sender, EventArgs e)
        {
            tool = new LineTool();
            showOptMenu();
            brush = new SquareBrush(brush);
            option = 0;
        }

        private void buttonFigure_Click(object sender, EventArgs e)
        {
            showSubMenu(panelFigure);
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            tool = new EllipsTool();
            showOptMenu();
            option = 1;
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            tool = new RectangleTool();
            showOptMenu();
            option = 2;
        }

        private void buttonTriangleIsosceles_Click(object sender, EventArgs e)
        {
            tool = new TrianglesamesizesTool();
            showOptMenu();
            option = 0;
        }

        private void buttonTriangleRectangular_Click(object sender, EventArgs e)
        {
            tool = new TriangleRectangularTool();
            showOptMenu();
            option = 0;
        }

        private void buttonNNgon_Click(object sender, EventArgs e)
        {
            tool = new NNgonTool();
            showOptMenu();
            option = 0;
        }

        private void buttonNAngular_Click(object sender, EventArgs e)
        {
            tool = new NgonTool(n);
            showOptMenu();
            n = Convert.ToInt32(numericUpDown1.Value);
            option = 0;
            panelAngles.Visible = true;
            if (n is SyntaxErrorException || n < 3) // проверка количества углов
            { 
                n = 3;
                numericUpDown1.Value = 3;
            }
            else if (n>=3) 
            {
                n = Convert.ToInt32(numericUpDown1.Value);
            }
        }

        // Методы основных событий
        
        private void pictureBoxClearAll_Click(object sender, EventArgs e)
        {
            pictureBoxSheet.Image = null; 
            startProgram();
        }

        private void pictureBoxReverse_Click(object sender, EventArgs e)
        {
            palette1.BackColor = paintColor2;
            palette2.BackColor = brush.BrushColor;
            paintColor1 = palette1.BackColor;
            paintColor2 = palette2.BackColor;
            brush.BrushColor = palette1.BackColor;
        }

        private void pictureBoxEraser_Click(object sender, EventArgs e)
        {
            brush = new SquareBrush(brush);
            tool = new PenTool();
            brush.BrushColor = pictureBoxSheet.BackColor;
        }

        private void pictureBoxSheet_MouseDown(object sender, MouseEventArgs e)
        {
            toolTmp = tool;
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                if (option == 1)
                {
                    tool = new CircleTool();
                }
                if (option == 2)
                {
                    tool = new SquareTool();
                }
            }
            else
                tool = toolTmp;
            tool.MouseDown((PictureBox)sender, canvas, brush, e);
        }

        private void pictureBoxSheet_MouseMove(object sender, MouseEventArgs e)
        {
            tool.MouseMove((PictureBox)sender, canvas, brush, e);
            palette1.BackColor = brush.BrushColor; // для пипетки
        }

        private void pictureBoxSheet_MouseUp(object sender, MouseEventArgs e)
        {
            tool.MouseUp((PictureBox)sender, canvas, brush, e);
            tool = toolTmp;
        }

        private void trackBarSize_Scroll(object sender, EventArgs e)
        {
            labelSize.Text = trackBarSize.Value + "";
            brush.BrushSize = Convert.ToInt32(labelSize.Text);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            n = Convert.ToInt32(numericUpDown1.Value);
            tool = new NgonTool(n);
        }

        private void pictureBoxFill_Click(object sender, EventArgs e)
        {
            tool = new FillTool();
        }

        private void pictureBoxSheet_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tool.MouseDoubleClick((PictureBox)sender, canvas, brush, e);
            tool = toolTmp;
        }

    }
}

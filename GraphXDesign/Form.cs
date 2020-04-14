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
        IBrush brush;
        bool expandActive;
        bool cursorActive;
        Bitmap boxSheet;
        ITool tool;
        private Point MouseHook;
        private Point MouseHookSheet;


        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            hideSubMenu();
            startProgram();
            pictureBoxSheet.SizeMode = PictureBoxSizeMode.StretchImage;
            paintColor1 = palette1.BackColor;
            paintColor2 = palette2.BackColor;
            brushSize = 5;
            expandActive = false;
            cursorActive = false;
            brush = new CircleBrush(brushSize, paintColor1);
            tool = new PenTool();
        }

        private void startProgram()
        {
            panelBrush.Visible = false;
            panelLine.Visible = false;
            panelFigure.Visible = false;
            pictureBoxSheet.BackColor = Color.White;
            boxSheet = new Bitmap(pictureBoxSheet.Width, pictureBoxSheet.Height);
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

        private void palette1_Click(object sender, EventArgs e)
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

        }

        // Методы панели инструментов

        private void buttonBrush_Click(object sender, EventArgs e)
        {
            showSubMenu(panelBrush);
        }

        private void buttonBrushDot_Click(object sender, EventArgs e)
        {
            tool = new PenTool();
            brush = new CircleBrush(brush);
            brush.BrushColor = palette1.BackColor;
        }

        private void buttonBrushSquare_Click(object sender, EventArgs e)
        {
            tool = new PenTool();
            brush = new SquareBrush(brush);
            brush.BrushColor = palette1.BackColor;
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            showSubMenu(panelLine);
        }

        private void buttonLineDot_Click(object sender, EventArgs e)
        {
            brush = new CircleBrush(brush);
            tool = new LineTool();
        }

        private void buttonLineSquare_Click(object sender, EventArgs e)
        {
            brush = new SquareBrush(brush);
            tool = new LineTool();
        }

        private void buttonFigure_Click(object sender, EventArgs e)
        {
            showSubMenu(panelFigure);
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {

        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            
            tool = new RectangleTool();
        }

        private void buttonTriangleIsosceles_Click(object sender, EventArgs e)
        {

        }

        private void buttonTriangleRectangular_Click(object sender, EventArgs e)
        {

        }

        private void buttonNAngular_Click(object sender, EventArgs e)
        {

        }

        // Методы основных событий

        private void pictureBoxSheet_MouseDown(object sender, MouseEventArgs e)
        {
            tool.MouseDown((PictureBox)sender, boxSheet, brush, e);
        }

        private void pictureBoxClearAll_Click(object sender, EventArgs e)
        {
            startProgram(); //что-то еще нужно добавить, чтобы обновлялся по клику, а не после того, как коснешься кистью листа
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
            brush.BrushColor = Color.White;
        }

        private void pictureBoxSheet_MouseMove(object sender, MouseEventArgs e)
        {
            tool.MouseMove((PictureBox)sender, boxSheet, brush, e);
        }

        private void pictureBoxSheet_MouseUp(object sender, MouseEventArgs e)
        {
            tool.MouseUp((PictureBox)sender, boxSheet, brush, e);
        }

        private void trackBarSize_Scroll(object sender, EventArgs e)
        {
            labelSize.Text = trackBarSize.Value + "";
            brush.BrushSize = Convert.ToInt32(labelSize.Text);
        }
    }
}

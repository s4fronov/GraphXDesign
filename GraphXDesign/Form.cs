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
        bool cursorActive;
        Bitmap boxSheet;
        int x1, y1, x2, y2;
        

        public Form()
        {
            InitializeComponent();
            hideSubMenu();
            startProgram();
            showSubMenu(panelBrush);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            paintColor1 = palette1.BackColor;
            paintColor2 = palette2.BackColor;
            brushSize = 5;
            boxSheet = new Bitmap(pictureBoxSheet.Width, pictureBoxSheet.Height);
            cursorActive = false;
            brush = new CircleBrush(brushSize, paintColor1);

        }

        private void startProgram()
        {
            panelBrush.Visible = false;
            panelLine.Visible = false;
            panelFigure.Visible = false;
            pictureBoxSheet.BackColor = Color.White;
        }

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

        private void panelProgram_Paint(object sender, PaintEventArgs e)
        {

        }

        private void imageExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelSettings_Paint(object sender, PaintEventArgs e)
        {

        }

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

        private void textBoxScale_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBoxMenu_Enter(object sender, EventArgs e)
        {

        }

        private void buttonBrush_Click(object sender, EventArgs e)
        {
            showSubMenu(panelBrush);
        }

        private void panelBrush_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonBrushDot_Click(object sender, EventArgs e)
        {
            brush = new CircleBrush(brush);
        }

        private void buttonBrushSquare_Click(object sender, EventArgs e)
        {
            brush = new SquareBrush(brush);
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            showSubMenu(panelLine);
        }

        private void panelLine_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonLineDot_Click(object sender, EventArgs e)
        {

        }

        private void buttonLineSquare_Click(object sender, EventArgs e)
        {

        }

        private void buttonFigure_Click(object sender, EventArgs e)
        {
            showSubMenu(panelFigure);
        }

        private void panelFigure_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {

        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {

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

        private void pictureBoxSheet_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxSheet_MouseDown(object sender, MouseEventArgs e)
        {
            cursorActive = true;
            x1 = e.X;
            y1 = e.Y;
            brush.DrawDot(boxSheet, e.X, e.Y);
            pictureBoxSheet.Image = boxSheet;
        }

        private void pictureBoxSheet_MouseMove(object sender, MouseEventArgs e)
        {

            if (cursorActive == true)
            {
                x2 = e.X;
                y2 = e.Y;
                brush.DrawLine(boxSheet, x1, y1, x2, y2);
                x1 = x2;
                y1 = y2;
                pictureBoxSheet.Image = boxSheet;
            }
        }

        private void pictureBoxSheet_MouseUp(object sender, MouseEventArgs e)
        {
            cursorActive = false;
            x2 = e.X;
            y2 = e.Y;
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            labelSize.Text = trackBar.Value + "";
            brush.BrushSize = Convert.ToInt32(labelSize.Text);
        }
    }
}

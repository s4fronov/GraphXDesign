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
             brushSize = 1;
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
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            { palette1.BackColor = colorDialog1.Color; }
        }

        private void palette2_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            { palette2.BackColor = colorDialog1.Color; }
        }

        private void pictureBoxPipette_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxPalette_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSize_TextChanged(object sender, EventArgs e)
        {
            brushSize = Convert.ToInt32(textBoxSize.Text);
            if (brushSize > pictureBoxSheet.Width || brushSize > pictureBoxSheet.Height)
                MessageBox.Show("Превышен размер кисти");
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

        }

        private void buttonBrushSquare_Click(object sender, EventArgs e)
        {

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
    }
}

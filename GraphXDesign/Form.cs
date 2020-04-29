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
        IFill fill;
        ITool tool;
        ITool toolTmp;
        int option; // 0 - круг, 1 - квадрат
        bool expandActive;
        bool cursorActive;
        private Point MouseHook;
        AbstractCanvas canvas; //переключается во вкладке режим

        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            startProgram();
            pictureBoxSheet.SizeMode = PictureBoxSizeMode.Normal;
            paintColor1 = palette1.BackColor;
            paintColor2 = palette2.BackColor;
            pictureBoxSheet.BackColor = Color.White;
            pictureBoxSheet.Image = null;
            pictureBoxSheet.DrawToBitmap(Canvas.GetCanvas.Bmp.Bmp, pictureBoxSheet.ClientRectangle); // Эта строка, делает фон листа белым
            brushSize = 5;
            numericAngle.Value = 5;
            expandActive = false;
            cursorActive = false;
            brush = new CircleBrush(brushSize, paintColor1);
            brush.BrushColor = palette1.BackColor;
            fill = new NoFill(paintColor2);
            tool = new PenTool();
            AbstractCanvas canvas = Canvas.GetCanvas;
            showModeMenu();
        }

        private void startProgram()
        {
            labelX.Text = Convert.ToString(pictureBoxSheet.Width);
            labelY.Text = Convert.ToString(pictureBoxSheet.Height);
            Canvas.GetCanvas.Init(pictureBoxSheet.Width, pictureBoxSheet.Height);
            VectorCanvas.GetCanvas.Init(pictureBoxSheet.Width, pictureBoxSheet.Height);
            canvas = Canvas.GetCanvas;
        }

        // Методы меню

        private void changeFill()
        {
            if (labelFillCont.ForeColor == Color.Gold)
            {
                pictureBoxFillCont.Visible = false;
                labelFillCont.ForeColor = Color.White;
            }
            if (labelFill.ForeColor == Color.Gold)
            {
                pictureBoxFillOnly.Visible = false;
                labelFill.ForeColor = Color.White;
            }
            if (labelCont.ForeColor == Color.Gold)
            {
                pictureBoxContOnly.Visible = false;
                labelCont.ForeColor = Color.White;
            }
        }

        private void showOptMenu()
        {
            // if (!(tool is NgonTool))
            panelAngles.Visible = false;
            panelFill.Visible = false;
        }

        private void showModeMenu()
        {
            if (canvas == Canvas.GetCanvas)
            {
                labelMode.Text = "Режим растровой графики";
                buttonEdit.Visible = false;
                panel5.Visible = false;
                buttonBrush.Visible = true;
                buttonNNgon.Visible = true;
                panelTools.Height = 208;
            }
            if (canvas == VectorCanvas.GetCanvas)
            {
                labelMode.Text = "Режим векторной графики";
                buttonEdit.Visible = true;
                panel5.Visible = true;
                buttonBrush.Visible = false;
                buttonNNgon.Visible = false;
                panelTools.Height = 158;
            }
        }

        // Методы верхней панели и ее объектов

        private void panelProgram_MouseMove(object sender, MouseEventArgs e) // Дижение окна формы
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
        }

        private void imageCollapse_Click(object sender, EventArgs e) // Свернуть
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void imageExpand_Click(object sender, EventArgs e) // Развернуть на весь экран
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

        private void imageExit_Click(object sender, EventArgs e) // Закрыть
        {
            this.Close();
        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e) // Создать
        {
            pictureBoxSheet.Image = null;
            startProgram();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) // Открыть
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = " All files (*.*)|*.*| Portable net graphics (*.png)|*.png| Bitmap files (*.bmp)|*.bmp";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                pictureBoxSheet.Load(filePath + "");
                startProgram();
                pictureBoxSheet.DrawToBitmap(Canvas.GetCanvas.Bmp.Bmp, pictureBoxSheet.ClientRectangle);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) // Сохранить
        {
            saveFileDialog.Filter = " Portable net graphics (*.png)|*.png| Bitmap files (*.bmp)|*.bmp";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Canvas.GetCanvas.Bmp.Bmp.Save(saveFileDialog.FileName);
            }
        }

        // Методы панели настроек инструмента

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
            fill.FillColor = palette2.BackColor;
        }

        private void pictureBoxReverse_Click(object sender, EventArgs e)
        {
            palette1.BackColor = paintColor2;
            palette2.BackColor = brush.BrushColor;
            paintColor1 = palette1.BackColor;
            paintColor2 = palette2.BackColor;
            brush.BrushColor = palette1.BackColor;
            fill.FillColor = palette2.BackColor;
        }

        private void pictureBoxPipette_Click(object sender, EventArgs e)
        {
            tool = new PipetteTool();
            option = 0;
        }

        private void pictureBoxFill_Click(object sender, EventArgs e)
        {
            tool = new FillTool();
        }

        private void pictureBoxEraser_Click(object sender, EventArgs e)
        {
            tool = new EraserTool();
            // brush.BrushColor = pictureBoxSheet.BackColor; // Color.Transparent для прозрачного PNG
        }

        private void pictureBoxClearAll_Click(object sender, EventArgs e)
        {
            pictureBoxSheet.Image = null;
            startProgram();
            pictureBoxSheet.DrawToBitmap(Canvas.GetCanvas.Bmp.Bmp, pictureBoxSheet.ClientRectangle); // Эта строка, делает фон листа белым
        }

        private void trackBarSize_Scroll(object sender, EventArgs e)
        {
            labelSize.Text = trackBarSize.Value + "";
            brush.BrushSize = Convert.ToInt32(labelSize.Text);
        }

        private void numericAngle_ValueChanged(object sender, EventArgs e)
        {
            tool = new FigureTool(new N_gon(Convert.ToInt32(numericAngle.Value)), canvas);
        }

        // Методы панели инструментов

        private void buttonBrush_Click(object sender, EventArgs e)
        {
            tool = new PenTool();
            showOptMenu();
            option = 0;
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            tool = new FigureTool(new Line(), canvas);
            fill = new NoFill(fill); // только первый цвет, по умолчанию
            showOptMenu();
            option = 0;
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            tool = new FigureTool(new Ellips(), canvas);
            showOptMenu();
            panelFill.Visible = true;
            option = 1;
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            tool = new FigureTool(new Rectangle(), canvas);
            showOptMenu();
            panelFill.Visible = true;
            option = 2;
        }

        private void buttonTriangleIsosceles_Click(object sender, EventArgs e)
        {
            tool = new FigureTool(new Trianglesamesizes(), canvas);
            showOptMenu();
            panelFill.Visible = true;
            option = 0;
        }

        private void buttonTriangleRectangular_Click(object sender, EventArgs e)
        {
            tool = new FigureTool(new TriangleRectangular(), canvas);
            showOptMenu();
            panelFill.Visible = true;
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
            showOptMenu();
            n = Convert.ToInt32(numericAngle.Value);
            option = 0;
            panelAngles.Visible = true;
            panelFill.Visible = true;
            if (n is SyntaxErrorException || n < 3) // Проверка количества углов
            {
                n = 3;
                numericAngle.Value = 3;
            }
            else if (n >= 3)
            {
                n = Convert.ToInt32(numericAngle.Value);
            }
            tool = new FigureTool(new N_gon(n), canvas);
        }

        // Методы работы листа с мышью

        private void pictureBoxSheet_MouseDown(object sender, MouseEventArgs e)
        {
            if (tool != null)
            {
                if (!(tool is PipetteTool))
                {
                    Canvas.GetCanvas.DeleteBmp(pictureBoxSheet);
                    Canvas.GetCanvas.AddToBmpList(pictureBoxSheet);
                }
                toolTmp = tool;
                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                {
                    if (option == 1)
                    {
                        tool = new FigureTool(new Circle(), canvas);
                    }
                    if (option == 2)
                    {
                        tool = new FigureTool(new Square(), canvas);
                    }
                }
                else
                    tool = toolTmp;
                tool.MouseDown((PictureBox)sender, brush, fill, e);
            }  
        }

        private void pictureBoxSheet_MouseMove(object sender, MouseEventArgs e)
        {
            if (tool != null)
            {
                tool.MouseMove((PictureBox)sender, brush, fill, e);
                if (tool is PipetteTool)
                {
                    palette1.BackColor = brush.BrushColor; // Для пипетки
                }
            }
        }

        private void pictureBoxSheet_MouseUp(object sender, MouseEventArgs e)
        {
            if (tool != null)
            {
                tool.MouseUp((PictureBox)sender, brush, fill, e);
                tool = toolTmp;
            }
        }

        private void pictureBoxSheet_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tool != null)
            {
                tool.MouseDoubleClick((PictureBox)sender, brush, fill, e);
                tool = toolTmp;
            }
        }

        // Методы изменения размера листа

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
                labelX.Text = Convert.ToString(pictureBoxSheet.Width);
                labelY.Text = Convert.ToString(pictureBoxSheet.Height);
            }
        }

        private void panelResizeSheet_MouseUp(object sender, MouseEventArgs e)
        {
            if (cursorActive == true)
            {
                pictureBoxSheet.Size += (Size)e.Location;
                startProgram();
                pictureBoxSheet.DrawToBitmap(Canvas.GetCanvas.Bmp.Bmp, pictureBoxSheet.ClientRectangle); // Эта строка, делает фон листа белым
                cursorActive = false;
            }
        }

        private void brushSquare_Click(object sender, EventArgs e)
        {
            brush = new SquareBrush(brush);
            brushSquare.BorderStyle = BorderStyle.Fixed3D;
            brushCircle.BorderStyle = BorderStyle.None;
        }

        private void brushCircle_Click(object sender, EventArgs e)
        {
            brush = new CircleBrush(brush);
            brushSquare.BorderStyle = BorderStyle.None;
            brushCircle.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBoxUndo_Click(object sender, EventArgs e)
        {
            if (canvas == Canvas.GetCanvas)
                Canvas.GetCanvas.Undo(pictureBoxSheet);
            //if (canvas == VectorCanvas.GetCanvas)
            //    VectorCanvas.GetCanvas.Undo(pictureBoxSheet);
        }

        private void pictureBoxRedo_Click(object sender, EventArgs e)
        {
            if (canvas == Canvas.GetCanvas)
                Canvas.GetCanvas.Redo(pictureBoxSheet);
            //if (canvas == VectorCanvas.GetCanvas)
            //    VectorCanvas.GetCanvas.Redo(pictureBoxSheet);
        }

        private void labelFillCont_Click(object sender, EventArgs e)
        {
            changeFill();
            labelFillCont.ForeColor = Color.Gold;
            pictureBoxFillCont.Visible = true;
            fill = new SolidFill(fill);
        }

        private void labelCont_Click(object sender, EventArgs e)
        {
            changeFill();
            labelCont.ForeColor = Color.Gold;
            pictureBoxContOnly.Visible = true;
            fill = new NoFill(fill);
        }

        private void labelFill_Click(object sender, EventArgs e)
        {
            changeFill();
            labelFill.ForeColor = Color.Gold;
            pictureBoxFillOnly.Visible = true;
            fill = new OnlyFill(fill);
        }

        private void растроваяГрафикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canvas = Canvas.GetCanvas;
            canvas.WriteToPictureBox(pictureBoxSheet);
            tool = new PenTool();
            showModeMenu();
        }

        private void векторнаяГрафикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canvas = VectorCanvas.GetCanvas;
            canvas.WriteToPictureBox(pictureBoxSheet);
            tool = null;
            showModeMenu();
        }

        private void buttonHand_Click(object sender, EventArgs e)
        {
            tool = new VectorFigureMoveTool();
            showOptMenu();
        }

        private void buttonResize_Click(object sender, EventArgs e)
        {
            showOptMenu();
        }

        private void buttonTransform_Click(object sender, EventArgs e)
        {
            canvas.PointChangeMode(pictureBoxSheet); // берет пустую реализацию из родителя, вместо нормальной из наследника
            tool = new VectorFigureTransformTool();
            showOptMenu();
        }

        private void buttonRotate_Click(object sender, EventArgs e)
        {
            showOptMenu();
        }

        private void buttonGitHub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/9rape/GraphXDesign");
        }
    }
}

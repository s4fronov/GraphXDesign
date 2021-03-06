﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace GraphXDesign
{
    public partial class FormProgram : Form
    {
        IBrush brush;
        IFill fill;
        ITool tool;
        ITool toolTmp;
        AbstractCanvas canvas;
        Color paintColor1;
        Color paintColor2;
        int brushSize;
        int n;
        int option; // 1 - Круг, 2 - Квадрат (при нажатом Shift)
        bool expandActive;
        bool cursorActive;
        private Point MouseHook;
        

        public FormProgram()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            pictureBoxSheet.SizeMode = PictureBoxSizeMode.Normal;
            paintColor1 = palette1.BackColor;
            paintColor2 = palette2.BackColor;
            pictureBoxSheet.BackColor = Color.White;
            brushSize = 5;
            numericAngle.Value = 5;
            expandActive = false;
            cursorActive = false;
            startProgram();
            showModeMenu();
        }

        // ================================================== Методы установки значений по умолчанию ==================================================

        private void startProgram() // Набор стартовых значений
        {
            labelX.Text = Convert.ToString(pictureBoxSheet.Width);
            labelY.Text = Convert.ToString(pictureBoxSheet.Height);
            if (canvas == Canvas.GetCanvas)
            {
                Canvas.GetCanvas.Init(pictureBoxSheet.Width, pictureBoxSheet.Height);
                setDefaultToolRaster();
            }
            if (canvas == VectorCanvas.GetCanvas)
            {
                VectorCanvas.GetCanvas.Init(pictureBoxSheet.Width, pictureBoxSheet.Height);
                setDefaultToolVector();
            }
            if (canvas == null)
            {
                Canvas.GetCanvas.Init(pictureBoxSheet.Width, pictureBoxSheet.Height);
                VectorCanvas.GetCanvas.Init(pictureBoxSheet.Width, pictureBoxSheet.Height);
                canvas = Canvas.GetCanvas;
                brush = new CircleBrush(brushSize, paintColor1);
                brush.BrushColor = palette1.BackColor;
                fill = new NoFill(paintColor2);
                tool = new PenTool();
            }
            pictureBoxSheet.DrawToBitmap(Canvas.GetCanvas.Bmp.Bmp, pictureBoxSheet.ClientRectangle);
        }

        private void setDefaultToolRaster() // Установка инструмента в растре по умолчанию
        {
            tool = new PenTool();
        }

        private void setDefaultToolVector() // Установка инструмента в векторе по умолчанию
        {
            tool = new FigureTool(new Line(), canvas);
            VectorCanvas.GetCanvas.RenderWrite(pictureBoxSheet);
        }

        private void cleanMemory() // Очистка памяти
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        // ================================================== Методы переключения режимов ==================================================

        private void растроваяГрафикаToolStripMenuItem_Click(object sender, EventArgs e) // Подготовка режима растровой графики
        {
            canvas = Canvas.GetCanvas;
            canvas.WriteToPictureBox(pictureBoxSheet);
            labelTool.Text = "   Кисть";
            tool = new PenTool();
            showModeMenu();
        }

        private void векторнаяГрафикаToolStripMenuItem_Click(object sender, EventArgs e) // Подготовка режима векторной графики
        {
            canvas = VectorCanvas.GetCanvas;
            canvas.WriteToPictureBox(pictureBoxSheet);
            labelTool.Text = "   Линия";
            tool = null;
            showModeMenu();
        }

        // ================================================== Методы работы меню ==================================================

        private void changeFill(object obj) // Изменение отображения параметров в меню заливки фигур
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
            if ((obj as Label).Text == "Контур + заливка")
            {
                labelFillCont.ForeColor = Color.Gold;
                pictureBoxFillCont.Visible = true;
                fill = new SolidFill(fill);
            }
            if ((obj as Label).Text == "Контур")
            {
                labelCont.ForeColor = Color.Gold;
                pictureBoxContOnly.Visible = true;
                fill = new NoFill(fill);
            }
            if ((obj as Label).Text == "Заливка")
            {
                labelFill.ForeColor = Color.Gold;
                pictureBoxFillOnly.Visible = true;
                fill = new OnlyFill(fill);
            }
        }

        private void hideOptMenu(object obj) // Скрытие неиспользуемых элементов
        {
            if (fill is NoFill)
            {
                labelCont.ForeColor = Color.Gold;
                labelFill.ForeColor = Color.White;
                labelFillCont.ForeColor = Color.White;
                pictureBoxContOnly.Visible = true;
                pictureBoxFillOnly.Visible = false;
                pictureBoxFillCont.Visible = false;
            }
            panelAngles.Visible = false;
            panelFill.Visible = false;
            labelTool.Text = (obj as Button).Text;
        }

        private void showModeMenu() // Подгрузка необходимых элементов при смене режимов
        {
            if (canvas == Canvas.GetCanvas)
            {
                tool = new PenTool();
                labelMode.Text = "Растровая графика";
                buttonEdit.Visible = false;
                panel5.Visible = false;
                buttonBrush.Visible = true;
                buttonNNgon.Visible = true;
                buttonFill.Visible = true;
                buttonEraser.Visible = true;
                buttonUndo.Visible = true;
                buttonRedo.Visible = true;
                panelAngles.Visible = false;
                panelFill.Visible = false;
                panelTools.Height = 208;
                panelInstruments.Width = 196;
            }
            if (canvas == VectorCanvas.GetCanvas)
            {
                tool = new FigureTool(new Line(), canvas);
                VectorCanvas.GetCanvas.RenderWrite(pictureBoxSheet);
                labelMode.Text = "Векторная графика";
                buttonEdit.Visible = true;
                panel5.Visible = true;
                buttonBrush.Visible = false;
                buttonNNgon.Visible = false;
                buttonFill.Visible = false;
                buttonEraser.Visible = false;
                buttonUndo.Visible = false;
                buttonRedo.Visible = false;
                panelAngles.Visible = false;
                panelFill.Visible = false;
                panelTools.Height = 158;
                panelInstruments.Width = 84;
            }
        }

        // ================================================== Методы панели программы и ее элементов ==================================================

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
                this.TopMost = false;
                expandActive = true;
                groupBoxMenu.Height = this.Height;
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

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e) // Новый файл (очищает лист)
        {
            pictureBoxSheet.Image = null;
            canvas.Bmp = null;
            startProgram();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) // Открыть файл
        {
            if (canvas == Canvas.GetCanvas)
            {
                string filePath;

                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = " All files (*.*)|*.*| Portable net graphics (*.png)|*.png| Bitmap files (*.bmp)|*.bmp";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    pictureBoxSheet.Load(filePath + "");
                    startProgram();
                    pictureBoxSheet.DrawToBitmap(Canvas.GetCanvas.Bmp.Bmp, pictureBoxSheet.ClientRectangle);
                }
            }

            if (canvas == VectorCanvas.GetCanvas)
            {
                string[] fileContent;
                string filePath;

                openFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = " JSON (*.json)|*.json";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;
                var jsonSerializerSettings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    fileContent = File.ReadAllLines(filePath);
                    VectorCanvas tmp = VectorCanvas.GetCanvas;
                    tmp.figures.Clear();
                    for (int i = 0; i < fileContent.Length; i++)
                    {
                        Drawfigure f = JsonConvert.DeserializeObject<Drawfigure>(fileContent[i], jsonSerializerSettings);
                        tmp.figures.Add(f);
                    }
                    VectorCanvas.GetCanvas.RenderWrite(pictureBoxSheet);
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) // Сохранить файл
        {
            if (canvas == Canvas.GetCanvas)
            {
                saveFileDialog.Filter = " Portable net graphics (*.png)|*.png| Bitmap files (*.bmp)|*.bmp";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Canvas.GetCanvas.Bmp.Bmp.Save(saveFileDialog.FileName);
                }
            }

            if (canvas == VectorCanvas.GetCanvas)
            {
                saveFileDialog.Filter = " JSON (*.json)|*.json";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                var jsonSerializerSettings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    VectorCanvas tmp = VectorCanvas.GetCanvas;
                    string file = "";
                    foreach (Drawfigure f in tmp.figures)
                    {
                        string json = JsonConvert.SerializeObject(f, jsonSerializerSettings);
                        file += json + "\n";
                    }
                    File.WriteAllText(saveFileDialog.FileName, file);
                }
            }
        }

        // ================================================== Методы вехней панели инструментов ==================================================

        public void palette1_Click(object sender, EventArgs e) // Основной цвет
        {
            colorDialog1.AllowFullOpen = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            { palette1.BackColor = colorDialog1.Color; }
            brush.BrushColor = palette1.BackColor;
        }

        private void palette2_Click(object sender, EventArgs e) // Дополнительный цвет
        {
            colorDialog1.AllowFullOpen = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            { palette2.BackColor = colorDialog1.Color; }
            paintColor2 = palette2.BackColor;
            fill.FillColor = palette2.BackColor;
        }

        private void buttonReverse_Click(object sender, EventArgs e) // Поменять местами основной и дополнительный цвет
        {
            palette1.BackColor = paintColor2;
            palette2.BackColor = brush.BrushColor;
            paintColor1 = palette1.BackColor;
            paintColor2 = palette2.BackColor;
            brush.BrushColor = palette1.BackColor;
            fill.FillColor = palette2.BackColor;
        }

        private void buttonPipette_Click(object sender, EventArgs e) // Пипетка
        {
            tool = new PipetteTool();
            option = 0;
        }

        private void buttonFill_Click(object sender, EventArgs e) // Заливка
        {
            tool = new FillTool(canvas);
        }

        private void buttonEraser_Click(object sender, EventArgs e) // Ластик
        {
            tool = new EraserTool();
        }

        private void buttonUndo_Click(object sender, EventArgs e) // Отменить действие
        {
            if (canvas == Canvas.GetCanvas)
                Canvas.GetCanvas.Undo(pictureBoxSheet);
        }

        private void buttonRedo_Click(object sender, EventArgs e) // Вернуть действие
        {
            if (canvas == Canvas.GetCanvas)
                Canvas.GetCanvas.Redo(pictureBoxSheet);
        }

        private void labelFillCont_Click(object sender, EventArgs e) // Рисование фигуры с заливкой и контуром
        {
            changeFill(sender);
        }

        private void labelCont_Click(object sender, EventArgs e) // Рисование фигуры только с контуром
        {
            changeFill(sender);
        }

        private void labelFill_Click(object sender, EventArgs e) // Рисование фигуры только с заливкой
        {
            changeFill(sender);
        }

        private void trackBarSize_Scroll(object sender, EventArgs e) // Изменение размера кисти
        {
            labelSize.Text = trackBarSize.Value + "";
            brush.BrushSize = Convert.ToInt32(labelSize.Text);
        }

        private void numericAngle_ValueChanged(object sender, EventArgs e) // Изменение количества углов многоугольника
        {
            tool = new FigureTool(new N_gon(Convert.ToInt32(numericAngle.Value)), canvas);
        }

        private void brushCircle_Click(object sender, EventArgs e) // Вызов круглой кисти
        {
            brush = new CircleBrush(brush);
            brushSquare.BorderStyle = BorderStyle.None;
            brushCircle.BorderStyle = BorderStyle.Fixed3D;
        }

        private void brushSquare_Click(object sender, EventArgs e) // Вызов квадратной кисти
        {
            brush = new SquareBrush(brush);
            brushSquare.BorderStyle = BorderStyle.Fixed3D;
            brushCircle.BorderStyle = BorderStyle.None;
        }

        // ================================================== Методы боковой панели инструментов ==================================================

        private void buttonBrush_Click(object sender, EventArgs e) // Выбор инструмента Кисть
        {
            tool = new PenTool();
            hideOptMenu(sender);
            option = 0;
        }

        private void buttonLine_Click(object sender, EventArgs e) // Выбор инструмента Линия
        {
            tool = new FigureTool(new Line(), canvas);
            if (canvas is VectorCanvas) VectorCanvas.GetCanvas.RenderWrite(pictureBoxSheet);
            fill = new NoFill(fill);
            hideOptMenu(sender);
            option = 0;
        }

        private void buttonCircle_Click(object sender, EventArgs e) // Выбор инструмента Эллипс
        {
            tool = new FigureTool(new Ellips(), canvas);
            if (canvas is VectorCanvas) VectorCanvas.GetCanvas.RenderWrite(pictureBoxSheet);
            hideOptMenu(sender);
            panelFill.Visible = true;
            option = 1;
        }

        private void buttonSquare_Click(object sender, EventArgs e) // Выбор инструмента Прямоугольник
        {
            tool = new FigureTool(new Rectangle(), canvas);
            if (canvas is VectorCanvas) VectorCanvas.GetCanvas.RenderWrite(pictureBoxSheet);
            hideOptMenu(sender);
            panelFill.Visible = true;
            option = 2;
        }

        private void buttonTriangleIsosceles_Click(object sender, EventArgs e) // Выбор инструмента Треугольник (равнобедренный)
        {
            tool = new FigureTool(new Trianglesamesizes(), canvas);
            if (canvas is VectorCanvas) VectorCanvas.GetCanvas.RenderWrite(pictureBoxSheet);
            hideOptMenu(sender);
            labelTool.Text += " равнобедренный";
            panelFill.Visible = true;
            option = 0;
        }

        private void buttonTriangleRectangular_Click(object sender, EventArgs e) // Выбор инструмента Треугольник (прямоугольный)
        {
            tool = new FigureTool(new TriangleRectangular(), canvas);
            if (canvas is VectorCanvas) VectorCanvas.GetCanvas.RenderWrite(pictureBoxSheet);
            hideOptMenu(sender);
            labelTool.Text += " прямоугольный";
            panelFill.Visible = true;
            option = 0;
        }

        private void buttonNNgon_Click(object sender, EventArgs e) // Выбор инструмента Многоугольник (неправильный)
        {
            tool = new NNgonTool();
            hideOptMenu(sender);
            labelTool.Text += " неправильный";
            option = 0;
        }

        private void buttonNAngular_Click(object sender, EventArgs e) // Выбор инструмента Многоугольник (правильный)
        {
            hideOptMenu(sender);
            labelTool.Text += " правильный";
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
            if (canvas is VectorCanvas) VectorCanvas.GetCanvas.RenderWrite(pictureBoxSheet);
        }

        private void buttonHand_Click(object sender, EventArgs e) // Выбор инструмента Рука
        {
            tool = new VectorFigureMoveTool();
            if (canvas is VectorCanvas) VectorCanvas.GetCanvas.RenderWrite(pictureBoxSheet);
            hideOptMenu(sender);
        }

        private void buttonResize_Click(object sender, EventArgs e) // Выбор инструмента Изменение размера
        {
            tool = new VectorFigureChangeSizeTool();
            if (canvas is VectorCanvas) VectorCanvas.GetCanvas.RenderWrite(pictureBoxSheet);
            hideOptMenu(sender);
        }

        private void buttonTransform_Click(object sender, EventArgs e) // Выбор инструмента Изменение фигуры
        {
            tool = new VectorFigureTransformTool();
            if (canvas is VectorCanvas) VectorCanvas.GetCanvas.RenderWrite(pictureBoxSheet);
            hideOptMenu(sender);
        }

        private void buttonRotate_Click(object sender, EventArgs e) // Выбор инструмента Поворот на 45 градусов
        {
            tool = new VectorFigureTurnTool();
            if (canvas is VectorCanvas) VectorCanvas.GetCanvas.RenderWrite(pictureBoxSheet);
            hideOptMenu(sender);
        }

        private void buttonPaint_Click(object sender, EventArgs e) // Выбор инструмента Замена цвета
        {
            tool = new VectorRepaintTool();
            if (canvas is VectorCanvas) VectorCanvas.GetCanvas.RenderWrite(pictureBoxSheet);
            hideOptMenu(sender);
            panelFill.Visible = true;
        }

        private void buttonOriginalState_Click(object sender, EventArgs e) // Выбор инструмента Отмена изменений
        {
            tool = new VectorFigureOriginalStateTool();
            if (canvas is VectorCanvas) VectorCanvas.GetCanvas.RenderWrite(pictureBoxSheet);
            hideOptMenu(sender);
        }

        private void buttonDelete_Click(object sender, EventArgs e) // Выбор инструмента Удаление фигуры
        {
            tool = new VectorDeleteFigureTool();
            if (canvas is VectorCanvas) VectorCanvas.GetCanvas.RenderWrite(pictureBoxSheet);
            hideOptMenu(sender);
        }

        // ================================================== Методы работы листа с мышью ==================================================

        private void pictureBoxSheet_MouseDown(object sender, MouseEventArgs e)
        {
            if (tool != null)
            {
                if (!(tool is PipetteTool))
                {
                    Canvas.GetCanvas.DeleteBmp(pictureBoxSheet);
                    Canvas.GetCanvas.AddToBmpList(pictureBoxSheet);
                }
                if ((tool is PenTool))
                {
                    Canvas.GetCanvas.DeleteBmp(pictureBoxSheet);
                    Canvas.GetCanvas.AddToBmpList(pictureBoxSheet);
                }
                if (!(tool is PipetteTool) && !(tool is PenTool))
                {
                    Canvas.GetCanvas.DeleteBmp(pictureBoxSheet);
                }
                toolTmp = tool;
                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                {
                    switch (option)
                    {
                        case 1:
                            tool = new FigureTool(new Circle(), canvas);
                            break;
                        case 2:
                            tool = new FigureTool(new Square(), canvas);
                            break;
                        default:
                            break;
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
                if (tool is PipetteTool)
                {
                    palette1.BackColor = brush.BrushColor; // Для пипетки
                }
                tool.MouseMove((PictureBox)sender, brush, fill, e);
            }
        }

        private void pictureBoxSheet_MouseUp(object sender, MouseEventArgs e)
        {
            if (tool != null)
            {
                if (!(tool is PipetteTool) && !(tool is PenTool))
                {
                    Canvas.GetCanvas.AddToBmpList(pictureBoxSheet);
                }
                tool.MouseUp((PictureBox)sender, brush, fill, e);
                tool = toolTmp;
            }
            cleanMemory();
        }

        private void pictureBoxSheet_MouseClick(object sender, MouseEventArgs e)
        {
            if (tool != null)
            {
                tool.MouseClick((PictureBox)sender, brush, fill, e);
            }
        }

        private void pictureBoxSheet_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tool != null)
            {
                tool.MouseDoubleClick((PictureBox)sender, brush, fill, e);
            }
        }

        // ================================================== Методы изменения размера листа ==================================================

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
                var jsonSerializerSettings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                VectorCanvas tmp = VectorCanvas.GetCanvas;
                string file = "";
                foreach (Drawfigure f in tmp.figures)
                {
                    string json = JsonConvert.SerializeObject(f, jsonSerializerSettings);
                    file += json + "|";
                }

                pictureBoxSheet.Size += (Size)e.Location;
                pictureBoxSheet.DrawToBitmap(Canvas.GetCanvas.Bmp.Bmp, pictureBoxSheet.ClientRectangle);
                VectorCanvas.GetCanvas.Init(pictureBoxSheet.Width, pictureBoxSheet.Height);

                string[] lines = file.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < lines.Length; i++)
                {
                    Drawfigure f = JsonConvert.DeserializeObject<Drawfigure>(lines[i], jsonSerializerSettings);
                    tmp.figures.Add(f);
                }
                VectorCanvas.GetCanvas.RenderWrite(pictureBoxSheet);

                cleanMemory();
            }
        }

        // ================================================== Методы дополнительного функционала ==================================================

        private void buttonGitHub_Click(object sender, EventArgs e) // Ссылка на репозиторий проекта
        {
            System.Diagnostics.Process.Start("https://github.com/9rape/GraphXDesign");
        }

        // ================================================== Методы изменения темы интерфейса ==================================================

        private void темнаяToolStripMenuItem_Click(object sender, EventArgs e) // Выбор темной темы
        {
            panelSettings.BackColor = Color.FromArgb(48, 48, 48);
            panelInfo.BackColor = Color.FromArgb(32, 32, 32);
            panelTools.BackColor = Color.FromArgb(48, 48, 48);
            panelTools.ForeColor = Color.FromArgb(136, 185, 144);
            buttonTools.BackColor = Color.FromArgb(32, 32, 32);
            buttonTools.ForeColor = Color.FromArgb(136, 185, 144);
            buttonEdit.BackColor = Color.FromArgb(32, 32, 32);
            buttonEdit.ForeColor = Color.FromArgb(136, 185, 144);
            panel5.BackColor = Color.FromArgb(48, 48, 48);
            panel5.ForeColor = Color.FromArgb(136, 185, 144);
            groupBoxMenu.BackColor = Color.FromArgb(32, 32, 32);
            panelProgram.BackColor = Color.FromArgb(136, 185, 144);
            файлToolStripMenuItem.BackColor = Color.FromArgb(136, 185, 144);
            режимToolStripMenuItem.BackColor = Color.FromArgb(136, 185, 144);
            темаToolStripMenuItem.BackColor = Color.FromArgb(136, 185, 144);
            buttonBrush.ForeColor = Color.FromArgb(136, 185, 144);
            buttonCircle.ForeColor = Color.FromArgb(136, 185, 144);
            buttonLine.ForeColor = Color.FromArgb(136, 185, 144);
            buttonSquare.ForeColor = Color.FromArgb(136, 185, 144);
            buttonNAngular.ForeColor = Color.FromArgb(136, 185, 144);
            buttonNNgon.ForeColor = Color.FromArgb(136, 185, 144);
            buttonTriangleRectangular.ForeColor = Color.FromArgb(136, 185, 144);
            buttonTriangleIsosceles.ForeColor = Color.FromArgb(136, 185, 144);
            buttonHand.ForeColor = Color.FromArgb(136, 185, 144);
            buttonDelete.ForeColor = Color.FromArgb(136, 185, 144);
            buttonResize.ForeColor = Color.FromArgb(136, 185, 144);
            buttonOriginalState.ForeColor = Color.FromArgb(136, 185, 144);
            buttonTransform.ForeColor = Color.FromArgb(136, 185, 144);
            buttonRotate.ForeColor = Color.FromArgb(136, 185, 144);
            buttonPaint.ForeColor = Color.FromArgb(136, 185, 144);
            panel2.BackColor = Color.FromArgb(48, 48, 48);
            panelLogo.BackColor = Color.FromArgb(136, 185, 144);
            label11.ForeColor = Color.FromArgb(223, 223, 223);
            label10.ForeColor = Color.FromArgb(223, 223, 223);
            labelX.ForeColor = Color.FromArgb(223, 223, 223);
            labelY.ForeColor = Color.FromArgb(223, 223, 223);
            labelTool.ForeColor = Color.FromArgb(223, 223, 223);
            labelMode.ForeColor = Color.FromArgb(223, 223, 223);
            label6.ForeColor = Color.FromArgb(223, 223, 223);
            label8.ForeColor = Color.FromArgb(223, 223, 223);
            label9.ForeColor = Color.FromArgb(223, 223, 223);
            numericAngle.ForeColor = Color.White;
            numericAngle.BackColor = Color.FromArgb(48, 48, 48);
        }

        private void светлаяToolStripMenuItem_Click(object sender, EventArgs e) // Выбор светлой темы
        {
            panelSettings.BackColor = Color.FromArgb(31, 101, 87);
            panelInfo.BackColor = Color.FromArgb(136, 185, 144);
            panelTools.BackColor = Color.FromArgb(31, 101, 87);
            panelTools.ForeColor = Color.FromArgb(255, 255, 255);
            buttonTools.BackColor = Color.FromArgb(136, 185, 144);
            buttonTools.ForeColor = Color.FromArgb(255, 255, 255);
            buttonEdit.BackColor = Color.FromArgb(136, 185, 144);
            buttonEdit.ForeColor = Color.FromArgb(255, 255, 255);
            panel5.BackColor = Color.FromArgb(31, 101, 87);
            panel5.ForeColor = Color.FromArgb(255, 255, 255);
            groupBoxMenu.BackColor = Color.FromArgb(136, 185, 144);
            panelProgram.BackColor = Color.FromArgb(136, 185, 144);
            файлToolStripMenuItem.BackColor = Color.FromArgb(136, 185, 144);
            режимToolStripMenuItem.BackColor = Color.FromArgb(136, 185, 144);
            темаToolStripMenuItem.BackColor = Color.FromArgb(136, 185, 144);
            buttonBrush.ForeColor = Color.FromArgb(223, 223, 223);
            buttonCircle.ForeColor = Color.FromArgb(223, 223, 223);
            buttonLine.ForeColor = Color.FromArgb(223, 223, 223);
            buttonSquare.ForeColor = Color.FromArgb(223, 223, 223);
            buttonNAngular.ForeColor = Color.FromArgb(223, 223, 223);
            buttonNNgon.ForeColor = Color.FromArgb(223, 223, 223);
            buttonTriangleRectangular.ForeColor = Color.FromArgb(223, 223, 223);
            buttonTriangleIsosceles.ForeColor = Color.FromArgb(223, 223, 223);
            buttonHand.ForeColor = Color.FromArgb(223, 223, 223);
            buttonDelete.ForeColor = Color.FromArgb(223, 223, 223);
            buttonResize.ForeColor = Color.FromArgb(223, 223, 223);
            buttonOriginalState.ForeColor = Color.FromArgb(223, 223, 223);
            buttonTransform.ForeColor = Color.FromArgb(223, 223, 223);
            buttonRotate.ForeColor = Color.FromArgb(223, 223, 223);
            buttonPaint.ForeColor = Color.FromArgb(223, 223, 223);
            panel2.BackColor = Color.FromArgb(136, 185, 144);
            panelLogo.BackColor = Color.FromArgb(31, 101, 87);
            label11.ForeColor = Color.FromArgb(48, 48, 48);
            label10.ForeColor = Color.FromArgb(48, 48, 48);
            labelX.ForeColor = Color.FromArgb(48, 48, 48);
            labelY.ForeColor = Color.FromArgb(48, 48, 48);
            labelTool.ForeColor = Color.FromArgb(48, 48, 48);
            labelMode.ForeColor = Color.FromArgb(48, 48, 48);
            label6.ForeColor = Color.FromArgb(48, 48, 48);
            label8.ForeColor = Color.FromArgb(48, 48, 48);
            label9.ForeColor = Color.FromArgb(48, 48, 48);
            numericAngle.ForeColor = Color.Black;
            numericAngle.BackColor = Color.FromArgb(136, 185, 144);
        }
    }
}

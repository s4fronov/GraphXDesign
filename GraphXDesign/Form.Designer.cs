namespace GraphXDesign
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainBox = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // mainBox
            // 
            this.mainBox.Location = new System.Drawing.Point(12, 12);
            this.mainBox.Name = "mainBox";
            this.mainBox.Size = new System.Drawing.Size(776, 312);
            this.mainBox.TabIndex = 0;
            this.mainBox.TabStop = false;
            this.mainBox.Text = "mainBox";
            this.mainBox.Enter += new System.EventHandler(this.mainBox_Enter);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainBox);
            this.Name = "Form";
            this.Text = "Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox mainBox;
    }
}


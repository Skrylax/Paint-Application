namespace DrawingProgram
{
    partial class Form1
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
            this.buttonDrawRec = new System.Windows.Forms.Button();
            this.buttonDrawEllipse = new System.Windows.Forms.Button();
            this.ResizeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDrawRec
            // 
            this.buttonDrawRec.Location = new System.Drawing.Point(13, 451);
            this.buttonDrawRec.Name = "buttonDrawRec";
            this.buttonDrawRec.Size = new System.Drawing.Size(108, 23);
            this.buttonDrawRec.TabIndex = 1;
            this.buttonDrawRec.Text = "Draw Rectangle";
            this.buttonDrawRec.UseVisualStyleBackColor = true;
            this.buttonDrawRec.Click += new System.EventHandler(this.buttonDrawRec_Click);
            // 
            // buttonDrawEllipse
            // 
            this.buttonDrawEllipse.Location = new System.Drawing.Point(13, 422);
            this.buttonDrawEllipse.Name = "buttonDrawEllipse";
            this.buttonDrawEllipse.Size = new System.Drawing.Size(108, 23);
            this.buttonDrawEllipse.TabIndex = 2;
            this.buttonDrawEllipse.Text = "Draw Ellipse";
            this.buttonDrawEllipse.UseVisualStyleBackColor = true;
            this.buttonDrawEllipse.Click += new System.EventHandler(this.buttonDrawEllipse_Click);
            // 
            // ResizeButton
            // 
            this.ResizeButton.Enabled = false;
            this.ResizeButton.Location = new System.Drawing.Point(13, 393);
            this.ResizeButton.Name = "ResizeButton";
            this.ResizeButton.Size = new System.Drawing.Size(108, 23);
            this.ResizeButton.TabIndex = 3;
            this.ResizeButton.Text = "Resize Shape";
            this.ResizeButton.UseVisualStyleBackColor = true;
            this.ResizeButton.Click += new System.EventHandler(this.ResizeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 486);
            this.Controls.Add(this.ResizeButton);
            this.Controls.Add(this.buttonDrawEllipse);
            this.Controls.Add(this.buttonDrawRec);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonDrawRec;
        private System.Windows.Forms.Button buttonDrawEllipse;
        private System.Windows.Forms.Button ResizeButton;
    }
}


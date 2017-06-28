namespace DrawingProgram.Forms
{
    partial class DecoratorForm
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
            this.ornamentTextBox = new System.Windows.Forms.TextBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.radioButtonTop = new System.Windows.Forms.RadioButton();
            this.radioButtonBottom = new System.Windows.Forms.RadioButton();
            this.radioButtonLeft = new System.Windows.Forms.RadioButton();
            this.radioButtonRight = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ornamentTextBox
            // 
            this.ornamentTextBox.Location = new System.Drawing.Point(72, 15);
            this.ornamentTextBox.Name = "ornamentTextBox";
            this.ornamentTextBox.Size = new System.Drawing.Size(157, 20);
            this.ornamentTextBox.TabIndex = 0;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(16, 64);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 1;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(97, 64);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // radioButtonTop
            // 
            this.radioButtonTop.AutoSize = true;
            this.radioButtonTop.Location = new System.Drawing.Point(16, 41);
            this.radioButtonTop.Name = "radioButtonTop";
            this.radioButtonTop.Size = new System.Drawing.Size(44, 17);
            this.radioButtonTop.TabIndex = 3;
            this.radioButtonTop.TabStop = true;
            this.radioButtonTop.Text = "Top";
            this.radioButtonTop.UseVisualStyleBackColor = true;
            // 
            // radioButtonBottom
            // 
            this.radioButtonBottom.AutoSize = true;
            this.radioButtonBottom.Location = new System.Drawing.Point(66, 41);
            this.radioButtonBottom.Name = "radioButtonBottom";
            this.radioButtonBottom.Size = new System.Drawing.Size(58, 17);
            this.radioButtonBottom.TabIndex = 4;
            this.radioButtonBottom.TabStop = true;
            this.radioButtonBottom.Text = "Bottom";
            this.radioButtonBottom.UseVisualStyleBackColor = true;
            // 
            // radioButtonLeft
            // 
            this.radioButtonLeft.AutoSize = true;
            this.radioButtonLeft.Location = new System.Drawing.Point(130, 41);
            this.radioButtonLeft.Name = "radioButtonLeft";
            this.radioButtonLeft.Size = new System.Drawing.Size(43, 17);
            this.radioButtonLeft.TabIndex = 5;
            this.radioButtonLeft.TabStop = true;
            this.radioButtonLeft.Text = "Left";
            this.radioButtonLeft.UseVisualStyleBackColor = true;
            // 
            // radioButtonRight
            // 
            this.radioButtonRight.AutoSize = true;
            this.radioButtonRight.Location = new System.Drawing.Point(179, 41);
            this.radioButtonRight.Name = "radioButtonRight";
            this.radioButtonRight.Size = new System.Drawing.Size(50, 17);
            this.radioButtonRight.TabIndex = 6;
            this.radioButtonRight.TabStop = true;
            this.radioButtonRight.Text = "Right";
            this.radioButtonRight.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ornament";
            // 
            // DecoratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 97);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonRight);
            this.Controls.Add(this.radioButtonLeft);
            this.Controls.Add(this.radioButtonBottom);
            this.Controls.Add(this.radioButtonTop);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.ornamentTextBox);
            this.Name = "DecoratorForm";
            this.Text = "DecoratorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ornamentTextBox;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.RadioButton radioButtonTop;
        private System.Windows.Forms.RadioButton radioButtonBottom;
        private System.Windows.Forms.RadioButton radioButtonLeft;
        private System.Windows.Forms.RadioButton radioButtonRight;
        private System.Windows.Forms.Label label1;
    }
}
namespace Graphics
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            drawPanel = new Panel();
            button1 = new Button();
            algosComboBox = new ComboBox();
            label1 = new Label();
            x1Box = new TextBox();
            label2 = new Label();
            y1Box = new TextBox();
            label3 = new Label();
            x2Box = new TextBox();
            label4 = new Label();
            y2Box = new TextBox();
            SuspendLayout();
            // 
            // drawPanel
            // 
            drawPanel.BackColor = SystemColors.GradientInactiveCaption;
            drawPanel.Location = new Point(238, 33);
            drawPanel.Name = "drawPanel";
            drawPanel.Size = new Size(716, 458);
            drawPanel.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(796, 508);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 1;
            button1.Text = "Draw";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // algosComboBox
            // 
            algosComboBox.FormattingEnabled = true;
            algosComboBox.Items.AddRange(new object[] { "DDA", "Bresenham", "Circle", "Ellipse" });
            algosComboBox.Location = new Point(570, 510);
            algosComboBox.Name = "algosComboBox";
            algosComboBox.Size = new Size(182, 33);
            algosComboBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 87);
            label1.Name = "label1";
            label1.Size = new Size(33, 25);
            label1.TabIndex = 3;
            label1.Text = "X1";
            // 
            // x1Box
            // 
            x1Box.Location = new Point(77, 84);
            x1Box.Name = "x1Box";
            x1Box.Size = new Size(150, 31);
            x1Box.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 154);
            label2.Name = "label2";
            label2.Size = new Size(32, 25);
            label2.TabIndex = 5;
            label2.Text = "Y1";
            // 
            // y1Box
            // 
            y1Box.Location = new Point(77, 148);
            y1Box.Name = "y1Box";
            y1Box.Size = new Size(150, 31);
            y1Box.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 222);
            label3.Name = "label3";
            label3.Size = new Size(33, 25);
            label3.TabIndex = 7;
            label3.Text = "X2";
            // 
            // x2Box
            // 
            x2Box.Location = new Point(77, 216);
            x2Box.Name = "x2Box";
            x2Box.Size = new Size(150, 31);
            x2Box.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 295);
            label4.Name = "label4";
            label4.Size = new Size(32, 25);
            label4.TabIndex = 9;
            label4.Text = "Y2";
            // 
            // y2Box
            // 
            y2Box.Location = new Point(77, 289);
            y2Box.Name = "y2Box";
            y2Box.Size = new Size(150, 31);
            y2Box.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 554);
            Controls.Add(y2Box);
            Controls.Add(label4);
            Controls.Add(x2Box);
            Controls.Add(label3);
            Controls.Add(y1Box);
            Controls.Add(label2);
            Controls.Add(x1Box);
            Controls.Add(label1);
            Controls.Add(algosComboBox);
            Controls.Add(button1);
            Controls.Add(drawPanel);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel drawPanel;
        private Button button1;
        private ComboBox algosComboBox;
        private Label label1;
        private TextBox x1Box;
        private Label label2;
        private TextBox y1Box;
        private Label label3;
        private TextBox x2Box;
        private Label label4;
        private TextBox y2Box;
    }
}

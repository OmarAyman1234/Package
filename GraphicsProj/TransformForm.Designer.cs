namespace GraphicsProj
{
    partial class TransformForm
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
            pictureBox = new PictureBox();
            xTrSlider = new TrackBar();
            yTrSlider = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            yScSlider = new TrackBar();
            xScSlider = new TrackBar();
            rotSlider = new TrackBar();
            label9 = new Label();
            label5 = new Label();
            label8 = new Label();
            yShSlider = new TrackBar();
            xShSlider = new TrackBar();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xTrSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)yTrSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)yScSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xScSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rotSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)yShSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xShSlider).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Image = Properties.Resources.fruits;
            pictureBox.Location = new Point(784, 40);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(512, 439);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // xTrSlider
            // 
            xTrSlider.Location = new Point(23, 92);
            xTrSlider.Maximum = 150;
            xTrSlider.Minimum = -150;
            xTrSlider.Name = "xTrSlider";
            xTrSlider.Size = new Size(156, 69);
            xTrSlider.TabIndex = 1;
            // 
            // yTrSlider
            // 
            yTrSlider.Location = new Point(201, 92);
            yTrSlider.Maximum = 150;
            yTrSlider.Minimum = -150;
            yTrSlider.Name = "yTrSlider";
            yTrSlider.Size = new Size(156, 69);
            yTrSlider.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 64);
            label1.Name = "label1";
            label1.Size = new Size(42, 25);
            label1.TabIndex = 3;
            label1.Text = "X: 0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(201, 64);
            label2.Name = "label2";
            label2.Size = new Size(41, 25);
            label2.TabIndex = 4;
            label2.Text = "Y: 0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(23, 20);
            label3.Name = "label3";
            label3.Size = new Size(146, 35);
            label3.TabIndex = 5;
            label3.Text = "Translation";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(23, 164);
            label4.Name = "label4";
            label4.Size = new Size(101, 35);
            label4.TabIndex = 6;
            label4.Text = "Scaling";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(201, 207);
            label6.Name = "label6";
            label6.Size = new Size(41, 25);
            label6.TabIndex = 10;
            label6.Text = "Y: 0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(23, 207);
            label7.Name = "label7";
            label7.Size = new Size(42, 25);
            label7.TabIndex = 9;
            label7.Text = "X: 0";
            // 
            // yScSlider
            // 
            yScSlider.Location = new Point(201, 235);
            yScSlider.Maximum = 20;
            yScSlider.Name = "yScSlider";
            yScSlider.Size = new Size(156, 69);
            yScSlider.TabIndex = 8;
            yScSlider.Value = 10;
            // 
            // xScSlider
            // 
            xScSlider.Location = new Point(23, 235);
            xScSlider.Maximum = 20;
            xScSlider.Name = "xScSlider";
            xScSlider.Size = new Size(156, 69);
            xScSlider.TabIndex = 7;
            xScSlider.Value = 10;
            // 
            // rotSlider
            // 
            rotSlider.Location = new Point(23, 327);
            rotSlider.Maximum = 180;
            rotSlider.Minimum = -180;
            rotSlider.Name = "rotSlider";
            rotSlider.Size = new Size(156, 69);
            rotSlider.TabIndex = 12;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(23, 289);
            label9.Name = "label9";
            label9.Size = new Size(112, 35);
            label9.TabIndex = 11;
            label9.Text = "Rotation";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(201, 429);
            label5.Name = "label5";
            label5.Size = new Size(41, 25);
            label5.TabIndex = 17;
            label5.Text = "Y: 0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(23, 429);
            label8.Name = "label8";
            label8.Size = new Size(42, 25);
            label8.TabIndex = 16;
            label8.Text = "X: 0";
            // 
            // yShSlider
            // 
            yShSlider.Location = new Point(201, 457);
            yShSlider.Maximum = 5;
            yShSlider.Minimum = -5;
            yShSlider.Name = "yShSlider";
            yShSlider.Size = new Size(156, 69);
            yShSlider.TabIndex = 15;
            // 
            // xShSlider
            // 
            xShSlider.Location = new Point(23, 457);
            xShSlider.Maximum = 5;
            xShSlider.Minimum = -5;
            xShSlider.Name = "xShSlider";
            xShSlider.Size = new Size(156, 69);
            xShSlider.TabIndex = 14;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(23, 386);
            label10.Name = "label10";
            label10.Size = new Size(119, 35);
            label10.TabIndex = 13;
            label10.Text = "Shearing";
            // 
            // TransformForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1334, 678);
            Controls.Add(label5);
            Controls.Add(label8);
            Controls.Add(yShSlider);
            Controls.Add(xShSlider);
            Controls.Add(label10);
            Controls.Add(rotSlider);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(yScSlider);
            Controls.Add(xScSlider);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(yTrSlider);
            Controls.Add(xTrSlider);
            Controls.Add(pictureBox);
            Name = "TransformForm";
            Text = "TransformForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)xTrSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)yTrSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)yScSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)xScSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)rotSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)yShSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)xShSlider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox imgDisplay;
        private PictureBox pictureBox;
        private TrackBar xTrSlider;
        private TrackBar yTrSlider;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private TrackBar yScSlider;
        private TrackBar xScSlider;
        private TrackBar rotSlider;
        private Label label9;
        private Label label5;
        private Label label8;
        private TrackBar yShSlider;
        private TrackBar xShSlider;
        private Label label10;
    }
}
namespace Maze
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
            label1 = new Label();
            label2 = new Label();
            lblTotalPaths = new Label();
            txtMazeSize = new TextBox();
            pictureBox = new PictureBox();
            btnCreateMaze = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 295);
            label1.Name = "label1";
            label1.Size = new Size(124, 15);
            label1.TabIndex = 0;
            label1.Text = "Общее кол-во путей:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 174);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 1;
            label2.Text = "Размер поля";
            // 
            // lblTotalPaths
            // 
            lblTotalPaths.AutoSize = true;
            lblTotalPaths.Location = new Point(178, 295);
            lblTotalPaths.Name = "lblTotalPaths";
            lblTotalPaths.Size = new Size(38, 15);
            lblTotalPaths.TabIndex = 2;
            lblTotalPaths.Text = "label3";
            // 
            // txtMazeSize
            // 
            txtMazeSize.Location = new Point(131, 171);
            txtMazeSize.Name = "txtMazeSize";
            txtMazeSize.Size = new Size(100, 23);
            txtMazeSize.TabIndex = 3;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(431, 77);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(400, 400);
            pictureBox.TabIndex = 4;
            pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Click);
            // 
            // btnCreateMaze
            // 
            btnCreateMaze.Location = new Point(78, 218);
            btnCreateMaze.Name = "btnCreateMaze";
            btnCreateMaze.Size = new Size(124, 23);
            btnCreateMaze.TabIndex = 5;
            btnCreateMaze.Text = "Создать лабиринт";
            btnCreateMaze.UseVisualStyleBackColor = true;
            btnCreateMaze.Click += btnCreateMaze_Click;
            // 
            // button2
            // 
            button2.Location = new Point(97, 328);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "Start";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 682);
            Controls.Add(button2);
            Controls.Add(btnCreateMaze);
            Controls.Add(pictureBox);
            Controls.Add(txtMazeSize);
            Controls.Add(lblTotalPaths);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";

            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label lblTotalPaths;
        private TextBox txtMazeSize;
        private PictureBox pictureBox;
        private Button btnCreateMaze;
        private Button button2;
    }
}

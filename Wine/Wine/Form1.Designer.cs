namespace Wine
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
            dataGridView1 = new DataGridView();
            txtMaxWeight = new TextBox();
            Start = new Button();
            label1 = new Label();
            lblResult = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(25, 112);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(462, 326);
            dataGridView1.TabIndex = 0;
            // 
            // txtMaxWeight
            // 
            txtMaxWeight.Location = new Point(518, 45);
            txtMaxWeight.Name = "txtMaxWeight";
            txtMaxWeight.Size = new Size(100, 23);
            txtMaxWeight.TabIndex = 1;
            // 
            // Start
            // 
            Start.Location = new Point(518, 101);
            Start.Name = "Start";
            Start.Size = new Size(75, 23);
            Start.TabIndex = 2;
            Start.Text = "Start";
            Start.UseVisualStyleBackColor = true;
            Start.Click += Start_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(384, 48);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 3;
            label1.Text = "Ограничение по весу:";
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(534, 170);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(38, 15);
            lblResult.TabIndex = 4;
            lblResult.Text = "label2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResult);
            Controls.Add(label1);
            Controls.Add(Start);
            Controls.Add(txtMaxWeight);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtMaxWeight;
        private Button Start;
        private Label label1;
        private Label lblResult;
    }
}

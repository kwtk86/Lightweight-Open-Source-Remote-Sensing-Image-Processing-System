namespace LOSRSS.statistic
{
    partial class HistoGraph
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
            this.ShowHistoButton = new System.Windows.Forms.Button();
            this.BandTextBox = new System.Windows.Forms.TextBox();
            this.InputBand = new System.Windows.Forms.Label();
            this.graphInfo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ShowCumuHistoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ShowHistoButton
            // 
            this.ShowHistoButton.Location = new System.Drawing.Point(12, 162);
            this.ShowHistoButton.Name = "ShowHistoButton";
            this.ShowHistoButton.Size = new System.Drawing.Size(126, 44);
            this.ShowHistoButton.TabIndex = 0;
            this.ShowHistoButton.Text = "生成直方图";
            this.ShowHistoButton.UseVisualStyleBackColor = true;
            this.ShowHistoButton.Click += new System.EventHandler(this.ShowHistoButton_Click);
            // 
            // BandTextBox
            // 
            this.BandTextBox.Location = new System.Drawing.Point(12, 114);
            this.BandTextBox.Name = "BandTextBox";
            this.BandTextBox.Size = new System.Drawing.Size(113, 28);
            this.BandTextBox.TabIndex = 1;
            this.BandTextBox.TextChanged += new System.EventHandler(this.BandTextBox_TextChanged);
            this.BandTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BandTextBox_KeyPress);
            // 
            // InputBand
            // 
            this.InputBand.AutoSize = true;
            this.InputBand.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.InputBand.Location = new System.Drawing.Point(13, 71);
            this.InputBand.Name = "InputBand";
            this.InputBand.Size = new System.Drawing.Size(92, 27);
            this.InputBand.TabIndex = 4;
            this.InputBand.Text = "输入波段";
            // 
            // graphInfo
            // 
            this.graphInfo.AutoSize = true;
            this.graphInfo.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.graphInfo.Location = new System.Drawing.Point(13, 24);
            this.graphInfo.Name = "graphInfo";
            this.graphInfo.Size = new System.Drawing.Size(110, 31);
            this.graphInfo.TabIndex = 5;
            this.graphInfo.Text = "输入波段";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(159, 24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(488, 479);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // ShowCumuHistoButton
            // 
            this.ShowCumuHistoButton.Location = new System.Drawing.Point(12, 238);
            this.ShowCumuHistoButton.Name = "ShowCumuHistoButton";
            this.ShowCumuHistoButton.Size = new System.Drawing.Size(126, 44);
            this.ShowCumuHistoButton.TabIndex = 7;
            this.ShowCumuHistoButton.Text = "生成累计直方图";
            this.ShowCumuHistoButton.UseVisualStyleBackColor = true;
            this.ShowCumuHistoButton.Click += new System.EventHandler(this.ShowCumuHistoButton_Click);
            // 
            // HistoGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 571);
            this.Controls.Add(this.ShowCumuHistoButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.graphInfo);
            this.Controls.Add(this.InputBand);
            this.Controls.Add(this.BandTextBox);
            this.Controls.Add(this.ShowHistoButton);
            this.Name = "HistoGraph";
            this.Text = "直方图";
            this.Load += new System.EventHandler(this.HistoGraph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ShowHistoButton;
        private System.Windows.Forms.TextBox BandTextBox;
        private System.Windows.Forms.Label InputBand;
        private System.Windows.Forms.Label graphInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ShowCumuHistoButton;
    }
}
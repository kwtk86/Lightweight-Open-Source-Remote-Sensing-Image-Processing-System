namespace LOSRSS
{
    partial class MatchForm
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
            this.grayBandText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.iniMatching = new System.Windows.Forms.Button();
            this.graphInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RBandText = new System.Windows.Forms.TextBox();
            this.GBandText = new System.Windows.Forms.TextBox();
            this.BBandText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // grayBandText
            // 
            this.grayBandText.Location = new System.Drawing.Point(21, 95);
            this.grayBandText.Name = "grayBandText";
            this.grayBandText.Size = new System.Drawing.Size(100, 28);
            this.grayBandText.TabIndex = 6;
            this.grayBandText.TextChanged += new System.EventHandler(this.grayBandText_TextChanged);
            this.grayBandText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grayBandText_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "灰度波段";
            // 
            // iniMatching
            // 
            this.iniMatching.Location = new System.Drawing.Point(21, 199);
            this.iniMatching.Name = "iniMatching";
            this.iniMatching.Size = new System.Drawing.Size(100, 29);
            this.iniMatching.TabIndex = 8;
            this.iniMatching.Text = "开始规定化";
            this.iniMatching.UseVisualStyleBackColor = true;
            this.iniMatching.Click += new System.EventHandler(this.iniMatching_Click);
            // 
            // graphInfo
            // 
            this.graphInfo.AutoSize = true;
            this.graphInfo.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.graphInfo.Location = new System.Drawing.Point(27, 30);
            this.graphInfo.Name = "graphInfo";
            this.graphInfo.Size = new System.Drawing.Size(82, 31);
            this.graphInfo.TabIndex = 9;
            this.graphInfo.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "彩色RGB";
            // 
            // RBandText
            // 
            this.RBandText.Location = new System.Drawing.Point(21, 165);
            this.RBandText.Name = "RBandText";
            this.RBandText.Size = new System.Drawing.Size(100, 28);
            this.RBandText.TabIndex = 10;
            this.RBandText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.RBandText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // GBandText
            // 
            this.GBandText.Location = new System.Drawing.Point(127, 165);
            this.GBandText.Name = "GBandText";
            this.GBandText.Size = new System.Drawing.Size(100, 28);
            this.GBandText.TabIndex = 12;
            this.GBandText.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.GBandText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // BBandText
            // 
            this.BBandText.Location = new System.Drawing.Point(233, 165);
            this.BBandText.Name = "BBandText";
            this.BBandText.Size = new System.Drawing.Size(100, 28);
            this.BBandText.TabIndex = 13;
            this.BBandText.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.BBandText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // MatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 276);
            this.Controls.Add(this.BBandText);
            this.Controls.Add(this.GBandText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RBandText);
            this.Controls.Add(this.graphInfo);
            this.Controls.Add(this.iniMatching);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grayBandText);
            this.Name = "MatchForm";
            this.Text = "图像规定化";
            this.Load += new System.EventHandler(this.MatchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox grayBandText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button iniMatching;
        private System.Windows.Forms.Label graphInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RBandText;
        private System.Windows.Forms.TextBox GBandText;
        private System.Windows.Forms.TextBox BBandText;
    }
}
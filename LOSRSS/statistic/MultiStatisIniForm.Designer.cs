namespace LOSRSS.statistic
{
    partial class MultiStatisIniForm
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
            this.graphInfo = new System.Windows.Forms.Label();
            this.InputBands = new System.Windows.Forms.Label();
            this.Band1Text = new System.Windows.Forms.TextBox();
            this.Band2Text = new System.Windows.Forms.TextBox();
            this.计算双波段统计量 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // graphInfo
            // 
            this.graphInfo.AutoSize = true;
            this.graphInfo.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.graphInfo.Location = new System.Drawing.Point(12, 9);
            this.graphInfo.Name = "graphInfo";
            this.graphInfo.Size = new System.Drawing.Size(82, 31);
            this.graphInfo.TabIndex = 4;
            this.graphInfo.Text = "label1";
            // 
            // InputBands
            // 
            this.InputBands.AutoSize = true;
            this.InputBands.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.InputBands.Location = new System.Drawing.Point(12, 54);
            this.InputBands.Name = "InputBands";
            this.InputBands.Size = new System.Drawing.Size(158, 31);
            this.InputBands.TabIndex = 5;
            this.InputBands.Text = "在此输入波段";
            // 
            // Band1Text
            // 
            this.Band1Text.Location = new System.Drawing.Point(18, 102);
            this.Band1Text.Name = "Band1Text";
            this.Band1Text.Size = new System.Drawing.Size(100, 28);
            this.Band1Text.TabIndex = 6;
            this.Band1Text.TextChanged += new System.EventHandler(this.Band1Text_TextChanged);
            this.Band1Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Band1Text_KeyPress);
            // 
            // Band2Text
            // 
            this.Band2Text.Location = new System.Drawing.Point(148, 102);
            this.Band2Text.Name = "Band2Text";
            this.Band2Text.Size = new System.Drawing.Size(100, 28);
            this.Band2Text.TabIndex = 7;
            this.Band2Text.TextChanged += new System.EventHandler(this.Band2Text_TextChanged);
            this.Band2Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Band2Text_KeyPress);
            // 
            // 计算双波段统计量
            // 
            this.计算双波段统计量.Location = new System.Drawing.Point(18, 150);
            this.计算双波段统计量.Name = "计算双波段统计量";
            this.计算双波段统计量.Size = new System.Drawing.Size(162, 34);
            this.计算双波段统计量.TabIndex = 8;
            this.计算双波段统计量.Text = "计算双波段统计量";
            this.计算双波段统计量.UseVisualStyleBackColor = true;
            this.计算双波段统计量.Click += new System.EventHandler(this.计算双波段统计量_Click);
            // 
            // MultiStatisIniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 202);
            this.Controls.Add(this.计算双波段统计量);
            this.Controls.Add(this.Band2Text);
            this.Controls.Add(this.Band1Text);
            this.Controls.Add(this.InputBands);
            this.Controls.Add(this.graphInfo);
            this.Name = "MultiStatisIniForm";
            this.Text = "双波段统计";
            this.Load += new System.EventHandler(this.MultiStatisIni_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label graphInfo;
        private System.Windows.Forms.Label InputBands;
        private System.Windows.Forms.TextBox Band1Text;
        private System.Windows.Forms.TextBox Band2Text;
        private System.Windows.Forms.Button 计算双波段统计量;
    }
}
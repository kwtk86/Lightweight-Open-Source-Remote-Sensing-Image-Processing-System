namespace LOSRSS
{
    partial class BandForm
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
            this.displayGraph = new System.Windows.Forms.Button();
            this.grayButton = new System.Windows.Forms.RadioButton();
            this.colorButton = new System.Windows.Forms.RadioButton();
            this.graphInfo = new System.Windows.Forms.Label();
            this.grayBandText = new System.Windows.Forms.TextBox();
            this.colorBandText1 = new System.Windows.Forms.TextBox();
            this.colorBandText3 = new System.Windows.Forms.TextBox();
            this.colorBandText2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.coordLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.图像校正ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.内部平均法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.平场法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.暗像元法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基本统计量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.协方差ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.直方图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算协方差矩阵ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算相关系数矩阵ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存选中图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allBandsListBox = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayGraph
            // 
            this.displayGraph.Location = new System.Drawing.Point(18, 366);
            this.displayGraph.Name = "displayGraph";
            this.displayGraph.Size = new System.Drawing.Size(128, 44);
            this.displayGraph.TabIndex = 0;
            this.displayGraph.Text = "显示图像";
            this.displayGraph.UseVisualStyleBackColor = true;
            this.displayGraph.Click += new System.EventHandler(this.DisplayGraph_Click);
            // 
            // grayButton
            // 
            this.grayButton.AutoSize = true;
            this.grayButton.Location = new System.Drawing.Point(17, 286);
            this.grayButton.Name = "grayButton";
            this.grayButton.Size = new System.Drawing.Size(141, 22);
            this.grayButton.TabIndex = 1;
            this.grayButton.TabStop = true;
            this.grayButton.Text = "显示灰度图像";
            this.grayButton.UseVisualStyleBackColor = true;
            this.grayButton.CheckedChanged += new System.EventHandler(this.grayButton_CheckedChanged);
            // 
            // colorButton
            // 
            this.colorButton.AutoSize = true;
            this.colorButton.Location = new System.Drawing.Point(17, 332);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(141, 22);
            this.colorButton.TabIndex = 2;
            this.colorButton.TabStop = true;
            this.colorButton.Text = "显示彩色图像";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.CheckedChanged += new System.EventHandler(this.colorButton_CheckedChanged);
            // 
            // graphInfo
            // 
            this.graphInfo.AutoSize = true;
            this.graphInfo.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.graphInfo.Location = new System.Drawing.Point(12, 195);
            this.graphInfo.Name = "graphInfo";
            this.graphInfo.Size = new System.Drawing.Size(82, 31);
            this.graphInfo.TabIndex = 3;
            this.graphInfo.Text = "label1";
            // 
            // grayBandText
            // 
            this.grayBandText.Location = new System.Drawing.Point(176, 280);
            this.grayBandText.Name = "grayBandText";
            this.grayBandText.Size = new System.Drawing.Size(64, 28);
            this.grayBandText.TabIndex = 5;
            this.grayBandText.TextChanged += new System.EventHandler(this.grayBandText_TextChanged);
            this.grayBandText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GrayBandText_KeyPress);
            // 
            // colorBandText1
            // 
            this.colorBandText1.Location = new System.Drawing.Point(176, 332);
            this.colorBandText1.Name = "colorBandText1";
            this.colorBandText1.Size = new System.Drawing.Size(64, 28);
            this.colorBandText1.TabIndex = 7;
            this.colorBandText1.TextChanged += new System.EventHandler(this.colorBandText1_TextChanged);
            this.colorBandText1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.colorBandText1_KeyPress);
            // 
            // colorBandText3
            // 
            this.colorBandText3.Location = new System.Drawing.Point(334, 332);
            this.colorBandText3.Name = "colorBandText3";
            this.colorBandText3.Size = new System.Drawing.Size(64, 28);
            this.colorBandText3.TabIndex = 8;
            this.colorBandText3.TextChanged += new System.EventHandler(this.colorBandText3_TextChanged);
            this.colorBandText3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.colorBandText3_KeyPress);
            // 
            // colorBandText2
            // 
            this.colorBandText2.Location = new System.Drawing.Point(254, 332);
            this.colorBandText2.Name = "colorBandText2";
            this.colorBandText2.Size = new System.Drawing.Size(64, 28);
            this.colorBandText2.TabIndex = 9;
            this.colorBandText2.TextChanged += new System.EventHandler(this.colorBandText2_TextChanged);
            this.colorBandText2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.colorBandText2_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "灰度波段";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "G";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(173, 311);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "R";
            // 
            // coordLabel
            // 
            this.coordLabel.AutoSize = true;
            this.coordLabel.BackColor = System.Drawing.Color.Transparent;
            this.coordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.coordLabel.Location = new System.Drawing.Point(356, 425);
            this.coordLabel.Name = "coordLabel";
            this.coordLabel.Size = new System.Drawing.Size(53, 20);
            this.coordLabel.TabIndex = 15;
            this.coordLabel.Text = "label1";
            this.coordLabel.Visible = false;
            this.coordLabel.TextChanged += new System.EventHandler(this.CoordLabel_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图像校正ToolStripMenuItem,
            this.图像统计ToolStripMenuItem,
            this.保存ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(409, 32);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 图像校正ToolStripMenuItem
            // 
            this.图像校正ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.内部平均法ToolStripMenuItem,
            this.平场法ToolStripMenuItem,
            this.暗像元法ToolStripMenuItem});
            this.图像校正ToolStripMenuItem.Name = "图像校正ToolStripMenuItem";
            this.图像校正ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.图像校正ToolStripMenuItem.Text = "图像校正";
            // 
            // 内部平均法ToolStripMenuItem
            // 
            this.内部平均法ToolStripMenuItem.Name = "内部平均法ToolStripMenuItem";
            this.内部平均法ToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.内部平均法ToolStripMenuItem.Text = "内部平均法";
            this.内部平均法ToolStripMenuItem.Click += new System.EventHandler(this.内部平均法ToolStripMenuItem_Click);
            // 
            // 平场法ToolStripMenuItem
            // 
            this.平场法ToolStripMenuItem.Name = "平场法ToolStripMenuItem";
            this.平场法ToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.平场法ToolStripMenuItem.Text = "平场法";
            this.平场法ToolStripMenuItem.Click += new System.EventHandler(this.平场法ToolStripMenuItem_Click);
            // 
            // 暗像元法ToolStripMenuItem
            // 
            this.暗像元法ToolStripMenuItem.Name = "暗像元法ToolStripMenuItem";
            this.暗像元法ToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.暗像元法ToolStripMenuItem.Text = "暗像元法";
            // 
            // 图像统计ToolStripMenuItem
            // 
            this.图像统计ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基本统计量ToolStripMenuItem,
            this.协方差ToolStripMenuItem,
            this.直方图ToolStripMenuItem,
            this.计算协方差矩阵ToolStripMenuItem,
            this.计算相关系数矩阵ToolStripMenuItem});
            this.图像统计ToolStripMenuItem.Name = "图像统计ToolStripMenuItem";
            this.图像统计ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.图像统计ToolStripMenuItem.Text = "图像统计";
            // 
            // 基本统计量ToolStripMenuItem
            // 
            this.基本统计量ToolStripMenuItem.Name = "基本统计量ToolStripMenuItem";
            this.基本统计量ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.基本统计量ToolStripMenuItem.Text = "单波段统计量";
            this.基本统计量ToolStripMenuItem.Click += new System.EventHandler(this.基本统计量ToolStripMenuItem_Click);
            // 
            // 协方差ToolStripMenuItem
            // 
            this.协方差ToolStripMenuItem.Name = "协方差ToolStripMenuItem";
            this.协方差ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.协方差ToolStripMenuItem.Text = "多波段统计量";
            this.协方差ToolStripMenuItem.Click += new System.EventHandler(this.协方差ToolStripMenuItem_Click);
            // 
            // 直方图ToolStripMenuItem
            // 
            this.直方图ToolStripMenuItem.Name = "直方图ToolStripMenuItem";
            this.直方图ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.直方图ToolStripMenuItem.Text = "直方图";
            this.直方图ToolStripMenuItem.Click += new System.EventHandler(this.直方图ToolStripMenuItem_Click);
            // 
            // 计算协方差矩阵ToolStripMenuItem
            // 
            this.计算协方差矩阵ToolStripMenuItem.Name = "计算协方差矩阵ToolStripMenuItem";
            this.计算协方差矩阵ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.计算协方差矩阵ToolStripMenuItem.Text = "计算协方差矩阵";
            this.计算协方差矩阵ToolStripMenuItem.Click += new System.EventHandler(this.计算协方差矩阵ToolStripMenuItem_Click);
            // 
            // 计算相关系数矩阵ToolStripMenuItem
            // 
            this.计算相关系数矩阵ToolStripMenuItem.Name = "计算相关系数矩阵ToolStripMenuItem";
            this.计算相关系数矩阵ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.计算相关系数矩阵ToolStripMenuItem.Text = "计算相关系数矩阵";
            this.计算相关系数矩阵ToolStripMenuItem.Click += new System.EventHandler(this.计算相关系数矩阵ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存选中图像ToolStripMenuItem});
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.保存ToolStripMenuItem.Text = "图像管理";
            // 
            // 保存选中图像ToolStripMenuItem
            // 
            this.保存选中图像ToolStripMenuItem.Name = "保存选中图像ToolStripMenuItem";
            this.保存选中图像ToolStripMenuItem.Size = new System.Drawing.Size(218, 34);
            this.保存选中图像ToolStripMenuItem.Text = "保存选中图像";
            this.保存选中图像ToolStripMenuItem.Click += new System.EventHandler(this.保存选中图像ToolStripMenuItem_Click);
            // 
            // allBandsListBox
            // 
            this.allBandsListBox.FormattingEnabled = true;
            this.allBandsListBox.ItemHeight = 18;
            this.allBandsListBox.Location = new System.Drawing.Point(17, 52);
            this.allBandsListBox.Name = "allBandsListBox";
            this.allBandsListBox.Size = new System.Drawing.Size(373, 130);
            this.allBandsListBox.TabIndex = 17;
            this.allBandsListBox.SelectedIndexChanged += new System.EventHandler(this.AllBandsListBox_SelectedIndexChanged);
            // 
            // BandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 454);
            this.Controls.Add(this.allBandsListBox);
            this.Controls.Add(this.coordLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.colorBandText2);
            this.Controls.Add(this.colorBandText3);
            this.Controls.Add(this.colorBandText1);
            this.Controls.Add(this.grayBandText);
            this.Controls.Add(this.graphInfo);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.grayButton);
            this.Controls.Add(this.displayGraph);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BandForm";
            this.Text = "波段管理";
            this.Load += new System.EventHandler(this.BandForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button displayGraph;
        private System.Windows.Forms.RadioButton grayButton;
        private System.Windows.Forms.RadioButton colorButton;
        private System.Windows.Forms.Label graphInfo;
        private System.Windows.Forms.TextBox grayBandText;
        private System.Windows.Forms.TextBox colorBandText1;
        private System.Windows.Forms.TextBox colorBandText3;
        private System.Windows.Forms.TextBox colorBandText2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label coordLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 图像统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 基本统计量ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 协方差ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 直方图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算协方差矩阵ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算相关系数矩阵ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像校正ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 内部平均法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 平场法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 暗像元法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存选中图像ToolStripMenuItem;
        private System.Windows.Forms.ListBox allBandsListBox;
    }
}
namespace LOSRSS
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.输入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载波段ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据转换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bSQ转BILToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bSQ转BIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.多波段合成BSQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyRecord = new System.Windows.Forms.Label();
            this.hisRecords = new System.Windows.Forms.ListBox();
            this.historyButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.输入ToolStripMenuItem,
            this.数据转换ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(565, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 输入ToolStripMenuItem
            // 
            this.输入ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加载波段ToolStripMenuItem});
            this.输入ToolStripMenuItem.Name = "输入ToolStripMenuItem";
            this.输入ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.输入ToolStripMenuItem.Text = "图像显示";
            // 
            // 加载波段ToolStripMenuItem
            // 
            this.加载波段ToolStripMenuItem.Name = "加载波段ToolStripMenuItem";
            this.加载波段ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.加载波段ToolStripMenuItem.Text = "加载波段";
            this.加载波段ToolStripMenuItem.Click += new System.EventHandler(this.加载波段ToolStripMenuItem_Click);
            // 
            // 数据转换ToolStripMenuItem
            // 
            this.数据转换ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bSQ转BILToolStripMenuItem,
            this.bSQ转BIPToolStripMenuItem,
            this.多波段合成BSQToolStripMenuItem});
            this.数据转换ToolStripMenuItem.Name = "数据转换ToolStripMenuItem";
            this.数据转换ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.数据转换ToolStripMenuItem.Text = "数据转换";
            // 
            // bSQ转BILToolStripMenuItem
            // 
            this.bSQ转BILToolStripMenuItem.Name = "bSQ转BILToolStripMenuItem";
            this.bSQ转BILToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.bSQ转BILToolStripMenuItem.Text = "BSQ转BIL";
            this.bSQ转BILToolStripMenuItem.Click += new System.EventHandler(this.BSQ转BILToolStripMenuItem_Click);
            // 
            // bSQ转BIPToolStripMenuItem
            // 
            this.bSQ转BIPToolStripMenuItem.Name = "bSQ转BIPToolStripMenuItem";
            this.bSQ转BIPToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.bSQ转BIPToolStripMenuItem.Text = "BSQ转BIP";
            this.bSQ转BIPToolStripMenuItem.Click += new System.EventHandler(this.BSQ转BIPToolStripMenuItem_Click);
            // 
            // 多波段合成BSQToolStripMenuItem
            // 
            this.多波段合成BSQToolStripMenuItem.Name = "多波段合成BSQToolStripMenuItem";
            this.多波段合成BSQToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.多波段合成BSQToolStripMenuItem.Text = "多波段合成BSQ";
            this.多波段合成BSQToolStripMenuItem.Click += new System.EventHandler(this.多波段合成BSQToolStripMenuItem_Click);
            // 
            // historyRecord
            // 
            this.historyRecord.AutoSize = true;
            this.historyRecord.Location = new System.Drawing.Point(12, 45);
            this.historyRecord.Name = "historyRecord";
            this.historyRecord.Size = new System.Drawing.Size(74, 21);
            this.historyRecord.TabIndex = 1;
            this.historyRecord.Text = "历史记录";
            // 
            // hisRecords
            // 
            this.hisRecords.FormattingEnabled = true;
            this.hisRecords.ItemHeight = 21;
            this.hisRecords.Location = new System.Drawing.Point(12, 77);
            this.hisRecords.Name = "hisRecords";
            this.hisRecords.Size = new System.Drawing.Size(383, 130);
            this.hisRecords.TabIndex = 3;
            // 
            // historyButton
            // 
            this.historyButton.BackColor = System.Drawing.Color.White;
            this.historyButton.Location = new System.Drawing.Point(401, 153);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(162, 51);
            this.historyButton.TabIndex = 4;
            this.historyButton.Text = "加载历史记录";
            this.historyButton.UseVisualStyleBackColor = false;
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(565, 216);
            this.Controls.Add(this.historyButton);
            this.Controls.Add(this.hisRecords);
            this.Controls.Add(this.historyRecord);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "miniOSRSS";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 输入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据转换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载波段ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bSQ转BILToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bSQ转BIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 多波段合成BSQToolStripMenuItem;
        private System.Windows.Forms.Label historyRecord;
        private System.Windows.Forms.ListBox hisRecords;
        private System.Windows.Forms.Button historyButton;
    }
}


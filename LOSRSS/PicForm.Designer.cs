namespace LOSRSS
{
    partial class PicForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.图像增强ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.恢复原状ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增强ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像规定化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置规定化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示规定化结果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像均衡化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像分割ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oTSUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最佳阈值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallPicBox = new System.Windows.Forms.PictureBox();
            this.mainPicBox = new System.Windows.Forms.PictureBox();
            this.picTestBox = new System.Windows.Forms.TextBox();
            this.分割依据波段 = new System.Windows.Forms.Label();
            this.bandComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smallPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图像增强ToolStripMenuItem,
            this.图像分割ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(901, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 图像增强ToolStripMenuItem
            // 
            this.图像增强ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.恢复原状ToolStripMenuItem,
            this.增强ToolStripMenuItem,
            this.图像规定化ToolStripMenuItem,
            this.图像均衡化ToolStripMenuItem});
            this.图像增强ToolStripMenuItem.Name = "图像增强ToolStripMenuItem";
            this.图像增强ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.图像增强ToolStripMenuItem.Text = "图像增强";
            // 
            // 恢复原状ToolStripMenuItem
            // 
            this.恢复原状ToolStripMenuItem.Name = "恢复原状ToolStripMenuItem";
            this.恢复原状ToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.恢复原状ToolStripMenuItem.Text = "恢复原状";
            this.恢复原状ToolStripMenuItem.Click += new System.EventHandler(this.恢复原状ToolStripMenuItem_Click);
            // 
            // 增强ToolStripMenuItem
            // 
            this.增强ToolStripMenuItem.Name = "增强ToolStripMenuItem";
            this.增强ToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.增强ToolStripMenuItem.Text = "2%增强";
            this.增强ToolStripMenuItem.Click += new System.EventHandler(this.增强ToolStripMenuItem_Click);
            // 
            // 图像规定化ToolStripMenuItem
            // 
            this.图像规定化ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置规定化ToolStripMenuItem,
            this.显示规定化结果ToolStripMenuItem});
            this.图像规定化ToolStripMenuItem.Name = "图像规定化ToolStripMenuItem";
            this.图像规定化ToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.图像规定化ToolStripMenuItem.Text = "图像规定化";
            // 
            // 设置规定化ToolStripMenuItem
            // 
            this.设置规定化ToolStripMenuItem.Name = "设置规定化ToolStripMenuItem";
            this.设置规定化ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.设置规定化ToolStripMenuItem.Text = "设置规定化";
            this.设置规定化ToolStripMenuItem.Click += new System.EventHandler(this.设置规定化ToolStripMenuItem_Click);
            // 
            // 显示规定化结果ToolStripMenuItem
            // 
            this.显示规定化结果ToolStripMenuItem.Enabled = false;
            this.显示规定化结果ToolStripMenuItem.Name = "显示规定化结果ToolStripMenuItem";
            this.显示规定化结果ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.显示规定化结果ToolStripMenuItem.Text = "显示规定化结果";
            this.显示规定化结果ToolStripMenuItem.Click += new System.EventHandler(this.显示规定化结果ToolStripMenuItem_Click);
            // 
            // 图像均衡化ToolStripMenuItem
            // 
            this.图像均衡化ToolStripMenuItem.Name = "图像均衡化ToolStripMenuItem";
            this.图像均衡化ToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.图像均衡化ToolStripMenuItem.Text = "图像均衡化";
            this.图像均衡化ToolStripMenuItem.Click += new System.EventHandler(this.图像均衡化ToolStripMenuItem_Click);
            // 
            // 图像分割ToolStripMenuItem
            // 
            this.图像分割ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oTSUToolStripMenuItem,
            this.最佳阈值ToolStripMenuItem});
            this.图像分割ToolStripMenuItem.Name = "图像分割ToolStripMenuItem";
            this.图像分割ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.图像分割ToolStripMenuItem.Text = "图像分割";
            // 
            // oTSUToolStripMenuItem
            // 
            this.oTSUToolStripMenuItem.Name = "oTSUToolStripMenuItem";
            this.oTSUToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.oTSUToolStripMenuItem.Text = "OTSU";
            this.oTSUToolStripMenuItem.Click += new System.EventHandler(this.OTSUToolStripMenuItem_Click);
            // 
            // 最佳阈值ToolStripMenuItem
            // 
            this.最佳阈值ToolStripMenuItem.Name = "最佳阈值ToolStripMenuItem";
            this.最佳阈值ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.最佳阈值ToolStripMenuItem.Text = "最佳阈值";
            this.最佳阈值ToolStripMenuItem.Click += new System.EventHandler(this.最佳阈值ToolStripMenuItem_Click);
            // 
            // smallPicBox
            // 
            this.smallPicBox.Location = new System.Drawing.Point(635, 409);
            this.smallPicBox.Name = "smallPicBox";
            this.smallPicBox.Size = new System.Drawing.Size(230, 230);
            this.smallPicBox.TabIndex = 1;
            this.smallPicBox.TabStop = false;
            // 
            // mainPicBox
            // 
            this.mainPicBox.Location = new System.Drawing.Point(13, 41);
            this.mainPicBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainPicBox.Name = "mainPicBox";
            this.mainPicBox.Size = new System.Drawing.Size(600, 600);
            this.mainPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainPicBox.TabIndex = 2;
            this.mainPicBox.TabStop = false;
            this.mainPicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPicBox_MouseMove);
            // 
            // picTestBox
            // 
            this.picTestBox.Location = new System.Drawing.Point(891, 655);
            this.picTestBox.Name = "picTestBox";
            this.picTestBox.Size = new System.Drawing.Size(10, 28);
            this.picTestBox.TabIndex = 3;
            this.picTestBox.Visible = false;
            // 
            // 分割依据波段
            // 
            this.分割依据波段.AutoSize = true;
            this.分割依据波段.Location = new System.Drawing.Point(635, 42);
            this.分割依据波段.Name = "分割依据波段";
            this.分割依据波段.Size = new System.Drawing.Size(116, 18);
            this.分割依据波段.TabIndex = 4;
            this.分割依据波段.Text = "分割依据波段";
            // 
            // bandComboBox
            // 
            this.bandComboBox.FormattingEnabled = true;
            this.bandComboBox.Location = new System.Drawing.Point(638, 63);
            this.bandComboBox.Name = "bandComboBox";
            this.bandComboBox.Size = new System.Drawing.Size(121, 26);
            this.bandComboBox.TabIndex = 5;
            // 
            // PicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 683);
            this.Controls.Add(this.bandComboBox);
            this.Controls.Add(this.分割依据波段);
            this.Controls.Add(this.picTestBox);
            this.Controls.Add(this.mainPicBox);
            this.Controls.Add(this.smallPicBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PicForm";
            this.Text = "图像显示";
            this.Load += new System.EventHandler(this.PicForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smallPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox smallPicBox;
        private System.Windows.Forms.ToolStripMenuItem 图像增强ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增强ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像规定化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 恢复原状ToolStripMenuItem;
        private System.Windows.Forms.PictureBox mainPicBox;
        private System.Windows.Forms.TextBox picTestBox;
        private System.Windows.Forms.ToolStripMenuItem 图像均衡化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示规定化结果ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置规定化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像分割ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oTSUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最佳阈值ToolStripMenuItem;
        private System.Windows.Forms.Label 分割依据波段;
        private System.Windows.Forms.ComboBox bandComboBox;
    }
}
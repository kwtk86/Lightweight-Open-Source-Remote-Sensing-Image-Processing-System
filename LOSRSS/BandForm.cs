using LOSRSS.Correction;
using LOSRSS.files;
using LOSRSS.funtions;
using LOSRSS.statistic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace LOSRSS
{
    /// <summary>
    /// BandForm用于展示图像包含的波段，作为显示的前奏
    /// </summary>
    public partial class BandForm : Form
    {
        private FileReader _curBands;
        private int[] colorBandIndex = new int[3];//记录待加载的彩色波段
        public FileReader CurBands { get => _curBands; set => _curBands = value; }
        //储存所有可能用到的波段
        private List<FileReader> allBands = new List<FileReader>();
        //关于小窗同步的委托事件
        public delegate void labelCoordChange(int [] centerCoord);
        public event labelCoordChange LabelCoordChangeEvent;
        public BandForm(string fileName)
        {
            CurBands = new FileReader(fileName);
            allBands.Add(CurBands);
            InitializeComponent();
            UpdateListBox();
            graphInfo.Text = "当前图像：" + CurBands.GraphName + "\n波段数:" + CurBands.Bands.ToString();
        }
        #region 控件管理
        /// <summary>
        /// 更新listbox
        /// </summary>
        private void UpdateListBox()
        {
            int length = allBands.Count;
            allBandsListBox.Items.Add(allBands[length - 1].GraphName);
        }
        /// <summary>
        /// 选择需要的图像
        /// </summary>
        private void AllBandsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectIndex = allBandsListBox.SelectedIndex;
                CurBands = allBands[selectIndex];
                graphInfo.Text = "当前图像：" + CurBands.GraphName + "\n波段数:" + CurBands.Bands.ToString();
            }
            catch { }
       }
        private void BandForm_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 显示图像
        /// </summary>
        private void DisplayGraph_Click(object sender, EventArgs e)
        {

            //灰度
            if(GetGraphType() == 1)
            {
                if(grayBandText.Text == "")
                {
                    return;
                }
                int[] grayBandIndex = new int[1]; 
                grayBandIndex[0] = Convert.ToInt32(grayBandText.Text);
                CurBands.SetGrayGraph(grayBandIndex[0]);
                PicForm newPicForm = new PicForm(CurBands, grayBandIndex, GetGraphType(), this);
                //初始化事件
                newPicForm.MouseMoveEvent += new PicForm.mouseMove(PicMouseMove);
                newPicForm.Show();
            }
            //彩色图像
            else
            {
                try
                {
                    colorBandIndex[0] = Convert.ToInt32(colorBandText1.Text) - 1;
                    colorBandIndex[1] = Convert.ToInt32(colorBandText2.Text) - 1;
                    colorBandIndex[2] = Convert.ToInt32(colorBandText3.Text) - 1;
                    CurBands.SetColorGraph(colorBandIndex[0], colorBandIndex[1], colorBandIndex[2]);
                    PicForm newPicForm = new PicForm(CurBands, colorBandIndex, GetGraphType(), this);
                    newPicForm.MouseMoveEvent += new PicForm.mouseMove(PicMouseMove);
                    newPicForm.Show();
                }
                catch
                {
                    return;
                }
            }
        }
        /// <summary>
        /// 获取被选中的ratiobutton，确定图像是灰度还是彩色。
        /// </summary>
        private int GetGraphType()
        {
            return grayButton.Checked ? 1 : 2;
        }
        #region 文本框数字范围控制及输入控制
        private void GrayBandText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (Char)8)
            {
                e.Handled = true;
            }
        }

        private void colorBandText1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (Char)8)
            {
                e.Handled = true;
            }
        }

        private void colorBandText2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (Char)8)
            {
                e.Handled = true;
            }
        }

        private void colorBandText3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (Char)8)
            {
                e.Handled = true;
            }
        }

        private void grayBandText_TextChanged(object sender, EventArgs e)
        {
            if(grayBandText.Text == "")
            {
                return;
            }
            int number = int.Parse(grayBandText.Text);
            if(number<=0 || number > this.CurBands.Bands)
            {
                MessageBox.Show("超出波段范围！");
                grayBandText.Text = "";
            }
        }

        private void colorBandText1_TextChanged(object sender, EventArgs e)
        {
            if (colorBandText1.Text == "")
            {
                return;
            }
            int number = int.Parse(colorBandText1.Text);
            if (number <= 0 || number > CurBands.Bands)
            {
                MessageBox.Show("超出波段范围！");
                colorBandText1.Text = "";
            }
        }

        private void colorBandText2_TextChanged(object sender, EventArgs e)
        {
            if (colorBandText2.Text == "")
            {
                return;
            }
            int number = int.Parse(colorBandText2.Text);
            if (number <= 0 || number > this.CurBands.Bands)
            {
                MessageBox.Show("超出波段范围！");
                colorBandText2.Text = "";
            }
        }

        private void colorBandText3_TextChanged(object sender, EventArgs e)
        {
            if (colorBandText3.Text == "")
            {
                return;
            }
            int number = int.Parse(colorBandText3.Text);
            if (number <= 0 || number > this.CurBands.Bands)
            {
                MessageBox.Show("超出波段范围！");
                colorBandText3.Text = "";
            }
        }

        private void grayButton_CheckedChanged(object sender, EventArgs e)
        {
            grayBandText.Focus();
        }

        private void colorButton_CheckedChanged(object sender, EventArgs e)
        {
            colorBandText1.Focus();
        }
        #endregion
        #endregion
        #region 同步视窗控制
        /// <summary>
        /// 引用的委托
        /// </summary>
        /// <param name="centerCoords"></param>
        void PicMouseMove(int[] centerCoords)
        {
            coordLabel.Text = centerCoords[0].ToString() + "," + centerCoords[1].ToString();
        }
        /// <summary>
        /// label作为中转，触发多个窗口的鹰眼图移动。
        /// </summary>
        private void CoordLabel_TextChanged(object sender, EventArgs e)
        {
            int[] tempArray = new int[2];
            tempArray[0] = Convert.ToInt32(coordLabel.Text.Split(',')[0]);
            tempArray[1] = Convert.ToInt32(coordLabel.Text.Split(',')[1]);
            LabelCoordChangeEvent(tempArray);
        }
        #endregion
        #region 波段统计
        private void 基本统计量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[] avgBands = SingleStatis.Avg(CurBands);
            double[] devBands = SingleStatis.Dev(CurBands, avgBands);
            double[] contrastBands = SingleStatis.Contrast(CurBands);
            double[] entropyBands = SingleStatis.Entropy(CurBands);
            SingleStatisForm basicStatis = new SingleStatisForm(avgBands, devBands, contrastBands, entropyBands);
            basicStatis.ShowDialog();

        }

        private void 协方差ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiStatisIniForm multiStatis = new MultiStatisIniForm(CurBands);
            multiStatis.Show();
        }

        private void 计算协方差矩阵ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatrixForm matrix = new MatrixForm(CurBands, "covariance");
            
            matrix.Show();
        }

        private void 计算相关系数矩阵ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatrixForm matrix = new MatrixForm(CurBands, "correlation");
            matrix.Show();
            
        }

        private void 直方图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoGraph histo = new HistoGraph(CurBands);
            histo.Show();
        }
        #endregion
        #region 图像校正
        private static int[] fieldExtent = new int[4];
        private void 内部平均法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InAvgCorrection avgCorrector = new InAvgCorrection(CurBands.GraphInner);
            byte[,,] newBand = avgCorrector.Correct(avgCorrector.Average);
            FileReader newDataFile = new FileReader(CurBands.GraphName + "_avgCorrection", newBand, CurBands.headInner);
            allBands.Add(newDataFile);
            UpdateListBox();
        }
        private void 平场法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (showFlatForm())
                {
                    fieldExtent = valueConvey.FlatFieldExtent;
                    FlatFieldCorrection flatFieldCorrection = new FlatFieldCorrection(CurBands.GraphInner, fieldExtent);
                    byte[,,] relaBand = flatFieldCorrection.Correct(flatFieldCorrection.Average);
                    FileReader newDataFile = new FileReader(CurBands.GraphName + "_flatCorrection", relaBand, CurBands.headInner);
                    allBands.Add(newDataFile);
                    UpdateListBox();
                }

            }
            catch
            {
                return;
            }
        }
        private bool showFlatForm()
        {
            if (GetGraphType() == 1)
            {
                if (grayBandText.Text == "")
                {
                    MessageBox.Show("必须确定波段才能平场域纠正");
                    return false;
                }
                int grayBand = Convert.ToInt32(grayBandText.Text);
                CurBands.SetGrayGraph(grayBand);
                FlatFieldForm flatFieldForm = new FlatFieldForm(CurBands, GetGraphType(), this);
                flatFieldForm.ShowDialog();
                fieldExtent = valueConvey.FlatFieldExtent;
                //初始化事件
                return true;
            }

            //彩色图像
            else
            {
                if (colorBandText1.Text == "" || colorBandText2.Text == "" || colorBandText3.Text == "")
                {
                    MessageBox.Show("必须确定波段才能平场域纠正");
                    return false;
                }
                colorBandIndex[0] = Convert.ToInt32(colorBandText1.Text) - 1;
                colorBandIndex[1] = Convert.ToInt32(colorBandText2.Text) - 1;
                colorBandIndex[2] = Convert.ToInt32(colorBandText3.Text) - 1;
                CurBands.SetColorGraph(colorBandIndex[0], colorBandIndex[1], colorBandIndex[2]);
                FlatFieldForm flatFieldForm = new FlatFieldForm(CurBands, GetGraphType(), this);
                flatFieldForm.Show();
                return true;
            }
        }
        #endregion
        #region 图像管理
        private void 保存选中图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileSaver = new SaveFileDialog();
            fileSaver.Filter = "头文件|*.hdr";
            //保存文件
            if (fileSaver.ShowDialog() == DialogResult.OK)
            {
                FileWriter curFileSaver = new FileWriter(fileSaver.FileName, GraphConvert.BandMerger(CurBands.GraphInner), CurBands.headInner);
                curFileSaver.saveHeadFile();
                curFileSaver.saveGraphFile();
            }
        }
        #endregion

        private void 保存选中波段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BandSelectForm bandSelectForm = new BandSelectForm(CurBands.GraphFileName, CurBands.Bands);
            if(bandSelectForm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}

using LOSRSS.files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOSRSS.statistic
{
    public partial class HistoGraph : Form
    {
        private byte[,] grayGraph;
        private byte[,,] colorGraph;
        private byte[,,] graphInner;
        private FileReader curBands;
        private int samples;
        private int lines;
        private int bands;
        public HistoGraph(FileReader curBands)
        {
            this.CurBands = curBands;
            InitializeComponent();
            graphInfo.Text = "当前图像波段数:" + CurBands.Bands.ToString();
            this.Samples = CurBands.Samples;
            this.Lines = CurBands.Lines;
            this.Bands = CurBands.Bands;
            this.GraphInner = CurBands.GraphInner;
            BandTextBox.Focus();
        }

        public FileReader CurBands { get => curBands; set => curBands = value; }
        public byte[,] GrayGraph { get => grayGraph; set => grayGraph = value; }
        public byte[,,] ColorGraph { get => colorGraph; set => colorGraph = value; }
        public byte[,,] GraphInner { get => graphInner; set => graphInner = value; }
        public int Samples { get => samples; set => samples = value; }
        public int Lines { get => lines; set => lines = value; }
        public int Bands { get => bands; set => bands = value; }

        private void HistoGraph_Load(object sender, EventArgs e)
        {

        }
        #region 控制输入范围
        private void BandTextBox_TextChanged(object sender, EventArgs e)
        {
            if (BandTextBox.Text == "")
            {
                return;
            }
            int number = int.Parse(BandTextBox.Text);
            if (number <= 0 || number > CurBands.Bands)
            {
                MessageBox.Show("超出波段范围！");
                BandTextBox.Text = "";
            }
        }

        private void BandTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (Char)8)
            {
                e.Handled = true;
            }
        }
        #endregion
        #region 控件控制
        private void ShowHistoButton_Click(object sender, EventArgs e)
        {
            if (BandTextBox.Text == "") 
            {
                return;
            }
            int bandNum = int.Parse(BandTextBox.Text) - 1;
            byte[] histoBand = GraphConvert.BandMerger(GraphConvert.BandSplit(this.graphInner, bandNum));
            int[] countPixel = BasicStatis.GetPixelCount(histoBand);
            DrawHisto(countPixel);
        }
        private void ShowCumuHistoButton_Click(object sender, EventArgs e)
        {
            if (BandTextBox.Text == "")
            {
                return;
            }
            int bandNum = int.Parse(BandTextBox.Text) - 1;
            byte[] histoBand = GraphConvert.BandMerger(GraphConvert.BandSplit(this.graphInner, bandNum));
            int[] accumPixel = BasicStatis.GetAccumCount(histoBand);
            DrawHisto(accumPixel);
        }
        #endregion
        /// <summary>
        /// 生成直方图
        /// </summary>
        /// <param name="countPixel">频数数组</param>
        private void DrawHisto(int[] countPixel)
        {
            //灰度值个数的最大值
            int maxPixel = 0;
            for (int i = 0; i < 256; i++)
            {
                if (countPixel[i] > maxPixel)
                {
                    maxPixel = countPixel[i];
                }
            }
            Graphics graph = pictureBox1.CreateGraphics();
            graph.Clear(Color.FromArgb(240, 240, 240));

            //创建一个宽度为1的黑色钢笔
            Pen curPen = new Pen(Brushes.Black, 1);
            //绘制坐标轴
            //（y，x）=(50,240)原点；
            graph.DrawLine(curPen, 50, 240, 320, 240);//横坐标
            graph.DrawLine(curPen, 50, 240, 50, 30);//纵坐标
            //绘制并标识坐标刻度
            graph.DrawLine(curPen, 100, 240, 100, 242);
            graph.DrawLine(curPen, 150, 240, 150, 242);
            graph.DrawLine(curPen, 200, 240, 200, 242);
            graph.DrawLine(curPen, 250, 240, 250, 242);
            graph.DrawLine(curPen, 300, 240, 300, 242);
            graph.DrawString("0", new Font("New Timer", 8), Brushes.Black, new PointF(46, 242));
            graph.DrawString("50", new Font("New Timer", 8), Brushes.Black, new PointF(92, 242));
            graph.DrawString("100", new Font("New Timer", 8), Brushes.Black, new PointF(139, 242));
            graph.DrawString("150", new Font("New Timer", 8), Brushes.Black, new PointF(189, 242));
            graph.DrawString("200", new Font("New Timer", 8), Brushes.Black, new PointF(239, 242));
            graph.DrawString("250", new Font("New Timer", 8), Brushes.Black, new PointF(289, 242));
            graph.DrawLine(curPen, 48, 40, 50, 40);
            graph.DrawString(maxPixel.ToString(), new Font("New Timer", 8), Brushes.RosyBrown, new PointF(0, 38));
            //开始绘制直方图
            double temp = 0;
            for (int i = 0; i < 256; i++)
            {
                //计算出纵坐标的长度
                temp = 200.0 * countPixel[i] / maxPixel;
                graph.DrawLine(new Pen(Brushes.RosyBrown, 1), 50 + i, 240, 50 + i, 240 - (int)temp);
            }
            //释放对象
            curPen.Dispose();
        }
    }
}

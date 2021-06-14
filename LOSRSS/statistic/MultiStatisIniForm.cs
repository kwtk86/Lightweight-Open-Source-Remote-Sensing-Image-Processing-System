using LOSRSS.files;
using System;
using System.Windows.Forms;

namespace LOSRSS.statistic
{
    public partial class MultiStatisIniForm : Form
    {
        FileReader curBands;
        public MultiStatisIniForm(FileReader curBands)
        {
            CurBands = curBands;
            InitializeComponent();
            graphInfo.Text = "当前图像波段数:" + CurBands.Bands.ToString();
        }

        public FileReader CurBands { get => curBands; set => curBands = value; }

        private void MultiStatisIni_Load(object sender, EventArgs e)
        {

        }
        #region 控制波段输入
        private void Band1Text_TextChanged(object sender, EventArgs e)
        {
            if (Band1Text.Text == "")
            {
                return;
            }
            int number = int.Parse(Band1Text.Text);
            if (number <= 0 || number > this.CurBands.Bands)
            {
                MessageBox.Show("超出波段范围！");
                Band1Text.Text = "";
            }
        }

        private void Band2Text_TextChanged(object sender, EventArgs e)
        {
            if (Band2Text.Text == "")
            {
                return;
            }
            int number = int.Parse(Band2Text.Text);
            if (number <= 0 || number > this.CurBands.Bands)
            {
                MessageBox.Show("超出波段范围！");
                Band2Text.Text = "";
            }
        }

        private void Band1Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (Char)8)
            {
                e.Handled = true;
            }
        }

        private void Band2Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (Char)8)
            {
                e.Handled = true;
            }
        }
        #endregion

        private void 计算双波段统计量_Click(object sender, EventArgs e)
        {
            if (Band1Text.Text == "" || Band2Text.Text == "")
            {
                MessageBox.Show("请输入波段");
                return;
            }
            int b1 = int.Parse(Band1Text.Text) - 1;
            int b2 = int.Parse(Band2Text.Text) - 1;
            byte[,] band1 = GraphConvert.BandSplit(curBands.GraphInner, b1);
            byte[,] band2 = GraphConvert.BandSplit(curBands.GraphInner, b2);

            byte[] mergerdBand1 = GraphConvert.BandMerger(band1);
            byte[] mergerdBand2 = GraphConvert.BandMerger(band2);

            double unionEntropy = MultiStatis.UnionEntropy(mergerdBand1, mergerdBand2);
            double mutualInfo = MultiStatis.MutualInfo(mergerdBand1, mergerdBand2);
            double coVariance = MultiStatis.Covariance(mergerdBand1, mergerdBand2);
            double correlation = MultiStatis.Correla(mergerdBand1, mergerdBand2);
            MessageBox.Show(
                "联合熵： " + unionEntropy.ToString() +
                "\n互信息： " + mutualInfo.ToString() +
                "\n协方差： " + coVariance.ToString() +
                "\n相关系数： " + correlation.ToString()
                );
        }

    }
}

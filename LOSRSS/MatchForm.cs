using LOSRSS.files;
using LOSRSS.statistic;
using System;
using System.Windows.Forms;
namespace LOSRSS
{
    public partial class MatchForm : Form
    {
        private int bandCount;
        private FileReader curBands;
        private byte[] originGraph;
        private byte[] newGraph;

        private byte[] matchedBand1;
        private byte[] matchedBand2;
        private byte[] matchedBand3;
        private string graphType;

        private byte[] originColorGraph1;
        private byte[] originColorGraph2;
        private byte[] originColorGraph3;


        public int BandCount { get => bandCount; set => bandCount = value; }
        public FileReader CurBands { get => curBands; set => curBands = value; }
        public byte[] OriginGraph { get => originGraph; set => originGraph = value; }
        public byte[] NewGraph { get => newGraph; set => newGraph = value; }
        public string GraphType { get => graphType; set => graphType = value; }
        public byte[] OriginColorGraph1 { get => originColorGraph1; set => originColorGraph1 = value; }
        public byte[] OriginColorGraph2 { get => originColorGraph2; set => originColorGraph2 = value; }
        public byte[] OriginColorGraph3 { get => originColorGraph3; set => originColorGraph3 = value; }
        public byte[] MatchedBand1 { get => matchedBand1; set => matchedBand1 = value; }
        public byte[] MatchedBand2 { get => matchedBand2; set => matchedBand2 = value; }
        public byte[] MatchedBand3 { get => matchedBand3; set => matchedBand3 = value; }

        public MatchForm(string fileName, string graphType)
        {
            CurBands = new FileReader(fileName);
            GraphType = graphType;
            BandCount = CurBands.Bands;
            InitializeComponent();
            graphInfo.Text = "当前图像波段数：" + bandCount.ToString();
        }

        private void MatchForm_Load(object sender, EventArgs e)
        {

        }
        #region 控制输入
        private void grayBandText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (Char)8)
            {
                e.Handled = true;
            }
        }

        private void grayBandText_TextChanged(object sender, EventArgs e)
        {
            if (grayBandText.Text == "")
            {
                return;
            }
            int number = int.Parse(grayBandText.Text);
            if (number <= 0 || number > this.CurBands.Bands)
            {
                MessageBox.Show("超出波段范围！");
                grayBandText.Text = "";
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (RBandText.Text == "")
            {
                return;
            }
            int number = int.Parse(RBandText.Text);
            if (number <= 0 || number > this.CurBands.Bands)
            {
                MessageBox.Show("超出波段范围！");
                RBandText.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (GBandText.Text == "")
            {
                return;
            }
            int number = int.Parse(GBandText.Text);
            if (number <= 0 || number > this.CurBands.Bands)
            {
                MessageBox.Show("超出波段范围！");
                GBandText.Text = "";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (BBandText.Text == "")
            {
                return;
            }
            int number = int.Parse(BBandText.Text);
            if (number <= 0 || number > this.CurBands.Bands)
            {
                MessageBox.Show("超出波段范围！");
                BBandText.Text = "";
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (Char)8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (Char)8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (Char)8)
            {
                e.Handled = true;
            }
        }
#endregion
        private void iniMatching_Click(object sender, EventArgs e)
        {
            if(GraphType == "gray")
            {
                if(grayBandText.Text == "")
                {
                    return;
                }
                int band = int.Parse(grayBandText.Text) - 1;
                byte[] aimGraph = GraphConvert.BandMerger(GraphConvert.BandSplit(this.curBands.GraphInner, band));
                HistoMatch histoMa = new HistoMatch(GraphType, OriginGraph, aimGraph, 1, 1);
                NewGraph = histoMa.Match();
            }
            else
            {
                if (RBandText.Text == "" || GBandText.Text == "" || BBandText.Text == "")
                {
                    return;
                }
                int band1 = int.Parse(RBandText.Text) - 1;
                int band2 = int.Parse(GBandText.Text) - 1;
                int band3 = int.Parse(BBandText.Text) - 1;

                byte[] aimGraph1 = GraphConvert.BandMerger(GraphConvert.BandSplit(this.curBands.GraphInner, band1));
                byte[] aimGraph2 = GraphConvert.BandMerger(GraphConvert.BandSplit(this.curBands.GraphInner, band2));
                byte[] aimGraph3 = GraphConvert.BandMerger(GraphConvert.BandSplit(this.curBands.GraphInner, band3));

                HistoMatch histoMa1 = new HistoMatch(GraphType, OriginColorGraph1, aimGraph1, 1, 1);
                HistoMatch histoMa2 = new HistoMatch(GraphType, OriginColorGraph2, aimGraph2, 1, 1);
                HistoMatch histoMa3 = new HistoMatch(GraphType, OriginColorGraph3, aimGraph3, 1, 1);

                MatchedBand1 = histoMa1.Match();
                MatchedBand2 = histoMa2.Match();
                MatchedBand3 = histoMa3.Match();
            }
        }
    }
}

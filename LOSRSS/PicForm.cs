using LOSRSS.files;
using LOSRSS.statistic;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace LOSRSS
{
    public partial class PicForm : Form
    {
        private string graphType;
        private byte[,] grayGraph;
        private byte[,] backGrayGraph;
        private byte[,,] colorGraph;
        private byte[,,] backColorGraph;
        private FileReader dataFile;
        private Bitmap mainBitmap;
        private Bitmap smallBitmap;
        private readonly int samples;
        private readonly int lines;
        private int graphTypeInt;

        private MatchForm newMatchForm;
        //委托事件，传递鼠标所在坐标
        public delegate void mouseMove(int[] centerCoord);
        public event mouseMove MouseMoveEvent;
        private void PicForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 构造函数 备份原始数据-加载图像-准备坐标协同
        /// </summary>
        /// <param name="dataFile">数据文件</param>
        /// <param name="bandIndex">波段号</param>
        /// <param name="graphTypeInt">图像类型（灰度或彩色）</param>
        /// <param name="bFrm">原窗口</param>
        public PicForm(FileReader dataFile, int[] bandIndex, int graphTypeInt, BandForm bFrm)
        {
            this.graphTypeInt = graphTypeInt;
            this.dataFile = dataFile;
            InitializeComponent();
            int tempCnt = 1;
            foreach (int bandId in bandIndex)
            {
                bandComboBox.Items.Add(tempCnt);
                tempCnt++;
            }
            //初始化位图
            mainBitmap = new Bitmap(dataFile.Lines, dataFile.Samples);
            //灰度图像
            if (graphTypeInt == 1)
            {
                graphType = "gray";
                grayGraph = dataFile.GrayGraph;
                samples = dataFile.Samples;
                lines = dataFile.Lines;
                //做好备份
                backGrayGraph = (byte[,])grayGraph.Clone();
                displayGrayGraph(grayGraph);
            }
            //彩色图像
            else
            {

                graphType = "color";
                colorGraph = dataFile.ColorGraph;
                samples = dataFile.Samples;
                lines = dataFile.Lines;
                //做好备份
                backColorGraph = (byte[,,])colorGraph.Clone();
                displayColorGraph(colorGraph);
            }
            //坐标协同事件
            bFrm.LabelCoordChangeEvent += new BandForm.labelCoordChange(ChangeSmallBoxExtent);
        }
        #region 显示图像
        /// <summary>
        /// 更新主图
        /// </summary>
        /// <param name="bm">位图</param>
        private void updateMainPicBox(Bitmap bm)
        {
            mainBitmap = bm;
            mainPicBox.Image = mainBitmap;
            mainPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        /// <summary>
        /// 更新小图
        /// </summary>
        /// <param name="bm">位图</param>
        private void updateSmallPicbox(Bitmap bm)
        {
            smallBitmap = bm;
            smallPicBox.Image = bm;
            smallPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        /// <summary>
        /// 显示灰度图像
        /// </summary>
        /// <param name="newGrayGraph">二维灰度数组</param>
        private void displayGrayGraph(byte[,] newGrayGraph)
        {
            ToBitmap(newGrayGraph, mainBitmap);
            updateMainPicBox(mainBitmap);
        }
        /// <summary>
        /// 显示灰度图像
        /// </summary>
        /// <param name="newGrayGraph">一维灰度数组</param>
        private void displayGrayGraph(byte[] newGrayGraph)
        {
            ToBitmap(newGrayGraph, mainBitmap);
            updateMainPicBox(mainBitmap);
        }
        /// <summary>
        /// 显示彩图
        /// </summary>
        /// <param name="newColorGraph">三维彩图数组</param>
        private void displayColorGraph(byte[,,] newColorGraph)
        {
            ToBitmap(newColorGraph, mainBitmap);
            updateMainPicBox(mainBitmap);
        }
        /// <summary>
        /// 显示彩图
        /// </summary>
        /// <param name="colorBand1">波段1</param>
        /// <param name="colorBand2">波段2</param>
        /// <param name="colorBand3">波段3</param>
        private void displayColorGraph(byte[] colorBand1, byte[] colorBand2, byte[] colorBand3)
        {
            ToBitmap(colorBand1, colorBand2, colorBand3, mainBitmap);
            updateMainPicBox(mainBitmap);
        }
        #endregion
        #region 图像增强
        private void 图像均衡化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graphType == "gray")
            {
                HistoEqual hisEq = new HistoEqual(graphType, GraphConvert.BandMerger(grayGraph), samples, lines);
                hisEq.Equal();
                ToBitmap(hisEq.OriginGraph, mainBitmap);
                updateMainPicBox(mainBitmap);
            }
            else
            {
                HistoEqual hisEq1 = new HistoEqual(graphType, GraphConvert.BandMerger(GraphConvert.BandSplit(colorGraph, 0)), samples, lines);
                HistoEqual hisEq2 = new HistoEqual(graphType, GraphConvert.BandMerger(GraphConvert.BandSplit(colorGraph, 1)), samples, lines);
                HistoEqual hisEq3 = new HistoEqual(graphType, GraphConvert.BandMerger(GraphConvert.BandSplit(colorGraph, 2)), samples, lines);
                hisEq1.Equal();
                hisEq2.Equal();
                hisEq3.Equal();
                ToBitmap(hisEq1.OriginGraph, hisEq2.OriginGraph, hisEq3.OriginGraph, mainBitmap);
                updateMainPicBox(mainBitmap);
            }
        }


        private void 增强ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //灰度图像2%拉伸
            if (graphType == "gray")
            {
                TwoPerEnhance tpEnhance = new TwoPerEnhance("gray", GraphConvert.BandMerger(backGrayGraph), samples, lines);
                byte[] enhancedGraph = tpEnhance.EnhanceByTwoPer();
                ToBitmap(enhancedGraph, mainBitmap);
                updateMainPicBox(mainBitmap);
            }
            //彩色图像2%拉伸
            else
            {
                TwoPerEnhance tpEnhance1 = new TwoPerEnhance("color", GraphConvert.BandMerger(GraphConvert.BandSplit(backColorGraph, 0)), samples, lines);
                TwoPerEnhance tpEnhance2 = new TwoPerEnhance("color", GraphConvert.BandMerger(GraphConvert.BandSplit(backColorGraph, 1)), samples, lines);
                TwoPerEnhance tpEnhance3 = new TwoPerEnhance("color", GraphConvert.BandMerger(GraphConvert.BandSplit(backColorGraph, 2)), samples, lines);

                byte[] enhancedGraph1 = tpEnhance1.EnhanceByTwoPer();
                byte[] enhancedGraph2 = tpEnhance2.EnhanceByTwoPer();
                byte[] enhancedGraph3 = tpEnhance3.EnhanceByTwoPer();

                ToBitmap(enhancedGraph1, enhancedGraph2, enhancedGraph3, mainBitmap);
                updateMainPicBox(mainBitmap);
            }
        }

        private void 显示规定化结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {if (graphType == "gray"){displayGrayGraph(newMatchForm.NewGraph);}
            else{displayColorGraph(newMatchForm.MatchedBand1, newMatchForm.MatchedBand2, newMatchForm.MatchedBand3);}}

        private void 设置规定化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (graphType == "gray")
            {
                OpenFileDialog aimGraphOpener = new OpenFileDialog();
                aimGraphOpener.Filter = "头文件|*.hdr";
                if (aimGraphOpener.ShowDialog() == DialogResult.OK)
                {
                    FileReader aimGraph = new FileReader(aimGraphOpener.FileName);
                    newMatchForm = new MatchForm(aimGraphOpener.FileName, graphType);
                    newMatchForm.OriginGraph = GraphConvert.BandMerger(grayGraph);
                    newMatchForm.Show();
                    显示规定化结果ToolStripMenuItem.Enabled = true;
                }
            }
            else
            {
                OpenFileDialog aimGraphOpener = new OpenFileDialog();
                aimGraphOpener.Filter = "头文件|*.hdr";
                if (aimGraphOpener.ShowDialog() == DialogResult.OK)
                {
                    FileReader aimGraph = new FileReader(aimGraphOpener.FileName);
                    newMatchForm = new MatchForm(aimGraphOpener.FileName, graphType);
                    newMatchForm.OriginColorGraph1 = GraphConvert.BandMerger(GraphConvert.BandSplit(colorGraph, 0));
                    newMatchForm.OriginColorGraph2 = GraphConvert.BandMerger(GraphConvert.BandSplit(colorGraph, 1));
                    newMatchForm.OriginColorGraph3 = GraphConvert.BandMerger(GraphConvert.BandSplit(colorGraph, 2));

                    newMatchForm.Show();
                    显示规定化结果ToolStripMenuItem.Enabled = true;
                }
            }
        }
        private void 恢复原状ToolStripMenuItem_Click(object sender, EventArgs e)
        {if (graphType == "gray"){displayGrayGraph(backGrayGraph);}
            else{displayColorGraph(backColorGraph);}}
        #endregion
        #region 生成主图的bitmap
        /// <summary>
        /// 设置位图内容
        /// </summary>
        /// <param name="byteArray">待添加的图像数组</param>
        /// <param name="bm">当前位图</param>
        private void ToBitmap(byte[] byteArray, Bitmap bm)
        {
            for (int i = 0; i < samples; i++)
            {
                for (int j = 0; j < lines; j++)
                {
                    bm.SetPixel(j, i, Color.FromArgb(byteArray[i * lines + j], byteArray[i * lines + j], byteArray[i * lines + j]));
                }
            }
        }
        /// <summary>
        /// 设置位图内容
        /// </summary>
        /// <param name="band1">波段1</param>
        /// <param name="band2">波段2</param>
        /// <param name="band3">波段3</param>
        /// <param name="bm">当前位图</param>
        private void ToBitmap(byte[] band1, byte[] band2, byte[] band3, Bitmap bm)
        {
            for (int i = 0; i < samples; i++)
            {
                for (int j = 0; j < lines; j++)
                {
                    bm.SetPixel(j, i, Color.FromArgb(band1[i * lines + j], band2[i * lines + j], band3[i * lines + j]));
                }
            }
        }
        /// <summary>
        /// 设置位图内容
        /// </summary>
        /// <param name="grayBands">二维灰度数组</param>
        /// <param name="bm">位图</param>
        private void ToBitmap(byte[,] grayBands, Bitmap bm)
        {
            for (int i = 0; i < samples; i++)
            {
                for (int j = 0; j < lines; j++)
                {
                    byte curNum = grayBands[i, j];
                    bm.SetPixel(j, i, Color.FromArgb(curNum, curNum, curNum));
                }
            }
        }
        /// <summary>
        /// 设置位图内容
        /// </summary>
        /// <param name="colorBands">三维彩图数组</param>
        /// <param name="bm">位图</param>
        private void ToBitmap(byte[,,] colorBands, Bitmap bm)
        {
            for (int i = 0; i < samples; i++)
            {
                for (int j = 0; j < lines; j++)
                {
                    byte curNum1 = colorBands[0, i, j];
                    byte curNum2 = colorBands[1, i, j];
                    byte curNum3 = colorBands[2, i, j];
                    bm.SetPixel(j, i, Color.FromArgb(curNum1, curNum2, curNum3));
                }
            }
        }
        #endregion
        #region 鼠标在主图上移动时改变放大图的范围
        private void mainPicBox_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                int[] centerCoord = new int[2];
                centerCoord[0] = (int)(e.X * (double)lines / mainPicBox.Width);
                centerCoord[1] = (int)(e.Y * (double)samples / mainPicBox.Height);
                Console.WriteLine(centerCoord[0].ToString() + "," + centerCoord[1].ToString());
                ChangeSmallBoxExtent(centerCoord);
                MouseMoveEvent(centerCoord);
            }
            catch
            {
                return;
            }
        }
        /// <summary>
        /// 这个还不够好用，待完善
        /// </summary>
        /// <param name="centerCoord"></param>
        public void ChangeSmallBoxExtent(int[] centerCoord)
        {
            Bitmap smallBitMap = new Bitmap(100, 100);
            for (int i = -50; i < 50; i++)
            {
                for (int j = -50; j < 50; j++)
                {
                    smallBitMap.SetPixel(i + 50, j + 50, mainBitmap.GetPixel(centerCoord[0] + i, centerCoord[1] + j));
                }
            }
            updateSmallPicbox(smallBitMap);
        }
        #endregion
        #region 分割图像
        /// <summary>
        /// 根据阈值分割图像
        /// </summary>
        /// <param name="graphInner">图像文件</param>
        /// <param name="threshold">阈值</param>
        /// <returns></returns>
        private byte[,] splitGraphByThreshold(byte[,] graphInner, int threshold)
        {
            for (int sample = 0; sample < graphInner.GetLength(0); sample++)
            {
                for (int line = 0; line < graphInner.GetLength(1); line++)
                {
                    if (graphInner[sample, line] >= threshold)
                    {
                        graphInner[sample, line] = 255;
                    }
                    else
                    {
                        graphInner[sample, line] = 0;
                    }
                }
            }
            return graphInner;
        }
        //otsu分割原始图像
        private void OTSUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[,] otsuTwoDimenGraph;
            byte[] otsuGraph;
            if (graphType == "gray")
            {
                otsuTwoDimenGraph = grayGraph;
                otsuGraph = GraphConvert.BandMerger(grayGraph);
            }

            else
            {
                if(this.bandComboBox.SelectedItem == null)
                {
                    return;
                }
                int otsuBandIndex = int.Parse(this.bandComboBox.SelectedItem.ToString());
                otsuTwoDimenGraph = GraphConvert.BandSplit(colorGraph, otsuBandIndex - 1);
                otsuGraph = GraphConvert.BandMerger(GraphConvert.BandSplit(colorGraph, otsuBandIndex - 1));
            }
            double[] otsuVarience = new double[256];
            double[] frequency = BasicStatis.GetAccumFrequency(otsuGraph);
            for (int i = 0; i < 256; i++)
            {
                //两类的发生概率
                double lowerFre = frequency[i];
                double upperFre = 1 - lowerFre;
                //计算平均值
                int[] lower = GraphConvert.GetPixelByRange(otsuGraph, 0, i);
                int[] upper = GraphConvert.GetPixelByRange(otsuGraph, i);
                double lowerAvg, upperAvg;
                try{lowerAvg = lower.Average();}catch{lowerAvg = 0;}
                try{upperAvg = upper.Average();}catch{upperAvg = 0;}
                double allAvg = BasicStatis.GetAvg(otsuGraph);
                //类内方差
                double lowerVa = BasicStatis.GetVariance(lower);
                double upperVa = BasicStatis.GetVariance(upper);
                double varience1 = lowerVa * lowerFre + upperVa * upperFre;
                //类间方差
                double varience2 = lowerFre * Math.Pow(lowerAvg - allAvg, 2) + upperFre * Math.Pow(upperAvg - allAvg, 2);
                otsuVarience[i] = varience2 / varience1;
            }
            //最终阈值
            int maxOTSUIndex = 0;
            double maxOTSUNumber = 0;
            for (int i = 0; i < 256; i++)
            {
                if (otsuVarience[i] > maxOTSUNumber)
                {
                    maxOTSUIndex = i;
                    maxOTSUNumber = otsuVarience[i];
                }
            }
            //分割图像
            byte[,] splitGraph = splitGraphByThreshold(otsuTwoDimenGraph, maxOTSUIndex);
            ToBitmap(splitGraph, mainBitmap);
            updateMainPicBox(mainBitmap);

        }
        //最佳阈值递归用图像
        private byte[] bestThreGraph;
        private double recurBestThre(double pre)
        {
            int[] lower = GraphConvert.GetPixelByRange(bestThreGraph, 0, pre);
            int[] upper = GraphConvert.GetPixelByRange(bestThreGraph, pre);
            double lowerAvg = lower.Average();
            double upperAvg = upper.Average();
            double cur = (lowerAvg + upperAvg) / 2;
            if (Math.Abs(cur - pre) < 0.1){return cur;}
            else{cur = recurBestThre(cur);}
            return cur;
        }
        private void 最佳阈值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[,] bestThreTwoDimenGraph;
            if (graphType == "gray")
            {
                bestThreTwoDimenGraph = grayGraph;
                bestThreGraph = GraphConvert.BandMerger(grayGraph);
            }

            else
            {
                if (bandComboBox.SelectedItem == null){return;}
                int bestThreBandIndex = int.Parse(this.bandComboBox.SelectedItem.ToString());
                bestThreTwoDimenGraph = GraphConvert.BandSplit(colorGraph, bestThreBandIndex - 1);
                bestThreGraph = GraphConvert.BandMerger(GraphConvert.BandSplit(colorGraph, bestThreBandIndex - 1));
            }
            //确定阈值
            int minPixel = BasicStatis.GetMin(bestThreGraph);
            int maxPixel = BasicStatis.GetMax(bestThreGraph);
            double threshold = (minPixel + maxPixel) / 2;
            //递归
            threshold = recurBestThre(threshold);
            int finalThreshold = Convert.ToInt32(threshold);
            Console.WriteLine(finalThreshold.ToString());
            //加载图像
            byte[,] splitGraph = splitGraphByThreshold(bestThreTwoDimenGraph, finalThreshold);
            ToBitmap(splitGraph, mainBitmap);
            updateMainPicBox(mainBitmap);
        }
        #endregion
    }
}
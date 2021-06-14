using LOSRSS.files;
using LOSRSS.statistic;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;
namespace LOSRSS
{
    public partial class FlatFieldForm : Form
    {
        private string _graphType;
        private byte[,] _grayGraph;
        private byte[,] _backGrayGraph;
        private byte[,,] _colorGraph;
        private byte[,,] _backColorGraph;
        private FileReader _dataFile;
        private Bitmap _mainBitmap;
        private readonly int samples;
        private readonly int lines;
        private int[] extent = new int[4];
        private Point sPoint;
        private Point ePoint;
        private bool isDrawing = false;
        List<DrawingObject> drawLst = new List<DrawingObject>();//存贮对象的容器
        private Graphics g1;

        //委托事件，传递鼠标所在坐标

        private void PicForm_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 构造函数 备份原始数据-加载图像-准备坐标协同
        /// </summary>
        /// <param name="dataFile"></param>
        /// <param name="graphTypeInt"></param>
        /// <param name="bFrm"></param>
        public FlatFieldForm(FileReader dataFile, int graphTypeInt, BandForm bFrm)
        {
            this._dataFile = dataFile;
            InitializeComponent();
            g1 = this.transparentPicBox.CreateGraphics();
            mainPicBox.Controls.Add(this.transparentPicBox);
            g1.Clear(Color.Transparent);
            _mainBitmap = new Bitmap(dataFile.Samples, dataFile.Lines);
            if (graphTypeInt == 1)
            {
                _graphType = "gray";
                _grayGraph = dataFile.GrayGraph;
                samples = dataFile.Samples;
                lines = dataFile.Lines;
                //做好备份
                _backGrayGraph = (byte[,])_grayGraph.Clone();
                displayGrayGraph();
            }
            else
            {

                _graphType = "color";
                _colorGraph = dataFile.ColorGraph;
                samples = dataFile.Samples;
                lines = dataFile.Lines;
                //做好备份
                _backColorGraph = (byte[,,])_colorGraph.Clone();
                displayColorGraph();
            }

        }
        #region 显示图像
        /// <summary>
        /// 以下两个函数用于更新显示
        /// </summary>
        /// <param name="bm"></param>
        private void updateMainPicBox(Bitmap bm)
        {
            _mainBitmap = bm;
            mainPicBox.Image = _mainBitmap;
            mainPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /// <summary>
        /// 设置灰度图像的显示
        /// </summary>
        private void displayGrayGraph()
        {
            TwoPerEnhance tpEnhance = new TwoPerEnhance("gray", GraphConvert.BandMerger(_grayGraph), samples, lines);
            byte[] enhancedGraph = tpEnhance.EnhanceByTwoPer();
            ToBitmap(enhancedGraph, _mainBitmap);
            updateMainPicBox(_mainBitmap);
        }
        /// <summary>
        /// 设置彩色图像的显示
        /// </summary>
        private void displayColorGraph()
        {
            TwoPerEnhance tpEnhance1 = new TwoPerEnhance("color", GraphConvert.BandMerger(GraphConvert.BandSplit(_colorGraph, 0)), samples, lines);
            TwoPerEnhance tpEnhance2 = new TwoPerEnhance("color", GraphConvert.BandMerger(GraphConvert.BandSplit(_colorGraph, 1)), samples, lines);
            TwoPerEnhance tpEnhance3 = new TwoPerEnhance("color", GraphConvert.BandMerger(GraphConvert.BandSplit(_colorGraph, 2)), samples, lines);

            byte[] enhancedGraph1 = tpEnhance1.EnhanceByTwoPer();
            byte[] enhancedGraph2 = tpEnhance2.EnhanceByTwoPer();
            byte[] enhancedGraph3 = tpEnhance3.EnhanceByTwoPer();

            ToBitmap(enhancedGraph1, enhancedGraph2, enhancedGraph3, _mainBitmap);
            updateMainPicBox(_mainBitmap);
        }
        #endregion
        #region 生成主图的bitmap
        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteArray">待添加的图像数组</param>
        /// <param name="bm">当前图框</param>
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

        private void ToBitmap(byte[] byteArray1, byte[] byteArray2, byte[] byteArray3, Bitmap bm)
        {
            for (int i = 0; i < samples; i++)
            {
                for (int j = 0; j < lines; j++)
                {
                    bm.SetPixel(j, i, Color.FromArgb(byteArray1[i * lines + j], byteArray2[i * lines + j], byteArray3[i * lines + j]));
                }
            }
        }

        private void ToBitmap(byte[,] byteArray, Bitmap bm)
        {
            for (int i = 0; i < samples; i++)
            {
                for (int j = 0; j < lines; j++)
                {
                    byte curNum = byteArray[i, j];
                    bm.SetPixel(j, i, Color.FromArgb(curNum, curNum, curNum));
                }
            }
        }

        private void ToBitmap(byte[,,] byteArray, Bitmap bm)
        {
            for (int i = 0; i < samples; i++)
            {
                for (int j = 0; j < lines; j++)
                {
                    byte curNum1 = byteArray[0, i, j];
                    byte curNum2 = byteArray[1, i, j];
                    byte curNum3 = byteArray[2, i, j];
                    bm.SetPixel(j, i, Color.FromArgb(curNum1, curNum2, curNum3));
                }
            }
        }
        #endregion

        private void flatFieldButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FlatFieldForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            valueConvey.FlatFieldExtent = valueConvey.resolutionAdjust(GetRealExtent());
        }
        private int[] GetRealExtent()
        {
            if (sPoint.X <= ePoint.X && sPoint.Y <= ePoint.Y)
            {

                int[] realExtent = { sPoint.X, sPoint.Y, ePoint.X - sPoint.X, ePoint.Y - sPoint.Y};
                return realExtent;
            }
            //左上移动
            else if (sPoint.X > ePoint.X && sPoint.Y > ePoint.Y)
            {
                int[] realExtent = { ePoint.X, ePoint.Y, sPoint.X - ePoint.X, sPoint.Y - ePoint.Y };
                return realExtent;

            }
            //右上移动
            else if (sPoint.X <= ePoint.X && sPoint.Y > ePoint.Y)
            {
                int[] realExtent = { sPoint.X, ePoint.Y, ePoint.X - sPoint.X, sPoint.Y - ePoint.Y };
                return realExtent;

            }
            //左下移动
            else
            {
                int[] realExtent = { ePoint.X, sPoint.Y, sPoint.X - ePoint.X, ePoint.Y - sPoint.Y };
                return realExtent;
            }

        }

        private void transparentPicBox_MouseDown(object sender, MouseEventArgs e)
        {
            sPoint = e.Location;
            isDrawing = true;
        }
        private void transparentPicBox_MouseUp(object sender, MouseEventArgs e)
        {
            //this.transparentPicBox2.BackColor = Color.Transparent;
            //g1.Clear(Color.Transparent);
            //transparentPicBox.BackColor = Color.Transparent;
            ePoint = e.Location;
            transparentPicBox.Invalidate();
            isDrawing = false;

        }

        private void transparentPicBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing)
            {
                return;
            }
            ePoint = e.Location;
            transparentPicBox.Invalidate();
        }

        private void transparentPicBox_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 2);
            int[] realExtent = GetRealExtent();
            g1.DrawRectangle(pen, realExtent[0], realExtent[1], realExtent[2], realExtent[3]);
        }

    }
    static class valueConvey
    {
        public static int[] FlatFieldExtent;
        public static int[] resolutionAdjust(int[] extent)
        {
            int[] resolutionExtent = { Convert.ToInt32(extent[0] * 1.5), Convert.ToInt32(extent[1] * 1.5), Convert.ToInt32(extent[2] * 1.5), Convert.ToInt32(extent[3] * 1.5) };
            return resolutionExtent;
        }
    }
    public class DrawingObject
    {
        public int X1, Y1, X2, Y2;
        public Pen pen;
        public DrawingObject(int X1, int Y1, int X2, int Y2, Pen pen)
        {
            this.pen = pen;
            this.X1 = X1;
            this.X2 = X2;
            this.Y1 = Y1;
            this.Y2 = Y2;
        }
        public virtual void Draw(Graphics g)
        { }
    }
    public class Square : DrawingObject
    {
        public Square(int X1, int Y1, int X2, int Y2, Pen p) : base(X1, Y1, X2, Y2, p) { }
        public override void Draw(Graphics g)
        {
            //右下移动
            if (X1 < X2 && Y1 < Y2)
            {
                g.DrawRectangle(pen, X1, Y1, X2 - X1, Y2 - Y1);
            }
            //左上移动
            else if (X1 > X2 && Y1 > Y2)
            {
                g.DrawRectangle(pen, X2, Y2, X1 - X2, Y1 - Y2);
            }
            //右上移动
            else if (X1 < X2 && Y1 > Y2)
            {
                g.DrawRectangle(pen, X1, Y2, X2 - X1, Y1 - Y2);
            }
            //左下移动
            else if (X1 > X2 && Y1 < Y2)
            {
                g.DrawRectangle(pen, X2, Y1, X1 - X2, Y2 - Y1);
            }
        }
    }
}
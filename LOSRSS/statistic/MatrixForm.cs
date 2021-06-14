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
    public partial class MatrixForm : Form
    {
        private FileReader curBands;
        private string matrixType;
        private double[,] correlation;
        private double[,] covariance;

        public MatrixForm(FileReader curBands, string matrixType)
        {
            InitializeComponent();
            CurBands = curBands;
            MatrixType = matrixType;
            AddColums();
            if (MatrixType == "covariance")
            {
                Text = "协方差矩阵";
                covariance = new double[CurBands.Bands, CurBands.Bands];
            }
            else if (MatrixType == "correlation")
            {
                Text = "相关系数矩阵";
                correlation = new double[CurBands.Bands, CurBands.Bands];
            }
            CalcuMatrix(matrixType);
            AddMatrix(matrixType);
        }
        /// <summary>
        /// 添加首行内容
        /// </summary>
        private void AddColums()
        {
            string curLine = "";
            MatrixText.Text += string.Format("{0,-10}", curLine);
            for (int i = 0; i < CurBands.Bands; i++)
            {
                curLine = "Band" + (i + 1).ToString();
                MatrixText.Text += string.Format("{0,-10}", curLine);
            }
            MatrixText.Text += "\n";
        }
        /// <summary>
        /// 添加矩阵信息
        /// </summary>
        private void AddMatrix(string matrixType)
        {
            for (int i = 0; i < CurBands.Bands; i++)
            {
                string curLine = "Band" + (i + 1).ToString();
                MatrixText.Text += string.Format("{0,-10}", curLine);

                if (matrixType == "covariance")
                {
                    for (int j = 0; j < CurBands.Bands; j++)
                    {
                        MatrixText.Text += string.Format("{0,-10}", Math.Round(covariance[i, j], 3));
                    }
                }
                else if (matrixType == "correlation")
                {
                    for (int j = 0; j < CurBands.Bands; j++)
                    {
                        MatrixText.Text += string.Format("{0,-10}", Math.Round(correlation[i, j], 3));
                    }
                }
                MatrixText.Text += "\n";

            }
            
        }
        /// <summary>
        /// 计算矩阵
        /// </summary>
        /// <param name="calcuType"></param>
        private void CalcuMatrix(string calcuType)
        {
            byte[,,] grapgInner = CurBands.GraphInner;
            byte[][] allBands = GraphConvert.SplitSeperateBands(CurBands.GraphInner, CurBands.Bands);

            for (int i = 0; i < CurBands.Bands; i++)
            {
                byte[] band1 = GraphConvert.BandMerger(GraphConvert.BandSplit(grapgInner, i));
                for (int j = 0; j < CurBands.Bands; j++)
                {
                    //根据不同类型计算不同矩阵
                    if(calcuType == "covariance")
                    {
                        covariance[i, j] = MultiStatis.Covariance(allBands[i], allBands[j]);
                    }
                    else if(calcuType == "correlation")
                    {
                        correlation[i, j] = MultiStatis.Correla(allBands[i], allBands[j]);
                    }
                }
            }
        }
        public FileReader CurBands { get => curBands; set => curBands = value; }
        public string MatrixType { get => matrixType; set => matrixType = value; }
        private void MatrixForm_Load(object sender, EventArgs e)
        {
        }
    }
}

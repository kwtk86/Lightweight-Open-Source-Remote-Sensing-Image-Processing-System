using LOSRSS.files;
using LOSRSS.statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 图像校正
/// </summary>
namespace LOSRSS.Correction
{
    /// <summary>
    /// 所有校正功能的基类
    /// </summary>
    class Correction
    {
        private byte[,,] graphInner;
        public Correction(byte[,,] graphInner)
        {
            GraphInner = graphInner;
        }

        public byte[,,] GraphInner { get => graphInner; set => graphInner = value; }
        /// <summary>
        /// 平均法校正
        /// </summary>
        /// <returns>平均后的图像数组</returns>
        public byte[,,] Correct(double[] average)
        {
            int len0 = GraphInner.GetLength(0);
            int len1 = GraphInner.GetLength(1);
            int len2 = GraphInner.GetLength(2);
            //输出结果
            byte[,,] avgBands = new byte[len0, len1, len2];
            //波段拆分
            byte[][,] seperatedBands = GraphConvert.SplitSeperateBands2(GraphInner);
            for (int band = 0; band < len0; band++)
            {
                average[band] = BasicStatis.GetAvg(seperatedBands[band]);

            }
            //逐个波段计算相对值及绝对值
            for (int band = 0; band < len0; band++)
            {
                double[,] relaArray = new double[len1, len2];
                for (int sample = 0; sample < len1; sample++)
                {
                    for (int line = 0; line < len2; line++)
                    {
                        relaArray[sample, line] = GraphInner[band, sample, line] / average[band];
                    }
                }
                //相对值转绝对值
                byte[,] absArray = GraphConvert.RelativeToAbsolute(relaArray);

                for (int sample = 0; sample < len1; sample++)
                {
                    for (int line = 0; line < len2; line++)
                    {
                        avgBands[band, sample, line] = absArray[sample, line];
                    }
                }
            }
            return avgBands;
        }

    }
    /// <summary>
    /// 内部平均法校正
    /// </summary>
    class InAvgCorrection:Correction
    {
        private double[] average;
        /// <summary>
        /// 内部平均法校正
        /// </summary>
        /// <param name="graphInner">三维图像数组</param>
        public InAvgCorrection(byte[,,] graphInner):base(graphInner)
        {
            int len0 = GraphInner.GetLength(0);
            byte[][,] seperatedBands = GraphConvert.SplitSeperateBands2(GraphInner);
            Average = new double[len0];
            for (int band = 0; band < len0; band++)
            {
                Average[band] = BasicStatis.GetAvg(seperatedBands[band]);
            }
        }
        public double[] Average { get => average; set => average = value; }
    }
    ///平场域法校正
    class FlatFieldCorrection: Correction
    {
        private double[] average;
        private int[] extent;
        public double[] Average { get => average; set => average = value; }

        public FlatFieldCorrection(byte[,,] graphInner, int[] extent) : base(graphInner)
        {
            this.Extent = extent;
            int len0 = GraphInner.GetLength(0);
            byte[][,] seperatedBands = GraphConvert.SplitSeperateBands2(GraphInner);
            Average = new double[len0];
            for (int band = 0; band < len0; band++)
            {
                Average[band] = BasicStatis.GetAvgByExtent(seperatedBands[band], Extent);
            }
        }
        public int[] Extent { get => extent; set => extent = value; }
    }
}

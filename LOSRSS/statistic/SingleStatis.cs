using LOSRSS.files;
using LOSRSS.statistic;
using System;

namespace LOSRSS.funtions
{
    class SingleStatis
    {
        #region 平均值
        /// <summary>
        /// 从文件中获取平均值
        /// </summary>
        /// <param name="curBands">文件内容</param>
        /// <returns></returns>
        public static double[] Avg(FileReader curBands)
        {
            int bands = curBands.Bands;
            double[] avgBands = new double[bands]; 
            for(int i = 0;i < bands; i++)
            {
                long total = 0;
                byte[] singleBand = GraphConvert.BandMerger(GraphConvert.BandSplit(curBands.GraphInner, i));
                for(int j = 0;j <singleBand.Length;j++)
                {
                    total += singleBand[j];
                }
                double length = (double)singleBand.Length;
                avgBands[i] = total / length;
            }
            return avgBands;
        }

        /// <summary>
        /// 平均值
        /// </summary>
        /// <param name="singleBand">一维波段数组</param>
        /// <returns></returns>
        /// 这个函数写重复了但是懒得改了
        public static double Avg(byte[] singleBand)
        {
            double total = 0;
            for (int j = 0; j < singleBand.Length; j++)
            { 
                total += singleBand[j];
            }
            return total/singleBand.Length;
        }
        #endregion
        #region 标准差

        public static double[] Dev(FileReader curBands, double[] avgBands)
        {
            int bands = curBands.Bands;
            double[] devBands = new double[bands];
            for(int i = 0; i < bands; i++)
            {
                double sum = 0;
                double curAvg = avgBands[i];
                byte[] singleBand = GraphConvert.BandMerger(GraphConvert.BandSplit(curBands.GraphInner, i));
                for(int j = 0; j<singleBand.Length;j++)
                {
                    sum += Math.Pow(curAvg - singleBand[j], 2);
                }
                devBands[i] = Math.Sqrt(sum / singleBand.Length);
            }
            return devBands;
        }
        #endregion
        #region 获取信息熵
        /// <summary>
        /// 对比度
        /// </summary>
        /// <param name="curBands">文件内容</param>
        /// <returns></returns>
        public static double[] Contrast(FileReader curBands)
        {
            int bands = curBands.Bands;
            int samples = curBands.Samples;
            int lines = curBands.Lines;
            double[] contrastBands = new double[bands];
            byte[,,] graphinner = curBands.GraphInner;
            for (int n = 1; n < bands + 1; n++)
            {
                int N = 2 * 4 + (2 * (samples + lines) - 4) * 3 + (samples - 1) * (lines - 1) * 4;
                double sum = Math.Pow((graphinner[n - 1, 0, 0] - graphinner[n - 1, 0, 1]), 2) + Math.Pow(graphinner[n - 1, 0, 0] - graphinner[n - 1, 1, 0], 2)
                    + Math.Pow(graphinner[n - 1, 0, lines - 1] - graphinner[n - 1, 0, lines - 2], 2) + Math.Pow(graphinner[n - 1, 1, lines - 1] - graphinner[n - 1, 0, lines - 1], 2)
                    + Math.Pow(graphinner[n - 1, samples - 1, 0] - graphinner[n - 1, samples - 2, 0], 2) + Math.Pow(graphinner[n - 1, samples - 1, 0] - graphinner[n - 1, samples - 1, 1], 2)
                    + Math.Pow(graphinner[n - 1, samples - 1, lines - 1] - graphinner[n - 1, samples - 1, lines - 2], 2) + Math.Pow(graphinner[n - 1, samples - 1, lines - 1] - graphinner[n - 1, samples - 2, lines - 1], 2);
                for (int j = 1; j < samples - 1; j++)
                {
                    sum += Math.Pow(graphinner[n - 1, j, 0] - graphinner[n - 1, j, 1], 2) + Math.Pow(graphinner[n - 1, j, 0] - graphinner[n - 1, j + 1, 0], 2)
                        + Math.Pow(graphinner[n - 1, j, 0] - graphinner[n - 1, j - 1, 0], 2);
                }
                for (int j = 1; j < samples - 1; j++)
                {
                    sum += Math.Pow(graphinner[n - 1, j, lines - 1] - graphinner[n - 1, j, lines - 2], 2) + Math.Pow(graphinner[n - 1, j, lines - 1] - graphinner[n - 1, j + 1, lines - 1], 2)
                        + Math.Pow(graphinner[n - 1, j, lines - 1] - graphinner[n - 1, j - 1, lines - 1], 2);
                }

                for (int j = 1; j < lines - 1; j++)
                {
                    sum += Math.Pow(graphinner[n - 1, 0, j] - graphinner[n - 1, 0, j - 1], 2) + Math.Pow(graphinner[n - 1, 0, j] - graphinner[n - 1, 0, j + 1], 2)
                        + Math.Pow(graphinner[n - 1, 0, j] - graphinner[n - 1, 1, j], 2);
                }
                for (int j = 1; j < lines - 1; j++)
                {
                    sum += Math.Pow(graphinner[n - 1, samples - 1, j] - graphinner[n - 1, samples - 1, j - 1], 2) + Math.Pow(graphinner[n - 1, samples - 1, j] - graphinner[n - 1, samples - 1, j + 1], 2)
                        + Math.Pow(graphinner[n - 1, samples - 1, j] - graphinner[n - 1, samples - 2, j], 2);
                }
                for (int i = 1; i < samples - 1; i++)
                {
                    for (int j = 1; j < lines - 1; j++)
                    {
                        sum += Math.Pow(graphinner[n - 1, i, j] - graphinner[n - 1, i + 1, j], 2) + Math.Pow(graphinner[n - 1, i, j] - graphinner[n - 1, i - 1, j], 2) +
                            Math.Pow(graphinner[n - 1, i, j] - graphinner[n - 1, i, j - 1], 2) + Math.Pow(graphinner[n - 1, i, j] - graphinner[n - 1, i, j + 1], 2);
                    }
                }
                double contrast = (sum / (N * N));
                contrastBands[n - 1] = contrast;
            }
            return contrastBands;
        }
        /// <summary>
        /// 获取所有波段的信息熵
        /// </summary>
        /// <param name="curBands"></param>
        /// <returns></returns>
        public static double[] Entropy(FileReader curBands)
        {
            int bands = curBands.Bands;
            double[] entropyBands = new double[bands];
            for (int i = 0; i < bands; i++)
            {
                double entropy = 0;
                byte[] singleBand = GraphConvert.BandMerger(GraphConvert.BandSplit(curBands.GraphInner, i));
                double[] singleFrequency = BasicStatis.GetPixelFrequency(singleBand);
                for (int j = 0; j < 256; j++)
                {
                    if (singleFrequency[j] == 0)
                        continue;
                    else
                        entropy = entropy - singleFrequency[j] * Math.Log(singleFrequency[j], 2);
                }
                entropyBands[i] = entropy;
            }
            return entropyBands;
        }
        /// <summary>
        /// 获取指定波段的信息熵
        /// </summary>
        /// <param name="curBands"></param>
        /// <param name="band">波段号</param>
        /// <returns></returns>
        public static double Entropy(FileReader curBands, int band)
        {
            band--;
            double entropy = 0;
            byte[] singleBand = GraphConvert.BandMerger(GraphConvert.BandSplit(curBands.GraphInner, band));
            double[] singleFrequency = BasicStatis.GetPixelFrequency(singleBand);
            for (int j = 0; j < 256; j++)
            {
                if (singleFrequency[j] == 0)
                    continue;
                else
                    entropy = entropy - singleFrequency[j] * Math.Log(singleFrequency[j], 2);
            }
            return entropy;
        }
        /// <summary>
        /// 根据传入的波段获取信息熵
        /// </summary>
        /// <param name="curBands"></param>
        /// <param name="band"></param>
        /// <returns></returns>
        public static double Entropy(byte[] singleBand)
        {
            double entropy = 0;
            double[] singleFrequency = BasicStatis.GetPixelFrequency(singleBand);
            for (int j = 0; j < 256; j++)
            {
                if (singleFrequency[j] == 0)
                    continue;
                else
                    entropy = entropy - singleFrequency[j] * Math.Log(singleFrequency[j], 2);
            }
            return entropy;
        }
        #endregion
    }
}

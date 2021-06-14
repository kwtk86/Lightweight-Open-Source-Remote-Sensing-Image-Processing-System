using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LOSRSS.statistic
{
    /// <summary>
    /// 图像基本统计量函数
    /// </summary>
    public class BasicStatis
    {
        #region 直方图相关
        /// <summary>
        /// 统计像素频数
        /// </summary>
        public static int[] GetPixelCount(byte[] graph, int max = 255)
        {
            int pixel;
            int[] countPixel = new int[max + 1];
            Array.Clear(countPixel, 0, max + 1);
            for (int i = 0; i < graph.Length; i++)
            {
                pixel = graph[i];
                countPixel[pixel]++;
            }
            return countPixel;
        }
        /// <summary>
        /// 统计像素频率
        /// </summary>
        public static double[] GetPixelFrequency(byte[] graph, int max = 255)
        {
            int[] countPixel = GetPixelCount(graph);
            double[] frequencyPixel = new double[max + 1];
            Array.Clear(frequencyPixel, 0, max + 1);
            for (int i = 0; i < max + 1; i++)
            {
                frequencyPixel[i] = System.Convert.ToDouble(countPixel[i]) / System.Convert.ToDouble(graph.Length);
            }
            return frequencyPixel;
        }
        /// <summary>
        /// 统计像素累计频率
        /// </summary>
        public static double[] GetAccumFrequency(byte[] graph, int max = 255)
        {
            //统计像素出现的频数
            int[] countPixel = GetPixelCount(graph, max);
            //统计像素值出现的累计频率
            double[] accumFrequency = new double[max + 1];
            Array.Clear(accumFrequency, 0, max + 1);
            for (int i = 0; i < max + 1; i++)
            {
                if (i == 0)
                {
                    accumFrequency[i] = (double)countPixel[i] / graph.Length;
                }
                else
                {
                    accumFrequency[i] = accumFrequency[i - 1] + (double)countPixel[i] / graph.Length;
                }
            }
            return accumFrequency;
        }
        /// <summary>
        /// 统计像素累计计数
        /// </summary>
        public static int[] GetAccumCount(byte[] graph, int max = 255)
        {
            //统计像素出现的频数
            int[] countPixel = GetPixelCount(graph, max);
            //统计像素值出现的累计频率
            int[] accumFrequency = new int[max + 1];
            Array.Clear(accumFrequency, 0, max + 1);
            for (int i = 0; i < max + 1; i++)
            {
                if (i == 0)
                {
                    accumFrequency[i] = countPixel[i];
                }
                else
                {
                    accumFrequency[i] = accumFrequency[i - 1] + countPixel[i];
                }
            }
            return accumFrequency;
        }
        #endregion
        #region 最大最小平均值
        /// <summary>
        /// 统计最小值
        /// </summary>
        public static byte GetMin(byte[] graph)
        {
            byte min = 255;
            for (int i = 0; i < graph.Length; i++)
            {
                if(graph[i] < min)
                {
                    min = graph[i];
                }
            }
            return min;
        }
        public static double GetMin(double[,] graph)
        {
            double min = 255;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (graph[i, j] < min)
                    {
                        min = graph[i, j];
                    }
                }

            }
            return min;
        }
        public static byte GetMin(byte[,] graph)
        {
            byte min = 255;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (graph[i,j] < min)
                    {
                        min = graph[i,j];
                    }
                }

            }
            return min;
        }
        /// <summary>
        /// 统计最大值
        /// </summary>
        public static byte GetMax(byte[] graph)
        {
            byte max = 0;
            for (int i = 0; i < graph.Length; i++)
            {
                if (graph[i] > max)
                {
                    max = graph[i];
                }
            }
            return max;
        }
        public static byte GetMax(byte[,] graph)
        {
            byte max = 0;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (graph[i, j] > max)
                    {
                        max = graph[i, j];
                    }
                }

            }
            return max;
        }
        /// <summary>
        /// 求double类型数组的平均值
        /// </summary>
        public static double GetAvg(double[,] graph)
        {
            double sum = 0;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    sum += graph[i, j];
                }

            }
            return sum / graph.Length;
        }
        public static double GetMax(double[,] graph)
        {
            double max = 0;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (graph[i, j] > max)
                    {
                        max = graph[i, j];
                    }
                }

            }
            return max;
        }


        /// <summary>
        /// 求二维数组的平均值
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static double GetAvg(byte[,] graph)
        {
            double sum = 0;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    sum += graph[i, j];
                }

            }
            return sum/graph.Length;
        }

        /// <summary>
        /// 求范围平均值
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static double GetAvgByExtent(byte[,] graph, int[] extent)
        {
            double sum = 0;
            for (int i = extent[0]; i < extent[1]; i++)
            {
                for (int j = extent[2]; j < extent[3]; j++)
                {
                    sum += graph[i, j];
                }

            }
            return sum / graph.Length;
        }
        /// <summary>
        /// 求一维数组的平均值
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static double GetAvg(byte[] graph)
        {
            double sum = 0;
            for (int i = 0; i < graph.Length; i++)
            {
                sum += graph[i];
            }
            return sum / graph.Length;
        }
        #endregion
        #region 方差
        public static double GetVariance(int[] graphInner)
        {
            double avg;
            try
            {
                avg = graphInner.Average();
            }
            catch
            {
                avg = 0;
            }
            int length = graphInner.GetLength(0);
            double sum = 0;
            for(int i = 0; i < length; i++)
            {
                sum += Math.Pow(graphInner[i] - avg, 2);
            }
            return sum/length;
        }

        public static double GetVariance(byte[] graphInner)
        {
            double avg;
            try
            {
                avg = (byte)BasicStatis.GetAvg(graphInner);
            }
            catch
            {
                avg = 0;
            }
            int length = graphInner.GetLength(0);
            double sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += Math.Pow(graphInner[i] - avg, 2);
            }
            return sum / length;
        }
        public static double GetVariance(byte[,] graphInner)
        {
            double avg = GetAvg(graphInner);
            return avg;
        }
        #endregion
    }
}

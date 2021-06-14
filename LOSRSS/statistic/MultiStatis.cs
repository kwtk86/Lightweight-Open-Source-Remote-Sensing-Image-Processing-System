using LOSRSS.files;
using LOSRSS.funtions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOSRSS.statistic
{
    class MultiStatis
    {
        /// <summary>
        /// 相关系数
        /// </summary>
        /// <param name="band1">波段1</param>
        /// <param name="band2">波段2</param>
        /// <returns></returns>
        public static double Correla(byte[] band1, byte[] band2)
        {
            double covariance = Covariance(band1, band2);
            double dev1 = Math.Sqrt(BasicStatis.GetVariance(band1));
            double dev2 = Math.Sqrt(BasicStatis.GetVariance(band2));
            return covariance / (dev1 * dev2);
        }
        /// <summary>
        /// 协方差
        /// </summary>
        /// <param name="band1">波段1</param>
        /// <param name="band2">波段2</param>
        /// <returns></returns>
        public static double Covariance(byte[] band1, byte[] band2)
        {
            if (band1.Length != band2.Length)
            {
                MessageBox.Show("图像大小不一致！");
                return -1;
            }
            double avg1 = SingleStatis.Avg(band1);

            double avg2 = SingleStatis.Avg(band2);
            double length = band1.Length;
            double sum = 0;
            for(int i = 0; i < band1.Length; i++)
            {
                sum += (band1[i] - avg1) * (band2[i] - avg2);
            }
            return sum/length;
        }
        /// <summary>
        /// 互信息
        /// </summary>
        /// <param name="band1">波段1</param>
        /// <param name="band2">波段2</param>
        /// <returns></returns>
        public static double MutualInfo(byte[] band1, byte[] band2)
        {
            if(band1.Length != band2.Length)
            {
                MessageBox.Show("图像大小不一致！");
                return -1;
            }
            double entropy1 = SingleStatis.Entropy(band1);
            double entropy2 = SingleStatis.Entropy(band2);
            double unEntropy = UnionEntropy(band1, band2);
            return -unEntropy + entropy1 + entropy2;
        }
        /// <summary>
        /// 联合熵
        /// </summary>
        /// <param name="band1">波段1</param>
        /// <param name="band2">波段2</param>
        /// <returns></returns>
        public static double UnionEntropy(byte[] band1, byte[] band2)
        {
            double[,] statisUnion = new double[256, 256];
            //统计二维出现次数
            for(int i = 0; i < band1.Length; i++)
            {
                statisUnion[band1[i], band2[i]]++;
            }
            //计算出现频率
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    statisUnion[i, j] = statisUnion[i, j] / band1.Length;
                }
            }

            double mutualEntropy = 0;
            // 计算图像信息熵
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    if (statisUnion[i, j] == 0.0)
                        continue;
                    else
                        mutualEntropy = mutualEntropy - statisUnion[i, j] * Math.Log(statisUnion[i, j], 2);
                }
            }
            return mutualEntropy;
        }
    }
}

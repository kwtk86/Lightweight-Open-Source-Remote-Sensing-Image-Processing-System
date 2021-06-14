using LOSRSS.statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOSRSS.files
{
    /// <summary>
    /// 关于操作波段的函数
    /// </summary>
    class GraphConvert
    {
        /// <summary>
        /// bsq转bil 
        /// </summary>
        /// <param name="BSQ">三维BSQ数组</param>
        /// <returns></returns>
        public static byte[] BSQtoBIL(byte[,,] BSQ)
        {
            
            byte[] newBIL = new byte[BSQ.Length];
            int count = 0;
            //通过改变波段进行格式转换
            for (int sample = 0; sample < BSQ.GetLength(1); sample++)
            {
                for (int band = 0; band < BSQ.GetLength(0); band++)
                {
                    for (int line = 0; line < BSQ.GetLength(2); line++)
                    {
                        newBIL[count] = BSQ[band, sample, line];
                        count++;
                    }
                }
            }
            return newBIL;
        }
        /// <summary>
        /// bsq转bip
        /// </summary>
        /// <param name="BSQ">三维BSQ数组</param>
        /// <returns></returns>
        public static byte[] BSQtoBIP(byte[,,] BSQ)
        {
            byte[] newBIP = new byte[BSQ.Length];
            int count = 0;
            //通过改变波段进行格式转换
            for (int sample = 0; sample < BSQ.GetLength(1); sample++)
            {
                for (int line = 0; line < BSQ.GetLength(2); line++)
                {
                    for (int band = 0; band < BSQ.GetLength(0); band++)
                    {
                        newBIP[count] = BSQ[band, sample, line];
                        count++;
                    }
                }
            }
            return newBIP;
        }
        /// <summary>
        /// 融合三维波段数组
        /// </summary>
        /// <param name="mulDimenArray">三维图像数组</param>
        /// <returns></returns>
        public static byte[] BandMerger(byte[,,] mulDimenArray)
        {
            byte[] newBIP = new byte[mulDimenArray.Length];
            int count = 0;
            for (int band = 0; band < mulDimenArray.GetLength(0); band++)
            {
                for (int sample = 0; sample < mulDimenArray.GetLength(1); sample++)
                {
                    for (int line = 0; line < mulDimenArray.GetLength(2); line++)
                    {
                        newBIP[count] = mulDimenArray[band, sample, line];
                        count++;
                    }
                }
            }
            return newBIP;
        }
        /// <summary>
        /// 融合二维波段数组列表
        /// </summary>
        /// <param name="mulDimenList">二维图像数组列表</param>
        /// <returns></returns>
        public static byte[] BandMerger(List<byte[,]> mulDimenList)
        {
            byte[] newBIP = new byte[mulDimenList[0].Length * mulDimenList.Count];
            int count = 0;
            foreach (byte[,] band in mulDimenList)
            {
                for (int sample = 0; sample < band.GetLength(0); sample++)
                {
                    for (int line = 0; line < band.GetLength(1); line++)
                    {
                        newBIP[count] = band[sample, line];
                        count++;
                    }
                }
            }
            return newBIP;
        }
        /// <summary>
        /// 融合二维波段数组
        /// </summary>
        /// <param name="mulDimenArray">二维图像数组</param>
        /// <returns></returns>
        public static byte[] BandMerger(byte[,] mulDimenArray)
        {
            byte[] newBIP = new byte[mulDimenArray.Length];
            int count = 0;
            for (int samples = 0; samples < mulDimenArray.GetLength(0); samples++)
            {
                for (int lines = 0; lines < mulDimenArray.GetLength(1); lines++)
                {

                    newBIP[count] = mulDimenArray[samples, lines];
                    count++;
                }
            }
            return newBIP;
        }
        /// <summary>
        /// 拆分波段
        /// </summary>
        /// <param name="originBands">三维图像数组</param>
        /// <param name="band">待拆波段号</param>
        /// <returns></returns>
        public static byte[,] BandSplit(byte[,,] originBands, int band)
        {
            byte[,] singleBand = new byte[originBands.GetLength(1), originBands.GetLength(2)];
            for(int i = 0; i< originBands.GetLength(1);i++)
            {
                for (int j = 0; j < originBands.GetLength(2); j++)
                {
                    singleBand[i, j] = originBands[band, i, j];
                }
            }
            return singleBand;
        }
        /// <summary>
        /// 拆分波段为1.5维数组
        /// </summary>
        /// 
        public static byte[][] SplitSeperateBands(byte[,,] graphInner, int bands)
        {
            byte[][] allBands = new byte[bands][];
            for(int i = 0; i < bands; i++)
            {
                allBands[i] = BandMerger(BandSplit(graphInner, i));
            }
            return allBands;
        }
        /// <summary>
        /// 拆分波段为2.5维数组
        /// </summary>
        public static byte[][,] SplitSeperateBands2(byte[,,] graphInner)
        {
            int bands = graphInner.GetLength(0);
            byte[][,] allBands = new byte[bands][,];
            for (int i = 0; i < bands; i++)
            {
                allBands[i] = BandSplit(graphInner, i);
            }
            return allBands;
        }
        /// <summary>
        /// 相对值转绝对值
        /// </summary>
        /// <param name="relaBand">相对值数组</param>
        /// <returns>绝对值数组</returns>
        public static byte[,] RelativeToAbsolute(double[,] relaBand)
        {
            byte[,] absBand = new byte[relaBand.GetLength(0), relaBand.GetLength(1)];
            double max = BasicStatis.GetMax(relaBand);
            double min = BasicStatis.GetMin(relaBand);
            double porpro = 255 / (max - min);
            for (int i = 0; i < relaBand.GetLength(0); i++)
            {
                for (int j = 0; j < relaBand.GetLength(1); j++)
                {
                    double temp = relaBand[i, j] - min;
                    absBand[i, j] = (byte)(temp * porpro);
                }
            }
            return absBand;
        }
        /// <summary>
        /// 获取从lower（包含）到upper（不包含）之间的无组织图像元素
        /// </summary>
        /// <param name="graphInner">图像数组</param>
        /// <param name="lowerThreshold">下界，默认值为0</param>
        /// <param name="upperThreshold">上界，默认值为255</param>
        /// <returns></returns>
        public static int[] GetPixelByRange(byte[] graphInner, double lowerThreshold = 0, double upperThreshold = 256)
        {
            List<int> tempRange = new List<int>();
            foreach (byte pixel in graphInner)
            {
                if (pixel >= lowerThreshold && pixel < upperThreshold)
                {
                    tempRange.Add(pixel);
                }
            }
            int[] rangeArray = tempRange.ToArray();
            return rangeArray;
        }

        /// <summary>
        /// 获取从lower（包含）到upper（不包含）之间的无组织图像元素(这个可能有错，我还没调试)
        /// </summary>
        /// <param name="graphInner">图像数组</param>
        /// <param name="lowerThreshold">下界，默认值为0</param>
        /// <param name="upperThreshold">上界，默认值为255</param>
        /// <returns></returns>
        public static int[] GetPixelByRange(byte[,] graphInner, double lowerThreshold = 0, double upperThreshold = 256)
        {
            List<int> tempRange = new List<int>();
            foreach (byte pixel in graphInner)
            {
                if (pixel >= lowerThreshold && pixel < upperThreshold)
                {
                    tempRange.Add(pixel);
                }
            }
            int[] rangeArray = tempRange.ToArray();
            return rangeArray;
        }

    }
}

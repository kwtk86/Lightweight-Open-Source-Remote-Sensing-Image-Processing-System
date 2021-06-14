using System;

namespace LOSRSS.statistic
{    
    /// <summary>
     /// 图像增强的基类
     /// </summary>
    public class Enhance
    {
        private int samples;
        private int lines;
        private string _graphType;
        private byte[] _originGraph;
        public byte[] OriginGraph { get => _originGraph; set => _originGraph = value; }
        public int Samples { get => samples; set => samples = value; }
        public int Lines { get => lines; set => lines = value; }
        public string GraphType { get => _graphType; set => _graphType = value; }

        public Enhance(int samples, int lines, byte[] originGraph, string graphType)
        {
            this.GraphType = graphType;
            this.Samples = samples;
            this.Lines = lines;
            this.OriginGraph = originGraph;
        }
    }

    /// <summary>
    /// 直方图均衡化
    /// </summary>
    public class HistoEqual : Enhance
    {
        public HistoEqual(string graphType, byte[] originGraph, int samples, int lines) : base(samples, lines, originGraph, graphType)
        {
        }
        /// <summary>
        /// 灰度图均衡化
        /// </summary>
        public void Equal()
        {
            byte max = GetMaxPixel();
            double[] frequencyPixel = BasicStatis.GetAccumFrequency(OriginGraph, max);
            for (int i = 0; i < OriginGraph.Length; i++)
            {
                OriginGraph[i] = (byte)(255 * frequencyPixel[OriginGraph[i]]);
            }
        }
        private byte GetMaxPixel()
        {
            byte max = 0;
            for (int i = 0; i < OriginGraph.Length; i++)
            {
                if (OriginGraph[i] >= max)
                    max = OriginGraph[i];
            }
            return max;
        }
    }
    /// <summary>
    /// 2%增强
    /// </summary>
    public class TwoPerEnhance : Enhance
    {
        public TwoPerEnhance(string graphType, byte[] originGraph, int samples, int lines) : base(samples, lines, originGraph, graphType)
        {
        }
        public byte[] EnhanceByTwoPer()
        {
            //统计每个像素值出现的个数
            double[] sum = BasicStatis.GetAccumFrequency(OriginGraph);
            //统计2%的临界像素值
            int num = -1;
            do
            {
                num++;
            } while (sum[num] < 0.02);
            int newMin = num;
            num = 0;
            do
            {
                num++;
            } while (sum[num] < 0.98);
            int newMax = num - 1;
            //根据临界值，修正图像
            for (int i = 0; i < OriginGraph.Length; i++)
            {
                if (OriginGraph[i] < newMin)
                {
                    OriginGraph[i] = 0;
                }
                else
                {
                    if (OriginGraph[i] > newMax)
                    {
                        OriginGraph[i] = 255;
                    }
                    else
                    {
                        OriginGraph[i] = (byte)(255.0 / (newMax - newMin) * ((int)OriginGraph[i] - newMin));
                    }
                }
            }
            return OriginGraph;
        }
    }

    /// <summary>
    /// 直方图规定化
    /// </summary>
    public class HistoMatch : Enhance
    {
        private byte[] _aimGraph;
        private int totalCnt = 0;
        public HistoMatch(string graphType, byte[] originGraph, byte[] aimGraph, int samples, int lines) : base(samples, lines, originGraph, graphType)
        {
            this.AimGraph = aimGraph;
            this.totalCnt = originGraph.Length;
        }
        public byte[] AimGraph { get => _aimGraph; set => _aimGraph = value; }
        public byte[] Match()
        {
            //分别均衡化两幅图
            double[] originAccum = BasicStatis.GetAccumFrequency(OriginGraph);
            int[] originHisto = new int[256];
            for (int i = 0; i < 256; i++)
            {
                originHisto[i] = System.Convert.ToInt32(255 * originAccum[i]);
            }

            double[] aimAccum = BasicStatis.GetAccumFrequency(AimGraph);
            int[] aimHisto = new int[256];
            for (int i = 0; i < 256; i++)
            {
                aimHisto[i] = System.Convert.ToInt32(255 * aimAccum[i]);
            }

            int[] matchedPixels = MatchByAim(originHisto, aimHisto);
            byte[] newGraph = GetMatchedGraph(matchedPixels, OriginGraph);
            return newGraph;
        }
        private int[] MatchByAim(int[] origin, int[] aim)
        {
            bool flag;
            int[] matchedPixels = new int[256];
            int cnt = 0;
            for (int i = 0; i < 256; i++)
            {
                int oriEle = origin[i];
                flag = true;
                for (int j = 0; j < 256; j++)
                {
                    if (aim[j] == oriEle)
                    {
                        matchedPixels[cnt++] = j;
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    int jMin = 0;
                    int minPixel = 255;
                    for (int j = 0; j < 256; j++)
                    {
                        int b = Math.Abs(aim[j] - oriEle);
                        if (b < minPixel)
                        {
                            minPixel = b;
                            jMin = j;
                        }
                    }
                    matchedPixels[cnt++] = jMin;
                }
            }
            return matchedPixels;
        }
        private byte[] GetMatchedGraph(int[] matchedPixel, byte[] originGraph)
        {
            for (int i = 0; i < totalCnt; i++)
            {
                originGraph[i] = (byte)matchedPixel[originGraph[i]];
            }
            return originGraph;
        }
    }
}


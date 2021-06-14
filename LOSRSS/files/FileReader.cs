using LOSRSS.dataFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LOSRSS.files
{
    /// <summary>
    /// ReadDataFile类是BandForm下储存图像的手段，初始化有两种重载：
    /// 一是通过读取头文件及相关图像
    /// 二是通过输入图像数组、图像头文件和图像名称
    /// SetColorGraph和SetGrayGraph方法是显示图像的前奏。
    /// </summary>
    public class FileReader:HeadFileReader
    {
        private byte[,] grayGraph;
        private byte[,,] colorGraph;
        private string graphFileName;
        private byte[,,] graphInner;
        private string graphName;

        public byte[,] GrayGraph { get => grayGraph; set => grayGraph = value; }
        public byte[,,] ColorGraph { get => colorGraph; set => colorGraph = value; }
        public string GraphFileName { get => graphFileName; set => graphFileName = value; }
        public byte[,,] GraphInner { get => graphInner; set => graphInner = value; }
        public string GraphName { get => graphName; set => graphName = value; }

        public FileReader(string headFileName):base(headFileName)
        {
            GraphName = System.IO.Path.GetFileNameWithoutExtension(headFileName);
            GraphFileName = headFileName.Split('.')[0];
            //创建储存图片内容的数组
            GraphInner = new byte[base.Bands, base.Samples, base.Lines];
            if(this.Interleave.ToLower() == "bsq")
            {
                getBSQInner();
            }
            else if (this.Interleave.ToLower() == "bip")
            {
                getBIPInner();
            }
            else if (this.Interleave.ToLower() == "bil")
            {
                getBILInner();
            }
        }

        public FileReader(string graphName, byte[,,] graphInner, Dictionary<string, string> headInner) : base(headInner)
        {
            this.graphInner = graphInner;
            this.graphName = graphName;
        }
        #region 根据类型获取图片内容
        /// <summary>
        /// 根据不同类型获取图片内容
        /// </summary>
        private void getBSQInner()
        {
            FileStream fileStream = new FileStream(GraphFileName, FileMode.Open);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            for (int i = 0; i < this.Bands; i++)
            {
                for (int j = 0; j < this.Samples; j++)
                {
                    for (int k = 0; k < this.Lines; k++)
                    {
                        GraphInner[i, j, k] = binaryReader.ReadByte();
                    }
                }
            }
            binaryReader.Close();
            fileStream.Close();
        }
        private void getBILInner()
        {
            FileStream fileStream = new FileStream(GraphFileName, FileMode.Open);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            for (int i = 0; i < this.Lines; i++)
            {
                for (int j = 0; j < this.Bands; j++)
                {
                    for (int k = 0; k < this.Samples; k++)
                    {
                        GraphInner[i, j, k] = binaryReader.ReadByte();
                    }
                }
            }
            binaryReader.Close();
            fileStream.Close();
        }
        private void getBIPInner()
        {
            FileStream fileStream = new FileStream(GraphFileName, FileMode.Open);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            for (int i = 0; i < this.Lines; i++)
            {
                for (int j = 0; j < this.Samples; j++)
                {
                    for (int k = 0; k < this.Bands; k++)
                    {
                        GraphInner[i, j, k] = binaryReader.ReadByte();
                    }
                }
            }
            binaryReader.Close();
            fileStream.Close();
        }
        #endregion
        //设置导入用的灰度图像
        public void SetGrayGraph(int band)
        {
            GrayGraph = new byte[Samples, Lines];
            for(int i = 0; i < this.Samples; i++)
            {
                for (int j = 0; j < this.Lines; j++)
                {
                    GrayGraph[i, j] = this.GraphInner[band - 1, i, j];
                }
            }
        }
        /// <summary>
        /// 逐个波段设置设置导入用的彩色合成图像。
        /// </summary>
        /// <param name="band1"></param>
        /// <param name="band2"></param>
        /// <param name="band3"></param>
        public void SetColorGraph(int band1, int band2, int band3)
        {
            ColorGraph = new byte[3, Samples, Lines];
            for (int i = 0; i < this.Samples; i++)
            {
                for (int j = 0; j < this.Lines; j++)
                {
                    ColorGraph[0, i, j] = this.GraphInner[band1, i, j];
                }
            }

            for (int i = 0; i < this.Samples; i++)
            {
                for (int j = 0; j < this.Lines; j++)
                {
                    ColorGraph[1, i, j] = this.GraphInner[band2, i, j];
                }
            }

            for (int i = 0; i < this.Samples; i++)
            {
                for (int j = 0; j < this.Lines; j++)
                {
                    ColorGraph[2, i, j] = this.GraphInner[band3, i, j];
                }
            }
        }
    }
}

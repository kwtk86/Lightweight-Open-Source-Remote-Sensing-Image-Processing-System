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
    /// 保存图像
    /// </summary>
    class FileWriter:HeadFileWriter
    {
        private string _saveGraphName;
        private byte[] _saveGraphInner;
        /// <summary>
        /// 保存图像
        /// </summary>
        /// <param name="writeFileName">保存文件名</param>
        /// <param name="writeGraphInner">图像数组</param>
        /// <param name="HeadInner">头文件</param>
        public FileWriter(string writeFileName, byte[] writeGraphInner, Dictionary<string, string> HeadInner):base(writeFileName, HeadInner)
        {
            this._saveGraphName = writeFileName.Split('.')[0];
            this._saveGraphInner = writeGraphInner;
        }
        public void saveGraphFile()
        {
            //直接使用write()函数写入全部内容
            FileStream graphStream = new FileStream(_saveGraphName, FileMode.Create);
            graphStream.Write(_saveGraphInner, 0, _saveGraphInner.Length);
            graphStream.Close();
        }
    }
}

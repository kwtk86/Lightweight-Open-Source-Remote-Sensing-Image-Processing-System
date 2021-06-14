using LOSRSS.files;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOSRSS.dataFile
{
    /// <summary>
    /// 读取头文件，有两个重载，原理类似ReadDataFile
    /// </summary>
    public class HeadFileReader
    {
        private int _samples;
        private int _lines;
        private int _headerOffset;
        private int _bands;
        private string _fileType;
        private string _dataType;
        private string _interleave;
        private string _sensorType;
        private int _byteOrder;
        private string _wavelengthUnits;
        //保存头文件信息的字典，向外传递主要依赖字典。
        public Dictionary<string, string> headInner = new Dictionary<string, string>();
        /// <summary>
        /// 读取头文件
        /// </summary>
        /// <param name="headFileName">头文件名</param>
        public HeadFileReader(string headFileName)
        {
            System.IO.StreamReader headReader = new System.IO.StreamReader(headFileName);
            string hearFileLine = "";
            while ((hearFileLine = headReader.ReadLine()) != null)
            {
                char spliter = '=';
                string[] curLine = hearFileLine.Split(spliter);
                if (curLine.Length == 1)
                {
                    continue;
                }
                //根据开头判断属性，读取头文件内容
                //可以有更多属性待后续补充
                #region 读取头文件
                if (hearFileLine.StartsWith("samples"))
                {
                    this.Lines1 = Convert.ToInt32(curLine[1].Trim());
                    headInner.Add("lines", Lines1.ToString());
                }
                else if (hearFileLine.StartsWith("lines"))
                {
                    this.Samples1 = Convert.ToInt32(curLine[1].Trim());
                    headInner.Add("samples", Samples1.ToString());
                }
                else if (hearFileLine.StartsWith("bands"))
                {
                    this.Bands1 = Convert.ToInt32(curLine[1].Trim());
                    headInner.Add("bands", Bands1.ToString());
                }
                else if (hearFileLine.StartsWith("header offset"))
                {
                    this.HeaderOffset1 = Convert.ToInt32(curLine[1].Trim());
                    headInner.Add("headerOffset", HeaderOffset1.ToString());
                }
                else if (hearFileLine.StartsWith("file type"))
                {
                    this.FileType1 = curLine[1].Trim();
                    headInner.Add("file type", FileType1);
                }
                else if (hearFileLine.StartsWith("data type"))
                {
                    this.DataType1 = curLine[1].Trim();
                    headInner.Add("data type", DataType1);
                }
                else if (hearFileLine.StartsWith("interleave"))
                {
                    this.Interleave1 = curLine[1].Trim();
                    headInner.Add("interleave", Interleave1);
                }
                else if (hearFileLine.StartsWith("sensor type"))
                {
                    this.SensorType1 = curLine[1].Trim();
                    headInner.Add("sensor type", SensorType1);
                }
                else if (hearFileLine.StartsWith("byte order"))
                {
                    this.ByteOrder1 = Convert.ToInt32(curLine[1].Trim());
                    headInner.Add("byteOrder", ByteOrder1.ToString());
                }
                else if (hearFileLine.StartsWith("wavelength units"))
                {
                    this.WavelengthUnits1 = curLine[1].Trim();
                    headInner.Add("wavelength units", WavelengthUnits1);
                }
                #endregion
            }
        }
        /// <summary>
        /// 生成新图像的头文件信息
        /// </summary>
        /// <param name="headInner">头文件信息</param>
        public HeadFileReader(Dictionary<string , string> headInner)
        {
            this.headInner = headInner;
            this.Bands = int.Parse(headInner["bands"]);
            this.Samples = int.Parse(headInner["samples"]);
            this.Lines = int.Parse(headInner["lines"]);
            this.FileType = headInner["file type"];
            this.DataType = headInner["data type"];
            this.Interleave = headInner["interleave"];
            this.SensorType = headInner["sensor type"];
            this.ByteOrder = int.Parse(headInner["byteOrder"]);
            this.WavelengthUnits = headInner["wavelength units"];
        }
        public string FileType { get => FileType1; set => FileType1 = value; }
        public string DataType { get => DataType1; set => DataType1 = value; }
        public string Interleave { get => Interleave1; set => Interleave1 = value; }
        public string SensorType { get => SensorType1; set => SensorType1 = value; }
        public int ByteOrder { get => ByteOrder1; set => ByteOrder1 = value; }
        public string WavelengthUnits { get => WavelengthUnits1; set => WavelengthUnits1 = value; }
        public int Samples { get => Samples1; set => Samples1 = value; }
        public int Lines { get => Lines1; set => Lines1 = value; }
        public int HeaderOffset { get => HeaderOffset1; set => HeaderOffset1 = value; }
        public int Bands { get => Bands1; set => Bands1 = value; }
        public int Samples1 { get => _samples; set => _samples = value; }
        public int Lines1 { get => _lines; set => _lines = value; }
        public int HeaderOffset1 { get => _headerOffset; set => _headerOffset = value; }
        public int Bands1 { get => _bands; set => _bands = value; }
        public string FileType1 { get => _fileType; set => _fileType = value; }
        public string DataType1 { get => _dataType; set => _dataType = value; }
        public string Interleave1 { get => _interleave; set => _interleave = value; }
        public string SensorType1 { get => _sensorType; set => _sensorType = value; }
        public int ByteOrder1 { get => _byteOrder; set => _byteOrder = value; }
        public string WavelengthUnits1 { get => _wavelengthUnits; set => _wavelengthUnits = value; }

    }
    /// <summary>
    /// 写头文件
    /// </summary>
    class HeadFileWriter
    {

        private Dictionary<string, string> _saveHeadInner = new Dictionary<string, string>();
        private string _saveFileName;
        /// <summary>
        /// 写头文件
        /// </summary>
        /// <param name="saveFileName">头文件名</param>
        /// <param name="saveHeadInner">头文件内容</param>
        public HeadFileWriter(string saveFileName, Dictionary<string, string> saveHeadInner)
        {
            this._saveHeadInner = saveHeadInner;
            this._saveFileName = saveFileName;
        }
        /// <summary>
        /// 根据字典内容写头文件
        /// </summary>
        public void saveHeadFile()
        {
            StreamWriter headWriter = new StreamWriter(this._saveFileName);
            headWriter.WriteLine("ENVI description = {File Imported into ENVI.}");
           
            foreach (KeyValuePair<string, string> keyPair in this._saveHeadInner)
            {
                headWriter.WriteLine(keyPair.Key + " = " + keyPair.Value);
            }
            headWriter.Close();
        }
    }
}

using LOSRSS.files;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LOSRSS
{
    public partial class MainForm : Form
    {
        //历史记录
        public MainForm()
        {
            InitializeComponent();
        }

        private void BSQ转BILToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //打开文件
            OpenFileDialog BSQOpener = new OpenFileDialog();
            BSQOpener.Filter = "头文件|*.hdr";
            if(BSQOpener.ShowDialog() == DialogResult.OK)
            {
                //读取文件内容
                string BSQName = BSQOpener.FileName;
                FileReader BSQToBILFile = new FileReader(BSQName);
                if(BSQToBILFile.Interleave.ToLower() != "bsq")
                {
                    MessageBox.Show("该头文件不对应bsq文件");
                    return;
                }
                //转为BIL并改写头文件
                byte[] newBILInner = GraphConvert.BSQtoBIL(BSQToBILFile.GraphInner);
                BSQToBILFile.headInner["interleave"] = "BIL";
                //保存文件
                SaveFileDialog BILSaver = new SaveFileDialog();
                BILSaver.Filter = "头文件|*.hdr";
                if (BILSaver.ShowDialog() == DialogResult.OK)
                {
                    FileWriter saveBIL = new FileWriter(BILSaver.FileName, newBILInner, BSQToBILFile.headInner);
                    saveBIL.saveHeadFile();
                    saveBIL.saveGraphFile();
                    MessageBox.Show("成功写入");
                }
            }
            
        }

        private void BSQ转BIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //打开文件
            OpenFileDialog BSQOpener = new OpenFileDialog();
            BSQOpener.Filter = "头文件|*.hdr";
            if (BSQOpener.ShowDialog() == DialogResult.OK)
            {
                //读取文件内容
                string BSQName = BSQOpener.FileName;
                FileReader BSQToBILFile = new FileReader(BSQName);
                if (BSQToBILFile.Interleave.ToLower() != "bsq")
                {
                    MessageBox.Show("该头文件不对应bsq文件");
                    return;
                }
                //转为BIL并改写头文件
                byte[] newBILInner = GraphConvert.BSQtoBIP(BSQToBILFile.GraphInner);
                BSQToBILFile.headInner["interleave"] = "BIP";
                //保存文件
                SaveFileDialog BILSaver = new SaveFileDialog();
                BILSaver.Filter = "头文件|*.hdr";
                if (BILSaver.ShowDialog() == DialogResult.OK)
                {
                    FileWriter saveBIL = new FileWriter(BILSaver.FileName, newBILInner, BSQToBILFile.headInner);
                    saveBIL.saveHeadFile();
                    saveBIL.saveGraphFile();
                    MessageBox.Show("成功写入");
                }
            }
        }

        private void 多波段合成BSQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog BSQMergerDialog = new OpenFileDialog();
            BSQMergerDialog.Filter = "头文件|*.hdr";
            BSQMergerDialog.Multiselect = true;
            //储存所有的图像信息

            if(BSQMergerDialog.ShowDialog() == DialogResult.OK)
            {
                if(BSQMergerDialog.FileNames.Length == 0)
                {
                    MessageBox.Show("未选中文件");
                    return;
                }

                int cnt = 0;
                int preSamples = -1;
                int preLines = -1;
                //初始化数组
                FileReader curFile0 = new FileReader(BSQMergerDialog.FileNames[0]);
                byte[,,] tempGraphs = new byte[BSQMergerDialog.FileNames.Length, curFile0.Samples, curFile0.Lines];
                byte[] mergeGraph = new byte[BSQMergerDialog.FileNames.Length * curFile0.Samples * curFile0.Lines];
                Dictionary<string, string> headInner = new Dictionary<string, string>();
                //逐个遍历待打开的文件
                foreach (string fileName in BSQMergerDialog.FileNames)
                {
                    FileReader curFile = new FileReader(fileName);
                    #region 判断是否可以合并
                    if (curFile.Bands != 1)
                    {
                        MessageBox.Show("不是单波段文件, 无法合并！");
                        return;
                    }
                    if(preSamples != -1 && preLines != -1)
                    {
                        if(curFile.Samples!=preSamples || curFile.Lines!=preLines)
                        {
                            MessageBox.Show("选择的图像大小不一致，无法合并。");
                            return;
                        }
                    }
#endregion
                    preSamples = curFile.Samples;
                    preLines = curFile.Lines;
                    //将单波段文件中的内容放入tempgraphs中
                    for(int i=0 ;i<curFile.Samples; i++)
                    {
                        for (int j = 0; j < curFile.Lines; j++)
                        {
                            tempGraphs[cnt, i, j] = curFile.GraphInner[0, i, j];
                        }
                    }
                    cnt++;
                    headInner = curFile.headInner;
                }
                //修改头文件内容
                headInner["bands"] = BSQMergerDialog.FileNames.Length.ToString();
                //合并波段
                mergeGraph = GraphConvert.BandMerger(tempGraphs);
                SaveFileDialog BSQSaverDialog = new SaveFileDialog();
                BSQSaverDialog.Filter = "头文件|*.hdr";
                //保存文件
                if(BSQSaverDialog.ShowDialog() == DialogResult.OK)
                {
                    FileWriter curFileSaver = new FileWriter(BSQSaverDialog.FileName, mergeGraph, headInner);
                    curFileSaver.saveHeadFile();
                    curFileSaver.saveGraphFile();
                    MessageBox.Show("ok");
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void 加载波段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog graphOpener = new OpenFileDialog();
            graphOpener.Filter = "头文件|*.hdr";
            if (graphOpener.ShowDialog() == DialogResult.OK)
            {
                //读取文件内容
                hisRecords.Items.Add(graphOpener.FileName);
                LoadBands(graphOpener.FileName);
            }
        }
        /// <summary>
        /// 载入历史图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void historyButton_Click(object sender, EventArgs e)
        {
            if(hisRecords.SelectedItems.Count == 0)
            {
                return;
            }
            LoadBands(hisRecords.SelectedItem.ToString());
        }
        private void LoadBands(string fileName)
        {
            BandForm newBandForm = new BandForm(fileName);
            newBandForm.Show();
        }
    }
}

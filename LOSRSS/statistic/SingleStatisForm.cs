using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOSRSS
{
    public partial class SingleStatisForm : Form
    {
        double[] avg;
        double[] dev;
        double[] contrast;
        double[] entropy;
        int bands;
        public SingleStatisForm(double[] avg, double[] dev, double[] contrast, double[] entropy)
        {
            Bands = avg.Length;
            Avg = avg;
            Dev = dev;
            Entropy = entropy;
            Contrast = contrast;
            InitializeComponent();
            IniListView();
            AddStaInfo();
        }
        public void IniListView()
        {
            StatisList.Columns.Add("波段", 40, HorizontalAlignment.Left);
            StatisList.Columns.Add("均值", 60, HorizontalAlignment.Left);
            StatisList.Columns.Add("标准差", 60, HorizontalAlignment.Left);
            StatisList.Columns.Add("对比度", 60, HorizontalAlignment.Left);
            StatisList.Columns.Add("信息熵", 60, HorizontalAlignment.Left);
            StatisList.BeginUpdate();
        }

        public void AddStaInfo()
        {
            for(int i = 0; i < Bands; i ++)
            {
                ListViewItem newItem = new ListViewItem();
                newItem.Text = "Band" + (i + 1).ToString();
                newItem.SubItems.Add(Math.Round(Avg[i], 2).ToString());
                newItem.SubItems.Add(Math.Round(Dev[i], 2).ToString());
                newItem.SubItems.Add(Math.Round(Contrast[i], 5).ToString());
                newItem.SubItems.Add(Math.Round(Entropy[i], 2).ToString());
                this.StatisList.Items.Add(newItem);
            }
        }

        public double[] Avg { get => avg; set => avg = value; }
        public double[] Dev { get => dev; set => dev = value; }
        public double[] Contrast { get => contrast; set => contrast = value; }
        public int Bands { get => bands; set => bands = value; }
        public double[] Entropy { get => entropy; set => entropy = value; }
        private void StatisForm_Load(object sender, EventArgs e)
        {

        }
    }
}

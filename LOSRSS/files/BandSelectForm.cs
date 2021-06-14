using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOSRSS.files
{
    public partial class BandSelectForm : Form
    {
        public BandSelectForm(string fileName, int bands)
        {
            InitializeComponent();
            for(int i = 1;i<bands+1;i++)
            {
                listBox1.Items.Add(fileName + "_band" + i.ToString());
            }
        }

        private void BandSelectForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSaveByBand_Click(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

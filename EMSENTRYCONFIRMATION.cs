using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMSMaterialPreparation
{
    public partial class EMSENTRYCONFIRMATION : Form
    {
        public EMSENTRYCONFIRMATION()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.OK;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
        }

        private void EMSENTRYCONFIRMATION_Load(object sender, EventArgs e)
        {
            lblconfmodel.Text = "Model : " + Form1.model;
            lblconfLot.Text = "Lot Num : " + Form1.lotNum;
            lblconfqty.Text = "Quantity : " + Form1.qty;
            lblemsloc.Text = "EMS Location : " + Form1.emsName;

        }
    }
}

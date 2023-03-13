using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMSMaterialPreparation
{
    public partial class Remarks : Form
    {
        public Remarks()
        {
            InitializeComponent();
        }

        private void Remarks_Load(object sender, EventArgs e)
        {
            lblModel.Text = "Model : " + Form1.model;
            lblLotNo.Text = "Lot Number : " + Form1.lotNum;
            lblProductionOrder.Text = "Prodution Order : " + Form1.productionOrder;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=172.16.206.20;Initial Catalog=IBusinessTest;User ID=Data_writer;Password=Pasmy@2791381230");
            string qry = "UPDATE [dbo].[EMS_MODEL_LOT_QUANTITY] SET [REMARKS] = @rmks WHERE [PRODUCTION_ORDER] = @ProdOrd AND [MODEL] = @modelNum AND [LOT_NO] = @lotNum";
            SqlCommand cmd = new SqlCommand(qry,cnn);
            SqlParameter rmksParam = new SqlParameter("@rmks", SqlDbType.NVarChar);
            rmksParam.Value = txtRemarks.Text;
            SqlParameter ProdOrdParam = new SqlParameter("@ProdOrd", SqlDbType.NVarChar);
            ProdOrdParam.Value = Form1.productionOrder;
            SqlParameter lotNumParam = new SqlParameter("@lotNum", SqlDbType.NVarChar);
            lotNumParam.Value = Form1.lotNum;
            SqlParameter modelNumParam = new SqlParameter("@modelNum", SqlDbType.NVarChar);
            modelNumParam.Value = Form1.model;

            cmd.Parameters.Add(rmksParam);
            cmd.Parameters.Add(ProdOrdParam);
            cmd.Parameters.Add(lotNumParam);
            cmd.Parameters.Add(modelNumParam);


            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();

            }
            catch(Exception ex)
            {

            }
            finally
            {
                DialogResult = DialogResult.OK;
                cnn.Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

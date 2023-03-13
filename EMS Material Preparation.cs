using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using EMSMaterialPreparation.GETProductionInfo;
using SixLabors.ImageSharp.ColorSpaces;

namespace EMSMaterialPreparation
{
    public partial class Form1 : Form
    {
        private SqlConnection cnn;
        private string sqlQry;
        private SqlDataAdapter da;
        public static string model;
        public static string productionOrder;
        public static string lotNum;
        public static string qty;
        public static string emsName;
        public static ArrayList poList = new ArrayList();

        public Form1()
        {
            InitializeComponent();
            cnn = new SqlConnection(@"Data Source=172.16.206.20;Initial Catalog=IBusinessTest;User ID=Data_writer;Password=Pasmy@2791381230");
        }

        private void rb_SANSHIN_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_SANSHIN.Checked)
            {
                generateData("SANSHIN");
                emsName = "SANSHIN";
            }
            
        }

        private void rb_scope_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_scope.Checked)
            {
                generateData("SCOPE");
                emsName = "SCOPE";
            }
            
        }

        private void rb_HotayiBT_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_HotayiBT.Checked)
            {
                generateData("HOTAYI_BT");
                emsName = "HOTAYI_BT";
            }
           
        }

        private void rb_HotayiBK_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_HotayiBK.Checked)
            {
                generateData("HOTAYI_BK");
                emsName = "HOTAYI_BK";
            }
            
        }
        private void generateData(string ems_param)
        {
            string command = "SELECT [MODEL],[LOT_NO],[QUANTITY],[EMS],[PRODUCTION_ORDER],[REMARKS] FROM [IBusinessTest].[dbo].[EMS_MODEL_LOT_QUANTITY] WHERE [EMS] = '" + ems_param + "' AND COMPLETED != 'X'";
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(command, cnn);
            try
            {
                cnn.Open();
                da.Fill(dt);
                dgvEMS.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }

        private void btn_rmk_Click(object sender, EventArgs e)
        {
            


            if(dgvEMS.SelectedRows.Count == 1)
            {
                DataGridViewRow row = this.dgvEMS.SelectedRows[0];
                model = row.Cells["MODEL"].Value.ToString();
                productionOrder = row.Cells["PRODUCTION_ORDER"].Value.ToString();
                lotNum = row.Cells["LOT_NO"].Value.ToString();
                Remarks f_rmk = new Remarks();
                if (f_rmk.ShowDialog(this) == DialogResult.OK)
                {
                    generateData(emsName);
                }

            }
            else if (dgvEMS.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select only one row");
            }
            else{
                MessageBox.Show("Select row first before adding a remark");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtProdOrdSearch.Text != "")
            {
                try
                {
                    if (rb_HotayiBK.Checked)
                    {
                        get_productionInfo(txtProdOrdSearch.Text, "HOTAYI_BK");
                    }
                    else if (rb_HotayiBT.Checked)
                    {
                        get_productionInfo(txtProdOrdSearch.Text, "HOTAYI_BT");
                    }
                    else if (rb_SANSHIN.Checked)
                    {
                        get_productionInfo(txtProdOrdSearch.Text, "SANSHIN");
                    }
                    else if (rb_scope.Checked)
                    {
                        get_productionInfo(txtProdOrdSearch.Text, "SCOPE");
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                EMSENTRYCONFIRMATION showConfirmation = new EMSENTRYCONFIRMATION();
                if (showConfirmation.ShowDialog(this) == DialogResult.OK)
                {
                    string insert_Query = "INSERT INTO [dbo].[EMS_MODEL_LOT_QUANTITY] ([MODEL],[LOT_NO],[QUANTITY],[EMS],[PRODUCTION_ORDER],[COMPLETED],[REMARKS]) VALUES (@model,@lotNumber,@qty,@emsSec,@prodOrd,'','')";
                    SqlCommand cmd  = new SqlCommand(insert_Query,cnn);
                    cmd.Parameters.AddWithValue("@model", model);
                    cmd.Parameters.AddWithValue("@lotNumber", lotNum);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@emsSec", emsName);
                    cmd.Parameters.AddWithValue("@prodOrd", txtProdOrdSearch.Text);
                    try { 
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                    catch(Exception ex) { }
                    finally
                    {
                        cnn.Close();
                        txtProdOrdSearch.Text = "";
                    }
                    generateData(emsName);
                }
                else
                {

                }
            }
 
        }

        private void get_productionInfo(string prodNum,string paramEmsName)
        {
            WsdlDataRetrieval wsdldata = new WsdlDataRetrieval();
           

            ZWM_MY_I_PROD_SCHEDResponse pShedResp = wsdldata.get_productionInfofromSAP(prodNum);
            if (pShedResp.ITEM.Length > 0)
            {
                model = pShedResp.ITEM[0].MODEL_NO;
                productionOrder = pShedResp.ITEM[0].PRODUCTION_ORDER;
                lotNum = pShedResp.ITEM[0].PRODUCTION_LOT;
                qty = pShedResp.ITEM[0].ORDER_QUANTITY.ToString();
                emsName = paramEmsName;

            }
            

        }

        private void btnGeneratePull_Click(object sender, EventArgs e)
        {
            if (poList.Count > 0)
            {
                poList.Clear();
            }
            foreach(DataGridViewRow row in dgvEMS.Rows)
            {
                poList.Add(row.Cells["PRODUCTION_ORDER"].Value);

            }



            Cursor.Current = Cursors.WaitCursor;
            GENERATEEMSPICKLIST picklistEMS = new GENERATEEMSPICKLIST();
            picklistEMS.Show();
            Cursor.Current = Cursors.Default;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_RemoveLot_Click(object sender, EventArgs e)
        {

            if (dgvEMS.SelectedRows.Count == 1)
            {
                DataGridViewRow row = this.dgvEMS.SelectedRows[0];
                model = row.Cells["MODEL"].Value.ToString();
                productionOrder = row.Cells["PRODUCTION_ORDER"].Value.ToString();
                lotNum = row.Cells["LOT_NO"].Value.ToString();

                string update_query = "UPDATE [dbo].[EMS_MODEL_LOT_QUANTITY] SET [COMPLETED] = 'X',[DATE_COMPLETED] = GETDATE() WHERE [MODEL] = @model and [LOT_NO] = @lotNumb AND [EMS] = @emsloc AND [PRODUCTION_ORDER] = @prodOrd";
                SqlCommand cmd = new SqlCommand(update_query, cnn);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@lotNumb", lotNum);
                cmd.Parameters.AddWithValue("@emsloc", emsName);
                cmd.Parameters.AddWithValue("@prodOrd", productionOrder);
                try
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                catch (Exception ex) { }
                finally
                {
                    cnn.Close();
                    generateData(emsName);
                }

            }
            else if (dgvEMS.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select only one row");
            }
            else
            {
                MessageBox.Show("Select row first before adding a remark");
            }

        }
    }
}

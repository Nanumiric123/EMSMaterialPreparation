using EMSMaterialPreparation.GETProductionInfo;
using EMSMaterialPreparation.GET_STOCK_PASMY_EMS;
using EMSMaterialPreparation.GETEMSVENDORSTOCK;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SixLabors.ImageSharp.ColorSpaces;
using MigraDoc.DocumentObjectModel.Tables;

namespace EMSMaterialPreparation
{
    public partial class GENERATEEMSPICKLIST : Form
    {
        private DataTable initialDt;
        private SqlConnection cnn;
        public string picklistNo = "";
        private string DONo = "";
        private string runningNumberEMSName = "";
        public GENERATEEMSPICKLIST()
        {
            InitializeComponent();
            initialDt = new DataTable();
            initialDt.Columns.Add("NO",typeof(int));
            initialDt.Columns.Add("COMPONENT");
            initialDt.Columns.Add("REQUIREMENT_QUANTITY");
            initialDt.Columns.Add("WITHDRAWN_QUANTITY");
            initialDt.Columns.Add("BALANCE");
            initialDt.Columns.Add("EMS_STOCK");
            initialDt.Columns.Add("VENDOR_STOCK");
            initialDt.Columns.Add("BAL_QTY",typeof(decimal));
            initialDt.Columns.Add("PRODUCTION_ORDER");
        }



        private void GENERATEEMSPICKLIST_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(@"Data Source=172.16.206.20;Initial Catalog=IBusinessTest;User ID=Data_writer;Password=Pasmy@2791381230");
            DataTable dt = new DataTable();
            dt.Columns.Add("COMPONENT");
            dt.Columns.Add("REQUIREMENT_QUANTITY");
            dt.Columns.Add("WITHDRAWN_QUANTITY");


            DataTable dt2 = new DataTable();
            dt2.Columns.Add("COMPONENT");
            dt2.Columns.Add("PRODUCTION_ORDER");

            DataTable dt3 = new DataTable();
            dt3.Columns.Add("COMPONENT");
            dt3.Columns.Add("REQUIREMENT_QUANTITY");
            dt3.Columns.Add("WITHDRAWN_QUANTITY");
            dt3.Columns.Add("PRODUCTION_ORDER");


            WsdlDataRetrieval wsdl = new WsdlDataRetrieval();

            foreach (var i in Form1.poList)
            {
                ZWM_MY_I_PROD_SCHEDResponse resp = wsdl.get_productionInfofromSAP(i.ToString());
                for(int K = 0;K < resp.ITEM.Length;K++)
                {
                    DataRow dr  = dt.NewRow();
                    dr["COMPONENT"] = resp.ITEM[K].COMPONENT;
                    dr["REQUIREMENT_QUANTITY"] = Convert.ToDecimal(resp.ITEM[K].REQUIREMENT_QUANTITY);
                    dr["WITHDRAWN_QUANTITY"] = Convert.ToDecimal(resp.ITEM[K].WITHDRAWN_QUANTITY);
                    dt.Rows.Add(dr);

                    DataRow dr2 = dt2.NewRow();
                    dr2["COMPONENT"] = resp.ITEM[K].COMPONENT;
                    dr2["PRODUCTION_ORDER"] = resp.ITEM[K].PRODUCTION_ORDER;
                    dt2.Rows.Add(dr2);
                }
            }

            try
            {

                var agrdt = dt.AsEnumerable().OrderBy(x => x.Field<string>("COMPONENT")).
                    GroupBy(r => r.Field<string>("COMPONENT"));

                var agrdt2 = dt2.AsEnumerable().Select(row => new DT2
                {
                    PRODUCTION_ORDER = row.Field<string>("PRODUCTION_ORDER"),
                    COMPONENT = row.Field<string>("COMPONENT")
                }).Distinct();

                foreach(var items in agrdt.ToList())
                {
                    string PO = "";

                    DataRow nr3 = dt3.NewRow();

                    foreach(DataRow row in items)
                    {
                        foreach (var item2 in agrdt2.ToList())
                        {
                            
                            if (row.ItemArray[0].ToString() == item2.COMPONENT)
                            {
                                if (!PO.Contains(item2.PRODUCTION_ORDER))
                                {
                                    PO = PO + " " + item2.PRODUCTION_ORDER;
                                }


                            }
                        }
                        nr3["COMPONENT"] = row["COMPONENT"];
                        nr3["PRODUCTION_ORDER"] = PO.Trim();
                        nr3["REQUIREMENT_QUANTITY"] = row["REQUIREMENT_QUANTITY"];
                        nr3["WITHDRAWN_QUANTITY"] = row["WITHDRAWN_QUANTITY"];
                    }

                    dt3.Rows.Add(nr3);
                }
                int num = 1;
                string stor_loc = "";
                string vendorCode = "";

                if (Form1.emsName == "HOTAYI_BK")
                {
                    stor_loc = "2106";
                    storType = "016";
                    vendorCode = "0030000162";
                    picklistNo = "DOHTY" + DateTime.Now.ToString("yyyyMM") + picklistNoRetrieval("HT_BK");
                    DONo = "DOHTY" + DateTime.Now.ToString("yyyyMM") + DONoRetrieval("HT_BK");
                    runningNumberEMSName = "HT_BK";
                }
                else if (Form1.emsName == "HOTAYI_BT")
                {
                    stor_loc = "2108";
                    storType = "018";
                    vendorCode = "0030001066";
                    picklistNo = "DOHTY" + DateTime.Now.ToString("yyyyMM") + picklistNoRetrieval("HT_BT");
                    DONo = "DOHTY" + DateTime.Now.ToString("yyyyMM") + DONoRetrieval("HT_BT");
                    runningNumberEMSName = "HT_BT";
                }
                else if (Form1.emsName == "SANSHIN")
                {
                    stor_loc = "2105";
                    storType = "015";
                    vendorCode = "0030000305";
                    picklistNo = "DOSS" + DateTime.Now.ToString("yyyyMM") + picklistNoRetrieval("SS_PB");
                    DONo = "DOS" + DateTime.Now.ToString("yyyyMM") + DONoRetrieval("SS_PB");
                    runningNumberEMSName = "SS_PB";
                }
                else if (Form1.emsName == "SCOPE")
                {
                    stor_loc = "2107";
                    storType = "017";
                    vendorCode = "0030000993";
                    picklistNo = "DOSCP" + DateTime.Now.ToString("yyyyMM") + picklistNoRetrieval("SCOPE");
                    DONo = "DOSCP" + DateTime.Now.ToString("yyyyMM") + DONoRetrieval("SCOPE");
                    runningNumberEMSName = "SCOPE";
                }
                else
                {

                }
                txt_pickListNo.Text = picklistNo;
                txt_DO_no.Text = DONo;

                ZIM_GET_EMS_STOCKResponse stocks = wsdl.getStockFromPASMYEMS(stor_loc);
                DataTable Vstocks = wsdl.getstockFromVENDOREMS(vendorCode);


                foreach (DataRow dr3 in dt3.Rows)
                {
                    DataRow initRow = initialDt.NewRow();
                    initRow["NO"] = num;
                    initRow["COMPONENT"] = dr3["COMPONENT"];
                    initRow["REQUIREMENT_QUANTITY"] = dr3["REQUIREMENT_QUANTITY"];
                    initRow["WITHDRAWN_QUANTITY"] = dr3["WITHDRAWN_QUANTITY"];
                    initRow["BALANCE"] = Convert.ToDecimal(dr3["REQUIREMENT_QUANTITY"].ToString()) - Convert.ToDecimal(dr3["WITHDRAWN_QUANTITY"].ToString());

                    int countPASMY = 0;
                    for (int i =0; i<stocks.ITEM.Length; i++)
                    {


                        if (dr3["COMPONENT"].ToString() == stocks.ITEM[i].MATNR)
                        {
                            initRow["EMS_STOCK"] = Convert.ToDecimal(stocks.ITEM[0].LABST);
                            countPASMY++;
                        }
                        if (countPASMY == 0)
                        {
                            initRow["EMS_STOCK"] = 0;
                        }

                    }

                    int countEMS = 0;
                    foreach (DataRow p in Vstocks.Rows)
                    {

                        if (p["MATNR"].ToString() == dr3["COMPONENT"].ToString())
                        {
                            initRow["VENDOR_STOCK"] = Convert.ToDecimal(p["QUANTITY"].ToString());
                            countEMS++;
                        }
                        if (countEMS == 0)
                        {
                            initRow["VENDOR_STOCK"] = 0;
                        }

                    }
                    decimal vendorStock = 0.0m;
                    decimal EMSStock = 0.0m;
                    try
                    {
                        vendorStock = Convert.ToDecimal(initRow["VENDOR_STOCK"].ToString());
                    }
                    catch
                    {
                        vendorStock = 0.0m;
                    }
                    try
                    {
                        EMSStock = Convert.ToDecimal(initRow["EMS_STOCK"].ToString());
                    }
                    catch
                    {
                        EMSStock = 0.0m;
                    }
                    

                    decimal totalPasmy = vendorStock + EMSStock;

                    initRow["BAL_QTY"] = totalPasmy - Convert.ToDecimal(initRow["BALANCE"].ToString());

                    initRow["PRODUCTION_ORDER"] = dr3["PRODUCTION_ORDER"];
                    initialDt.Rows.Add(initRow);
                    num++;
                }

                gridviewMain.DataSource = initialDt;

                DataTable scannedItems = getScannedData(Form1.emsName, "0");

                DataTable wrongPick = new DataTable();
                wrongPick.Columns.Add("Material", typeof(string));

                List<string> materials = new List<string>();


                    foreach (DataRow scr in scannedItems.Rows)
                    {
                        int k = 0;
                        foreach (DataGridViewRow row in gridviewMain.Rows)
                        {
                            if (row.Cells[1].Value.ToString() == scr["Part Number"].ToString())
                            {
                                k++;
                            }
                            else
                            {

                            }
                        }
                        if ( k == 0)
                        {
                            DataRow nr = wrongPick.NewRow();
                            nr["Material"] = scr["Part Number"].ToString();
                            wrongPick.Rows.Add(nr);
                        }

                    }
                


                gridViewWrongItem.DataSource = wrongPick;
                generateSignatureNames();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            lblEMS.Text = Form1.emsName;

        }

        private string DONoRetrieval(string emsName)
        {
            string qry = "SELECT [EMS_DO_LIST_NUMBER] FROM [IBusinessTest].[dbo].[EMS_RUNNIG_NUMBER_STORAGE] where [EMS_NAME] = @emsName";
            SqlCommand cmd = new SqlCommand(qry, cnn);
            cmd.Parameters.AddWithValue("@emsName", emsName);
            try
            {
                cnn.Open();
                int docno = (int)cmd.ExecuteScalar();
                string f_docno = "";
                if (docno >= 10)
                {
                    f_docno = "0" + docno.ToString();

                }
                else if (docno < 10)
                {
                    f_docno = "00" + docno.ToString();
                }
                else
                {
                    f_docno = docno.ToString();
                }
                return f_docno;
            }
            catch
            {
                return "999";
            }
            finally
            {
                cnn.Close();
            }

        }

        private string picklistNoRetrieval(string emsName)
        {
            string qry = "SELECT [EMS_PL_LIST_NUMBER] FROM [IBusinessTest].[dbo].[EMS_RUNNIG_NUMBER_STORAGE] where [EMS_NAME] = @emsName";
            SqlCommand cmd = new SqlCommand(qry,cnn);
            cmd.Parameters.AddWithValue("@emsName", emsName);
            try
            {
                cnn.Open();
                int docno = (int)cmd.ExecuteScalar();
                string f_docno = "";
                if (docno >= 10)
                {
                    f_docno = "0" + docno.ToString();

                }
                else if(docno < 10) {
                    f_docno = "00" + docno.ToString();
                }
                else
                {
                    f_docno = docno.ToString();
                }
                return f_docno;
            }
            catch
            {
                return "999";
            }
            finally
            {
                cnn.Close();
            }

        }

        private  string storType = "";
        private void btnPicklist_Click(object sender, EventArgs e)
        {
            DataTable pullListDT = new DataTable();
            pullListDT.Columns.Add("Material", typeof(string));
            pullListDT.Columns.Add("Quantity", typeof(string));
            pullListDT.Columns.Add("Location", typeof(string));
            pullListDT.Columns.Add("Num Reel",typeof(string));

            DataTable temptDT = new DataTable();
            temptDT.Columns.Add("Material", typeof(string));
            temptDT.Columns.Add("Quantity", typeof(string));

            foreach (DataGridViewRow row in gridviewMain.Rows)
            {
                decimal qty_temp = (decimal)row.Cells[7].Value;

                if (qty_temp <= 0)
                {
                    DataRow dr = temptDT.NewRow();
                    dr["Material"] = row.Cells[1].Value;
                    dr["Quantity"] = row.Cells[7].Value;
                    temptDT.Rows.Add(dr);
                }

            }

            WsdlDataRetrieval wsdl = new WsdlDataRetrieval();
            DataTable SAPLoc = wsdl.getlocationsMaterialsIn2006();

            foreach (DataRow dr in temptDT.Rows)
            {
                string locations = "";
                foreach (DataRow locRows in SAPLoc.Rows)
                {
                    if (dr["Material"].ToString() == locRows["Material"].ToString())
                    {
                        locations = locRows["Location"].ToString();
                    }


                }

                DataRow nr = pullListDT.NewRow();
                nr["Material"] = dr["Material"].ToString();
                nr["Quantity"] = dr["Quantity"].ToString();
                nr["Location"] = locations;
                nr["Num Reel"] = "";
                pullListDT.Rows.Add(nr);

            }

            generatePDF P = new generatePDF();
            P.generatePulllist(storType, pullListDT);

        }

        private DataTable getScannedData(string ems,string docStat)
        {
            DataTable dbTable = new DataTable();
            string qry = "SELECT DISTINCT [PART_NO],[QUANTITY],[BOX_NUMBER],[HS_CODE],S.[MATERIAL_DESCRIPTION] FROM (SELECT A.[PART_NO],[QUANTITY],[BOX_NUMBER],B.[HS_CODE] FROM [IBusinessTest].[dbo].[EMS_PRINT_DATA] A " +
                "INNER JOIN [IBusinessTest].[dbo].[EMS_STOCK_REQUIREMENT_QUANTITY] B on A.[PART_NO] = B.[PART_NO]  where DOCUMENT_STATUS = @DSTAT and [EMS] = @emsName) F LEFT JOIN [IBusiness].[dbo].[SAP_ITEM] S ON F.PART_NO = S.MATERIAL";

            SqlDataAdapter da = new SqlDataAdapter(qry, cnn);
            da.SelectCommand.Parameters.AddWithValue("@emsName", ems);
            da.SelectCommand.Parameters.AddWithValue("@DSTAT", docStat);

            try
            {
                cnn.Open();
                da.Fill(dbTable);
            }
            catch
            {

            }
            finally
            {
                cnn.Close();
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("No", typeof(string));
            dt.Columns.Add("Part Number", typeof(string));
            dt.Columns.Add("Item Group", typeof(string));
            dt.Columns.Add("Hs Code", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("UOM", typeof(string));
            dt.Columns.Add("Box Number", typeof(string));
            int j = 0;
            foreach(DataRow dr in dbTable.Rows)
            {
                j++;
                DataRow nr = dt.NewRow();
                nr["No"] = j.ToString();
                nr["Part Number"] = dr["PART_NO"].ToString();
                nr["Item Group"] = dr["MATERIAL_DESCRIPTION"].ToString();
                nr["Hs Code"] = dr["HS_CODE"].ToString();
                nr["Quantity"] = dr["QUANTITY"].ToString();
                nr["UOM"] = "PC";
                nr["Box Number"] = dr["BOX_NUMBER"].ToString();
                dt.Rows.Add(nr);
            }

            return dt;
        }
        private void updateEMSrunningNum(string emsName,string listType)
        {
            string qry = "SELECT * FROM [IBusinessTest].[dbo].[EMS_RUNNIG_NUMBER_STORAGE] where [EMS_NAME] = @ems";
            SqlDataAdapter DA = new SqlDataAdapter(qry, cnn);
            DA.SelectCommand.Parameters.AddWithValue("ems", emsName);

            DataTable dt = new DataTable();

            try
            {
                cnn.Open();
                DA.Fill(dt);
            }
            catch
            {

            }
            finally
            {
                cnn.Close();
            }

            if (listType == "EMS_PULL_LIST_NUMBER")
            {

            }
            else if(listType == "EMS_DO_LIST_NUMBER")
            {
                try
                {
                    int currentNo = Convert.ToInt32(dt.Rows[0][1].ToString());
                    currentNo++;
                    string update_qry = "UPDATE [dbo].[EMS_RUNNIG_NUMBER_STORAGE] SET [EMS_DO_LIST_NUMBER] = @newNum WHERE [EMS_NAME] = @ems";
                    SqlCommand cmd = new SqlCommand(update_qry, cnn);
                    cmd.Parameters.AddWithValue("@ems", emsName);
                    cmd.Parameters.AddWithValue("@newNum", currentNo);
                    cnn.Open();
                    cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    cnn.Close();
                }
            }
            else if (listType == "EMS_CF_LIST_NUMBER")
            {
                try
                {
                    int currentNo = Convert.ToInt32(dt.Rows[0][1].ToString());
                    currentNo++;
                    string update_qry = "UPDATE [dbo].[EMS_RUNNIG_NUMBER_STORAGE] SET [EMS_CF_LIST_NUMBER] = @newNum WHERE [EMS_NAME] = @ems";
                    SqlCommand cmd = new SqlCommand(update_qry, cnn);
                    cmd.Parameters.AddWithValue("@ems", emsName);
                    cmd.Parameters.AddWithValue("@newNum", currentNo);
                    cnn.Open();
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    cnn.Close();
                }
            }
            else if (listType == "EMS_PL_LIST_NUMBER")
            {
                try
                {
                    int currentNo = Convert.ToInt32(dt.Rows[0][3].ToString());
                    currentNo++;
                    string update_qry = "UPDATE [dbo].[EMS_RUNNIG_NUMBER_STORAGE] SET [EMS_PL_LIST_NUMBER] = @newNum WHERE [EMS_NAME] = @ems";
                    SqlCommand cmd = new SqlCommand(update_qry, cnn);
                    cmd.Parameters.AddWithValue("@ems", emsName);
                    cmd.Parameters.AddWithValue("@newNum", currentNo);
                    cnn.Open();
                    cmd.ExecuteNonQuery();


                }
                catch(Exception ex)  {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    cnn.Close();
                }
            }
        }

        private void updateDocStatus(DataTable dt,string newStatus,string emsName,string oldStats)
        {
            foreach(DataRow dr in dt.Rows)
            {
                string update_qry = "UPDATE [dbo].[EMS_PRINT_DATA] SET [DOCUMENT_STATUS] = @stats WHERE [EMS] = @emsn AND [DOCUMENT_STATUS] = @ostats AND [PART_NO] = @PN";
                SqlCommand cmd = new SqlCommand(update_qry, cnn);
                cmd.Parameters.AddWithValue("@stats", newStatus);
                cmd.Parameters.AddWithValue("@emsn", emsName);
                cmd.Parameters.AddWithValue("@ostats", oldStats);
                cmd.Parameters.AddWithValue("@PN", dr["Part Number"].ToString());
                try
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();

                }
                catch
                {

                }
                finally
                {
                    cnn.Close();
                }

            }
        }

        private void btn_generatePicklist_Click(object sender, EventArgs e)
        {
            DataTable dt = getScannedData(Form1.emsName,"0");

            generatePDF pdf = new generatePDF();
            try
            {

                pdf.generatePickList(Form1.emsName, txt_pickListNo.Text, dt);
                updateEMSrunningNum(runningNumberEMSName, "EMS_PL_LIST_NUMBER");
                updateDocStatus(dt, "1", Form1.emsName, "0");

            }
            catch(Exception EX)
            {
                MessageBox.Show(EX.Message.ToString());
            }

        }

        private void btn_generateDO_Click(object sender, EventArgs e)
        {
            DataTable dt = getScannedData(Form1.emsName,"1");

            generatePDF pdf = new generatePDF();
            try
            {
                if (txtpreparedby.Text != "" || txtshipby.Text != "")
                {
                    pdf.generateDO(Form1.emsName, txt_DO_no.Text, dt, txtpreparedby.Text, txtshipby.Text);
                    updateEMSrunningNum(runningNumberEMSName, "EMS_DO_LIST_NUMBER");
                    updateDocStatus(dt, "2", Form1.emsName, "1");
                }
                else
                {
                    MessageBox.Show("Fill out name first");
                }
                
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message.ToString());
            }
        }

        private void btncsform_Click(object sender, EventArgs e)
        {
            DataTable dt = getScannedData(Form1.emsName, "2");
            generatePDF pdf = new generatePDF();
            pdf.generateCustomForm(Form1.emsName, dt, txtOfficerName.Text);
            updateEMSrunningNum(runningNumberEMSName, "EMS_CF_LIST_NUMBER");
            updateDocStatus(dt, "3", Form1.emsName, "2");

        }

        private void txtOfficerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void generateSignatureNames()
        {
            string qry = "SELECT [SHIP_BY],[PREP_BY],[OFFICER_NAME] FROM [IBusinessTest].[dbo].[EMS_RUNNIG_NUMBER_STORAGE] WHERE [EMS_NAME] = @ems";
            SqlDataAdapter DA = new SqlDataAdapter(qry, cnn);
            DA.SelectCommand.Parameters.AddWithValue("ems", runningNumberEMSName);
            DataTable dt = new DataTable();
            try
            {
                cnn.Open();
                DA.Fill(dt);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                cnn.Close();
            }
            txtshipby.Text = dt.Rows[0][0].ToString();
            txtpreparedby.Text = dt.Rows[0][1].ToString();
            txtOfficerName.Text = dt.Rows[0][2].ToString();

        }

        private void lblupdateName_Click(object sender, EventArgs e)
        {
            string update_qry = "UPDATE [dbo].[EMS_RUNNIG_NUMBER_STORAGE] SET [SHIP_BY] = @shipBy, [PREP_BY] = @prepBy, [OFFICER_NAME] = @officerName  WHERE [EMS_NAME] = @ems";
            try
            {
                SqlCommand cmd = new SqlCommand(update_qry, cnn);
                cmd.Parameters.AddWithValue("@shipBy", txtshipby.Text);
                cmd.Parameters.AddWithValue("@prepBy", txtpreparedby.Text);
                cmd.Parameters.AddWithValue("@officerName", txtOfficerName.Text);
                cmd.Parameters.AddWithValue("@ems", runningNumberEMSName);

                cnn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                cnn.Close();
                generateSignatureNames();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EMSMaterialPreparation.GETProductionInfo;
using EMSMaterialPreparation.GET_STOCK_PASMY_EMS;
using EMSMaterialPreparation.GETEMSVENDORSTOCK;
using System.Data;
using EMSMaterialPreparation.GET_LOCATION;

namespace EMSMaterialPreparation
{
    internal class WsdlDataRetrieval
    {
        public ZWM_MY_I_PROD_SCHEDResponse get_productionInfofromSAP(string prodNum)
        {
            ZWM_MY_I_PROD_SCHED pSched = new ZWM_MY_I_PROD_SCHED();
            ZWM_MY_I_PROD_SCHED1 pShed1 = new ZWM_MY_I_PROD_SCHED1();
            GETProductionInfo.ZWM_MY_I_FM_BARCODE_MS pShedMs = new GETProductionInfo.ZWM_MY_I_FM_BARCODE_MS();
            ZWM_MY_I_PROD_SCHEDResponse pShedResp = new ZWM_MY_I_PROD_SCHEDResponse();
            ZWM_MY_I_PROD_SCHED_S pShedRespS = new ZWM_MY_I_PROD_SCHED_S();

            NetworkCredential CRED = new NetworkCredential();
            CRED.UserName = ConfigurationManager.AppSettings["Username"];
            CRED.Password = ConfigurationManager.AppSettings["Password"];

            pSched.PreAuthenticate = true;
            pSched.Credentials = CRED;
            pShed1.IPRODORDER = "00" + prodNum.Trim();
            pShed1.IPRODSTART = "2021-01-01";
            pShed1.IPRODEND = "2023-01-03";

            return pSched.CallZWM_MY_I_PROD_SCHED(pShed1);
        }

        public ZIM_GET_EMS_STOCKResponse getStockFromPASMYEMS(string ems_name)
        {
            ZIM_GET_EMS_STOCK emsStock = new ZIM_GET_EMS_STOCK();
            ZIM_GET_EMS_STOCK1 emsstock1 = new ZIM_GET_EMS_STOCK1();

            NetworkCredential CRED = new NetworkCredential();
            CRED.UserName = ConfigurationManager.AppSettings["Username"];
            CRED.Password = ConfigurationManager.AppSettings["Password"];

            emsStock.PreAuthenticate = true;
            emsStock.Credentials = CRED;
            emsstock1.PLANT = "1020";
            emsstock1.LGORT = ems_name;

            return emsStock.CallZIM_GET_EMS_STOCK(emsstock1);

        }

        public DataTable getstockFromVENDOREMS(string vendorcode)
        {
            ZIM_GET_VENDOR_STOCK Vstock = new ZIM_GET_VENDOR_STOCK();
            ZIM_GET_VENDOR_STOCK1 Vstock1 = new ZIM_GET_VENDOR_STOCK1();
            NetworkCredential CRED = new NetworkCredential();
            CRED.UserName = ConfigurationManager.AppSettings["Username"];
            CRED.Password = ConfigurationManager.AppSettings["Password"];

            Vstock.PreAuthenticate = true;
            Vstock.Credentials = CRED;
            Vstock1.PLANT = "1020";
            Vstock1.VENDOR = vendorcode;
            Vstock1.MATERIAL = "";
            ZIM_GET_VENDOR_STOCKResponse L = Vstock.CallZIM_GET_VENDOR_STOCK(Vstock1);
            DataTable dt = new DataTable();
            dt.Columns.Add("MATNR");
            dt.Columns.Add("QUANTITY",typeof(decimal));

            for(int i = 0; i < L.ITEM.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["MATNR"] = L.ITEM[i].MATNR;
                dr["QUANTITY"] = Convert.ToDecimal(L.ITEM[i].LBLAB);
                dt.Rows.Add(dr);
            }

            var result = dt.AsEnumerable().GroupBy(R => R.Field<string>("MATNR"))
                .Select(g =>
                {
                    var row = dt.NewRow();

                    row["MATNR"] = g.Key;
                    row["QUANTITY"] = g.Sum(r => r.Field<decimal>("QUANTITY"));
                    return row;
                }).CopyToDataTable();
            


            return result;
        }

        public DataTable getlocationsMaterialsIn2006()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Material",typeof(string));
            dt.Columns.Add("Location",typeof(string));

            DataTable finaldt = new DataTable();
            finaldt.Columns.Add("Material", typeof(string));
            finaldt.Columns.Add("Location", typeof(string));

            ZWM_I_MFRPN_BARC mfprn = new ZWM_I_MFRPN_BARC();
            ZWM_I_MFRPN_BARC1 mfprn1 = new ZWM_I_MFRPN_BARC1();

            mfprn.PreAuthenticate = true;

            NetworkCredential CRED = new NetworkCredential();
            CRED.UserName = ConfigurationManager.AppSettings["Username"];
            CRED.Password = ConfigurationManager.AppSettings["Password"];

            mfprn.Credentials = CRED;

            mfprn1.MATERIAL = "";
            mfprn1.STOR_LOC = "2006";
            mfprn1.YEAR = "";

          
            try
            {
                ZWM_I_MFRPN_BARCResponse resp = mfprn.CallZWM_I_MFRPN_BARC(mfprn1);
                for (int i = 0; i < resp.ITEM.Length; i++)
                {
                    DataRow dr = finaldt.NewRow();
                    dr["Material"] = resp.ITEM[i].MATNR;
                    dr["Location"] = resp.ITEM[i].LGPBE;
                    finaldt.Rows.Add(dr);
                }
                return finaldt;

            }
            catch (Exception ex) 
            {
                DataRow dr = finaldt.NewRow();
                dr["Material"] = ex.Message.ToString();
                dr["Location"] = ex.Message.ToString();
                return dt;
            }
            



        }

    }
    class DT2
    {
        public string COMPONENT { get; set; }
        public string PRODUCTION_ORDER { get; set; }
    }

    class DT
    {
        public string MATNR { get; set; }
        public decimal QUANTITY { get; set; }
    }

}

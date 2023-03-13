using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Drawing;
using PdfSharp.Drawing.BarCodes;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using BarcodeLib;
using System.Diagnostics.Tracing;
using System.Data;
using ZXing.QrCode.Internal;
using ZXing;
using ZXing.QrCode;
using System.ComponentModel;
using System.Reflection;
using SixLabors.ImageSharp.ColorSpaces;

namespace EMSMaterialPreparation
{
    internal class generatePDF
    {

        static string MigraDocFilenameFromByteArray(byte[] image)
        {
            return "base64:" + Convert.ToBase64String(image);
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public void generatePulllist(string ems_code,DataTable data)
        {
            string emsName = "";
            switch (ems_code)
            {
                case "015":
                    emsName = "SANSHIN";
                        break;
                case "016":
                    emsName = "HOTAYI BATU KAWAN";
                    break;
                case "018":
                    emsName = "HOTAYI BUKIT TENGAH";
                    break;
                case "017":
                    emsName = "SCOPE";
                    break;

            }
            Document document = new Document();
            Section section = document.AddSection();
            BarcodeLib.Barcode b_006 = new BarcodeLib.Barcode();
            b_006.IncludeLabel= true;
            int imageWidth = 130;  // barcode image width
            int imageHeight = 60; //barcode image height
            System.Drawing.Color foreColor = System.Drawing.Color.Black; // Color to print barcode
            System.Drawing.Color backColor = System.Drawing.Color.Transparent; //background color
            //numeric string to generate barcode
            string NumericString = "006";
            System.Drawing.Image img = b_006.Encode(TYPE.CODE39, NumericString, foreColor, backColor, imageWidth, imageHeight);
            string fileName006 = MigraDocFilenameFromByteArray(ImageToByteArray(img));

            TextFrame loc006tf = section.AddTextFrame();
            loc006tf.WrapFormat.DistanceLeft = Unit.FromMillimeter(-15);
            loc006tf.WrapFormat.DistanceTop = Unit.FromMillimeter(-20);
            loc006tf.AddImage(fileName006);

            BarcodeLib.Barcode b_ems = new BarcodeLib.Barcode();
            b_ems.IncludeLabel = true;
            string barcodestring = ems_code;
            System.Drawing.Image imgEms = b_006.Encode(TYPE.CODE39, barcodestring, foreColor, backColor, imageWidth, imageHeight);
            string fileNameems = MigraDocFilenameFromByteArray(ImageToByteArray(imgEms));

            TextFrame locEmstf = section.AddTextFrame();
            locEmstf.WrapFormat.DistanceLeft = Unit.FromMillimeter(139);
            locEmstf.WrapFormat.DistanceTop = Unit.FromMillimeter(-25);
            locEmstf.AddImage(fileNameems);

            TextFrame titleEms = section.AddTextFrame();
            titleEms.Width = Unit.FromMillimeter(60);
            titleEms.WrapFormat.DistanceTop = Unit.FromMillimeter(-25);
            titleEms.WrapFormat.DistanceLeft = Unit.FromMillimeter(55);
            Paragraph titlepulllist = titleEms.AddParagraph();
            var titleFont = new MigraDoc.DocumentObjectModel.Font();
            titleFont.Size = 11;
            titleFont.Name = "Cascadia Mono ExtraLight";
            titlepulllist.AddFormattedText("SMT Material Pull List",titleFont);

            TextFrame EMSdesctf = section.AddTextFrame();
            EMSdesctf.Width = Unit.FromMillimeter(60);
            EMSdesctf.WrapFormat.DistanceTop = Unit.FromMillimeter(-10);
            EMSdesctf.WrapFormat.DistanceLeft = Unit.FromMillimeter(68);
            Paragraph EMSdescpara = EMSdesctf.AddParagraph();
            var emsdescFont = new MigraDoc.DocumentObjectModel.Font();
            emsdescFont.Size = 14;
            emsdescFont.Name = "Arial";
            emsdescFont.Bold = true;
            EMSdescpara.AddFormattedText(emsName, emsdescFont);

            TextFrame reqDateTf = section.AddTextFrame();
            reqDateTf.Width = Unit.FromMillimeter(50);
            reqDateTf.WrapFormat.DistanceLeft = Unit.FromMillimeter(140);
            reqDateTf.WrapFormat.DistanceTop = Unit.FromMillimeter(-15);
            Paragraph reqDatePara= reqDateTf.AddParagraph();
            reqDatePara.AddText("Req Date " + DateTime.Now.ToString("yyyy-MM-dd"));
            Paragraph serialNum = reqDateTf.AddParagraph();
            serialNum.AddText("No Siri SS15");



            Table mainTab = new Table();
            mainTab.Borders.Width = 1;
            mainTab.Style = "Table";
            mainTab.Rows.Alignment = RowAlignment.Center;

            Column no_col = mainTab.AddColumn();
            no_col.Width = Unit.FromMillimeter(9);
            no_col.Format.Alignment = ParagraphAlignment.Center;

            Column mat_col = mainTab.AddColumn();
            mat_col.Width = Unit.FromMillimeter(31);
            mat_col.Format.Alignment = ParagraphAlignment.Center;

            Column quantity_col = mainTab.AddColumn();
            quantity_col.Width = Unit.FromMillimeter(15);
            quantity_col.Format.Alignment = ParagraphAlignment.Center;

            Column barcode_col = mainTab.AddColumn();
            barcode_col.Width = Unit.FromMillimeter(38);
            barcode_col.Format.Alignment = ParagraphAlignment.Center;

            Column refLoc_col = mainTab.AddColumn();
            refLoc_col.Width = Unit.FromMillimeter(20);
            refLoc_col.Format.Alignment = ParagraphAlignment.Center;


            Column numReel_col = mainTab.AddColumn();
            numReel_col.Width = Unit.FromMillimeter(20);
            numReel_col.Format.Alignment = ParagraphAlignment.Center;

            Column recvBy_col = mainTab.AddColumn();
            recvBy_col.Width = Unit.FromMillimeter(20);
            recvBy_col.Format.Alignment = ParagraphAlignment.Center;

            Row rNo = mainTab.AddRow();
            rNo.VerticalAlignment = VerticalAlignment.Center;
            rNo.Height = Unit.FromMillimeter(9);
            rNo.HeadingFormat = true;
            rNo.Format.Font.Color = MigraDoc.DocumentObjectModel.Color.FromRgb(255, 255, 255);
            rNo.Shading.Color = MigraDoc.DocumentObjectModel.Color.FromRgb(0, 0, 255);
            rNo.Format.Font.Bold = true;

            rNo.Cells[0].AddParagraph("No.");
            rNo.Cells[1].AddParagraph("Part Number");
            rNo.Cells[2].AddParagraph("Quantity");
            rNo.Cells[3].AddParagraph("Barcode");
            rNo.Cells[4].AddParagraph("Ref. Location");
            rNo.Cells[4].Shading.Color = MigraDoc.DocumentObjectModel.Color.FromRgb(255, 0, 0);
            rNo.Cells[5].AddParagraph("Num of Reel");
            rNo.Cells[5].Shading.Color = MigraDoc.DocumentObjectModel.Color.FromRgb(255, 0, 0);
            rNo.Cells[6].AddParagraph("Recieved by");
            rNo.Cells[6].Shading.Color = MigraDoc.DocumentObjectModel.Color.FromRgb(255, 0, 0);

            int i = 0;
            int numPages = 0;

            foreach (DataRow dr in data.Rows)
            {
                i++;
                    Row nrows = mainTab.AddRow();
                    nrows.VerticalAlignment = VerticalAlignment.Center;
                    nrows.Height = Unit.FromMillimeter(10);
                    nrows.Cells[0].AddParagraph(i.ToString());
                    nrows.Cells[1].AddParagraph(dr["Material"].ToString());
                    nrows.Cells[2].AddParagraph(dr["Quantity"].ToString());
                    QrCodeEncodingOptions options = new QrCodeEncodingOptions();
                    options = new QrCodeEncodingOptions
                    {
                        DisableECI = true,
                        CharacterSet = "UTF-8",
                        Width = 50,
                        Height = 50,
                        Margin = 0,
                    };
                    var qr = new ZXing.BarcodeWriter();
                    qr.Options = options;
                    qr.Format = ZXing.BarcodeFormat.QR_CODE;
                    var result = new Bitmap(qr.Write(dr["Material"].ToString()));
                    string fileNamePnum = MigraDocFilenameFromByteArray(ImageToByteArray(result));

                    nrows.Cells[3].AddImage(fileNamePnum);
                    nrows.Cells[4].AddParagraph(dr["Location"].ToString());
                    nrows.Cells[5].AddParagraph("");
                    nrows.Cells[6].AddParagraph("");

            }

            mainTab = mainTab.Clone();
            section.Add(mainTab);





            document.UseCmykColor = true;
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            string pdfPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "PULL_LIST");
            string filename = pdfPath + "\\PULLLIST2006" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";
            pdfRenderer.PdfDocument.Save(filename);
            Process.Start(filename);
        }

        public void generateDO(string ems,string DOnum,DataTable data,string Preparedbyname,string shipByname)
        {
            Document document = new Document();
            Section section = document.AddSection();

            TextFrame logoTF = section.AddTextFrame();
            logoTF.WrapFormat.DistanceTop = -60;
            logoTF.WrapFormat.DistanceLeft = -50;
            string ImgPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Panasonic_Logo.jpg");

            logoTF.AddImage(ImgPath);

            TextFrame addressTF = section.AddTextFrame();
            //addressTF.LineFormat.Color = Colors.Black;
            addressTF.Width = Unit.FromMillimeter(130);
            addressTF.WrapFormat.DistanceLeft = -50;
            addressTF.WrapFormat.DistanceTop = -50;
            Paragraph CompanyNamepara = addressTF.AddParagraph();
            CompanyNamepara.Format.Alignment = ParagraphAlignment.Left;
            CompanyNamepara.AddText("Panasonic Automotive Systems Malaysia Sdn. Bhd. (204211-U)");
            CompanyNamepara.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);
            CompanyNamepara.Format.Font.Bold = true;

            Paragraph address1Para = addressTF.AddParagraph();
            address1Para.Format.Alignment = ParagraphAlignment.Left;
            address1Para.AddText("PLOT 10 , PHASE 4 , PRAI INDUSTRIAL ESTATE");
            address1Para.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);

            Paragraph address2Para = addressTF.AddParagraph();
            address2Para.Format.Alignment = ParagraphAlignment.Left;
            address2Para.AddText("13600 PRAI, PENANG, MALAYSIA.");
            address2Para.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);

            Paragraph address3Para = addressTF.AddParagraph();
            address3Para.Format.Alignment = ParagraphAlignment.Left;
            address3Para.AddText("TEL : 604 - 5078 988 FAX : 604 - 5078 814 / 644");
            address3Para.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);

            TextFrame titleTF = section.AddTextFrame();
            //addressTF.LineFormat.Color = Colors.Black;
            titleTF.Width = Unit.FromMillimeter(130);
            titleTF.WrapFormat.DistanceTop = -20;
            titleTF.WrapFormat.DistanceLeft = 40;

            Paragraph doctitle = titleTF.AddParagraph();
            doctitle.Format.Alignment = ParagraphAlignment.Center;
            doctitle.AddText("DELIVERY ORDER");
            doctitle.Format.Font.Bold = true;
            doctitle.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 20);

            string EMScompanyname = "";
            string EMSaddressline1 = "";
            string EMSaddressline2 = "";
            string EMSaddressline3 = "";
            string EMSaddressline4 = "";

            switch (ems)
            {
                case "SANSHIN":
                    EMScompanyname = "\tSANSHIN (M) SDN BHD";
                    EMSaddressline1 = "\tLOT 55, BAKAR ARANG INDUSTRIAL ESTATE";
                    EMSaddressline2 = "\t08000 SUNGAI PETANI, KEDAH";
                    EMSaddressline3 = "";
                    EMSaddressline4 = "";
                    break;
                case "SCOPE":
                    EMScompanyname = "\tSCOPE MANUFACTURERS (M) SDN.BHD (229373-P)";
                    EMSaddressline1 = "\tLot 6181, Jalan Perusahaan 2";
                    EMSaddressline2 = "\tKawasan Perindustrian Parit Buntar,Perak";
                    EMSaddressline3 = "\tMalaysia";
                    EMSaddressline4 = "";
                    break;
                case "HOTAYI_BT":
                    EMScompanyname = "\tHotayi Electronic (M) SDN. BHD.";
                    EMSaddressline1 = "\tPLOT 100, LORONG PERUSAHAAN UTAMA,";
                    EMSaddressline2 = "\tTAMAN PERINDUSTRIAN BUKIT TENGAH,";
                    EMSaddressline3 = "\t14000 BUKIT MERTAJAM, PENANG, MALAYSIA";
                    EMSaddressline4 = "";
                    break;
                case "HOTAYI_BK":
                    EMScompanyname = "\tHotayi Electronic (M) SDN. BHD.";
                    EMSaddressline1 = "\tPMT 751, Persiaran Cassia Selatan 1,";
                    EMSaddressline2 = "\tTaman Perindustrian Batu Kawan,";
                    EMSaddressline3 = "\tBandar Cassia, 14110, Penang, Malaysia";
                    EMSaddressline4 = "";
                    break;
            }

            TextFrame emsAddressTF = section.AddTextFrame();
            emsAddressTF.Width = Unit.FromMillimeter(100);
            emsAddressTF.WrapFormat.DistanceTop = -50;
            emsAddressTF.WrapFormat.DistanceLeft = -50;

            Paragraph delTo = emsAddressTF.AddParagraph();
            delTo.Format.Alignment = ParagraphAlignment.Left;
            delTo.AddText("DELIVERY TO :");
            delTo.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);

            Paragraph EMSname = emsAddressTF.AddParagraph();
            EMSname.Format.Alignment = ParagraphAlignment.Left;
            EMSname.AddText(EMScompanyname);
            EMSname.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);
            EMSname.Format.Font.Bold = true;

            Paragraph EMSaddress1 = emsAddressTF.AddParagraph();
            EMSaddress1.Format.Alignment = ParagraphAlignment.Left;
            EMSaddress1.AddText(EMSaddressline1);
            EMSaddress1.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);

            Paragraph EMSaddress2 = emsAddressTF.AddParagraph();
            EMSaddress2.Format.Alignment = ParagraphAlignment.Left;
            EMSaddress2.AddText(EMSaddressline2);
            EMSaddress2.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);

            Paragraph EMSaddress3 = emsAddressTF.AddParagraph();
            EMSaddress3.Format.Alignment = ParagraphAlignment.Left;
            EMSaddress3.AddText(EMSaddressline3);
            EMSaddress3.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);

            Paragraph EMSaddress4 = emsAddressTF.AddParagraph();
            EMSaddress4.Format.Alignment = ParagraphAlignment.Left;
            EMSaddress4.AddText(EMSaddressline4);
            EMSaddress4.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);

            TextFrame pickingListNoTF = section.AddTextFrame();
            pickingListNoTF.Width = Unit.FromMillimeter(100);
            pickingListNoTF.WrapFormat.DistanceTop = -61;
            pickingListNoTF.WrapFormat.DistanceLeft = 330;

            Paragraph pickinglistNoPara = pickingListNoTF.AddParagraph();
            pickinglistNoPara.Format.Alignment = ParagraphAlignment.Left;
            pickinglistNoPara.AddText("PICKING LIST NO.: " + DOnum);

            Paragraph datePara = pickingListNoTF.AddParagraph();
            datePara.Format.Alignment = ParagraphAlignment.Left;
            datePara.AddText("DATE :\t" + DateTime.Now.ToString("dd.MM.yyyy"));

            Paragraph shipViaPara = pickingListNoTF.AddParagraph();
            shipViaPara.Format.Alignment = ParagraphAlignment.Left;
            shipViaPara.AddText("SHIP VIA : _____________");

            Paragraph InvoiceNoPara = pickingListNoTF.AddParagraph();
            InvoiceNoPara.Format.Alignment = ParagraphAlignment.Left;
            InvoiceNoPara.AddText("Invoice No : _____________");

            Table mainTab = new Table();
            mainTab.Borders.Width = 1;
            mainTab.Style = "Table";
            mainTab.Rows.Alignment = RowAlignment.Center;

            Column no_col = mainTab.AddColumn();
            no_col.Width = Unit.FromMillimeter(10);
            no_col.Format.Alignment = ParagraphAlignment.Center;

            Column mat_col = mainTab.AddColumn();
            mat_col.Width = Unit.FromMillimeter(31);
            mat_col.Format.Alignment = ParagraphAlignment.Center;

            Column quantity_col = mainTab.AddColumn();
            quantity_col.Width = Unit.FromMillimeter(69);
            quantity_col.Format.Alignment = ParagraphAlignment.Center;

            Column barcode_col = mainTab.AddColumn();
            barcode_col.Width = Unit.FromMillimeter(24.5);
            barcode_col.Format.Alignment = ParagraphAlignment.Center;

            Column refLoc_col = mainTab.AddColumn();
            refLoc_col.Width = Unit.FromMillimeter(10);
            refLoc_col.Format.Alignment = ParagraphAlignment.Center;

            Row rNo = mainTab.AddRow();
            rNo.VerticalAlignment = VerticalAlignment.Top;
            rNo.Height = Unit.FromMillimeter(9);
            rNo.HeadingFormat = true;
            rNo.Format.Font.Bold = true;

            rNo.Cells[0].AddParagraph("NO");
            rNo.Cells[1].AddParagraph("PART NUMBER");
            rNo.Cells[2].AddParagraph("ITEM GROUP");
            rNo.Cells[3].AddParagraph("Quantity");
            rNo.Cells[4].AddParagraph("UOM");

            foreach (DataRow dr in data.Rows)
            {
                Row nrows = mainTab.AddRow();
                nrows.VerticalAlignment = VerticalAlignment.Center;
                nrows.Height = Unit.FromMillimeter(10);
                nrows.Cells[0].AddParagraph(dr["No"].ToString());
                nrows.Cells[1].AddParagraph(dr["Part Number"].ToString());
                nrows.Cells[2].AddParagraph(dr["Item Group"].ToString());
                nrows.Cells[3].AddParagraph(dr["Quantity"].ToString());
                nrows.Cells[4].AddParagraph(dr["UOM"].ToString());

            }

            mainTab = mainTab.Clone();
            section.Add(mainTab);

            Table sigTab = section.Document.LastSection.AddTable();
            //sigTab.Borders.Width = 1;
            sigTab.Style = "Table";
            sigTab.Rows.Alignment = RowAlignment.Center;
            

            Column PreparedBy = sigTab.AddColumn();
            PreparedBy.Width = Unit.FromMillimeter(55);
            PreparedBy.Format.Alignment = ParagraphAlignment.Center;

            Column shippedBy = sigTab.AddColumn();
            shippedBy.Width = Unit.FromMillimeter(55);
            shippedBy.Format.Alignment = ParagraphAlignment.Center;

            Column gro = sigTab.AddColumn();
            gro.Width = Unit.FromMillimeter(55);
            gro.Format.Alignment = ParagraphAlignment.Center;

            Row nrow = sigTab.AddRow();
            nrow.VerticalAlignment = VerticalAlignment.Top;
            nrow.Height = Unit.FromMillimeter(30);

            TextFrame prepbyTF = nrow.Cells[0].AddTextFrame();
            prepbyTF.Width = Unit.FromCentimeter(5);
            prepbyTF.AddParagraph("Prepared by\n\n\n\n");
            prepbyTF.AddParagraph("_________________________");
            prepbyTF.AddParagraph("Name : " + Preparedbyname);

            TextFrame shipbyTF = nrow.Cells[1].AddTextFrame();
            shipbyTF.Width = Unit.FromCentimeter(5);
            shipbyTF.AddParagraph("Shipped by\n\n\n\n");
            shipbyTF.AddParagraph("_________________________");
            shipbyTF.AddParagraph("Name : " + shipByname);

            TextFrame groTF = nrow.Cells[2].AddTextFrame();
            groTF.Width = Unit.FromCentimeter(5);
            groTF.AddParagraph("Goods Received In Good Order\n\n\n\n");
            groTF.AddParagraph("_________________________");
            groTF.AddParagraph("Consignee Chop & Sign");

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            string pdfPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "DO");
            string filename = pdfPath + "\\DO" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";
            pdfRenderer.PdfDocument.Save(filename);
            Process.Start(filename);
        }

        public void generatePickList(string ems,string pickListNum,DataTable data)
        {
            Document document = new Document();
            Section section = document.AddSection();

            TextFrame logoTF = section.AddTextFrame();
            logoTF.WrapFormat.DistanceTop = -60;
            logoTF.WrapFormat.DistanceLeft = -50;
            string ImgPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Panasonic_Logo.jpg");

            logoTF.AddImage(ImgPath);

            TextFrame addressTF = section.AddTextFrame();
            //addressTF.LineFormat.Color = Colors.Black;
            addressTF.Width = Unit.FromMillimeter(130);
            addressTF.WrapFormat.DistanceLeft = -50;
            addressTF.WrapFormat.DistanceTop = -50;
            Paragraph CompanyNamepara = addressTF.AddParagraph();
            CompanyNamepara.Format.Alignment = ParagraphAlignment.Left;
            CompanyNamepara.AddText("Panasonic Automotive Systems Malaysia Sdn. Bhd. (204211-U)");
            CompanyNamepara.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);
            CompanyNamepara.Format.Font.Bold = true;

            Paragraph address1Para = addressTF.AddParagraph();
            address1Para.Format.Alignment = ParagraphAlignment.Left;
            address1Para.AddText("PLOT 10 , PHASE 4 , PRAI INDUSTRIAL ESTATE");
            address1Para.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);

            Paragraph address2Para = addressTF.AddParagraph();
            address2Para.Format.Alignment = ParagraphAlignment.Left;
            address2Para.AddText("13600 PRAI, PENANG, MALAYSIA.");
            address2Para.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);

            Paragraph address3Para = addressTF.AddParagraph();
            address3Para.Format.Alignment = ParagraphAlignment.Left;
            address3Para.AddText("TEL : 604 - 5078 988 FAX : 604 - 5078 814 / 644");
            address3Para.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);

            TextFrame titleTF = section.AddTextFrame();
            //addressTF.LineFormat.Color = Colors.Black;
            titleTF.Width = Unit.FromMillimeter(130);
            titleTF.WrapFormat.DistanceTop = -20;
            titleTF.WrapFormat.DistanceLeft = 40;

            Paragraph doctitle = titleTF.AddParagraph();
            doctitle.Format.Alignment = ParagraphAlignment.Center;
            doctitle.AddText("PICKING LIST");
            doctitle.Format.Font.Bold = true;
            doctitle.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 20);

            string EMScompanyname = "";
            string EMSaddressline1 = "";
            string EMSaddressline2 = "";
            string EMSaddressline3 = "";
            string EMSaddressline4= "";

            switch (ems)
            {
                case "SANSHIN":
                    EMScompanyname = "\tSANSHIN (M) SDN BHD";
                    EMSaddressline1 = "\tLOT 55, BAKAR ARANG INDUSTRIAL ESTATE";
                    EMSaddressline2 = "\t08000 SUNGAI PETANI, KEDAH";
                    EMSaddressline3 = "";
                    EMSaddressline4 = "";
                    break;
                case "SCOPE":
                    EMScompanyname = "\tSCOPE MANUFACTURERS (M) SDN.BHD (229373-P)";
                    EMSaddressline1 = "\tLot 6181, Jalan Perusahaan 2";
                    EMSaddressline2 = "\tKawasan Perindustrian Parit Buntar,Perak";
                    EMSaddressline3 = "\tMalaysia";
                    EMSaddressline4 = "";
                    break;
                case "HOTAYI_BT":
                    EMScompanyname = "\tHotayi Electronic (M) SDN. BHD.";
                    EMSaddressline1 = "\tPLOT 100, LORONG PERUSAHAAN UTAMA,";
                    EMSaddressline2 = "\tTAMAN PERINDUSTRIAN BUKIT TENGAH,";
                    EMSaddressline3 = "\t14000 BUKIT MERTAJAM, PENANG, MALAYSIA";
                    EMSaddressline4 = "";
                    break;
                case "HOTAYI_BK":
                    EMScompanyname = "\tHotayi Electronic (M) SDN. BHD.";
                    EMSaddressline1 = "\tPMT 751, Persiaran Cassia Selatan 1,";
                    EMSaddressline2 = "\tTaman Perindustrian Batu Kawan,";
                    EMSaddressline3 = "\tBandar Cassia, 14110, Penang, Malaysia";
                    EMSaddressline4 = "";
                    break;
            }

            TextFrame emsAddressTF = section.AddTextFrame();
            emsAddressTF.Width = Unit.FromMillimeter(100);
            emsAddressTF.WrapFormat.DistanceTop = -50;
            emsAddressTF.WrapFormat.DistanceLeft = -50;

            Paragraph delTo = emsAddressTF.AddParagraph();
            delTo.Format.Alignment = ParagraphAlignment.Left;
            delTo.AddText("DELIVERY TO :");
            delTo.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);

            Paragraph EMSname = emsAddressTF.AddParagraph();
            EMSname.Format.Alignment = ParagraphAlignment.Left;
            EMSname.AddText(EMScompanyname);
            EMSname.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);
            EMSname.Format.Font.Bold = true;

            Paragraph EMSaddress1 = emsAddressTF.AddParagraph();
            EMSaddress1.Format.Alignment = ParagraphAlignment.Left;
            EMSaddress1.AddText(EMSaddressline1);
            EMSaddress1.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);

            Paragraph EMSaddress2 = emsAddressTF.AddParagraph();
            EMSaddress2.Format.Alignment = ParagraphAlignment.Left;
            EMSaddress2.AddText(EMSaddressline2);
            EMSaddress2.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);

            Paragraph EMSaddress3 = emsAddressTF.AddParagraph();
            EMSaddress3.Format.Alignment = ParagraphAlignment.Left;
            EMSaddress3.AddText(EMSaddressline3);
            EMSaddress3.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);

            Paragraph EMSaddress4 = emsAddressTF.AddParagraph();
            EMSaddress4.Format.Alignment = ParagraphAlignment.Left;
            EMSaddress4.AddText(EMSaddressline4);
            EMSaddress4.Format.Font = new MigraDoc.DocumentObjectModel.Font("Times New Roman", 10);

            TextFrame pickingListNoTF = section.AddTextFrame();
            pickingListNoTF.Width = Unit.FromMillimeter(100);
            pickingListNoTF.WrapFormat.DistanceTop = -61;
            pickingListNoTF.WrapFormat.DistanceLeft = 330;

            Paragraph pickinglistNoPara = pickingListNoTF.AddParagraph();
            pickinglistNoPara.Format.Alignment = ParagraphAlignment.Left;
            pickinglistNoPara.AddText("PICKING LIST NO.: " + pickListNum);

            Paragraph datePara = pickingListNoTF.AddParagraph();
            datePara.Format.Alignment = ParagraphAlignment.Left;
            datePara.AddText("DATE :\t" + DateTime.Now.ToString("dd.MM.yyyy"));

            Paragraph shipViaPara = pickingListNoTF.AddParagraph();
            shipViaPara.Format.Alignment = ParagraphAlignment.Left;
            shipViaPara.AddText("SHIP VIA : _____________");

            Paragraph InvoiceNoPara = pickingListNoTF.AddParagraph();
            InvoiceNoPara.Format.Alignment = ParagraphAlignment.Left;
            InvoiceNoPara.AddText("Invoice No : _____________");

            Table mainTab = new Table();
            mainTab.Borders.Width = 1;
            mainTab.Style = "Table";
            mainTab.Rows.Alignment = RowAlignment.Center;

            Column no_col = mainTab.AddColumn();
            no_col.Width = Unit.FromMillimeter(10);
            no_col.Format.Alignment = ParagraphAlignment.Center;

            Column mat_col = mainTab.AddColumn();
            mat_col.Width = Unit.FromMillimeter(31);
            mat_col.Format.Alignment = ParagraphAlignment.Center;

            Column quantity_col = mainTab.AddColumn();
            quantity_col.Width = Unit.FromMillimeter(69);
            quantity_col.Format.Alignment = ParagraphAlignment.Center;

            Column barcode_col = mainTab.AddColumn();
            barcode_col.Width = Unit.FromMillimeter(24.5);
            barcode_col.Format.Alignment = ParagraphAlignment.Center;

            Column refLoc_col = mainTab.AddColumn();
            refLoc_col.Width = Unit.FromMillimeter(28);
            refLoc_col.Format.Alignment = ParagraphAlignment.Center;


            Column numReel_col = mainTab.AddColumn();
            numReel_col.Width = Unit.FromMillimeter(10);
            numReel_col.Format.Alignment = ParagraphAlignment.Center;

            Column recvBy_col = mainTab.AddColumn();
            recvBy_col.Width = Unit.FromMillimeter(20);
            recvBy_col.Format.Alignment = ParagraphAlignment.Center;

            Row rNo = mainTab.AddRow();
            rNo.VerticalAlignment = VerticalAlignment.Top;
            rNo.Height = Unit.FromMillimeter(9);
            rNo.HeadingFormat = true;
            rNo.Format.Font.Bold = true;

            rNo.Cells[0].AddParagraph("No.");
            rNo.Cells[1].AddParagraph("PART NUMBER");
            rNo.Cells[2].AddParagraph("ITEM GROUP");
            rNo.Cells[3].AddParagraph("HS CODE");
            rNo.Cells[4].AddParagraph("Quantity");
            rNo.Cells[5].AddParagraph("UOM");
            rNo.Cells[6].AddParagraph("BOX NUMBER");

            foreach(DataRow dr in data.Rows)
            {
                Row nrows = mainTab.AddRow();
                nrows.VerticalAlignment = VerticalAlignment.Center;
                nrows.Height = Unit.FromMillimeter(10);
                nrows.Cells[0].AddParagraph(dr["No"].ToString());
                nrows.Cells[1].AddParagraph(dr["Part Number"].ToString());
                nrows.Cells[2].AddParagraph(dr["Item Group"].ToString());
                nrows.Cells[3].AddParagraph(dr["Hs Code"].ToString());
                nrows.Cells[4].AddParagraph(dr["Quantity"].ToString());
                nrows.Cells[5].AddParagraph(dr["UOM"].ToString());
                nrows.Cells[6].AddParagraph(dr["Box Number"].ToString());

            }

            mainTab = mainTab.Clone();
             
            section.Add(mainTab);

            TextFrame signatureTF = section.Document.LastSection.AddTextFrame();
            signatureTF.Width = Unit.FromMillimeter(100);
            signatureTF.WrapFormat.DistanceLeft = -50;
            signatureTF.WrapFormat.DistanceTop = 20;

            Paragraph sigCompanyName = signatureTF.AddParagraph();
            sigCompanyName.Format.Alignment = ParagraphAlignment.Left;
            sigCompanyName.AddText("Panasonic Automotive Systems Malaysia Sdn. Bhd.");

            Paragraph dottedLine = signatureTF.AddParagraph();
            dottedLine.Format.Alignment = ParagraphAlignment.Left;
            dottedLine.AddText("\n\n\n............................................................................................");

            Paragraph authSing = signatureTF.AddParagraph();
            authSing.Format.Alignment = ParagraphAlignment.Left;
            authSing.AddText("(AUTHORIZED SIGNATORY)");

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            string pdfPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "PICKLIST");
            string filename = pdfPath + "\\PICKLIST" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";
            pdfRenderer.PdfDocument.Save(filename);
            Process.Start(filename);
        }

        public void generateCustomForm(string ems, DataTable data,string officerName)
        {
            Document document = new Document();
            document.DefaultPageSetup.Orientation = Orientation.Landscape;
            Section section = document.AddSection();


            TextFrame titleTF = section.AddTextFrame();
            titleTF.WrapFormat.DistanceTop = Unit.FromCentimeter(-1);
            titleTF.WrapFormat.DistanceLeft = Unit.FromCentimeter(4);
            titleTF.Width = Unit.FromCentimeter(17);
            titleTF.Height = Unit.FromCentimeter(1);            

            Paragraph titlePara = titleTF.AddParagraph();
            titlePara.Format.Alignment = ParagraphAlignment.Center;
            titlePara.Format.Font.Bold= true;
            titlePara.Format.Font.Size = 12;
            titlePara.AddText("PENYATA PENGERAKAN BAHAN MENTAH/KOMPONEN/BARANG SIAP");

            TextFrame lanpiranTF = section.AddTextFrame();
            lanpiranTF.WrapFormat.DistanceTop = Unit.FromMillimeter(-5);
            lanpiranTF.WrapFormat.DistanceLeft = Unit.FromCentimeter(20);
            lanpiranTF.Width = Unit.FromCentimeter(5);

            Paragraph lanpiranPara = lanpiranTF.AddParagraph();
            lanpiranPara.Format.Alignment = ParagraphAlignment.Right;
            lanpiranPara.Format.Font.Size = 12;
            lanpiranPara.AddText("LAMPIRAN Q");

            Paragraph perPara = lanpiranTF.AddParagraph();
            perPara.Format.Alignment = ParagraphAlignment.Right;
            perPara.Format.Font.Size = 12;
            perPara.AddText("PER: 16.3");

            Paragraph ptkPara = lanpiranTF.AddParagraph();
            ptkPara.Format.Alignment= ParagraphAlignment.Right;
            ptkPara.Format.Font.Size = 12;
            ptkPara.AddText("PTK NO.27");

            TextFrame GPBTF = section.AddTextFrame();
            GPBTF.LineFormat.Color = Colors.Black;
            GPBTF.WrapFormat.DistanceTop = Unit.FromMillimeter(-10);
            GPBTF.WrapFormat.DistanceLeft = Unit.FromMillimeter(192);
            GPBTF.Width = Unit.FromCentimeter(5.8);
            GPBTF.Height= Unit.FromMillimeter(5);

            Paragraph gbpPara = GPBTF.AddParagraph();
            gbpPara.Format.Alignment = ParagraphAlignment.Center;
            gbpPara.Format.Font.Size = 12;
            gbpPara.AddText("GPB 1");

            TextFrame senderTF = section.AddTextFrame();
            senderTF.WrapFormat.DistanceLeft = -14;

            Table detailTable = senderTF.AddTable();
            //detailTable.Borders.Width = 1;
            detailTable.Rows.Alignment = RowAlignment.Left;

            Column panaAdd= detailTable.AddColumn();
            panaAdd.Width = Unit.FromMillimeter(80);
            panaAdd.Format.Alignment = ParagraphAlignment.Left;

            Column detailCol = detailTable.AddColumn();
            detailCol.Width = Unit.FromMillimeter(95);
            detailCol.Format.Alignment = ParagraphAlignment.Left;

            Column recvCol = detailTable.AddColumn();
            recvCol.Width = Unit.FromMillimeter(85);
            recvCol.Format.Alignment = ParagraphAlignment.Left;

            Row detailRow = detailTable.AddRow();
            TextFrame panaAddTF = detailRow.Cells[0].AddTextFrame();
            panaAddTF.Width = Unit.FromMillimeter(88.1);
            Paragraph panaaddPara = panaAddTF.AddParagraph();
            panaaddPara.AddText("Nama dan Alamat Syarikat Penghantar");
            Paragraph panaaddPara1 = panaAddTF.AddParagraph();
            panaaddPara1.AddText("PLOT 10, FASA 4,");
            Paragraph panaaddPara2 = panaAddTF.AddParagraph();
            panaaddPara2.AddText("KAWASAN PERINDUSTRIAN PERAI");
            Paragraph panaaddPara3 = panaAddTF.AddParagraph();
            panaaddPara3.AddText("13600 PERAI, PULAU PINANG");
           

           

            string EMScompanyname = "";
            string EMSaddressline1 = "";
            string EMSaddressline2 = "";
            string EMSaddressline3 = "";
            string EMSaddressline4 = "";
            string refNo = "";
            string approvalDate = "";
            switch (ems)
            {
                case "SANSHIN":
                    EMScompanyname = "SANSHIN (M) SDN BHD";
                    EMSaddressline1 = "LOT 55, BAKAR ARANG INDUSTRIAL ESTATE";
                    EMSaddressline2 = "08000 SUNGAI PETANI, KEDAH";
                    EMSaddressline3 = "";
                    EMSaddressline4 = "";
                    refNo = "KE.PD(83)26403-208KLT.5(36)";
                    approvalDate = "3.11.2022-31.10.2023";
                    break;
                case "SCOPE":
                    EMScompanyname = "SCOPE MANUFACTURERS (M) SDN.BHD (229373-P)";
                    EMSaddressline1 = "Lot 6181, Jalan Perusahaan 2";
                    EMSaddressline2 = "Kawasan Perindustrian Parit Buntar,Perak";
                    EMSaddressline3 = "Malaysia";
                    EMSaddressline4 = "";
                    break;
                case "HOTAYI_BT":
                    EMScompanyname = "Hotayi Electronic (M) SDN. BHD.";
                    EMSaddressline1 = "PLOT 100, LORONG PERUSAHAAN UTAMA,";
                    EMSaddressline2 = "TAMAN PERINDUSTRIAN BUKIT TENGAH,";
                    EMSaddressline3 = "14000 BUKIT MERTAJAM, PENANG, MALAYSIA";
                    EMSaddressline4 = "";
                    break;
                case "HOTAYI_BK":
                    EMScompanyname = "Hotayi Electronic (M) SDN. BHD.";
                    EMSaddressline1 = "PMT 751, Persiaran Cassia Selatan 1,";
                    EMSaddressline2 = "Taman Perindustrian Batu Kawan,";
                    EMSaddressline3 = "Bandar Cassia, 14110, Penang, Malaysia";
                    EMSaddressline4 = "";
                    break;
            }
            TextFrame datedetailsTF = detailRow.Cells[1].AddTextFrame();
            datedetailsTF.Width = Unit.FromMillimeter(96);
            Paragraph DATEPara = datedetailsTF.AddParagraph();
            DATEPara.AddFormattedText("Tarikh\t\t\t" + " : " + DateTime.Now.ToString("dd.MM.yyyy"));
            Paragraph PKNRef = datedetailsTF.AddParagraph();
            PKNRef.AddFormattedText("Rujukan Kelulusan PKN : " + refNo);
            Paragraph appPeriod = datedetailsTF.AddParagraph();
            appPeriod.AddFormattedText("Tempoh Diluluskan\t : " + approvalDate);
            Paragraph vehicleNo = datedetailsTF.AddParagraph();
            vehicleNo.AddFormattedText("No.Kenderaan\t\t : -");

            TextFrame receiveraddTF = detailRow.Cells[2].AddTextFrame();
            receiveraddTF.Width = Unit.FromMillimeter(75);
            Paragraph receiveraddPara = receiveraddTF.AddParagraph();
            receiveraddPara.AddFormattedText("Nama dan Alamat Syarikat Penerima");
            Paragraph receiveraddPara1 = receiveraddTF.AddParagraph();
            receiveraddPara1.AddFormattedText(EMScompanyname);
            Paragraph receiveraddPara2 = receiveraddTF.AddParagraph();
            receiveraddPara2.AddFormattedText(EMSaddressline1);
            Paragraph receiveraddPara3 = receiveraddTF.AddParagraph();
            receiveraddPara3.AddFormattedText(EMSaddressline2);
            Paragraph receiveraddPara4 = receiveraddTF.AddParagraph();
            receiveraddPara4.AddFormattedText(EMSaddressline3);
            Paragraph receiveraddPara5 = receiveraddTF.AddParagraph();
            receiveraddPara5.AddFormattedText(EMSaddressline4);

            Table mainTab = new Table();
            mainTab.Borders.Width = 1;
            mainTab.Style = "Table";
            mainTab.Rows.Alignment = RowAlignment.Center;

            Column no_col = mainTab.AddColumn();
            no_col.Width = Unit.FromMillimeter(35);
            no_col.Format.Alignment = ParagraphAlignment.Center;

            Column mat_col = mainTab.AddColumn();
            mat_col.Width = Unit.FromMillimeter(53);
            mat_col.Format.Alignment = ParagraphAlignment.Center;

            Column quantity_col = mainTab.AddColumn();
            quantity_col.Width = Unit.FromMillimeter(37.5);
            quantity_col.Format.Alignment = ParagraphAlignment.Center;

            Column barcode_col = mainTab.AddColumn();
            barcode_col.Width = Unit.FromMillimeter(30.1);
            barcode_col.Format.Alignment = ParagraphAlignment.Center;

            Column refLoc_col = mainTab.AddColumn();
            refLoc_col.Width = Unit.FromMillimeter(29);
            refLoc_col.Format.Alignment = ParagraphAlignment.Center;


            Column numReel_col = mainTab.AddColumn();
            numReel_col.Width = Unit.FromMillimeter(75);
            numReel_col.Format.Alignment = ParagraphAlignment.Center;


            Row rNo = mainTab.AddRow();
            rNo.VerticalAlignment = VerticalAlignment.Top;
            rNo.Height = Unit.FromMillimeter(9);
            rNo.HeadingFormat = true;
            rNo.Format.Font.Bold = true;

            rNo.Cells[0].MergeRight = 2;
            rNo.Cells[0].AddParagraph("Nama Bahan Mentah/Komponen/Barang Siap");
            rNo.Cells[2].AddParagraph("No. Kod Tariff");
            rNo.Cells[3].AddParagraph("Kuantiti");
            rNo.Cells[4].AddParagraph("Berat");
            rNo.Cells[5].AddParagraph("Lain - Lain Kenyataan");

            foreach (DataRow dr in data.Rows)
            {
                Row nrows = mainTab.AddRow();
                nrows.VerticalAlignment = VerticalAlignment.Center;
                nrows.Height = Unit.FromMillimeter(5);
                nrows.Cells[0].AddParagraph(dr["Part Number"].ToString());
                nrows.Cells[1].AddParagraph(dr["Item Group"].ToString());
                nrows.Cells[2].AddParagraph(dr["Hs Code"].ToString());
                nrows.Cells[3].AddParagraph(dr["Quantity"].ToString());
                nrows.Cells[4].AddParagraph("");
                nrows.Cells[5].AddParagraph("");

            }

            mainTab = mainTab.Clone();
            section.Add(mainTab);

            Table sgTable = new Table();
            mainTab.Style = "Table";
            mainTab.Rows.Alignment = RowAlignment.Left;

            Column pasmySig = sgTable.AddColumn();
            pasmySig.Width = Unit.FromMillimeter(130);
            pasmySig.Format.Alignment = ParagraphAlignment.Left;

            Column emsSig = sgTable.AddColumn();
            emsSig.Width = Unit.FromMillimeter(130);
            emsSig.Format.Alignment = ParagraphAlignment.Right;

            Row rowSig = sgTable.AddRow();
            rowSig.VerticalAlignment = VerticalAlignment.Top;
            rowSig.Height = Unit.FromMillimeter(40);

            Paragraph sigPara = rowSig.Cells[0].AddParagraph();
            sigPara.AddFormattedText("\n\n\n\n\n");
            sigPara.AddFormattedText("______________________________________________\n");
            sigPara.AddFormattedText("Tandatangan Pegawai Syarikat Yang Bertangungjawab\n");
            sigPara.AddFormattedText("(Syarikat Penghantar)\n");
            sigPara.AddFormattedText("Nama: "+ officerName + "\n");
            sigPara.AddFormattedText("Jawatan: SECTION HEAD");


            Paragraph emssigPara = rowSig.Cells[1].AddParagraph();
            emssigPara.AddFormattedText("\n");
            emssigPara.AddFormattedText("Saya mengakui menerima barangan tersebut di atas pada jam: \n\n\n\n");
            emssigPara.AddFormattedText("_______________________________________________\n");
            emssigPara.AddFormattedText("Tandatangan Pegawai Syarikat Yang Bertangungjawab\n");
            emssigPara.AddFormattedText("(Syarikat Penerima)\n");
            emssigPara.AddFormattedText("Nama:\t\t\t\t\t\t");


            section.Document.LastSection.Add(sgTable);

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            string pdfPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "CUSTOMFORM");
            string filename = pdfPath + "\\CUSTOMFORM" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";
            pdfRenderer.PdfDocument.Save(filename);
            Process.Start(filename);
        }

    }
}

namespace EMSMaterialPreparation
{
    partial class GENERATEEMSPICKLIST
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridviewMain = new System.Windows.Forms.DataGridView();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPONENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REQUIREMENT_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WITHDRAWN_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BALANCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMS_STOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VENDOR_STOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAL_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTION_ORDER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridViewWrongItem = new System.Windows.Forms.DataGridView();
            this.lblwrongpick = new System.Windows.Forms.Label();
            this.lblEMS = new System.Windows.Forms.Label();
            this.btnPicklist = new System.Windows.Forms.Button();
            this.btn_generatePicklist = new System.Windows.Forms.Button();
            this.lbl_picklistno = new System.Windows.Forms.Label();
            this.txt_pickListNo = new System.Windows.Forms.TextBox();
            this.lbl_DONum = new System.Windows.Forms.Label();
            this.txt_DO_no = new System.Windows.Forms.TextBox();
            this.btn_generateDO = new System.Windows.Forms.Button();
            this.lblpreparedbyName = new System.Windows.Forms.Label();
            this.lblshipby = new System.Windows.Forms.Label();
            this.txtpreparedby = new System.Windows.Forms.TextBox();
            this.txtshipby = new System.Windows.Forms.TextBox();
            this.btncsform = new System.Windows.Forms.Button();
            this.lbl_officername = new System.Windows.Forms.Label();
            this.txtOfficerName = new System.Windows.Forms.TextBox();
            this.lblupdateName = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWrongItem)).BeginInit();
            this.SuspendLayout();
            // 
            // gridviewMain
            // 
            this.gridviewMain.AllowUserToAddRows = false;
            this.gridviewMain.AllowUserToDeleteRows = false;
            this.gridviewMain.AllowUserToOrderColumns = true;
            this.gridviewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NO,
            this.COMPONENT,
            this.REQUIREMENT_QUANTITY,
            this.WITHDRAWN_QUANTITY,
            this.BALANCE,
            this.EMS_STOCK,
            this.VENDOR_STOCK,
            this.BAL_QTY,
            this.PRODUCTION_ORDER});
            this.gridviewMain.Location = new System.Drawing.Point(12, 46);
            this.gridviewMain.Name = "gridviewMain";
            this.gridviewMain.ReadOnly = true;
            this.gridviewMain.Size = new System.Drawing.Size(947, 458);
            this.gridviewMain.TabIndex = 0;
            // 
            // NO
            // 
            this.NO.DataPropertyName = "NO";
            this.NO.HeaderText = "No.";
            this.NO.Name = "NO";
            this.NO.ReadOnly = true;
            // 
            // COMPONENT
            // 
            this.COMPONENT.DataPropertyName = "COMPONENT";
            this.COMPONENT.HeaderText = "Component";
            this.COMPONENT.Name = "COMPONENT";
            this.COMPONENT.ReadOnly = true;
            // 
            // REQUIREMENT_QUANTITY
            // 
            this.REQUIREMENT_QUANTITY.DataPropertyName = "REQUIREMENT_QUANTITY";
            this.REQUIREMENT_QUANTITY.HeaderText = "QTY required for PO / s";
            this.REQUIREMENT_QUANTITY.Name = "REQUIREMENT_QUANTITY";
            this.REQUIREMENT_QUANTITY.ReadOnly = true;
            // 
            // WITHDRAWN_QUANTITY
            // 
            this.WITHDRAWN_QUANTITY.DataPropertyName = "WITHDRAWN_QUANTITY";
            this.WITHDRAWN_QUANTITY.HeaderText = "QTY Withdrawn by PO";
            this.WITHDRAWN_QUANTITY.Name = "WITHDRAWN_QUANTITY";
            this.WITHDRAWN_QUANTITY.ReadOnly = true;
            // 
            // BALANCE
            // 
            this.BALANCE.DataPropertyName = "BALANCE";
            this.BALANCE.HeaderText = "Balance Required QTY after GR";
            this.BALANCE.Name = "BALANCE";
            this.BALANCE.ReadOnly = true;
            // 
            // EMS_STOCK
            // 
            this.EMS_STOCK.DataPropertyName = "EMS_STOCK";
            this.EMS_STOCK.HeaderText = "Current Stock PASMY EMS";
            this.EMS_STOCK.Name = "EMS_STOCK";
            this.EMS_STOCK.ReadOnly = true;
            // 
            // VENDOR_STOCK
            // 
            this.VENDOR_STOCK.DataPropertyName = "VENDOR_STOCK";
            this.VENDOR_STOCK.HeaderText = "Current Stock in EMS ";
            this.VENDOR_STOCK.Name = "VENDOR_STOCK";
            this.VENDOR_STOCK.ReadOnly = true;
            // 
            // BAL_QTY
            // 
            this.BAL_QTY.DataPropertyName = "BAL_QTY";
            this.BAL_QTY.HeaderText = "Balance Quantity";
            this.BAL_QTY.Name = "BAL_QTY";
            this.BAL_QTY.ReadOnly = true;
            // 
            // PRODUCTION_ORDER
            // 
            this.PRODUCTION_ORDER.DataPropertyName = "PRODUCTION_ORDER";
            this.PRODUCTION_ORDER.HeaderText = "Production Order";
            this.PRODUCTION_ORDER.Name = "PRODUCTION_ORDER";
            this.PRODUCTION_ORDER.ReadOnly = true;
            // 
            // gridViewWrongItem
            // 
            this.gridViewWrongItem.AllowUserToAddRows = false;
            this.gridViewWrongItem.AllowUserToDeleteRows = false;
            this.gridViewWrongItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewWrongItem.Location = new System.Drawing.Point(965, 46);
            this.gridViewWrongItem.Name = "gridViewWrongItem";
            this.gridViewWrongItem.ReadOnly = true;
            this.gridViewWrongItem.Size = new System.Drawing.Size(192, 458);
            this.gridViewWrongItem.TabIndex = 1;
            // 
            // lblwrongpick
            // 
            this.lblwrongpick.AutoSize = true;
            this.lblwrongpick.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwrongpick.Location = new System.Drawing.Point(971, 12);
            this.lblwrongpick.Name = "lblwrongpick";
            this.lblwrongpick.Size = new System.Drawing.Size(173, 24);
            this.lblwrongpick.TabIndex = 2;
            this.lblwrongpick.Text = "Items wrong picked";
            // 
            // lblEMS
            // 
            this.lblEMS.AutoSize = true;
            this.lblEMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEMS.Location = new System.Drawing.Point(12, 12);
            this.lblEMS.Name = "lblEMS";
            this.lblEMS.Size = new System.Drawing.Size(0, 25);
            this.lblEMS.TabIndex = 3;
            // 
            // btnPicklist
            // 
            this.btnPicklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPicklist.Location = new System.Drawing.Point(17, 579);
            this.btnPicklist.Name = "btnPicklist";
            this.btnPicklist.Size = new System.Drawing.Size(173, 65);
            this.btnPicklist.TabIndex = 4;
            this.btnPicklist.Text = "Generate Pull List 2006";
            this.btnPicklist.UseVisualStyleBackColor = true;
            this.btnPicklist.Click += new System.EventHandler(this.btnPicklist_Click);
            // 
            // btn_generatePicklist
            // 
            this.btn_generatePicklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_generatePicklist.Location = new System.Drawing.Point(219, 580);
            this.btn_generatePicklist.Name = "btn_generatePicklist";
            this.btn_generatePicklist.Size = new System.Drawing.Size(173, 65);
            this.btn_generatePicklist.TabIndex = 5;
            this.btn_generatePicklist.Text = "Generate Picklist";
            this.btn_generatePicklist.UseVisualStyleBackColor = true;
            this.btn_generatePicklist.Click += new System.EventHandler(this.btn_generatePicklist_Click);
            // 
            // lbl_picklistno
            // 
            this.lbl_picklistno.AutoSize = true;
            this.lbl_picklistno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_picklistno.Location = new System.Drawing.Point(17, 511);
            this.lbl_picklistno.Name = "lbl_picklistno";
            this.lbl_picklistno.Size = new System.Drawing.Size(125, 20);
            this.lbl_picklistno.TabIndex = 6;
            this.lbl_picklistno.Text = "Picklist Number :";
            // 
            // txt_pickListNo
            // 
            this.txt_pickListNo.Location = new System.Drawing.Point(149, 510);
            this.txt_pickListNo.Name = "txt_pickListNo";
            this.txt_pickListNo.Size = new System.Drawing.Size(138, 20);
            this.txt_pickListNo.TabIndex = 7;
            // 
            // lbl_DONum
            // 
            this.lbl_DONum.AutoSize = true;
            this.lbl_DONum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DONum.Location = new System.Drawing.Point(37, 542);
            this.lbl_DONum.Name = "lbl_DONum";
            this.lbl_DONum.Size = new System.Drawing.Size(105, 20);
            this.lbl_DONum.TabIndex = 8;
            this.lbl_DONum.Text = "DO Number : ";
            // 
            // txt_DO_no
            // 
            this.txt_DO_no.Location = new System.Drawing.Point(149, 544);
            this.txt_DO_no.Name = "txt_DO_no";
            this.txt_DO_no.Size = new System.Drawing.Size(138, 20);
            this.txt_DO_no.TabIndex = 9;
            // 
            // btn_generateDO
            // 
            this.btn_generateDO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_generateDO.Location = new System.Drawing.Point(421, 579);
            this.btn_generateDO.Name = "btn_generateDO";
            this.btn_generateDO.Size = new System.Drawing.Size(173, 65);
            this.btn_generateDO.TabIndex = 10;
            this.btn_generateDO.Text = "Generate DO";
            this.btn_generateDO.UseVisualStyleBackColor = true;
            this.btn_generateDO.Click += new System.EventHandler(this.btn_generateDO_Click);
            // 
            // lblpreparedbyName
            // 
            this.lblpreparedbyName.AutoSize = true;
            this.lblpreparedbyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpreparedbyName.Location = new System.Drawing.Point(314, 511);
            this.lblpreparedbyName.Name = "lblpreparedbyName";
            this.lblpreparedbyName.Size = new System.Drawing.Size(108, 20);
            this.lblpreparedbyName.TabIndex = 11;
            this.lblpreparedbyName.Text = "Prepared By : ";
            // 
            // lblshipby
            // 
            this.lblshipby.AutoSize = true;
            this.lblshipby.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblshipby.Location = new System.Drawing.Point(321, 544);
            this.lblshipby.Name = "lblshipby";
            this.lblshipby.Size = new System.Drawing.Size(96, 20);
            this.lblshipby.TabIndex = 12;
            this.lblshipby.Text = "Shipped by :";
            // 
            // txtpreparedby
            // 
            this.txtpreparedby.Location = new System.Drawing.Point(418, 513);
            this.txtpreparedby.Name = "txtpreparedby";
            this.txtpreparedby.Size = new System.Drawing.Size(159, 20);
            this.txtpreparedby.TabIndex = 13;
            // 
            // txtshipby
            // 
            this.txtshipby.Location = new System.Drawing.Point(418, 546);
            this.txtshipby.Name = "txtshipby";
            this.txtshipby.Size = new System.Drawing.Size(159, 20);
            this.txtshipby.TabIndex = 14;
            // 
            // btncsform
            // 
            this.btncsform.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncsform.Location = new System.Drawing.Point(634, 580);
            this.btncsform.Name = "btncsform";
            this.btncsform.Size = new System.Drawing.Size(173, 65);
            this.btncsform.TabIndex = 15;
            this.btncsform.Text = "Generate Custom Form";
            this.btncsform.UseVisualStyleBackColor = true;
            this.btncsform.Click += new System.EventHandler(this.btncsform_Click);
            // 
            // lbl_officername
            // 
            this.lbl_officername.AutoSize = true;
            this.lbl_officername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_officername.Location = new System.Drawing.Point(598, 517);
            this.lbl_officername.Name = "lbl_officername";
            this.lbl_officername.Size = new System.Drawing.Size(240, 20);
            this.lbl_officername.TabIndex = 16;
            this.lbl_officername.Text = "PASMY Logistics Officer Name : ";
            // 
            // txtOfficerName
            // 
            this.txtOfficerName.Location = new System.Drawing.Point(832, 519);
            this.txtOfficerName.Name = "txtOfficerName";
            this.txtOfficerName.Size = new System.Drawing.Size(166, 20);
            this.txtOfficerName.TabIndex = 17;
            this.txtOfficerName.TextChanged += new System.EventHandler(this.txtOfficerName_TextChanged);
            // 
            // lblupdateName
            // 
            this.lblupdateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblupdateName.Location = new System.Drawing.Point(1016, 517);
            this.lblupdateName.Name = "lblupdateName";
            this.lblupdateName.Size = new System.Drawing.Size(141, 65);
            this.lblupdateName.TabIndex = 18;
            this.lblupdateName.Text = "Update Signature names";
            this.lblupdateName.UseVisualStyleBackColor = true;
            this.lblupdateName.Click += new System.EventHandler(this.lblupdateName_Click);
            // 
            // GENERATEEMSPICKLIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 656);
            this.Controls.Add(this.lblupdateName);
            this.Controls.Add(this.txtOfficerName);
            this.Controls.Add(this.lbl_officername);
            this.Controls.Add(this.btncsform);
            this.Controls.Add(this.txtshipby);
            this.Controls.Add(this.txtpreparedby);
            this.Controls.Add(this.lblshipby);
            this.Controls.Add(this.lblpreparedbyName);
            this.Controls.Add(this.btn_generateDO);
            this.Controls.Add(this.txt_DO_no);
            this.Controls.Add(this.lbl_DONum);
            this.Controls.Add(this.txt_pickListNo);
            this.Controls.Add(this.lbl_picklistno);
            this.Controls.Add(this.btn_generatePicklist);
            this.Controls.Add(this.btnPicklist);
            this.Controls.Add(this.lblEMS);
            this.Controls.Add(this.lblwrongpick);
            this.Controls.Add(this.gridViewWrongItem);
            this.Controls.Add(this.gridviewMain);
            this.Name = "GENERATEEMSPICKLIST";
            this.Text = "GENERATEEMSPICKLIST";
            this.Load += new System.EventHandler(this.GENERATEEMSPICKLIST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWrongItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridviewMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPONENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn REQUIREMENT_QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn WITHDRAWN_QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn BALANCE;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMS_STOCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn VENDOR_STOCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAL_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTION_ORDER;
        private System.Windows.Forms.DataGridView gridViewWrongItem;
        private System.Windows.Forms.Label lblwrongpick;
        private System.Windows.Forms.Label lblEMS;
        private System.Windows.Forms.Button btnPicklist;
        private System.Windows.Forms.Button btn_generatePicklist;
        private System.Windows.Forms.Label lbl_picklistno;
        private System.Windows.Forms.TextBox txt_pickListNo;
        private System.Windows.Forms.Label lbl_DONum;
        private System.Windows.Forms.TextBox txt_DO_no;
        private System.Windows.Forms.Button btn_generateDO;
        private System.Windows.Forms.Label lblpreparedbyName;
        private System.Windows.Forms.Label lblshipby;
        private System.Windows.Forms.TextBox txtpreparedby;
        private System.Windows.Forms.TextBox txtshipby;
        private System.Windows.Forms.Button btncsform;
        private System.Windows.Forms.Label lbl_officername;
        private System.Windows.Forms.TextBox txtOfficerName;
        private System.Windows.Forms.Button lblupdateName;
    }
}
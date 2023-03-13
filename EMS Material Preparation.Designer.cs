namespace EMSMaterialPreparation
{
    partial class Form1
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
            this.grp_ems = new System.Windows.Forms.GroupBox();
            this.rb_HotayiBK = new System.Windows.Forms.RadioButton();
            this.rb_HotayiBT = new System.Windows.Forms.RadioButton();
            this.rb_scope = new System.Windows.Forms.RadioButton();
            this.rb_SANSHIN = new System.Windows.Forms.RadioButton();
            this.dgvEMS = new System.Windows.Forms.DataGridView();
            this.MODEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTION_ORDER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REMARKS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_rmk = new System.Windows.Forms.Button();
            this.txtProdOrdSearch = new System.Windows.Forms.TextBox();
            this.lblPONum = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnGeneratePull = new System.Windows.Forms.Button();
            this.btn_RemoveLot = new System.Windows.Forms.Button();
            this.grp_ems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEMS)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_ems
            // 
            this.grp_ems.Controls.Add(this.rb_HotayiBK);
            this.grp_ems.Controls.Add(this.rb_HotayiBT);
            this.grp_ems.Controls.Add(this.rb_scope);
            this.grp_ems.Controls.Add(this.rb_SANSHIN);
            this.grp_ems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_ems.Location = new System.Drawing.Point(17, 12);
            this.grp_ems.Name = "grp_ems";
            this.grp_ems.Size = new System.Drawing.Size(179, 156);
            this.grp_ems.TabIndex = 1;
            this.grp_ems.TabStop = false;
            this.grp_ems.Text = "Choose EMS";
            // 
            // rb_HotayiBK
            // 
            this.rb_HotayiBK.AutoSize = true;
            this.rb_HotayiBK.Location = new System.Drawing.Point(7, 119);
            this.rb_HotayiBK.Name = "rb_HotayiBK";
            this.rb_HotayiBK.Size = new System.Drawing.Size(162, 24);
            this.rb_HotayiBK.TabIndex = 3;
            this.rb_HotayiBK.TabStop = true;
            this.rb_HotayiBK.Text = "Hotayi Batu Kawan";
            this.rb_HotayiBK.UseVisualStyleBackColor = true;
            this.rb_HotayiBK.CheckedChanged += new System.EventHandler(this.rb_HotayiBK_CheckedChanged);
            // 
            // rb_HotayiBT
            // 
            this.rb_HotayiBT.AutoSize = true;
            this.rb_HotayiBT.Location = new System.Drawing.Point(7, 88);
            this.rb_HotayiBT.Name = "rb_HotayiBT";
            this.rb_HotayiBT.Size = new System.Drawing.Size(170, 24);
            this.rb_HotayiBT.TabIndex = 2;
            this.rb_HotayiBT.TabStop = true;
            this.rb_HotayiBT.Text = "Hotayi Bukit Tengah";
            this.rb_HotayiBT.UseVisualStyleBackColor = true;
            this.rb_HotayiBT.CheckedChanged += new System.EventHandler(this.rb_HotayiBT_CheckedChanged);
            // 
            // rb_scope
            // 
            this.rb_scope.AutoSize = true;
            this.rb_scope.Location = new System.Drawing.Point(7, 57);
            this.rb_scope.Name = "rb_scope";
            this.rb_scope.Size = new System.Drawing.Size(73, 24);
            this.rb_scope.TabIndex = 1;
            this.rb_scope.TabStop = true;
            this.rb_scope.Text = "Scope";
            this.rb_scope.UseVisualStyleBackColor = true;
            this.rb_scope.CheckedChanged += new System.EventHandler(this.rb_scope_CheckedChanged);
            // 
            // rb_SANSHIN
            // 
            this.rb_SANSHIN.AutoSize = true;
            this.rb_SANSHIN.Location = new System.Drawing.Point(7, 26);
            this.rb_SANSHIN.Name = "rb_SANSHIN";
            this.rb_SANSHIN.Size = new System.Drawing.Size(99, 24);
            this.rb_SANSHIN.TabIndex = 0;
            this.rb_SANSHIN.TabStop = true;
            this.rb_SANSHIN.Text = "SANSHIN";
            this.rb_SANSHIN.UseVisualStyleBackColor = true;
            this.rb_SANSHIN.CheckedChanged += new System.EventHandler(this.rb_SANSHIN_CheckedChanged);
            // 
            // dgvEMS
            // 
            this.dgvEMS.AllowUserToAddRows = false;
            this.dgvEMS.AllowUserToDeleteRows = false;
            this.dgvEMS.AllowUserToOrderColumns = true;
            this.dgvEMS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEMS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MODEL,
            this.LOT_NO,
            this.QUANTITY,
            this.EMS,
            this.PRODUCTION_ORDER,
            this.REMARKS});
            this.dgvEMS.Location = new System.Drawing.Point(17, 184);
            this.dgvEMS.Name = "dgvEMS";
            this.dgvEMS.ReadOnly = true;
            this.dgvEMS.Size = new System.Drawing.Size(1056, 434);
            this.dgvEMS.TabIndex = 2;
            // 
            // MODEL
            // 
            this.MODEL.DataPropertyName = "MODEL";
            this.MODEL.HeaderText = "Model";
            this.MODEL.Name = "MODEL";
            this.MODEL.ReadOnly = true;
            this.MODEL.Width = 130;
            // 
            // LOT_NO
            // 
            this.LOT_NO.DataPropertyName = "LOT_NO";
            this.LOT_NO.HeaderText = "Lot Number";
            this.LOT_NO.Name = "LOT_NO";
            this.LOT_NO.ReadOnly = true;
            this.LOT_NO.Width = 130;
            // 
            // QUANTITY
            // 
            this.QUANTITY.DataPropertyName = "QUANTITY";
            this.QUANTITY.HeaderText = "Quantity";
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.ReadOnly = true;
            this.QUANTITY.Width = 50;
            // 
            // EMS
            // 
            this.EMS.DataPropertyName = "EMS";
            this.EMS.HeaderText = "EMS";
            this.EMS.Name = "EMS";
            this.EMS.ReadOnly = true;
            // 
            // PRODUCTION_ORDER
            // 
            this.PRODUCTION_ORDER.DataPropertyName = "PRODUCTION_ORDER";
            this.PRODUCTION_ORDER.HeaderText = "Production Order";
            this.PRODUCTION_ORDER.Name = "PRODUCTION_ORDER";
            this.PRODUCTION_ORDER.ReadOnly = true;
            // 
            // REMARKS
            // 
            this.REMARKS.DataPropertyName = "REMARKS";
            this.REMARKS.HeaderText = "Remarks";
            this.REMARKS.Name = "REMARKS";
            this.REMARKS.ReadOnly = true;
            this.REMARKS.Width = 500;
            // 
            // btn_rmk
            // 
            this.btn_rmk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rmk.Location = new System.Drawing.Point(203, 22);
            this.btn_rmk.Name = "btn_rmk";
            this.btn_rmk.Size = new System.Drawing.Size(133, 40);
            this.btn_rmk.TabIndex = 3;
            this.btn_rmk.Text = "Add Remarks";
            this.btn_rmk.UseVisualStyleBackColor = true;
            this.btn_rmk.Click += new System.EventHandler(this.btn_rmk_Click);
            // 
            // txtProdOrdSearch
            // 
            this.txtProdOrdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdOrdSearch.Location = new System.Drawing.Point(214, 134);
            this.txtProdOrdSearch.Name = "txtProdOrdSearch";
            this.txtProdOrdSearch.Size = new System.Drawing.Size(177, 26);
            this.txtProdOrdSearch.TabIndex = 4;
            // 
            // lblPONum
            // 
            this.lblPONum.AutoSize = true;
            this.lblPONum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPONum.Location = new System.Drawing.Point(210, 104);
            this.lblPONum.Name = "lblPONum";
            this.lblPONum.Size = new System.Drawing.Size(129, 20);
            this.lblPONum.TabIndex = 5;
            this.lblPONum.Text = "Production Order";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(397, 131);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(140, 29);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = " Save";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnGeneratePull
            // 
            this.btnGeneratePull.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneratePull.Location = new System.Drawing.Point(544, 131);
            this.btnGeneratePull.Name = "btnGeneratePull";
            this.btnGeneratePull.Size = new System.Drawing.Size(153, 29);
            this.btnGeneratePull.TabIndex = 7;
            this.btnGeneratePull.Text = "Generate Picklists";
            this.btnGeneratePull.UseVisualStyleBackColor = true;
            this.btnGeneratePull.Click += new System.EventHandler(this.btnGeneratePull_Click);
            // 
            // btn_RemoveLot
            // 
            this.btn_RemoveLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RemoveLot.Location = new System.Drawing.Point(343, 22);
            this.btn_RemoveLot.Name = "btn_RemoveLot";
            this.btn_RemoveLot.Size = new System.Drawing.Size(151, 40);
            this.btn_RemoveLot.TabIndex = 8;
            this.btn_RemoveLot.Text = "Remove Lot";
            this.btn_RemoveLot.UseVisualStyleBackColor = true;
            this.btn_RemoveLot.Click += new System.EventHandler(this.btn_RemoveLot_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 630);
            this.Controls.Add(this.btn_RemoveLot);
            this.Controls.Add(this.btnGeneratePull);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblPONum);
            this.Controls.Add(this.txtProdOrdSearch);
            this.Controls.Add(this.btn_rmk);
            this.Controls.Add(this.dgvEMS);
            this.Controls.Add(this.grp_ems);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grp_ems.ResumeLayout(false);
            this.grp_ems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEMS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_ems;
        private System.Windows.Forms.RadioButton rb_HotayiBK;
        private System.Windows.Forms.RadioButton rb_HotayiBT;
        private System.Windows.Forms.RadioButton rb_scope;
        private System.Windows.Forms.RadioButton rb_SANSHIN;
        private System.Windows.Forms.DataGridView dgvEMS;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMS;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTION_ORDER;
        private System.Windows.Forms.DataGridViewTextBoxColumn REMARKS;
        private System.Windows.Forms.Button btn_rmk;
        private System.Windows.Forms.TextBox txtProdOrdSearch;
        private System.Windows.Forms.Label lblPONum;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnGeneratePull;
        private System.Windows.Forms.Button btn_RemoveLot;
    }
}


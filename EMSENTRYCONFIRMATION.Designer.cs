namespace EMSMaterialPreparation
{
    partial class EMSENTRYCONFIRMATION
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
            this.lblconftitle = new System.Windows.Forms.Label();
            this.lblconfmodel = new System.Windows.Forms.Label();
            this.lblconfLot = new System.Windows.Forms.Label();
            this.lblconfqty = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.lblemsloc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblconftitle
            // 
            this.lblconftitle.AutoSize = true;
            this.lblconftitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblconftitle.Location = new System.Drawing.Point(12, 9);
            this.lblconftitle.Name = "lblconftitle";
            this.lblconftitle.Size = new System.Drawing.Size(159, 25);
            this.lblconftitle.TabIndex = 0;
            this.lblconftitle.Text = "Confirm Save ?";
            // 
            // lblconfmodel
            // 
            this.lblconfmodel.AutoSize = true;
            this.lblconfmodel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblconfmodel.Location = new System.Drawing.Point(12, 55);
            this.lblconfmodel.Name = "lblconfmodel";
            this.lblconfmodel.Size = new System.Drawing.Size(52, 20);
            this.lblconfmodel.TabIndex = 1;
            this.lblconfmodel.Text = "Model";
            // 
            // lblconfLot
            // 
            this.lblconfLot.AutoSize = true;
            this.lblconfLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblconfLot.Location = new System.Drawing.Point(12, 96);
            this.lblconfLot.Name = "lblconfLot";
            this.lblconfLot.Size = new System.Drawing.Size(112, 20);
            this.lblconfLot.TabIndex = 2;
            this.lblconfLot.Text = "Production Lot";
            // 
            // lblconfqty
            // 
            this.lblconfqty.AutoSize = true;
            this.lblconfqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblconfqty.Location = new System.Drawing.Point(12, 138);
            this.lblconfqty.Name = "lblconfqty";
            this.lblconfqty.Size = new System.Drawing.Size(89, 20);
            this.lblconfqty.TabIndex = 3;
            this.lblconfqty.Text = "QUANTITY";
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(49, 245);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 38);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btncancel
            // 
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Location = new System.Drawing.Point(195, 245);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 38);
            this.btncancel.TabIndex = 5;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // lblemsloc
            // 
            this.lblemsloc.AutoSize = true;
            this.lblemsloc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblemsloc.Location = new System.Drawing.Point(12, 180);
            this.lblemsloc.Name = "lblemsloc";
            this.lblemsloc.Size = new System.Drawing.Size(94, 25);
            this.lblemsloc.TabIndex = 6;
            this.lblemsloc.Text = "Location";
            // 
            // EMSENTRYCONFIRMATION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 295);
            this.Controls.Add(this.lblemsloc);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblconfqty);
            this.Controls.Add(this.lblconfLot);
            this.Controls.Add(this.lblconfmodel);
            this.Controls.Add(this.lblconftitle);
            this.Name = "EMSENTRYCONFIRMATION";
            this.Text = "EMSENTRYCONFIRMATION";
            this.Load += new System.EventHandler(this.EMSENTRYCONFIRMATION_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblconftitle;
        private System.Windows.Forms.Label lblconfmodel;
        private System.Windows.Forms.Label lblconfLot;
        private System.Windows.Forms.Label lblconfqty;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label lblemsloc;
    }
}
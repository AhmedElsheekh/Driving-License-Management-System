namespace DVLD_Presentation.Applications.Renew_Local_Licenses
{
    partial class frmRenewLocalLicenseApplication
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
            this.label1 = new System.Windows.Forms.Label();
            this.gbAppInfo = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblExpDate = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblRenewedLicenseID = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblLicenseFees = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRLApplicationID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRenew = new System.Windows.Forms.Button();
            this.lklNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.lklPersonLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.ctrlLicenseCardWithFilter1 = new DVLD_Presentation.Licenses.Local_Licenses.ctrlLicenseCardWithFilter();
            this.gbAppInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(252, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Renew Local License Application";
            // 
            // gbAppInfo
            // 
            this.gbAppInfo.Controls.Add(this.txtNotes);
            this.gbAppInfo.Controls.Add(this.label22);
            this.gbAppInfo.Controls.Add(this.lblTotalFees);
            this.gbAppInfo.Controls.Add(this.label13);
            this.gbAppInfo.Controls.Add(this.lblCreatedBy);
            this.gbAppInfo.Controls.Add(this.label15);
            this.gbAppInfo.Controls.Add(this.lblExpDate);
            this.gbAppInfo.Controls.Add(this.label17);
            this.gbAppInfo.Controls.Add(this.lblOldLicenseID);
            this.gbAppInfo.Controls.Add(this.label19);
            this.gbAppInfo.Controls.Add(this.lblRenewedLicenseID);
            this.gbAppInfo.Controls.Add(this.label21);
            this.gbAppInfo.Controls.Add(this.lblLicenseFees);
            this.gbAppInfo.Controls.Add(this.label9);
            this.gbAppInfo.Controls.Add(this.lblAppFees);
            this.gbAppInfo.Controls.Add(this.label11);
            this.gbAppInfo.Controls.Add(this.lblIssueDate);
            this.gbAppInfo.Controls.Add(this.label7);
            this.gbAppInfo.Controls.Add(this.lblAppDate);
            this.gbAppInfo.Controls.Add(this.label5);
            this.gbAppInfo.Controls.Add(this.lblRLApplicationID);
            this.gbAppInfo.Controls.Add(this.label2);
            this.gbAppInfo.Location = new System.Drawing.Point(31, 446);
            this.gbAppInfo.Name = "gbAppInfo";
            this.gbAppInfo.Size = new System.Drawing.Size(736, 244);
            this.gbAppInfo.TabIndex = 2;
            this.gbAppInfo.TabStop = false;
            this.gbAppInfo.Text = "Renew License Application Info";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(115, 200);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(465, 36);
            this.txtNotes.TabIndex = 21;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(26, 219);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 13);
            this.label22.TabIndex = 20;
            this.label22.Text = "Notes";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Location = new System.Drawing.Point(561, 184);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(31, 13);
            this.lblTotalFees.TabIndex = 19;
            this.lblTotalFees.Text = "[???]";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(453, 184);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Total Fees";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(561, 146);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(31, 13);
            this.lblCreatedBy.TabIndex = 17;
            this.lblCreatedBy.Text = "[???]";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(453, 146);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Created By";
            // 
            // lblExpDate
            // 
            this.lblExpDate.AutoSize = true;
            this.lblExpDate.Location = new System.Drawing.Point(561, 108);
            this.lblExpDate.Name = "lblExpDate";
            this.lblExpDate.Size = new System.Drawing.Size(31, 13);
            this.lblExpDate.TabIndex = 15;
            this.lblExpDate.Text = "[???]";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(453, 108);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 13);
            this.label17.TabIndex = 14;
            this.label17.Text = "Expiration Date";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Location = new System.Drawing.Point(561, 70);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(31, 13);
            this.lblOldLicenseID.TabIndex = 13;
            this.lblOldLicenseID.Text = "[???]";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(453, 70);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 13);
            this.label19.TabIndex = 12;
            this.label19.Text = "Old License ID";
            // 
            // lblRenewedLicenseID
            // 
            this.lblRenewedLicenseID.AutoSize = true;
            this.lblRenewedLicenseID.Location = new System.Drawing.Point(561, 32);
            this.lblRenewedLicenseID.Name = "lblRenewedLicenseID";
            this.lblRenewedLicenseID.Size = new System.Drawing.Size(31, 13);
            this.lblRenewedLicenseID.TabIndex = 11;
            this.lblRenewedLicenseID.Text = "[???]";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(453, 32);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(107, 13);
            this.label21.TabIndex = 10;
            this.label21.Text = "Renewed License ID";
            // 
            // lblLicenseFees
            // 
            this.lblLicenseFees.AutoSize = true;
            this.lblLicenseFees.Location = new System.Drawing.Point(125, 184);
            this.lblLicenseFees.Name = "lblLicenseFees";
            this.lblLicenseFees.Size = new System.Drawing.Size(31, 13);
            this.lblLicenseFees.TabIndex = 9;
            this.lblLicenseFees.Text = "[???]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "License Fees";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Location = new System.Drawing.Point(125, 146);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(31, 13);
            this.lblAppFees.TabIndex = 7;
            this.lblAppFees.Text = "[???]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Application Fees";
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Location = new System.Drawing.Point(125, 108);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(31, 13);
            this.lblIssueDate.TabIndex = 5;
            this.lblIssueDate.Text = "[???]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Issue Date";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Location = new System.Drawing.Point(125, 70);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(31, 13);
            this.lblAppDate.TabIndex = 3;
            this.lblAppDate.Text = "[???]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Application Date";
            // 
            // lblRLApplicationID
            // 
            this.lblRLApplicationID.AutoSize = true;
            this.lblRLApplicationID.Location = new System.Drawing.Point(125, 32);
            this.lblRLApplicationID.Name = "lblRLApplicationID";
            this.lblRLApplicationID.Size = new System.Drawing.Size(31, 13);
            this.lblRLApplicationID.TabIndex = 1;
            this.lblRLApplicationID.Text = "[???]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "R L Application ID";
            // 
            // btnRenew
            // 
            this.btnRenew.Location = new System.Drawing.Point(692, 697);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(75, 29);
            this.btnRenew.TabIndex = 3;
            this.btnRenew.Text = "Renew";
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // lklNewLicenseInfo
            // 
            this.lklNewLicenseInfo.AutoSize = true;
            this.lklNewLicenseInfo.Location = new System.Drawing.Point(28, 705);
            this.lklNewLicenseInfo.Name = "lklNewLicenseInfo";
            this.lklNewLicenseInfo.Size = new System.Drawing.Size(120, 13);
            this.lklNewLicenseInfo.TabIndex = 4;
            this.lklNewLicenseInfo.TabStop = true;
            this.lklNewLicenseInfo.Text = "Show New License Info";
            this.lklNewLicenseInfo.Click += new System.EventHandler(this.lklNewLicenseInfo_Click);
            // 
            // lklPersonLicensesHistory
            // 
            this.lklPersonLicensesHistory.AutoSize = true;
            this.lklPersonLicensesHistory.Location = new System.Drawing.Point(171, 705);
            this.lklPersonLicensesHistory.Name = "lklPersonLicensesHistory";
            this.lklPersonLicensesHistory.Size = new System.Drawing.Size(150, 13);
            this.lklPersonLicensesHistory.TabIndex = 5;
            this.lklPersonLicensesHistory.TabStop = true;
            this.lklPersonLicensesHistory.Text = "Show Person Licenses History";
            this.lklPersonLicensesHistory.Click += new System.EventHandler(this.lklPersonLicensesHistory_Click);
            // 
            // ctrlLicenseCardWithFilter1
            // 
            this.ctrlLicenseCardWithFilter1.EnableFilter = true;
            this.ctrlLicenseCardWithFilter1.Location = new System.Drawing.Point(78, 44);
            this.ctrlLicenseCardWithFilter1.Name = "ctrlLicenseCardWithFilter1";
            this.ctrlLicenseCardWithFilter1.Size = new System.Drawing.Size(666, 412);
            this.ctrlLicenseCardWithFilter1.TabIndex = 1;
            this.ctrlLicenseCardWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlLicenseCardWithFilter1_OnLicenseSelected);
            // 
            // frmRenewLocalLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 738);
            this.Controls.Add(this.lklPersonLicensesHistory);
            this.Controls.Add(this.lklNewLicenseInfo);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.gbAppInfo);
            this.Controls.Add(this.ctrlLicenseCardWithFilter1);
            this.Controls.Add(this.label1);
            this.Name = "frmRenewLocalLicenseApplication";
            this.Text = "Renew Local License Application";
            this.Load += new System.EventHandler(this.frmRenewLocalLicenseApplication_Load);
            this.gbAppInfo.ResumeLayout(false);
            this.gbAppInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Licenses.Local_Licenses.ctrlLicenseCardWithFilter ctrlLicenseCardWithFilter1;
        private System.Windows.Forms.GroupBox gbAppInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblExpDate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblRenewedLicenseID;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblLicenseFees;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRLApplicationID;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.LinkLabel lklNewLicenseInfo;
        private System.Windows.Forms.LinkLabel lklPersonLicensesHistory;
    }
}
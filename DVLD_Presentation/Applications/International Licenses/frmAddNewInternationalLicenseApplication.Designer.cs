namespace DVLD_Presentation.Applications.International_Licenses
{
    partial class frmAddNewInternationalLicenseApplication
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
            this.ctrlLicenseCardWithFilter1 = new DVLD_Presentation.Licenses.Local_Licenses.ctrlLicenseCardWithFilter();
            this.gbAppInfo = new System.Windows.Forms.GroupBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblExpDate = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblLocalLicenseID = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblILicenseID = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblFees = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblILApplicationId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lklLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.lklPersonLicenesHistory = new System.Windows.Forms.LinkLabel();
            this.gbAppInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlLicenseCardWithFilter1
            // 
            this.ctrlLicenseCardWithFilter1.EnableFilter = true;
            this.ctrlLicenseCardWithFilter1.Location = new System.Drawing.Point(66, 12);
            this.ctrlLicenseCardWithFilter1.Name = "ctrlLicenseCardWithFilter1";
            this.ctrlLicenseCardWithFilter1.Size = new System.Drawing.Size(666, 412);
            this.ctrlLicenseCardWithFilter1.TabIndex = 0;
            this.ctrlLicenseCardWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlLicenseCardWithFilter1_OnLicenseSelected);
            // 
            // gbAppInfo
            // 
            this.gbAppInfo.Controls.Add(this.lblCreatedBy);
            this.gbAppInfo.Controls.Add(this.label10);
            this.gbAppInfo.Controls.Add(this.lblExpDate);
            this.gbAppInfo.Controls.Add(this.label12);
            this.gbAppInfo.Controls.Add(this.lblLocalLicenseID);
            this.gbAppInfo.Controls.Add(this.label14);
            this.gbAppInfo.Controls.Add(this.lblILicenseID);
            this.gbAppInfo.Controls.Add(this.label16);
            this.gbAppInfo.Controls.Add(this.lblFees);
            this.gbAppInfo.Controls.Add(this.label8);
            this.gbAppInfo.Controls.Add(this.lblIssueDate);
            this.gbAppInfo.Controls.Add(this.label6);
            this.gbAppInfo.Controls.Add(this.lblApplicationDate);
            this.gbAppInfo.Controls.Add(this.label4);
            this.gbAppInfo.Controls.Add(this.lblILApplicationId);
            this.gbAppInfo.Controls.Add(this.label1);
            this.gbAppInfo.Location = new System.Drawing.Point(86, 430);
            this.gbAppInfo.Name = "gbAppInfo";
            this.gbAppInfo.Size = new System.Drawing.Size(620, 165);
            this.gbAppInfo.TabIndex = 1;
            this.gbAppInfo.TabStop = false;
            this.gbAppInfo.Text = "Application Info";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(480, 136);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(31, 13);
            this.lblCreatedBy.TabIndex = 15;
            this.lblCreatedBy.Text = "[???]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(383, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Created By";
            // 
            // lblExpDate
            // 
            this.lblExpDate.AutoSize = true;
            this.lblExpDate.Location = new System.Drawing.Point(480, 101);
            this.lblExpDate.Name = "lblExpDate";
            this.lblExpDate.Size = new System.Drawing.Size(31, 13);
            this.lblExpDate.TabIndex = 13;
            this.lblExpDate.Text = "[???]";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(383, 101);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Expiration Date";
            // 
            // lblLocalLicenseID
            // 
            this.lblLocalLicenseID.AutoSize = true;
            this.lblLocalLicenseID.Location = new System.Drawing.Point(480, 66);
            this.lblLocalLicenseID.Name = "lblLocalLicenseID";
            this.lblLocalLicenseID.Size = new System.Drawing.Size(31, 13);
            this.lblLocalLicenseID.TabIndex = 11;
            this.lblLocalLicenseID.Text = "[???]";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(383, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Local License ID";
            // 
            // lblILicenseID
            // 
            this.lblILicenseID.AutoSize = true;
            this.lblILicenseID.Location = new System.Drawing.Point(480, 31);
            this.lblILicenseID.Name = "lblILicenseID";
            this.lblILicenseID.Size = new System.Drawing.Size(31, 13);
            this.lblILicenseID.TabIndex = 9;
            this.lblILicenseID.Text = "[???]";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(383, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "I License ID";
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Location = new System.Drawing.Point(116, 136);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(31, 13);
            this.lblFees.TabIndex = 7;
            this.lblFees.Text = "[???]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Fees";
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Location = new System.Drawing.Point(116, 101);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(31, 13);
            this.lblIssueDate.TabIndex = 5;
            this.lblIssueDate.Text = "[???]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Issue Date";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Location = new System.Drawing.Point(116, 66);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(31, 13);
            this.lblApplicationDate.TabIndex = 3;
            this.lblApplicationDate.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Application Date";
            // 
            // lblILApplicationId
            // 
            this.lblILApplicationId.AutoSize = true;
            this.lblILApplicationId.Location = new System.Drawing.Point(116, 31);
            this.lblILApplicationId.Name = "lblILApplicationId";
            this.lblILApplicationId.Size = new System.Drawing.Size(31, 13);
            this.lblILApplicationId.TabIndex = 1;
            this.lblILApplicationId.Text = "[???]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "I L Application ID";
            // 
            // btnIssue
            // 
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.Image = global::DVLD_Presentation.Properties.Resources.License_View_32;
            this.btnIssue.Location = new System.Drawing.Point(669, 601);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(75, 35);
            this.btnIssue.TabIndex = 2;
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD_Presentation.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(569, 601);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 35);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lklLicenseInfo
            // 
            this.lklLicenseInfo.AutoSize = true;
            this.lklLicenseInfo.Location = new System.Drawing.Point(21, 612);
            this.lklLicenseInfo.Name = "lklLicenseInfo";
            this.lklLicenseInfo.Size = new System.Drawing.Size(101, 13);
            this.lklLicenseInfo.TabIndex = 4;
            this.lklLicenseInfo.TabStop = true;
            this.lklLicenseInfo.Text = "Show I License Info";
            this.lklLicenseInfo.Click += new System.EventHandler(this.lklLicenseInfo_Click);
            // 
            // lklPersonLicenesHistory
            // 
            this.lklPersonLicenesHistory.AutoSize = true;
            this.lklPersonLicenesHistory.Location = new System.Drawing.Point(150, 612);
            this.lklPersonLicenesHistory.Name = "lklPersonLicenesHistory";
            this.lklPersonLicenesHistory.Size = new System.Drawing.Size(150, 13);
            this.lklPersonLicenesHistory.TabIndex = 5;
            this.lklPersonLicenesHistory.TabStop = true;
            this.lklPersonLicenesHistory.Text = "Show Person Licenses History";
            this.lklPersonLicenesHistory.Click += new System.EventHandler(this.lklPersonLicenesHistory_Click);
            // 
            // frmAddNewInternationalLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 641);
            this.Controls.Add(this.lklPersonLicenesHistory);
            this.Controls.Add(this.lklLicenseInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.gbAppInfo);
            this.Controls.Add(this.ctrlLicenseCardWithFilter1);
            this.Name = "frmAddNewInternationalLicenseApplication";
            this.Text = "frmAddNewInternationalLicenseApplication";
            this.Load += new System.EventHandler(this.frmAddNewInternationalLicenseApplication_Load);
            this.gbAppInfo.ResumeLayout(false);
            this.gbAppInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Licenses.Local_Licenses.ctrlLicenseCardWithFilter ctrlLicenseCardWithFilter1;
        private System.Windows.Forms.GroupBox gbAppInfo;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblExpDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblLocalLicenseID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblILicenseID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblILApplicationId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel lklLicenseInfo;
        private System.Windows.Forms.LinkLabel lklPersonLicenesHistory;
    }
}
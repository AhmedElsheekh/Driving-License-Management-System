namespace DVLD_Presentation.Applications.Detained_Licenses
{
    partial class frmReleaseDetainedLicense
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
            this.ctrlLicenseCardWithFilter1 = new DVLD_Presentation.Licenses.Local_Licenses.ctrlLicenseCardWithFilter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblReleasedBy = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAppID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFineFees = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.lblDetainedBy = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lklLicenseDetails = new System.Windows.Forms.LinkLabel();
            this.lklLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btnRelease = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(285, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Release Detained License";
            // 
            // ctrlLicenseCardWithFilter1
            // 
            this.ctrlLicenseCardWithFilter1.EnableFilter = true;
            this.ctrlLicenseCardWithFilter1.Location = new System.Drawing.Point(71, 55);
            this.ctrlLicenseCardWithFilter1.Name = "ctrlLicenseCardWithFilter1";
            this.ctrlLicenseCardWithFilter1.Size = new System.Drawing.Size(666, 412);
            this.ctrlLicenseCardWithFilter1.TabIndex = 2;
            this.ctrlLicenseCardWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlLicenseCardWithFilter1_OnLicenseSelected);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblReleasedBy);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblAppID);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblFineFees);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lblTotalFees);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblAppFees);
            this.groupBox1.Controls.Add(this.lblDetainedBy);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblLicenseID);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblDetainDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblDetainID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(35, 462);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(702, 130);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detain Info";
            // 
            // lblReleasedBy
            // 
            this.lblReleasedBy.AutoSize = true;
            this.lblReleasedBy.Location = new System.Drawing.Point(599, 27);
            this.lblReleasedBy.Name = "lblReleasedBy";
            this.lblReleasedBy.Size = new System.Drawing.Size(31, 13);
            this.lblReleasedBy.TabIndex = 17;
            this.lblReleasedBy.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(507, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Released By";
            // 
            // lblAppID
            // 
            this.lblAppID.AutoSize = true;
            this.lblAppID.Location = new System.Drawing.Point(399, 105);
            this.lblAppID.Name = "lblAppID";
            this.lblAppID.Size = new System.Drawing.Size(31, 13);
            this.lblAppID.TabIndex = 15;
            this.lblAppID.Text = "[???]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(328, 105);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "App ID";
            // 
            // lblFineFees
            // 
            this.lblFineFees.AutoSize = true;
            this.lblFineFees.Location = new System.Drawing.Point(399, 79);
            this.lblFineFees.Name = "lblFineFees";
            this.lblFineFees.Size = new System.Drawing.Size(31, 13);
            this.lblFineFees.TabIndex = 13;
            this.lblFineFees.Text = "[???]";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(328, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Fine Fees";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Location = new System.Drawing.Point(96, 109);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(31, 13);
            this.lblTotalFees.TabIndex = 11;
            this.lblTotalFees.Text = "[???]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Total Fees";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Location = new System.Drawing.Point(96, 79);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(31, 13);
            this.lblAppFees.TabIndex = 9;
            this.lblAppFees.Text = "[???]";
            // 
            // lblDetainedBy
            // 
            this.lblDetainedBy.AutoSize = true;
            this.lblDetainedBy.Location = new System.Drawing.Point(399, 53);
            this.lblDetainedBy.Name = "lblDetainedBy";
            this.lblDetainedBy.Size = new System.Drawing.Size(31, 13);
            this.lblDetainedBy.TabIndex = 8;
            this.lblDetainedBy.Text = "[???]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(328, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Detained By";
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Location = new System.Drawing.Point(399, 27);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(31, 13);
            this.lblLicenseID.TabIndex = 6;
            this.lblLicenseID.Text = "[???]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(328, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "License ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "App Fees";
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.Location = new System.Drawing.Point(96, 53);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(31, 13);
            this.lblDetainDate.TabIndex = 3;
            this.lblDetainDate.Text = "[???]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Detain Date";
            // 
            // lblDetainID
            // 
            this.lblDetainID.AutoSize = true;
            this.lblDetainID.Location = new System.Drawing.Point(96, 27);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(31, 13);
            this.lblDetainID.TabIndex = 1;
            this.lblDetainID.Text = "[???]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Detain ID";
            // 
            // lklLicenseDetails
            // 
            this.lklLicenseDetails.AutoSize = true;
            this.lklLicenseDetails.Location = new System.Drawing.Point(169, 617);
            this.lklLicenseDetails.Name = "lklLicenseDetails";
            this.lklLicenseDetails.Size = new System.Drawing.Size(85, 13);
            this.lklLicenseDetails.TabIndex = 8;
            this.lklLicenseDetails.TabStop = true;
            this.lklLicenseDetails.Text = "License Detainls";
            // 
            // lklLicensesHistory
            // 
            this.lklLicensesHistory.AutoSize = true;
            this.lklLicensesHistory.Location = new System.Drawing.Point(34, 614);
            this.lklLicensesHistory.Name = "lklLicensesHistory";
            this.lklLicensesHistory.Size = new System.Drawing.Size(114, 13);
            this.lklLicensesHistory.TabIndex = 7;
            this.lklLicensesHistory.TabStop = true;
            this.lklLicensesHistory.Text = "Show Licenses History";
            // 
            // btnRelease
            // 
            this.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelease.Image = global::DVLD_Presentation.Properties.Resources.Release_Detained_License_32;
            this.btnRelease.Location = new System.Drawing.Point(664, 605);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(75, 31);
            this.btnRelease.TabIndex = 6;
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // frmReleaseDetainedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 639);
            this.Controls.Add(this.lklLicenseDetails);
            this.Controls.Add(this.lklLicensesHistory);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlLicenseCardWithFilter1);
            this.Controls.Add(this.label1);
            this.Name = "frmReleaseDetainedLicense";
            this.Text = "frmReleaseDetainedLicense";
            this.Load += new System.EventHandler(this.frmReleaseDetainedLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Licenses.Local_Licenses.ctrlLicenseCardWithFilter ctrlLicenseCardWithFilter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAppID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblFineFees;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label lblDetainedBy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lklLicenseDetails;
        private System.Windows.Forms.LinkLabel lklLicensesHistory;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Label lblReleasedBy;
        private System.Windows.Forms.Label label4;
    }
}
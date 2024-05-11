namespace DVLD_Presentation.Applications.Replace_Licenses
{
    partial class frmReplaceLicense
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbReplacementFor = new System.Windows.Forms.GroupBox();
            this.rbLost = new System.Windows.Forms.RadioButton();
            this.rbDamaged = new System.Windows.Forms.RadioButton();
            this.ctrlLicenseCardWithFilter1 = new DVLD_Presentation.Licenses.Local_Licenses.ctrlLicenseCardWithFilter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblReplacedLicenseID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRApplicationID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIssue = new System.Windows.Forms.Button();
            this.lklLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.lklNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.gbReplacementFor.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(333, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(43, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // gbReplacementFor
            // 
            this.gbReplacementFor.Controls.Add(this.rbLost);
            this.gbReplacementFor.Controls.Add(this.rbDamaged);
            this.gbReplacementFor.Location = new System.Drawing.Point(703, 28);
            this.gbReplacementFor.Name = "gbReplacementFor";
            this.gbReplacementFor.Size = new System.Drawing.Size(200, 100);
            this.gbReplacementFor.TabIndex = 1;
            this.gbReplacementFor.TabStop = false;
            this.gbReplacementFor.Text = "Replacement For";
            // 
            // rbLost
            // 
            this.rbLost.AutoSize = true;
            this.rbLost.Location = new System.Drawing.Point(26, 61);
            this.rbLost.Name = "rbLost";
            this.rbLost.Size = new System.Drawing.Size(85, 17);
            this.rbLost.TabIndex = 1;
            this.rbLost.TabStop = true;
            this.rbLost.Text = "Lost License";
            this.rbLost.UseVisualStyleBackColor = true;
            this.rbLost.CheckedChanged += new System.EventHandler(this.rbLost_CheckedChanged);
            // 
            // rbDamaged
            // 
            this.rbDamaged.AutoSize = true;
            this.rbDamaged.Location = new System.Drawing.Point(26, 29);
            this.rbDamaged.Name = "rbDamaged";
            this.rbDamaged.Size = new System.Drawing.Size(111, 17);
            this.rbDamaged.TabIndex = 0;
            this.rbDamaged.TabStop = true;
            this.rbDamaged.Text = "Damaged License";
            this.rbDamaged.UseVisualStyleBackColor = true;
            this.rbDamaged.CheckedChanged += new System.EventHandler(this.rbDamaged_CheckedChanged);
            // 
            // ctrlLicenseCardWithFilter1
            // 
            this.ctrlLicenseCardWithFilter1.EnableFilter = true;
            this.ctrlLicenseCardWithFilter1.Location = new System.Drawing.Point(12, 47);
            this.ctrlLicenseCardWithFilter1.Name = "ctrlLicenseCardWithFilter1";
            this.ctrlLicenseCardWithFilter1.Size = new System.Drawing.Size(666, 412);
            this.ctrlLicenseCardWithFilter1.TabIndex = 2;
            this.ctrlLicenseCardWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlLicenseCardWithFilter1_OnLicenseSelected);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCreatedBy);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblOldLicenseID);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblReplacedLicenseID);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblAppFees);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblAppDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblRApplicationID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(34, 465);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 123);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Info For License Replacement";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(582, 96);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(31, 13);
            this.lblCreatedBy.TabIndex = 11;
            this.lblCreatedBy.Text = "[???]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(469, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Created By";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Location = new System.Drawing.Point(582, 63);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(31, 13);
            this.lblOldLicenseID.TabIndex = 9;
            this.lblOldLicenseID.Text = "[???]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(469, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Old License ID";
            // 
            // lblReplacedLicenseID
            // 
            this.lblReplacedLicenseID.AutoSize = true;
            this.lblReplacedLicenseID.Location = new System.Drawing.Point(582, 30);
            this.lblReplacedLicenseID.Name = "lblReplacedLicenseID";
            this.lblReplacedLicenseID.Size = new System.Drawing.Size(31, 13);
            this.lblReplacedLicenseID.TabIndex = 7;
            this.lblReplacedLicenseID.Text = "[???]";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(469, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Replaced License ID";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Location = new System.Drawing.Point(126, 96);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(31, 13);
            this.lblAppFees.TabIndex = 5;
            this.lblAppFees.Text = "[???]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Application Fees";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Location = new System.Drawing.Point(126, 63);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(31, 13);
            this.lblAppDate.TabIndex = 3;
            this.lblAppDate.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Application Date";
            // 
            // lblRApplicationID
            // 
            this.lblRApplicationID.AutoSize = true;
            this.lblRApplicationID.Location = new System.Drawing.Point(126, 30);
            this.lblRApplicationID.Name = "lblRApplicationID";
            this.lblRApplicationID.Size = new System.Drawing.Size(31, 13);
            this.lblRApplicationID.TabIndex = 1;
            this.lblRApplicationID.Text = "[???]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "R Application ID";
            // 
            // btnIssue
            // 
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.Image = global::DVLD_Presentation.Properties.Resources.License_View_32;
            this.btnIssue.Location = new System.Drawing.Point(714, 594);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(75, 35);
            this.btnIssue.TabIndex = 4;
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // lklLicenseHistory
            // 
            this.lklLicenseHistory.AutoSize = true;
            this.lklLicenseHistory.Location = new System.Drawing.Point(31, 605);
            this.lklLicenseHistory.Name = "lklLicenseHistory";
            this.lklLicenseHistory.Size = new System.Drawing.Size(114, 13);
            this.lklLicenseHistory.TabIndex = 5;
            this.lklLicenseHistory.TabStop = true;
            this.lklLicenseHistory.Text = "Show Licenses History";
            this.lklLicenseHistory.Click += new System.EventHandler(this.lklLicenseHistory_Click);
            // 
            // lklNewLicenseInfo
            // 
            this.lklNewLicenseInfo.AutoSize = true;
            this.lklNewLicenseInfo.Location = new System.Drawing.Point(175, 605);
            this.lklNewLicenseInfo.Name = "lklNewLicenseInfo";
            this.lklNewLicenseInfo.Size = new System.Drawing.Size(120, 13);
            this.lklNewLicenseInfo.TabIndex = 6;
            this.lklNewLicenseInfo.TabStop = true;
            this.lklNewLicenseInfo.Text = "Show New License Info";
            this.lklNewLicenseInfo.Click += new System.EventHandler(this.lklNewLicenseInfo_Click);
            // 
            // frmReplaceLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 641);
            this.Controls.Add(this.lklNewLicenseInfo);
            this.Controls.Add(this.lklLicenseHistory);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlLicenseCardWithFilter1);
            this.Controls.Add(this.gbReplacementFor);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmReplaceLicense";
            this.Text = "frmReplaceLicense";
            this.Load += new System.EventHandler(this.frmReplaceLicense_Load);
            this.gbReplacementFor.ResumeLayout(false);
            this.gbReplacementFor.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbReplacementFor;
        private System.Windows.Forms.RadioButton rbLost;
        private System.Windows.Forms.RadioButton rbDamaged;
        private Licenses.Local_Licenses.ctrlLicenseCardWithFilter ctrlLicenseCardWithFilter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblReplacedLicenseID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRApplicationID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.LinkLabel lklLicenseHistory;
        private System.Windows.Forms.LinkLabel lklNewLicenseInfo;
    }
}
namespace DVLD_Presentation.Applications.Local_Driving_Licenses
{
    partial class ctrlLDLApplicationInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLDLApplicatonID = new System.Windows.Forms.Label();
            this.lblLicenseClass = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPassedTests = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lklLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.ctrlBaseApplicationInfo1 = new DVLD_Presentation.Applications.Controls.ctrlBaseApplicationInfo();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lklLicenseInfo);
            this.groupBox1.Controls.Add(this.lblPassedTests);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblLicenseClass);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblLDLApplicatonID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LDL Application Info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "LDL Application ID";
            // 
            // lblLDLApplicatonID
            // 
            this.lblLDLApplicatonID.AutoSize = true;
            this.lblLDLApplicatonID.Location = new System.Drawing.Point(129, 33);
            this.lblLDLApplicatonID.Name = "lblLDLApplicatonID";
            this.lblLDLApplicatonID.Size = new System.Drawing.Size(37, 13);
            this.lblLDLApplicatonID.TabIndex = 1;
            this.lblLDLApplicatonID.Text = "[????]";
            // 
            // lblLicenseClass
            // 
            this.lblLicenseClass.AutoSize = true;
            this.lblLicenseClass.Location = new System.Drawing.Point(129, 57);
            this.lblLicenseClass.Name = "lblLicenseClass";
            this.lblLicenseClass.Size = new System.Drawing.Size(37, 13);
            this.lblLicenseClass.TabIndex = 3;
            this.lblLicenseClass.Text = "[????]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Applied For License";
            // 
            // lblPassedTests
            // 
            this.lblPassedTests.AutoSize = true;
            this.lblPassedTests.Location = new System.Drawing.Point(463, 33);
            this.lblPassedTests.Name = "lblPassedTests";
            this.lblPassedTests.Size = new System.Drawing.Size(37, 13);
            this.lblPassedTests.TabIndex = 5;
            this.lblPassedTests.Text = "[????]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(370, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Passed Tests";
            // 
            // lklLicenseInfo
            // 
            this.lklLicenseInfo.AutoSize = true;
            this.lklLicenseInfo.Location = new System.Drawing.Point(370, 57);
            this.lklLicenseInfo.Name = "lklLicenseInfo";
            this.lklLicenseInfo.Size = new System.Drawing.Size(95, 13);
            this.lklLicenseInfo.TabIndex = 6;
            this.lklLicenseInfo.TabStop = true;
            this.lklLicenseInfo.Text = "Show License Info";
            this.lklLicenseInfo.Click += new System.EventHandler(this.lklLicenseInfo_Click);
            // 
            // ctrlBaseApplicationInfo1
            // 
            this.ctrlBaseApplicationInfo1.Location = new System.Drawing.Point(15, 119);
            this.ctrlBaseApplicationInfo1.Name = "ctrlBaseApplicationInfo1";
            this.ctrlBaseApplicationInfo1.Size = new System.Drawing.Size(603, 267);
            this.ctrlBaseApplicationInfo1.TabIndex = 1;
            // 
            // ctrlLDLApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlBaseApplicationInfo1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlLDLApplicationInfo";
            this.Size = new System.Drawing.Size(630, 398);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLDLApplicatonID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lklLicenseInfo;
        private System.Windows.Forms.Label lblPassedTests;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLicenseClass;
        private System.Windows.Forms.Label label4;
        private Controls.ctrlBaseApplicationInfo ctrlBaseApplicationInfo1;
    }
}

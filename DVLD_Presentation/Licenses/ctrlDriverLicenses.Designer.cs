namespace DVLD_Presentation.Licenses
{
    partial class ctrlDriverLicenses
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
            this.components = new System.ComponentModel.Container();
            this.gbDriverLicenses = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpLocal = new System.Windows.Forms.TabPage();
            this.dgvLocalLicenses = new System.Windows.Forms.DataGridView();
            this.cmsLocalLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsLocalLicensesCMS = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.tpInternational = new System.Windows.Forms.TabPage();
            this.dgvInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.cmsInternationalLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsInternationalCMS = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumOfLocalRecords = new System.Windows.Forms.Label();
            this.lblNumOfInternationlRec = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbDriverLicenses.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).BeginInit();
            this.cmsLocalLicenses.SuspendLayout();
            this.tpInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).BeginInit();
            this.cmsInternationalLicenses.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDriverLicenses
            // 
            this.gbDriverLicenses.Controls.Add(this.tabControl1);
            this.gbDriverLicenses.Location = new System.Drawing.Point(14, 12);
            this.gbDriverLicenses.Name = "gbDriverLicenses";
            this.gbDriverLicenses.Size = new System.Drawing.Size(574, 266);
            this.gbDriverLicenses.TabIndex = 0;
            this.gbDriverLicenses.TabStop = false;
            this.gbDriverLicenses.Text = "Driver Licenses";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpLocal);
            this.tabControl1.Controls.Add(this.tpInternational);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(562, 241);
            this.tabControl1.TabIndex = 0;
            // 
            // tpLocal
            // 
            this.tpLocal.Controls.Add(this.lblNumOfLocalRecords);
            this.tpLocal.Controls.Add(this.label1);
            this.tpLocal.Controls.Add(this.dgvLocalLicenses);
            this.tpLocal.Controls.Add(this.label2);
            this.tpLocal.Location = new System.Drawing.Point(4, 22);
            this.tpLocal.Name = "tpLocal";
            this.tpLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocal.Size = new System.Drawing.Size(554, 215);
            this.tpLocal.TabIndex = 0;
            this.tpLocal.Text = "Local";
            this.tpLocal.UseVisualStyleBackColor = true;
            // 
            // dgvLocalLicenses
            // 
            this.dgvLocalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenses.ContextMenuStrip = this.cmsLocalLicenses;
            this.dgvLocalLicenses.Location = new System.Drawing.Point(21, 38);
            this.dgvLocalLicenses.Name = "dgvLocalLicenses";
            this.dgvLocalLicenses.Size = new System.Drawing.Size(516, 141);
            this.dgvLocalLicenses.TabIndex = 3;
            // 
            // cmsLocalLicenses
            // 
            this.cmsLocalLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsLocalLicensesCMS});
            this.cmsLocalLicenses.Name = "cmsLocalLicenses";
            this.cmsLocalLicenses.Size = new System.Drawing.Size(142, 26);
            // 
            // showDetailsLocalLicensesCMS
            // 
            this.showDetailsLocalLicensesCMS.Name = "showDetailsLocalLicensesCMS";
            this.showDetailsLocalLicensesCMS.Size = new System.Drawing.Size(141, 22);
            this.showDetailsLocalLicensesCMS.Text = "Show Details";
            this.showDetailsLocalLicensesCMS.Click += new System.EventHandler(this.showDetailsLocalLicensesCMS_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Local Licenses";
            // 
            // tpInternational
            // 
            this.tpInternational.Controls.Add(this.lblNumOfInternationlRec);
            this.tpInternational.Controls.Add(this.label5);
            this.tpInternational.Controls.Add(this.dgvInternationalLicenses);
            this.tpInternational.Controls.Add(this.label3);
            this.tpInternational.Location = new System.Drawing.Point(4, 22);
            this.tpInternational.Name = "tpInternational";
            this.tpInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternational.Size = new System.Drawing.Size(554, 215);
            this.tpInternational.TabIndex = 1;
            this.tpInternational.Text = "International";
            this.tpInternational.UseVisualStyleBackColor = true;
            // 
            // dgvInternationalLicenses
            // 
            this.dgvInternationalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenses.ContextMenuStrip = this.cmsInternationalLicenses;
            this.dgvInternationalLicenses.Location = new System.Drawing.Point(22, 45);
            this.dgvInternationalLicenses.Name = "dgvInternationalLicenses";
            this.dgvInternationalLicenses.Size = new System.Drawing.Size(516, 141);
            this.dgvInternationalLicenses.TabIndex = 4;
            // 
            // cmsInternationalLicenses
            // 
            this.cmsInternationalLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsInternationalCMS});
            this.cmsInternationalLicenses.Name = "cmsInternationalLicenses";
            this.cmsInternationalLicenses.Size = new System.Drawing.Size(142, 26);
            // 
            // showDetailsInternationalCMS
            // 
            this.showDetailsInternationalCMS.Name = "showDetailsInternationalCMS";
            this.showDetailsInternationalCMS.Size = new System.Drawing.Size(141, 22);
            this.showDetailsInternationalCMS.Text = "Show Details";
            this.showDetailsInternationalCMS.Click += new System.EventHandler(this.showDetailsInternationalCMS_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "International Licenses";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number Of Records";
            // 
            // lblNumOfLocalRecords
            // 
            this.lblNumOfLocalRecords.AutoSize = true;
            this.lblNumOfLocalRecords.Location = new System.Drawing.Point(125, 193);
            this.lblNumOfLocalRecords.Name = "lblNumOfLocalRecords";
            this.lblNumOfLocalRecords.Size = new System.Drawing.Size(31, 13);
            this.lblNumOfLocalRecords.TabIndex = 5;
            this.lblNumOfLocalRecords.Text = "????";
            // 
            // lblNumOfInternationlRec
            // 
            this.lblNumOfInternationlRec.AutoSize = true;
            this.lblNumOfInternationlRec.Location = new System.Drawing.Point(126, 199);
            this.lblNumOfInternationlRec.Name = "lblNumOfInternationlRec";
            this.lblNumOfInternationlRec.Size = new System.Drawing.Size(31, 13);
            this.lblNumOfInternationlRec.TabIndex = 7;
            this.lblNumOfInternationlRec.Text = "????";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Number Of Records";
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbDriverLicenses);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(603, 299);
            this.gbDriverLicenses.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpLocal.ResumeLayout(false);
            this.tpLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).EndInit();
            this.cmsLocalLicenses.ResumeLayout(false);
            this.tpInternational.ResumeLayout(false);
            this.tpInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).EndInit();
            this.cmsInternationalLicenses.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDriverLicenses;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpLocal;
        private System.Windows.Forms.DataGridView dgvLocalLicenses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tpInternational;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvInternationalLicenses;
        private System.Windows.Forms.ContextMenuStrip cmsLocalLicenses;
        private System.Windows.Forms.ToolStripMenuItem showDetailsLocalLicensesCMS;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalLicenses;
        private System.Windows.Forms.ToolStripMenuItem showDetailsInternationalCMS;
        private System.Windows.Forms.Label lblNumOfLocalRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumOfInternationlRec;
        private System.Windows.Forms.Label label5;
    }
}

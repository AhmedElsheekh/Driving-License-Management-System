namespace DVLD_Presentation.Licenses
{
    partial class frmShowPersonLicensesHistory
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
            this.ctrlPersonCardWithFilter1 = new DVLD_Presentation.People.ctrlPersonCardWithFilter();
            this.ctrlDriverLicenses1 = new DVLD_Presentation.Licenses.ctrlDriverLicenses();
            this.SuspendLayout();
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.EnableFilter = true;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(34, 13);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(646, 322);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            this.ctrlPersonCardWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlPersonCardWithFilter1_OnPersonSelected);
            // 
            // ctrlDriverLicenses1
            // 
            this.ctrlDriverLicenses1.Location = new System.Drawing.Point(77, 341);
            this.ctrlDriverLicenses1.Name = "ctrlDriverLicenses1";
            this.ctrlDriverLicenses1.Size = new System.Drawing.Size(603, 299);
            this.ctrlDriverLicenses1.TabIndex = 1;
            // 
            // frmShowPersonLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 643);
            this.Controls.Add(this.ctrlDriverLicenses1);
            this.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.Name = "frmShowPersonLicensesHistory";
            this.Text = "Show Person Licenses History";
            this.Load += new System.EventHandler(this.frmShowPersonLicensesHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private People.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private ctrlDriverLicenses ctrlDriverLicenses1;
    }
}
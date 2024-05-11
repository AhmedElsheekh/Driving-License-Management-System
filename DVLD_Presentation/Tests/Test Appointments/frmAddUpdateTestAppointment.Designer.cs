namespace DVLD_Presentation.Tests.Test_Appointments
{
    partial class frmAddUpdateTestAppointment
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
            this.ctrlAddUpdateTestAppointment1 = new DVLD_Presentation.Tests.Test_Appointments.ctrlAddUpdateTestAppointment();
            this.SuspendLayout();
            // 
            // ctrlAddUpdateTestAppointment1
            // 
            this.ctrlAddUpdateTestAppointment1.Location = new System.Drawing.Point(69, 12);
            this.ctrlAddUpdateTestAppointment1.Name = "ctrlAddUpdateTestAppointment1";
            this.ctrlAddUpdateTestAppointment1.Size = new System.Drawing.Size(469, 575);
            this.ctrlAddUpdateTestAppointment1.TabIndex = 0;
            this.ctrlAddUpdateTestAppointment1.TestTypeID = DVLD_Business.clsTestType.enTestType.VisionTest;
            // 
            // frmAddUpdateTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 616);
            this.Controls.Add(this.ctrlAddUpdateTestAppointment1);
            this.Name = "frmAddUpdateTestAppointment";
            this.Text = "frmAddUpdateTestAppointment";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlAddUpdateTestAppointment ctrlAddUpdateTestAppointment1;
    }
}
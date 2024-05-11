namespace DVLD_Presentation.Applications.Local_Driving_Licenses
{
    partial class frmLDLApplicationInfo
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
            this.ctrlLDLApplicationInfo1 = new DVLD_Presentation.Applications.Local_Driving_Licenses.ctrlLDLApplicationInfo();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(188, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local Driving License Application Info";
            // 
            // ctrlLDLApplicationInfo1
            // 
            this.ctrlLDLApplicationInfo1.Location = new System.Drawing.Point(12, 46);
            this.ctrlLDLApplicationInfo1.Name = "ctrlLDLApplicationInfo1";
            this.ctrlLDLApplicationInfo1.Size = new System.Drawing.Size(630, 398);
            this.ctrlLDLApplicationInfo1.TabIndex = 1;
            // 
            // frmLDLApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 432);
            this.Controls.Add(this.ctrlLDLApplicationInfo1);
            this.Controls.Add(this.label1);
            this.Name = "frmLDLApplicationInfo";
            this.Text = "Local Driving License Application Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ctrlLDLApplicationInfo ctrlLDLApplicationInfo1;
    }
}
namespace DVLD_Presentation.Tests.Test_Appointments
{
    partial class frmTestTypeAppointmentsHome
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
            this.components = new System.ComponentModel.Container();
            this.pbTestTypeImage = new System.Windows.Forms.PictureBox();
            this.lblTestTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAllAppointments = new System.Windows.Forms.DataGridView();
            this.cmsAppointments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumOfRecords = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.ctrlLDLApplicationInfo1 = new DVLD_Presentation.Applications.Local_Driving_Licenses.ctrlLDLApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllAppointments)).BeginInit();
            this.cmsAppointments.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbTestTypeImage
            // 
            this.pbTestTypeImage.Location = new System.Drawing.Point(348, 12);
            this.pbTestTypeImage.Name = "pbTestTypeImage";
            this.pbTestTypeImage.Size = new System.Drawing.Size(100, 60);
            this.pbTestTypeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestTypeImage.TabIndex = 0;
            this.pbTestTypeImage.TabStop = false;
            // 
            // lblTestTitle
            // 
            this.lblTestTitle.AutoSize = true;
            this.lblTestTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTestTitle.Location = new System.Drawing.Point(296, 85);
            this.lblTestTitle.Name = "lblTestTitle";
            this.lblTestTitle.Size = new System.Drawing.Size(214, 20);
            this.lblTestTitle.TabIndex = 1;
            this.lblTestTitle.Text = "Vision Test Appointments";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 525);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Appointments";
            // 
            // dgvAllAppointments
            // 
            this.dgvAllAppointments.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllAppointments.ContextMenuStrip = this.cmsAppointments;
            this.dgvAllAppointments.Location = new System.Drawing.Point(12, 563);
            this.dgvAllAppointments.Name = "dgvAllAppointments";
            this.dgvAllAppointments.Size = new System.Drawing.Size(776, 150);
            this.dgvAllAppointments.TabIndex = 4;
            // 
            // cmsAppointments
            // 
            this.cmsAppointments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.cmsAppointments.Name = "cmsAppointments";
            this.cmsAppointments.Size = new System.Drawing.Size(181, 70);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 727);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Number Of Records: ";
            // 
            // lblNumOfRecords
            // 
            this.lblNumOfRecords.AutoSize = true;
            this.lblNumOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfRecords.Location = new System.Drawing.Point(131, 727);
            this.lblNumOfRecords.Name = "lblNumOfRecords";
            this.lblNumOfRecords.Size = new System.Drawing.Size(35, 13);
            this.lblNumOfRecords.TabIndex = 6;
            this.lblNumOfRecords.Text = "????";
            // 
            // btnAddNew
            // 
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Image = global::DVLD_Presentation.Properties.Resources.NewApp32;
            this.btnAddNew.Location = new System.Drawing.Point(734, 509);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(54, 39);
            this.btnAddNew.TabIndex = 7;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // ctrlLDLApplicationInfo1
            // 
            this.ctrlLDLApplicationInfo1.Location = new System.Drawing.Point(64, 108);
            this.ctrlLDLApplicationInfo1.Name = "ctrlLDLApplicationInfo1";
            this.ctrlLDLApplicationInfo1.Size = new System.Drawing.Size(630, 398);
            this.ctrlLDLApplicationInfo1.TabIndex = 2;
            // 
            // frmTestTypeAppointmentsHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 749);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.lblNumOfRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvAllAppointments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlLDLApplicationInfo1);
            this.Controls.Add(this.lblTestTitle);
            this.Controls.Add(this.pbTestTypeImage);
            this.Name = "frmTestTypeAppointmentsHome";
            this.Text = "frmTestTypeAppointmentsHome";
            this.Load += new System.EventHandler(this.frmTestTypeAppointmentsHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllAppointments)).EndInit();
            this.cmsAppointments.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTestTypeImage;
        private System.Windows.Forms.Label lblTestTitle;
        private Applications.Local_Driving_Licenses.ctrlLDLApplicationInfo ctrlLDLApplicationInfo1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAllAppointments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNumOfRecords;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.ContextMenuStrip cmsAppointments;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}
namespace DVLD_Presentation.Tests.Test_Types
{
    partial class frmTestTypesHome
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAllTestTypes = new System.Windows.Forms.DataGridView();
            this.cmsTestTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumOfRecords = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllTestTypes)).BeginInit();
            this.cmsTestTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(326, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Test Types";
            // 
            // dgvAllTestTypes
            // 
            this.dgvAllTestTypes.AllowUserToAddRows = false;
            this.dgvAllTestTypes.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllTestTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllTestTypes.ContextMenuStrip = this.cmsTestTypes;
            this.dgvAllTestTypes.Location = new System.Drawing.Point(12, 129);
            this.dgvAllTestTypes.Name = "dgvAllTestTypes";
            this.dgvAllTestTypes.Size = new System.Drawing.Size(776, 150);
            this.dgvAllTestTypes.TabIndex = 1;
            // 
            // cmsTestTypes
            // 
            this.cmsTestTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.cmsTestTypes.Name = "cmsTestTypes";
            this.cmsTestTypes.Size = new System.Drawing.Size(181, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number Of Records";
            // 
            // lblNumOfRecords
            // 
            this.lblNumOfRecords.AutoSize = true;
            this.lblNumOfRecords.Location = new System.Drawing.Point(122, 306);
            this.lblNumOfRecords.Name = "lblNumOfRecords";
            this.lblNumOfRecords.Size = new System.Drawing.Size(25, 13);
            this.lblNumOfRecords.TabIndex = 3;
            this.lblNumOfRecords.Text = "???";
            // 
            // frmTestTypesHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 346);
            this.Controls.Add(this.lblNumOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvAllTestTypes);
            this.Controls.Add(this.label1);
            this.Name = "frmTestTypesHome";
            this.Text = "Test Types ";
            this.Load += new System.EventHandler(this.frmTestTypesHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllTestTypes)).EndInit();
            this.cmsTestTypes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAllTestTypes;
        private System.Windows.Forms.ContextMenuStrip cmsTestTypes;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumOfRecords;
    }
}
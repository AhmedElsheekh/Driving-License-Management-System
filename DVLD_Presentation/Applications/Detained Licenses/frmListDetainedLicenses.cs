using DVLD_Business;
using DVLD_Presentation.Licenses;
using DVLD_Presentation.Licenses.Local_Licenses;
using DVLD_Presentation.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.Detained_Licenses
{
    public partial class frmListDetainedLicenses : Form
    {
        DataTable _AllDetainedLicenses;
        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            _AllDetainedLicenses = clsDetainedLicense.GetAllDetainedLicenses();
            dgvDetainedLicenses.DataSource = _AllDetainedLicenses;
            lblNumOfRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();

            if(dgvDetainedLicenses.Rows.Count > 0)
            {
                dgvDetainedLicenses.Columns[0].HeaderText = "Detain ID";
                dgvDetainedLicenses.Columns[0].Width = 100;

                dgvDetainedLicenses.Columns[1].HeaderText = "License ID";
                dgvDetainedLicenses.Columns[1].Width = 100;

                dgvDetainedLicenses.Columns[2].HeaderText = "Detain Date";
                dgvDetainedLicenses.Columns[2].Width = 150;

                dgvDetainedLicenses.Columns[3].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[3].Width = 100;

                dgvDetainedLicenses.Columns[4].HeaderText = "Detained By User ID";
                dgvDetainedLicenses.Columns[4].Width = 100;

                dgvDetainedLicenses.Columns[5].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[5].Width = 150;

            }

            cbFilterBy.SelectedIndex = 0;
            cbIsReleased.SelectedIndex = 0;
            
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.Text == "None")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = false;
            }
            else
            {
                cbIsReleased.Visible = cbFilterBy.Text == "Is Released";
                txtFilterValue.Visible = !cbIsReleased.Visible;

                if(txtFilterValue.Visible)
                {
                    txtFilterValue.Clear();
                    txtFilterValue.Focus();
                }
            }

        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";
            string FilterValue = "";

            switch(cbIsReleased.Text)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "")
                _AllDetainedLicenses.DefaultView.RowFilter = "";
            else
                _AllDetainedLicenses.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, FilterValue);

            lblNumOfRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            string FilterValue = txtFilterValue.Text;

            switch(cbFilterBy.Text)
            {
                case "None":
                    break;

                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;

                case "License ID":
                    FilterColumn = "LicenseID";
                    break;

                case "Detained By User ID":
                    FilterColumn = "CreatedByUserID";
                    break;
            }

            if(cbFilterBy.Text == "None" || txtFilterValue.Text == "")
            {
                _AllDetainedLicenses.DefaultView.RowFilter = "";
                lblNumOfRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
                return;
            }

            
            _AllDetainedLicenses.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, FilterValue);
           
            lblNumOfRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsLicense.GetLicenseByID((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value).Driver.PersonID;
            frmPersonInfo frm = new frmPersonInfo(PersonID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void showPersonLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsLicense.GetLicenseByID((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value).Driver.PersonID;
            frmShowPersonLicensesHistory frm = new frmShowPersonLicensesHistory(PersonID);
            frm.ShowDialog();
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void cmsDetainedLicenses_Opening(object sender, CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled = !(bool)dgvDetainedLicenses.CurrentRow.Cells[5].Value;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            _LoadData();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
            _LoadData();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            _LoadData();
        }
    }
}

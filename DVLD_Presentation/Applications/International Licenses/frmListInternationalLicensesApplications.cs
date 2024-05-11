using DVLD_Business;
using DVLD_Presentation.Licenses;
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

namespace DVLD_Presentation.Applications.International_Licenses
{
    public partial class frmListInternationalLicensesApplications : Form
    {
        DataTable _AllInternationalLicenses;
        public frmListInternationalLicensesApplications()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            _AllInternationalLicenses = clsInternationalLicense.GetAllInternationalLicenses();
            dgvAllApplications.DataSource = _AllInternationalLicenses;
            lblNumOfRecords.Text = dgvAllApplications.RowCount.ToString();
            cbFilterBy.SelectedIndex = 0;

            if(dgvAllApplications.RowCount > 0)
            {
                dgvAllApplications.Columns[0].HeaderText = "Int. License ID";
                dgvAllApplications.Columns[0].Width = 100;

                dgvAllApplications.Columns[1].HeaderText = "Application ID";
                dgvAllApplications.Columns[1].Width = 100;

                dgvAllApplications.Columns[2].HeaderText = "Driver ID";
                dgvAllApplications.Columns[2].Width = 100;

                dgvAllApplications.Columns[3].HeaderText = "Local License ID";
                dgvAllApplications.Columns[3].Width = 100;

                dgvAllApplications.Columns[4].HeaderText = "Issue Date";
                dgvAllApplications.Columns[4].Width = 200;

                dgvAllApplications.Columns[5].HeaderText = "Expiration Date";
                dgvAllApplications.Columns[5].Width = 200;

                dgvAllApplications.Columns[6].HeaderText = "Is Active";
                dgvAllApplications.Columns[6].Width = 100;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbIsActive.Visible = cbFilterBy.Text == "Is Active";
            txtFilterValue.Visible = !cbIsActive.Visible;

            if(cbFilterBy.Text == "None")
            {
                cbIsActive.Visible = false;
                txtFilterValue.Visible = false;
            }
            else
            {
                if(cbFilterBy.Text != "Is Active")
                {
                    txtFilterValue.Focus();
                    txtFilterValue.Clear();
                }
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsActive.Text == "All")
                _AllInternationalLicenses.DefaultView.RowFilter = "";
            else if (cbIsActive.Text == "Yes")
                _AllInternationalLicenses.DefaultView.RowFilter = string.Format("{0} = {1}", "IsActive", "1");
            else
                _AllInternationalLicenses.DefaultView.RowFilter = string.Format("{0} = {1}", "IsActive", "0");

            lblNumOfRecords.Text = dgvAllApplications.RowCount.ToString();
        }

        private void frmListInternationalLicensesApplications_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsDriver.GetDriverByID((int)dgvAllApplications.CurrentRow.Cells[2].Value).PersonID;
            frmPersonInfo frm = new frmPersonInfo(PersonID);
            frm.ShowDialog();
        }

        private void showPersonLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsDriver.GetDriverByID((int)dgvAllApplications.CurrentRow.Cells[2].Value).PersonID;
            frmShowPersonLicensesHistory frm = new frmShowPersonLicensesHistory(PersonID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dgvAllApplications.CurrentRow.Cells[0].Value;
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(InternationalLicenseID);
            frm.ShowDialog();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicenseApplication frm = new frmAddNewInternationalLicenseApplication();
            frm.ShowDialog();
            _LoadData();
        }
    }
}

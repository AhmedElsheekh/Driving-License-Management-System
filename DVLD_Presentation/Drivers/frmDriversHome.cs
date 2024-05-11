using DVLD_Business;
using DVLD_Presentation.Applications.International_Licenses;
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

namespace DVLD_Presentation.Drivers
{
    public partial class frmDriversHome : Form
    {
        DataTable _AllDrivers;
        public frmDriversHome()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            _AllDrivers = clsDriver.GetAllDrivers();
            dgvAllDrivers.DataSource = _AllDrivers;
            lblNumOfRecords.Text = dgvAllDrivers.RowCount.ToString();
            cbFilterBy.SelectedIndex = 0;

            if(dgvAllDrivers.RowCount > 0)
            {
                dgvAllDrivers.Columns[0].HeaderText = "Driver ID";
                dgvAllDrivers.Columns[0].Width = 100;

                dgvAllDrivers.Columns[1].HeaderText = "Person ID";
                dgvAllDrivers.Columns[1].Width = 100;

                dgvAllDrivers.Columns[2].HeaderText = "National No";
                dgvAllDrivers.Columns[2].Width = 100;

                dgvAllDrivers.Columns[3].HeaderText = "Full Name";
                dgvAllDrivers.Columns[3].Width = 300;

                dgvAllDrivers.Columns[4].HeaderText = "Date";
                dgvAllDrivers.Columns[4].Width = 200;

                dgvAllDrivers.Columns[5].HeaderText = "Active Licenses";
                dgvAllDrivers.Columns[5].Width = 100;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = cbFilterBy.Text != "None";

            txtFilterValue.Clear();
            txtFilterValue.Focus();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterValue = "";

            switch(cbFilterBy.Text)
            {
                case "None":
                    FilterValue = "None";
                    break;

                case "Driver ID":
                    FilterValue = "DriverID";
                    break;

                case "Person ID":
                    FilterValue = "PersonID";
                    break;

                case "National No":
                    FilterValue = "NationalNo";
                    break;

                case "Full Name":
                    FilterValue = "FullName";
                    break;

                case "Date":
                    FilterValue = "CreatedDate";
                    break;

                case "Active Licenses":
                    FilterValue = "ActiveLicenses";
                    break;
            }

            if(txtFilterValue.Text.Trim() == "" || FilterValue == "None")
            {
                _AllDrivers.DefaultView.RowFilter = "";
                lblNumOfRecords.Text = dgvAllDrivers.Rows.Count.ToString();
                return;
            }

            if(FilterValue == "DriverID" || FilterValue == "PersonID" || FilterValue == "ActiveLicenses")
            {
                _AllDrivers.DefaultView.RowFilter = string.Format("{0} = {1}", FilterValue, txtFilterValue.Text.Trim());
            }
            else
            {
                _AllDrivers.DefaultView.RowFilter = string.Format("{0} like '{1}%'", FilterValue, txtFilterValue.Text.Trim());
            }

            lblNumOfRecords.Text = dgvAllDrivers.RowCount.ToString();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "Active Licenses")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frmDriversHome_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvAllDrivers.CurrentRow.Cells[1].Value;
            frmPersonInfo frm = new frmPersonInfo(PersonID);
            frm.ShowDialog();
            _LoadData();
        }

        private void issueInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvAllDrivers.CurrentRow.Cells[0].Value;
            clsDriver Driver = clsDriver.GetDriverByID(DriverID);
            int LicenseID = clsLicense.GetActiveLicenseByPersonID(Driver.PersonID, 3);

            if(LicenseID == -1)
            {
                MessageBox.Show("This Person Does Not Have An Active License Of Class 3", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddNewInternationalLicenseApplication frm = new frmAddNewInternationalLicenseApplication(LicenseID);
            frm.ShowDialog();
        }

        private void showPersonLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int PersonID = (int)dgvAllDrivers.CurrentRow.Cells[1].Value;

            frmShowPersonLicensesHistory frm = new frmShowPersonLicensesHistory();
            frm.ShowDialog();
            _LoadData();
        }
    }
}

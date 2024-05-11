using DVLD_Business;
using DVLD_Presentation.Licenses;
using DVLD_Presentation.Licenses.Local_Licenses;
using DVLD_Presentation.Tests.Test_Appointments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications.Local_Driving_Licenses
{
    public partial class frmLDLApplicationsHome : Form
    {
        DataTable _AllLDLApplications;
        public frmLDLApplicationsHome()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            _AllLDLApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvAllApplications.DataSource = _AllLDLApplications;

            if(dgvAllApplications.Rows.Count > 0)
            {
                dgvAllApplications.Columns[0].HeaderText = "LDL Application ID";

                dgvAllApplications.Columns[1].HeaderText = "Driving Class";
                dgvAllApplications.Columns[1].Width = 220;

                dgvAllApplications.Columns[2].HeaderText = "National No";

                dgvAllApplications.Columns[3].HeaderText = "Full Name";
                dgvAllApplications.Columns[3].Width = 250;

                dgvAllApplications.Columns[4].HeaderText = "Application Date";
                dgvAllApplications.Columns[4].Width = 200;

                dgvAllApplications.Columns[5].HeaderText = "Passed Tests";

            }

            lblNumOfRecords.Text = dgvAllApplications.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            txtFilterValue.Clear();
            txtFilterValue.Focus();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterValue = "";

            switch(cbFilterBy.Text)
            {
                case "LDL Application ID":
                    FilterValue = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No":
                    FilterValue = "NationalNo";
                    break;

                case "Full Name":
                    FilterValue = "FullName";
                    break;

                case "Status":
                    FilterValue = "Status";
                    break;

                default:
                    FilterValue = "None";
                    break;
            }

            if(cbFilterBy.Text == "None" || txtFilterValue.Text.Trim() == "")
            {
                _AllLDLApplications.DefaultView.RowFilter = "";
                lblNumOfRecords.Text = dgvAllApplications.Rows.Count.ToString();
                return;
            }

            if(cbFilterBy.Text == "LDL Application ID")
            {
                _AllLDLApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterValue, txtFilterValue.Text.Trim());
            }
            else
            {
                _AllLDLApplications.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterValue, txtFilterValue.Text.Trim());
            }

            lblNumOfRecords.Text = dgvAllApplications.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "LDL Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frmLDLApplicationsHome_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication();
            frm.ShowDialog();
            _LoadData();
        }

        private void applicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLDLApplicationInfo frm = new frmLDLApplicationInfo((int)dgvAllApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadData();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication(
                (int)dgvAllApplications.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
            _LoadData();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Delete This Applications?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LDLApplicationID = (int)dgvAllApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LDLApplication = clsLocalDrivingLicenseApplication.GetLDLApplicationByID(
                LDLApplicationID);

            if(LDLApplication == null)
            {
                MessageBox.Show("No Application Exists with this ID");
                return;
            }

            if(LDLApplication.Delete())
            {
                MessageBox.Show("Application is deleted successfully");
                _LoadData();
            }
            else
            {
                MessageBox.Show("Failed to delete because application is related to other data");
            } 
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Cancel This Applications?", "Confirmation",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LDLApplicationID = (int)dgvAllApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LDLApplication = clsLocalDrivingLicenseApplication.GetLDLApplicationByID(
                LDLApplicationID);

            if (LDLApplication == null)
            {
                MessageBox.Show("No Application Exists with this ID");
                return;
            }

            if (LDLApplication.Cancel())
            {
                MessageBox.Show("Application is cancelled successfully");
                _LoadData();
            }
            else
            {
                MessageBox.Show("Failed to cancel because application is related to other data");
            }
        }

        private void cmsLDLApplications_Opening(object sender, CancelEventArgs e)
        {
            int LDLApplicationID = (int)dgvAllApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LDLApplication = clsLocalDrivingLicenseApplication.GetLDLApplicationByID(
                LDLApplicationID);

            int TotalPassedTests = (int)dgvAllApplications.CurrentRow.Cells[5].Value;

            bool LicenseExists = clsLicense.IsLicenseExistsByPersonID(LDLApplication.ApplicantPersonID,
                LDLApplication.LicenseClassID);

            editApplicationToolStripMenuItem.Enabled = LDLApplication.ApplicationStatus == clsApplication.enApplicationStatus.New;

            deleteApplicationToolStripMenuItem.Enabled = LDLApplication.ApplicationStatus == clsApplication.enApplicationStatus.New;

            cancelApplicationToolStripMenuItem.Enabled = LDLApplication.ApplicationStatus == clsApplication.enApplicationStatus.New;

            bool PassVisionTest = LDLApplication.DoesPassTestType((int)clsTestType.enTestType.VisionTest);
            bool PassWrittenTest = LDLApplication.DoesPassTestType((int)clsTestType.enTestType.WrittenTest);
            bool PassStreetTest = LDLApplication.DoesPassTestType((int)clsTestType.enTestType.StreetTest);

            scheduleTestToolStripMenuItem.Enabled = (!PassVisionTest || !PassWrittenTest || !PassStreetTest) && (
                LDLApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            if (scheduleTestToolStripMenuItem.Enabled)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = !PassVisionTest;
                scheduleWrittenTestToolStripMenuItem.Enabled = PassVisionTest && !PassWrittenTest;
                scheduleStreetTestToolStripMenuItem.Enabled = PassVisionTest && PassWrittenTest && !PassStreetTest;
            }

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (TotalPassedTests == 3) && (!LicenseExists);
            showLicenseInfoToolStripMenuItem.Enabled = LicenseExists;
            showPersonsLicensesHistoryToolStripMenuItem.Enabled = clsDriver.GetDriverByPersonID(
                LDLApplication.ApplicantPersonID) != null;
        }

        private void _ScheduleTest(clsTestType.enTestType TestType)
        {
            int LDLApplicationID = (int)dgvAllApplications.CurrentRow.Cells[0].Value;

            frmTestTypeAppointmentsHome frm = new frmTestTypeAppointmentsHome(LDLApplicationID, TestType);

            frm.ShowDialog();
            _LoadData();
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.VisionTest);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.WrittenTest);
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.StreetTest);
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvAllApplications.CurrentRow.Cells[0].Value;
            frmIssueDrivingLicenseFirstTime frm = new frmIssueDrivingLicenseFirstTime(LDLApplicationID);
            frm.ShowDialog();
            _LoadData();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvAllApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LDLApplication = clsLocalDrivingLicenseApplication.GetLDLApplicationByID(
                LDLApplicationID);

            if(LDLApplication == null)
            {
                MessageBox.Show("Local Driving License Application Does Not Exist");
                return;
            }

            int LicenseID = LDLApplication.GetActiveLicenseID();

            if(LicenseID == -1)
            {
                MessageBox.Show("No License Exists For This Application");
                return;
            }

            frmLicenseInfo frm = new frmLicenseInfo(LicenseID);
            frm.ShowDialog();
            
        }

        private void showPersonsLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvAllApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LDLApplication = clsLocalDrivingLicenseApplication.GetLDLApplicationByID(
                LDLApplicationID);

            frmShowPersonLicensesHistory frm = new frmShowPersonLicensesHistory(LDLApplication.ApplicantPersonID);
            frm.ShowDialog();
        }
    }
}

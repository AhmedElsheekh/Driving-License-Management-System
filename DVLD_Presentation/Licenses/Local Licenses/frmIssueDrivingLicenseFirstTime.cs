using DVLD_Business;
using DVLD_Presentation.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Licenses.Local_Licenses
{
    public partial class frmIssueDrivingLicenseFirstTime : Form
    {
        int _LDLApplicationID;
        clsLocalDrivingLicenseApplication _LDLApplication;

        public frmIssueDrivingLicenseFirstTime(int LDLApplicationID)
        {
            InitializeComponent();
            _LDLApplicationID = LDLApplicationID;
        }

        private void _LoadData()
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.GetLDLApplicationByID(_LDLApplicationID);

            if(_LDLApplication == null)
            {
                MessageBox.Show("No Local Driving License Application With That ID", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(_LDLApplication.GetNumberOfPassedTests() != 3)
            {
                MessageBox.Show("Did Not Pass All Tests", "Not Allowed", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if(clsLicense.GetActiveLicenseByPersonID(_LDLApplication.ApplicantPersonID,
                _LDLApplication.LicenseClassID) != -1)
            {
                MessageBox.Show("This Person Already Has A License Of This Class", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlLDLApplicationInfo1.LoadLDLApplicationInfoByLDLApplicationID(_LDLApplicationID);
        }



        private void btnIssue_Click(object sender, EventArgs e)
        {
            int CreatedByUserID = clsLogedUser.CurrentUser.UserID;
            int LicenseID = _LDLApplication.IssueLicenseForTheFirstTime(txtNotes.Text.Trim(), CreatedByUserID);

            if(LicenseID != -1)
            {
                MessageBox.Show($"New License Has Been Issued With ID = {LicenseID}", "Successful Process",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed To Issue New License", "Failed Process",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _LoadData();
        }

        private void frmIssueDrivingLicenseFirstTime_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}

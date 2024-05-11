using DVLD_Business;
using DVLD_Presentation.Licenses.Local_Licenses;
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
    public partial class ctrlLDLApplicationInfo : UserControl
    {
        int _LDLApplicationID;
        clsLocalDrivingLicenseApplication _LDLApplication;
        int _LicenseID = -1;

        public int LDLApplicationID
        {
            get { return _LDLApplicationID; }
        }

        public ctrlLDLApplicationInfo()
        {
            InitializeComponent();
        }

        public void ResetDefaultValues()
        {
            _LDLApplicationID = -1;
            _LicenseID = -1;

            lblLDLApplicatonID.Text = "[????]";
            lblLicenseClass.Text = "[????]";
            lblPassedTests.Text = "[????]";
            lklLicenseInfo.Enabled = false;
            ctrlBaseApplicationInfo1.ResetDefaultValues();
            lklLicenseInfo.Enabled = false;
        }

        private void _FillLDLApplicationInfo()
        {
            lblLDLApplicatonID.Text = _LDLApplicationID.ToString();
            lblLicenseClass.Text = _LDLApplication.LicenseClass.ClassName;
            lblPassedTests.Text = _LDLApplication.GetNumberOfPassedTests().ToString() + "/3";
            ctrlBaseApplicationInfo1.LoadApplicationInfo(_LDLApplication.ApplicationID);
            lklLicenseInfo.Enabled = _LicenseID != -1;
        }

        public void LoadLDLApplicationInfoByLDLApplicationID(int LDLApplicationID)
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.GetLDLApplicationByID(LDLApplicationID);

            if(_LDLApplication == null)
            {
                MessageBox.Show("No LDL Application With this ID", "Not Found", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ResetDefaultValues();
                return;
            }

            _LicenseID = clsLicense.GetActiveLicenseByPersonID(_LDLApplication.ApplicantPersonID,
                _LDLApplication.LicenseClassID);
            _LDLApplicationID = LDLApplicationID;
            _FillLDLApplicationInfo();
        }

        public void LoadLDLApplicationInfoByApplicationID(int ApplicationID)
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.GetLDLApplicationByApplicationID(ApplicationID);

            if (_LDLApplication == null)
            {
                MessageBox.Show("No LDL Application With this ID", "Not Found", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ResetDefaultValues();
                return;
            }

            //_LicenseID = _LDLApplication.GetActiveLicenseID();
            lklLicenseInfo.Enabled = _LicenseID != -1;
            _LDLApplicationID = _LDLApplication.LocalDrivingLicenseApplicationID;
            _FillLDLApplicationInfo();
        }

        private void lklLicenseInfo_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }
    }
}

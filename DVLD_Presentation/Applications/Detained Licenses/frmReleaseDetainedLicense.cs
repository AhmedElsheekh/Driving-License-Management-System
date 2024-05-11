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

namespace DVLD_Presentation.Applications.Detained_Licenses
{
    public partial class frmReleaseDetainedLicense : Form
    {
        int _LicenseID = -1;

        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
            ctrlLicenseCardWithFilter1.LoadInfo(_LicenseID);
            ctrlLicenseCardWithFilter1.EnableFilter = false;
        }

        private void _FillApplicationValues()
        {
            lblLicenseID.Text = _LicenseID.ToString();
            lblDetainID.Text = ctrlLicenseCardWithFilter1.SelectedLicense.DetainedInfo.DetainID.ToString();
            lblFineFees.Text = ctrlLicenseCardWithFilter1.SelectedLicense.DetainedInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblFineFees.Text) + Convert.ToSingle(lblAppFees.Text)).ToString();
            lblDetainedBy.Text = ctrlLicenseCardWithFilter1.SelectedLicense.DetainedInfo.CreatedByUser.Username;
        }

        private void ctrlLicenseCardWithFilter1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;

            if (_LicenseID == -1)
            {
                MessageBox.Show("Invalid License ID");
                return;
            }

            if (!ctrlLicenseCardWithFilter1.SelectedLicense.IsDetained)
            {
                MessageBox.Show("Selected License Is Not Already Detained, Choose Another One");
                return;
            }

            if (!ctrlLicenseCardWithFilter1.SelectedLicense.IsActive || ctrlLicenseCardWithFilter1.SelectedLicense.IsLicenseExpired())
            {
                MessageBox.Show("Selected License Is Inactive Or Expired, Choose Another One");
                return;
            }

            _Activate();
            _FillApplicationValues();
     
        }

        private void _Deactivate()
        {
            btnRelease.Enabled = false;
            lklLicenseDetails.Enabled = false;
            lklLicensesHistory.Enabled = false;
        }

        private void _Activate()
        {
            btnRelease.Enabled = true;
            lklLicenseDetails.Enabled = true;
            lklLicensesHistory.Enabled = true;
        }

        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = DateTime.Now.ToString();
            lblReleasedBy.Text = clsLogedUser.CurrentUser.Username;
            lblAppFees.Text = clsApplicationType.GetApplicationTypeByID(5).ApplicationFees.ToString();

            if (ctrlLicenseCardWithFilter1.EnableFilter)
            {
                _Deactivate();
            }
            else
            {
                _Activate();
                _FillApplicationValues();
            }

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Release This License?", "Confirmation", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            bool IsReleased = ctrlLicenseCardWithFilter1.SelectedLicense.ReleaseIfLicenseDetained(clsLogedUser.CurrentUser.UserID);

            if(!IsReleased)
            {
                MessageBox.Show("Failed To Release License");
                return;
            }

            MessageBox.Show("License Has Been Released Successfully");
            btnRelease.Enabled = false;
        }
    }
}

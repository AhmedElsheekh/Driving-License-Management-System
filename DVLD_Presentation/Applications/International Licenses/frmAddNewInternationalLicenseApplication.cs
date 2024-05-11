using DVLD_Business;
using DVLD_Presentation.Global_Classes;
using DVLD_Presentation.Licenses;
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

namespace DVLD_Presentation.Applications.International_Licenses
{
    public partial class frmAddNewInternationalLicenseApplication : Form
    {
        
        int _InternationalLicenseID = -1;
        public frmAddNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        public frmAddNewInternationalLicenseApplication(int LicenseID)
        {
            InitializeComponent();
            ctrlLicenseCardWithFilter1.LoadInfo(LicenseID);
        }

        private void _GetMode()
        {
            if(!ctrlLicenseCardWithFilter1.EnableFilter)
            {

                btnIssue.Enabled = true;
                lklPersonLicenesHistory.Enabled = true;
            }
        }

        private void ctrlLicenseCardWithFilter1_OnLicenseSelected(int obj)
        {
            int LocalLicenseID = obj;

            if(LocalLicenseID == -1)
            {
                btnIssue.Enabled = false;
                lklLicenseInfo.Enabled = false;
                lklPersonLicenesHistory.Enabled = false;
                return;
            }

            btnIssue.Enabled = true;
            lklPersonLicenesHistory.Enabled = true;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Issue New International License?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if(ctrlLicenseCardWithFilter1.SelectedLicense.LicenseClassID != 3)
            {
                MessageBox.Show("Selected Local License Must Be Of Class 3 To Issue International License",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int InternationalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseByDriverID(
                ctrlLicenseCardWithFilter1.SelectedLicense.DriverID);

            if(InternationalLicenseID != -1)
            {
                MessageBox.Show($"This Person Already Has An Active International License With ID = {InternationalLicenseID}",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsInternationalLicense InternationalLicense = new clsInternationalLicense();

            InternationalLicense.DriverID = ctrlLicenseCardWithFilter1.SelectedLicense.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ctrlLicenseCardWithFilter1.LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            InternationalLicense.IsActive = true;
            InternationalLicense.IntCreatedByUserID = clsLogedUser.CurrentUser.UserID;

            InternationalLicense.ApplicantPersonID = ctrlLicenseCardWithFilter1.SelectedLicense.Driver.PersonID;
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.ApplicationTypeID = 6;
            InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsApplicationType.GetApplicationTypeByID(6).ApplicationFees;
            InternationalLicense.CreatedByUserID = clsLogedUser.CurrentUser.UserID;

            if(!InternationalLicense.Save())
            {
                MessageBox.Show("Failed To Issue New International License", "Failed Process",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            lklLicenseInfo.Enabled = true;

            MessageBox.Show($"New International License Has Been Issued Successfully With ID = {_InternationalLicenseID}", "Successful Process",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblILApplicationId.Text = InternationalLicense.ApplicationID.ToString();
            lblApplicationDate.Text = InternationalLicense.ApplicationDate.ToShortDateString();
            lblIssueDate.Text = InternationalLicense.IssueDate.ToShortDateString();
            lblFees.Text = InternationalLicense.PaidFees.ToString();
            lblILicenseID.Text = _InternationalLicenseID.ToString();
            lblLocalLicenseID.Text = ctrlLicenseCardWithFilter1.LicenseID.ToString();
            lblExpDate.Text = InternationalLicense.ExpirationDate.ToShortDateString();
            lblCreatedBy.Text = clsLogedUser.CurrentUser.Username;
        }

        private void frmAddNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            btnIssue.Enabled = false;
            lklLicenseInfo.Enabled = false;
            lklPersonLicenesHistory.Enabled = false;

            _GetMode();
        }

        private void lklLicenseInfo_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }

        private void lklPersonLicenesHistory_Click(object sender, EventArgs e)
        {
            frmShowPersonLicensesHistory frm = new frmShowPersonLicensesHistory(ctrlLicenseCardWithFilter1.SelectedLicense.Driver.PersonID);
            frm.ShowDialog();
        }
    }
}

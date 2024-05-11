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

namespace DVLD_Presentation.Applications.Renew_Local_Licenses
{
    public partial class frmRenewLocalLicenseApplication : Form
    {
        int _NewLicenseID = -1;
        public frmRenewLocalLicenseApplication()
        {
            InitializeComponent();
        }

        private void ctrlLicenseCardWithFilter1_OnLicenseSelected(int obj)
        {
            int LicenseID = obj;

            if(LicenseID == -1)
            {
                MessageBox.Show("Invalid License ID", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!ctrlLicenseCardWithFilter1.SelectedLicense.IsLicenseExpired())
            {
                MessageBox.Show($"Selected License Is Not Expired, It Is Valid To {ctrlLicenseCardWithFilter1.SelectedLicense.ExpirationDate}",
                    "License Is Not Expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lklPersonLicensesHistory.Enabled = true;
                return;
            }

            if(!ctrlLicenseCardWithFilter1.SelectedLicense.IsActive)
            {
                MessageBox.Show("Selected License Is Not Active, Choose An Active One",
                    "License Is Not Active", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lklPersonLicensesHistory.Enabled = true;
                return;
            }

            btnRenew.Enabled = true;
            lklPersonLicensesHistory.Enabled = true;

            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblAppFees.Text = clsApplicationType.GetApplicationTypeByID(2).ApplicationFees.ToString();
            lblLicenseFees.Text = clsLicenseClass.GetLicenseClassByID(ctrlLicenseCardWithFilter1.SelectedLicense.LicenseClassID).ClassFees.ToString();
            lblOldLicenseID.Text = ctrlLicenseCardWithFilter1.SelectedLicense.LicenseID.ToString();
            lblCreatedBy.Text = clsLogedUser.CurrentUser.Username;
            lblTotalFees.Text = (Convert.ToSingle(lblAppFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();

        }

        private void frmRenewLocalLicenseApplication_Load(object sender, EventArgs e)
        {
            btnRenew.Enabled = false;
            lklNewLicenseInfo.Enabled = false;
            lklPersonLicensesHistory.Enabled = false;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Renew The Selected License?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLicense NewLicense = ctrlLicenseCardWithFilter1.SelectedLicense.Renew(clsLogedUser.CurrentUser.UserID,
                txtNotes.Text.Trim());

            if(NewLicense == null)
            {
                MessageBox.Show("Failed To Renew License", "Failed Process", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            _NewLicenseID = NewLicense.LicenseID;
            lklNewLicenseInfo.Enabled = true;

            lblRLApplicationID.Text = NewLicense.ApplicationID.ToString();
            lblRenewedLicenseID.Text = _NewLicenseID.ToString();
            lblExpDate.Text = NewLicense.ExpirationDate.ToString();

        }

        private void lklNewLicenseInfo_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }

        private void lklPersonLicensesHistory_Click(object sender, EventArgs e)
        {
            frmShowPersonLicensesHistory frm = new frmShowPersonLicensesHistory(ctrlLicenseCardWithFilter1.SelectedLicense.Driver.PersonID);
            frm.ShowDialog();
        }
    }
}

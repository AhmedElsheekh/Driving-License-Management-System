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

namespace DVLD_Presentation.Applications.Replace_Licenses
{
    public partial class frmReplaceLicense : Form
    {
        int _NewLicenseID = -1;
        public frmReplaceLicense()
        {
            InitializeComponent();
        }

        private int _GetApplicationTypeID()
        {
            if (rbDamaged.Checked)
                return 4;
            else
                return 3;
        }

        private clsLicense.enIssueReason _GetIssueReason()
        {
            if (rbDamaged.Checked)
                return clsLicense.enIssueReason.DamagedReplacement;
            else
                return clsLicense.enIssueReason.LostReplacement;
        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            if(rbDamaged.Checked)
            {
                lblTitle.Text = "Replacement For Damaged License";
                this.Text = lblTitle.Text;
                lblAppFees.Text = clsApplicationType.GetApplicationTypeByID(_GetApplicationTypeID()).ApplicationFees.ToString();
            }
        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLost.Checked)
            {
                lblTitle.Text = "Replacement For Lost License";
                this.Text = lblTitle.Text;
                lblAppFees.Text = clsApplicationType.GetApplicationTypeByID(_GetApplicationTypeID()).ApplicationFees.ToString();
            }
        }

        private void frmReplaceLicense_Load(object sender, EventArgs e)
        {
            gbReplacementFor.Enabled = true;
            rbDamaged.Checked = true;
            btnIssue.Enabled = false;
            lklNewLicenseInfo.Enabled = false;
            lklLicenseHistory.Enabled = false;
        }

        private void ctrlLicenseCardWithFilter1_OnLicenseSelected(int obj)
        {
            int LicenseID = obj;

            lklLicenseHistory.Enabled = LicenseID != -1;

            if(LicenseID == -1)
            {
                MessageBox.Show("Invlid License ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!ctrlLicenseCardWithFilter1.SelectedLicense.IsActive)
            {
                MessageBox.Show("Selected License Is Not Active, Choose An Active One", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ctrlLicenseCardWithFilter1.SelectedLicense.IsLicenseExpired())
            {
                MessageBox.Show("Selected License Is Expired, Choose A Valid One", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblOldLicenseID.Text = LicenseID.ToString();
            lblCreatedBy.Text = clsLogedUser.CurrentUser.Username;
            btnIssue.Enabled = true;

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Issue Replacement?", "Confirmation", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLicense NewLicense = ctrlLicenseCardWithFilter1.SelectedLicense.Replace(clsLogedUser.CurrentUser.UserID,
                _GetIssueReason());

            if(NewLicense == null)
            {
                MessageBox.Show("Failed To Issue Replacement", "Failed Process", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            _NewLicenseID = NewLicense.LicenseID;

            MessageBox.Show($"License Has Been Replaced Successfully With New License ID = {_NewLicenseID}");

            lblRApplicationID.Text = NewLicense.ApplicationID.ToString();
            lblReplacedLicenseID.Text = _NewLicenseID.ToString();
            lklNewLicenseInfo.Enabled = true;
            btnIssue.Enabled = false;
            
        }

        private void lklLicenseHistory_Click(object sender, EventArgs e)
        {
            frmShowPersonLicensesHistory frm = new frmShowPersonLicensesHistory(ctrlLicenseCardWithFilter1.SelectedLicense.Driver.PersonID);
            frm.ShowDialog();
        }

        private void lklNewLicenseInfo_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }
    }
}

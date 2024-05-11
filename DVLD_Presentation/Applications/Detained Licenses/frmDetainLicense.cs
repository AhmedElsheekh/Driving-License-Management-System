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

namespace DVLD_Presentation.Applications.Detained_Licenses
{
    public partial class frmDetainLicense : Form
    {
        int _DetainID = -1;
        int _LicenseID = -1;
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            btnDetain.Enabled = false;
            txtFineFees.Enabled = false;
            lklLicenseDetails.Enabled = false;
            lklLicensesHistory.Enabled = false;
            lblDetainDate.Text = DateTime.Now.ToString();
            lblCreatedBy.Text = clsLogedUser.CurrentUser.Username;
        }

        private void ctrlLicenseCardWithFilter1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;

            if(_LicenseID == -1)
            {
                MessageBox.Show("Invalid License ID");
                return;
            }

            if(ctrlLicenseCardWithFilter1.SelectedLicense.IsDetained)
            {
                MessageBox.Show("Selected License Is Already Detained, Choose Another One");
                return;
            }

            if(!ctrlLicenseCardWithFilter1.SelectedLicense.IsActive || ctrlLicenseCardWithFilter1.SelectedLicense.IsLicenseExpired())
            {
                MessageBox.Show("Selected License Is Inactive Or Expired, Choose Another One");
                return;
            }

            btnDetain.Enabled = true;
            txtFineFees.Enabled = true;
            lblLicenseID.Text = _LicenseID.ToString();
            lklLicenseDetails.Enabled = true;
            lklLicensesHistory.Enabled = true;
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "This Field Can't Be Blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFineFees, "");
            }

            if(!clsValidation.ValidateNumber(txtFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Invalid Number");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFineFees, "");
            }

        }

        private void btnDetain_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are You Sure You Want To Detain This License?", "Confirmation", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Are Empty");
                return;
            }

            _DetainID = ctrlLicenseCardWithFilter1.SelectedLicense.Detain(Convert.ToDecimal(txtFineFees.Text),
                clsLogedUser.CurrentUser.UserID);

            if(_DetainID == -1)
            {
                MessageBox.Show("Failed To Detain");
                return;
            }

            MessageBox.Show($"License With ID = {_LicenseID} Has Been Detained Successfully");
            lblDetainID.Text = _DetainID.ToString();
            btnDetain.Enabled = false;
        }

        private void lklLicensesHistory_Click(object sender, EventArgs e)
        {
            frmShowPersonLicensesHistory frm = new frmShowPersonLicensesHistory(ctrlLicenseCardWithFilter1.SelectedLicense.Driver.PersonID);
            frm.ShowDialog();
        }

        private void lklLicenseDetails_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }
    }
}

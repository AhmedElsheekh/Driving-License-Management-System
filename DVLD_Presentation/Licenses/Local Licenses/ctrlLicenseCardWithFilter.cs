using DVLD_Business;
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
    public partial class ctrlLicenseCardWithFilter : UserControl
    {
        public event Action<int> OnLicenseSelected;

        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if(handler != null)
            {
                handler(LicenseID);
            }
        }

        int _LicenseID = -1;
        bool _EnableFilter = true;

        public ctrlLicenseCardWithFilter()
        {
            InitializeComponent();
        }

        public int LicenseID
        {
            get
            {
                return ctrlLicenseInfo1.LicenseID;
            }
        }

        public clsLicense SelectedLicense
        {
            get
            {
                return ctrlLicenseInfo1.License;
            }
        }

        public bool EnableFilter
        {
            get { return _EnableFilter; }
            set
            {
                _EnableFilter = value;
                gbFilter.Enabled = _EnableFilter;
            }
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if(e.KeyChar == (char)13)
            {
                btnFindLicense.PerformClick();
            }
        }

        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtLicenseID.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseID, "This Filed Can't Be Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLicenseID, "");
            }
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Are Empty, Check Red Signals");
                return;
            }

            _LicenseID = int.Parse(txtLicenseID.Text);

            ctrlLicenseInfo1.LoadLicenseInfo(_LicenseID);

            if (OnLicenseSelected != null && EnableFilter)
                OnLicenseSelected(ctrlLicenseInfo1.LicenseID);
        }

        public void LoadInfo(int LicenseID)
        {
            txtLicenseID.Text = LicenseID.ToString();
            EnableFilter = false;

            ctrlLicenseInfo1.LoadLicenseInfo(LicenseID);

        }

    }
}

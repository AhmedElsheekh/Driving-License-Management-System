using DVLD_Business;
using DVLD_Presentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Licenses.Local_Licenses
{
    public partial class ctrlLicenseInfo : UserControl
    {
        int _LicenseID = -1;
        clsLicense _License;
        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }

        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicense License
        {
            get { return _License; }
        }

        private void _LoadPersonImage()
        {
            if (_License.Driver.Person.Gender == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = _License.Driver.Person.ImagePath;

            if(!string.IsNullOrEmpty(ImagePath))
            {
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show($"Failed To Load File {ImagePath}");
            }
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            
            _License = clsLicense.GetLicenseByID(LicenseID);

            if(_License == null)
            {
                MessageBox.Show("No License Exists With That ID", "Not Found", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                _ResetDefaultValues();
                _LicenseID = -1;
                return;
            }

            _LicenseID = LicenseID;

            lblClass.Text = _License.LicenseClass.ClassName;
            lblName.Text = _License.Driver.Person.FullName;
            lblLicenseID.Text = _LicenseID.ToString();
            lblNationalNo.Text = _License.Driver.Person.NationalNo;
            lblGender.Text = _License.Driver.Person.Gender == 0 ? "Male" : "Female";
            lblIssueDate.Text = _License.IssueDate.ToShortDateString();
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = _License.Notes;
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _License.Driver.Person.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToShortDateString();
            lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";
        }

        private void _ResetDefaultValues()
        {
            lblClass.Text = "???";
            lblName.Text = "???";
            lblLicenseID.Text = "???";
            lblNationalNo.Text = "???";
            lblGender.Text = "???";
            lblIssueDate.Text = "???";
            lblIssueReason.Text = "???";
            lblNotes.Text = "???";
            lblIsActive.Text = "???";
            lblDateOfBirth.Text = "???";
            lblDriverID.Text = "???";
            lblExpirationDate.Text = "???";
            lblIsDetained.Text = "???";
        }

    }
}

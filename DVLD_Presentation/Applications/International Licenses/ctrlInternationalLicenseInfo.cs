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

namespace DVLD_Presentation.Applications.International_Licenses
{
    public partial class ctrlInternationalLicenseInfo : UserControl
    {
        int _InternationalLicenseID = -1;
        clsInternationalLicense _InternationalLicense;
        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public int InternationalLicense
        {
            get { return _InternationalLicenseID; }
        }

        private void _LoadPersonImage()
        {
            if (_InternationalLicense.Driver.Person.Gender == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = _InternationalLicense.Driver.Person.ImagePath;

            if(ImagePath != "")
            {
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Failed To Load Person Image");
            }
        }

        public void LoadInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID = InternationalLicenseID;
            _InternationalLicense = clsInternationalLicense.GetInternationalLicenseByID(InternationalLicenseID);

            if(_InternationalLicense == null)
            {
                MessageBox.Show("No International License With That ID", "Not Found", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            lblName.Text = _InternationalLicense.Driver.Person.FullName;
            lblIntLicenseID.Text = _InternationalLicenseID.ToString();
            lblLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = _InternationalLicense.Driver.Person.NationalNo;
            lblGender.Text = _InternationalLicense.Driver.Person.Gender == 0 ? "Male" : "Female";
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
            lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            lblIsActive.Text = _InternationalLicense.IsActive ? "Yes" : "No";
            lblBirthDate.Text = _InternationalLicense.Driver.Person.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblExpDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();

            _LoadPersonImage();
        }
    }
}

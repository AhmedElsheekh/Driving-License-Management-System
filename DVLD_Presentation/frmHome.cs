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
using DVLD_Business;
using DVLD_Presentation.Applications.ApplicationType;
using DVLD_Presentation.Applications.Detained_Licenses;
using DVLD_Presentation.Applications.International_Licenses;
using DVLD_Presentation.Applications.Local_Driving_Licenses;
using DVLD_Presentation.Applications.Renew_Local_Licenses;
using DVLD_Presentation.Applications.Replace_Licenses;
using DVLD_Presentation.Drivers;
using DVLD_Presentation.Global_Classes;
using DVLD_Presentation.People;
using DVLD_Presentation.Tests.Test_Types;
using DVLD_Presentation.Users;

namespace DVLD_Presentation
{
    public partial class frmHome : Form
    {
        frmLogin _frmLogin;
        public frmHome(frmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeopleHome frm = new frmPeopleHome();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsersHome frm = new frmUsersHome();
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApplicationTypesHome frm = new frmApplicationTypesHome();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsLogedUser.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsLogedUser.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _frmLogin.Show();
            this.Hide();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestTypesHome frm = new frmTestTypesHome();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLDLApplicationsHome frm = new frmLDLApplicationsHome();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriversHome frm = new frmDriversHome();
            frm.ShowDialog();
        }

        private void internationaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicensesApplications frm = new frmListInternationalLicensesApplications();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicenseApplication frm = new frmAddNewInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void renewLocalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalLicenseApplication frm = new frmRenewLocalLicenseApplication();
            frm.ShowDialog();
        }

        private void replaceDamageOrLostLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLicense frm = new frmReplaceLicense();
            frm.ShowDialog();
        }

        private void allDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frm = new frmListDetainedLicenses();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLDLApplicationsHome frm = new frmLDLApplicationsHome();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }
    }
}

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

namespace DVLD_Presentation.Applications.Local_Driving_Licenses
{
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {
        enum enMode { AddNew = 0, Update = 1}

        enMode _Mode;
        int _LDLApplicationID;
        clsLocalDrivingLicenseApplication _LDLApplication;
        int _SelectedPersonID = -1;

        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateLocalDrivingLicenseApplication(int LDLApplicationID)
        {
            InitializeComponent();
            _LDLApplicationID = LDLApplicationID;
            _Mode = enMode.Update;
        }

        private void _FillLicenseClassesInComboBox()
        {
            DataTable AllLicenseClasses = clsLicenseClass.GetAllLicenseClasses();

            foreach(DataRow Row in AllLicenseClasses.Rows)
            {
                cmbLicenseClasses.Items.Add(Row["ClassName"]);
            }
        }

        private void _ResetDefaultValues()
        {
            _FillLicenseClassesInComboBox();
            _LDLApplication = new clsLocalDrivingLicenseApplication();

            lblLDLApplicationID.Text = "???";
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblPaidFees.Text = clsApplicationType.GetApplicationTypeByID(1).ApplicationFees.ToString();
            cmbLicenseClasses.SelectedIndex = 3;
            lblCreatedByUser.Text = clsLogedUser.CurrentUser.Username;
        }

        private void _FillLDLApplicationInfo()
        {
            _FillLicenseClassesInComboBox();
            _LDLApplication = clsLocalDrivingLicenseApplication.GetLDLApplicationByID(_LDLApplicationID);

            if(_LDLApplication == null)
            {
                MessageBox.Show("No Local Driving License Application with this ID");
                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_LDLApplication.ApplicantPersonID);
            ctrlPersonCardWithFilter1.EnableFilter = false;

            lblLDLApplicationID.Text = _LDLApplicationID.ToString();
            lblApplicationDate.Text = _LDLApplication.ApplicationDate.ToShortDateString();
            lblPaidFees.Text = _LDLApplication.PaidFees.ToString();
            cmbLicenseClasses.SelectedIndex = cmbLicenseClasses.FindString(_LDLApplication.LicenseClass.ClassName);
            lblCreatedByUser.Text = clsUser.GetUserInfoByUserID(_LDLApplication.CreatedByUserID).Username;
        }

        private void _LoadData()
        {
            if(_Mode == enMode.AddNew)
            {
                this.Text = "Add New Local Driving License Application";
                lblTitle.Text = "Add New Local Driving License Application";

                tpApplicationInfo.Enabled = false;
                btnSave.Enabled = false;
                _ResetDefaultValues();
            }
            else
            {
                this.Text = "Update Local Driving License Application";
                lblTitle.Text = "Update Local Driving License Application";

                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
                tcLDLApplication.SelectedIndex = 1;
                _FillLDLApplicationInfo();
            }
        }

        private void frmAddUpdateLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.Update)
            {
                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
                tcLDLApplication.SelectedIndex = 1;
                return;
            }

            if(ctrlPersonCardWithFilter1.PersonID != -1)
            {
                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
                tcLDLApplication.SelectedIndex = 1;
            }
            else
            {
                tpApplicationInfo.Enabled = false;
                btnSave.Enabled = false;

                MessageBox.Show("You must choose a person", "No Person Choosed", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are invalid");
                return;
            }

            int LicenseClassID = clsLicenseClass.GetLicenseClassByName(cmbLicenseClasses.Text).LicenseClassID;

            int ActiveApplicationID = clsLocalDrivingLicenseApplication.GetActiveApplicationIDForLicenseClass(
                ctrlPersonCardWithFilter1.PersonID, 1, LicenseClassID);

            if(ActiveApplicationID != -1)
            {
                MessageBox.Show("This person has already an active application for this license class, can't make another one",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LDLApplication.LicenseClassID = LicenseClassID;
            _LDLApplication.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;
            _LDLApplication.ApplicationDate = DateTime.Now;
            _LDLApplication.ApplicationTypeID = 1;
            _LDLApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LDLApplication.LastStatusDate = DateTime.Now;
            _LDLApplication.PaidFees = clsApplicationType.GetApplicationTypeByID(1).ApplicationFees;
            _LDLApplication.CreatedByUserID = clsLogedUser.CurrentUser.UserID;

            if(_LDLApplication.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Successfull Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblLDLApplicationID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
                _Mode = enMode.Update;
                this.Text = "Update Local Driving License Application";
                lblTitle.Text = "Update Local Driving License Application";
            }
            else
            {
                MessageBox.Show("Failed to save data", "Failed To Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }
    }
}

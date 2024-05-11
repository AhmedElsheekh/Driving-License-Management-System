using DVLD_Business;
using DVLD_Presentation.Global_Classes;
using DVLD_Presentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Tests.Test_Appointments
{
    public partial class ctrlAddUpdateTestAppointment : UserControl
    {
        public ctrlAddUpdateTestAppointment()
        {
            InitializeComponent();
        }

        enum enMode { AddNew = 0, Update = 1}
        enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1}

        enMode _Mode;
        enCreationMode _CreationMode;

        clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        int _TestAppointmentID;
        clsTestAppointment _TestAppointment;
        int _LDLApplicationID;
        clsLocalDrivingLicenseApplication _LDLApplication;
        int _RetakenTestAppointment;

        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }
            set { _TestTypeID = value; }
        }

        private void _LoadTestTypeTitleAndImage()
        {
            switch(_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    pbTestTypeImage.Image = Resources.Vision_512;
                    lblTestTypeTitle.Text = "Vision Test";
                    break;

                case clsTestType.enTestType.WrittenTest:
                    pbTestTypeImage.Image = Resources.Written_Test_512;
                    lblTestTypeTitle.Text = "Written Test";
                    break;

                case clsTestType.enTestType.StreetTest:
                    pbTestTypeImage.Image = Resources.Street_Test_32;
                    lblTestTypeTitle.Text = "Street Test";
                    break;
            }
        }

        private void _HandleCreationMode()
        {
            if (_CreationMode == enCreationMode.FirstTimeSchedule)
            {
                gbRetakeTestInfo.Enabled = false;
                lblRetakeTestAppID.Text = "NA";
                lblRetakeTestFees.Text = "0";
                lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRetakeTestFees.Text)).ToString();
            }
            else
            {
                gbRetakeTestInfo.Enabled = true;
                lblRetakeTestAppID.Text = "0";
                lblRetakeTestFees.Text = clsApplicationType.GetApplicationTypeByID(7).ApplicationFees.ToString();
                lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRetakeTestFees.Text)).ToString();
            }
        }

        private void _AddNewAppointment()
        {
            _TestAppointment = new clsTestAppointment();

            _LoadTestTypeTitleAndImage();

            lblTestStatus.Text = "Add New Appointment For";
            lblLDLApplicationID.Text = _LDLApplicationID.ToString();
            lblDrivingClass.Text = _LDLApplication.LicenseClass.ClassName;
            lblName.Text = _LDLApplication.ApplicantPerson.FullName;
            lblTrials.Text = _LDLApplication.TotalTrialsPerTestType(_TestTypeID).ToString();
            lblFees.Text = clsTestType.GetTypeTypeByID(_TestTypeID).Fees.ToString();
            dtpAppointmentDate.MinDate = DateTime.Now;

            _HandleCreationMode();
        }

        private void _UpdateAppointment()
        {
            _TestAppointment = clsTestAppointment.GetTestAppointmentByID(_TestAppointmentID);

            if(_TestAppointment == null)
            {
                MessageBox.Show("No Appointment Exists With That ID", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            _LoadTestTypeTitleAndImage();

            lblTestStatus.Text = "Update Appointment For";
            lblLDLApplicationID.Text = _LDLApplicationID.ToString();
            lblDrivingClass.Text = _LDLApplication.LicenseClass.ClassName;
            lblName.Text = _LDLApplication.ApplicantPerson.FullName;
            lblTrials.Text = _LDLApplication.TotalTrialsPerTestType(_TestTypeID).ToString();
            lblFees.Text = clsTestType.GetTypeTypeByID(_TestTypeID).Fees.ToString();

            if (DateTime.Compare(_TestAppointment.AppointmentDate, DateTime.Now) < 0)
                dtpAppointmentDate.MinDate = _TestAppointment.AppointmentDate;
            else
                dtpAppointmentDate.MinDate = DateTime.Now;

            dtpAppointmentDate.Value = _TestAppointment.AppointmentDate;

            _HandleCreationMode();
        }

        private bool _HanldeActiveTestAppointment()
        {
            if (_LDLApplication.DoesHaveAnActiveTestAppointment((int)_TestTypeID) && _Mode == enMode.AddNew)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "This Person Already Has An Active Test Appointment, You Can't Schedule Another one";
                btnSave.Enabled = false;
                dtpAppointmentDate.Enabled = false;

                return false;
            }
            else
                lblUserMessage.Visible = false;

            return true;
        }

        private bool _HandleLockedAppointment()
        {
            if (_TestAppointment.IsLocked)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "This Person Already Already Attended This Appointment, Appointment Is Locked";
                btnSave.Enabled = false;
                dtpAppointmentDate.Enabled = false;

                return false;
            }
            else
                lblUserMessage.Visible = false;

            return true;
        }

        private bool _HandleRetakeTestApplication()
        {
            if (_CreationMode == enCreationMode.RetakeTestSchedule && _Mode == enMode.AddNew)
            {
                clsRetakenTest Application = new clsRetakenTest();

                Application.ApplicantPersonID = _LDLApplication.ApplicantPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationTypeID = 7;
                Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = clsApplicationType.GetApplicationTypeByID(7).ApplicationFees;
                Application.CreatedByUserID = clsLogedUser.CurrentUser.UserID;
                Application.TestAppointmentID = _RetakenTestAppointment;

                if (!Application.Save())
                    return false;

                lblRetakeTestAppID.Text = Application.ApplicationID.ToString();

                return true;
            }

            return true;
                
        }

        private bool _HandlePreviousTestType()
        {
            switch(_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    lblUserMessage.Visible = false;
                    return true;

                case clsTestType.enTestType.WrittenTest:
                    if(_LDLApplication.DoesPassTestType((int)clsTestType.enTestType.VisionTest))
                    {
                        return true;
                    }
                    else
                    {
                        lblUserMessage.Visible = true;
                        lblUserMessage.Text = "You Must Pass Vision Test First";
                        btnSave.Enabled = false;
                        dtpAppointmentDate.Enabled = false;

                        return false;
                    }

                case clsTestType.enTestType.StreetTest:
                    if (_LDLApplication.DoesPassTestType((int)clsTestType.enTestType.WrittenTest))
                    {
                        return true;
                    }
                    else
                    {
                        lblUserMessage.Visible = true;
                        lblUserMessage.Text = "You Must Pass Written Test First";
                        btnSave.Enabled = false;
                        dtpAppointmentDate.Enabled = false;

                        return false;
                    }
            }
            return true;
        }

        public void LoadData(int LDLApplicationID, clsTestType.enTestType TestTypeID, int TestAppointmentID = -1,
            int RetakenTestAppointment = -1)
        {
             if (TestAppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _LDLApplicationID = LDLApplicationID;
            _TestAppointmentID = TestAppointmentID;
            _TestTypeID = TestTypeID;
            _RetakenTestAppointment = RetakenTestAppointment;

            _LDLApplication = clsLocalDrivingLicenseApplication.GetLDLApplicationByID(LDLApplicationID);

            if(_LDLApplication == null)
            {
                MessageBox.Show("No Local Driving License Application With That ID", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_LDLApplication.DoesAttendTestAppointment((int)_TestTypeID))
                _CreationMode = enCreationMode.RetakeTestSchedule;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;

            if(_Mode == enMode.AddNew)
            {
                _AddNewAppointment();
            }
            else
            {
                _UpdateAppointment();
            }

            if (!_HanldeActiveTestAppointment())
                return;

            if (_HandleLockedAppointment())
                return;

            if (!_HandlePreviousTestType())
                return;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeTestApplication())
                return;



            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LDLApplicationID = _LDLApplicationID;
            _TestAppointment.AppointmentDate = dtpAppointmentDate.Value;
            _TestAppointment.PaidFees = clsTestType.GetTypeTypeByID(_TestTypeID).Fees;
            _TestAppointment.CreatedByUserID = clsLogedUser.CurrentUser.UserID;
            _TestAppointment.IsLocked = false;

            if(_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully");
            }
            else
            {
                MessageBox.Show("Failed To Save Data");
            }
        }
    }
}

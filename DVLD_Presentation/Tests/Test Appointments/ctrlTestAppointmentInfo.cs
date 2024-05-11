using DVLD_Business;
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
    public partial class ctrlTestAppointmentInfo : UserControl
    {
        int _TestAppointmentID = -1;
        clsTestAppointment _TestAppointment;
        int _LDLApplicationID = -1;
        clsLocalDrivingLicenseApplication _LDLApplication;
        int _TestID = -1;
        clsTest _Test;
        clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        public ctrlTestAppointmentInfo()
        {
            InitializeComponent();
        }

        public int TestAppointmentID
        {
            get { return _TestAppointmentID; }
            set { _TestAppointmentID = value; }
        }

        public int TestID
        {
            get { return _TestID; }
            set { _TestID = value; }
        }

        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }
            set { _TestTypeID = value; }
        }

        private void _LoadTestTypeTitleAndImage()
        {
            switch (_TestTypeID)
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

        public void LoadInfo(int TestAppointmentID)
        {
            _TestAppointment = clsTestAppointment.GetTestAppointmentByID(TestAppointmentID);

            if(_TestAppointment == null)
            {
                MessageBox.Show("No Test Appointment With That ID", "Not Exists", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            _TestAppointmentID = TestAppointmentID;
            _LDLApplicationID = _TestAppointment.LDLApplicationID;
            _LDLApplication = clsLocalDrivingLicenseApplication.GetLDLApplicationByID(_LDLApplicationID);

            if(_LDLApplication == null)
            {
                MessageBox.Show("No Test Appointment With That ID", "Not Exists", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            _TestTypeID = _TestAppointment.TestTypeID;

            _LoadTestTypeTitleAndImage();

            lblLDLApplicationID.Text = _LDLApplicationID.ToString();
            lblDrivingClass.Text = _LDLApplication.LicenseClass.ClassName;
            lblName.Text = _LDLApplication.ApplicantPerson.FullName;
            lblTrials.Text = _LDLApplication.TotalTrialsPerTestType(_TestTypeID).ToString();
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            lblAppointmentDate.Text = _TestAppointment.AppointmentDate.ToShortDateString();

            _Test = clsTest.GetLastTestByPersonTestTypeLicenseClass(_LDLApplication.ApplicantPersonID,
                _TestTypeID, _LDLApplication.LicenseClassID);

            _TestID = _Test != null ? _Test.TestID : -1;

            lblTestID.Text = _Test != null ? _Test.TestID.ToString() : "Not Taken Yet";

        }
        
    }
}

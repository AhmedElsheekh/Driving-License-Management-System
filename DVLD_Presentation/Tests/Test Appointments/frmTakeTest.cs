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

namespace DVLD_Presentation.Tests.Test_Appointments
{
    public partial class frmTakeTest : Form
    {
        int _TestAppointmentID;
        clsTestAppointment _TestAppointment;
        int _TestID;
        clsTest _Test = new clsTest();
        clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
        }

        private void _LoadData()
        {
            _TestAppointment = clsTestAppointment.GetTestAppointmentByID(_TestAppointmentID);

            if(_TestAppointment == null)
            {
                MessageBox.Show("No Test Appointment Exists With That ID", "Not Found", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            _TestTypeID = _TestAppointment.TestTypeID;

            ctrlTestAppointmentInfo1.LoadInfo(_TestAppointmentID);

            _TestID = ctrlTestAppointmentInfo1.TestID;


            if (_TestID != -1)
            {
                _Test = clsTest.GetTestByID(_TestID);

                if (_Test.TestResult == true || _TestAppointment.IsLocked)
                    _FillTestValues();
                else
                    _ResetTestDefaultValues();
            }
            else
                _ResetTestDefaultValues();
        }

        private void _ResetTestDefaultValues()
        {
            _Test = new clsTest();

            rbPass.Checked = true;
            lblTestID.Text = "NA";
            lblUserMessage.Visible = false;
            lblCreatedByUser.Text = "???";
            txtNotes.Text = "";

            btnSave.Enabled = true;
        }

        private void _FillTestValues()
        {
            if (_Test.TestResult)
                rbPass.Checked = true;
            else
                rbFail.Checked = true;

            lblTestID.Text = _Test.TestID.ToString();
            lblCreatedByUser.Text = clsUser.GetUserInfoByUserID(_Test.CreatedByUserID).Username;
            txtNotes.Text = _Test.Notes;
            lblUserMessage.Visible = true;

            btnSave.Enabled = false;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Save Test Result", "Confirmation", MessageBoxButtons.YesNo
                ) == DialogResult.No)
                return;

            _Test.TestAppointmentID = _TestAppointmentID;

            if (rbPass.Checked)
                _Test.TestResult = true;
            else
                _Test.TestResult = false;

            _Test.Notes = txtNotes.Text;
            _Test.CreatedByUserID = clsLogedUser.CurrentUser.UserID;

            if(_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully");
            }
            else
            {
                MessageBox.Show("Failed To Save Data");
            }
        }


    }
}

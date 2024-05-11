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
    public partial class frmTestTypeAppointmentsHome : Form
    {
        DataTable _AllTestTypeAppointments;
        int _LDLApplicationID = -1;
        clsLocalDrivingLicenseApplication _LDLAppliction;
        clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        public frmTestTypeAppointmentsHome(int LDLApplicationID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            _LDLApplicationID = LDLApplicationID;
            _TestTypeID = TestTypeID;

        }

        private void _LoadTestImageAndTitle()
        {
            switch(_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    lblTestTitle.Text = "Vision Test Appointments";
                    this.Text = lblTestTitle.Text;
                    pbTestTypeImage.Image = Resources.Vision_512;
                    break;

                case clsTestType.enTestType.WrittenTest:
                    lblTestTitle.Text = "Written Test Appointments";
                    this.Text = lblTestTitle.Text;
                    pbTestTypeImage.Image = Resources.Written_Test_512;
                    break;

                case clsTestType.enTestType.StreetTest:
                    lblTestTitle.Text = "Street Test Appointments";
                    this.Text = lblTestTitle.Text;
                    pbTestTypeImage.Image = Resources.Street_Test_32;
                    break;

                default:
                    lblTestTitle.Text = "Vision Test Appointments";
                    this.Text = lblTestTitle.Text;
                    pbTestTypeImage.Image = Resources.Vision_512;
                    break;
            }
        }

        private void _LoadData()
        {
            _LoadTestImageAndTitle();

            ctrlLDLApplicationInfo1.LoadLDLApplicationInfoByLDLApplicationID(_LDLApplicationID);

            _AllTestTypeAppointments = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LDLApplicationID,
                (int)_TestTypeID);
            dgvAllAppointments.DataSource = _AllTestTypeAppointments;

            lblNumOfRecords.Text = dgvAllAppointments.Rows.Count.ToString();

            if(dgvAllAppointments.Rows.Count > 0)
            {
                dgvAllAppointments.Columns[0].HeaderText = "Appointment ID";

                dgvAllAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvAllAppointments.Columns[1].Width = 120;

                dgvAllAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvAllAppointments.Columns[3].HeaderText = "Is Locked?";
            }
        }

        private void frmTestTypeAppointmentsHome_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _LDLAppliction = clsLocalDrivingLicenseApplication.GetLDLApplicationByID(_LDLApplicationID);

            if(_LDLAppliction.DoesHaveAnActiveTestAppointment((int)_TestTypeID))
            {
                MessageBox.Show("This Person Already Has An Active Appointment", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(_LDLAppliction.DoesAttendTestAppointment((int)_TestTypeID) && !_LDLAppliction.DoesPassTestType(
                (int)_TestTypeID))
            {
                int RetakenAppointment = (int)dgvAllAppointments.Rows[0].Cells[0].Value;
                frmAddUpdateTestAppointment frm1 = new frmAddUpdateTestAppointment(_LDLApplicationID, _TestTypeID,
                    -1, RetakenAppointment);
                frm1.ShowDialog();
                _LoadData();
                return;
            }

            if(_LDLAppliction.DoesPassTestType((int)_TestTypeID))
            {
                MessageBox.Show($"This Person Already Passed {_TestTypeID.ToString()}, Not Allowed To Retake",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddUpdateTestAppointment frm = new frmAddUpdateTestAppointment(_LDLApplicationID, _TestTypeID);
            frm.ShowDialog();
            _LoadData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvAllAppointments.CurrentRow.Cells[0].Value;
            frmAddUpdateTestAppointment frm = new frmAddUpdateTestAppointment(_LDLApplicationID, _TestTypeID,
                TestAppointmentID);

            frm.ShowDialog();
            _LoadData();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest frm = new frmTakeTest((int)dgvAllAppointments.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadData();
        }
    }
}

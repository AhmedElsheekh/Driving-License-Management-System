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

namespace DVLD_Presentation.Tests.Test_Appointments
{
    public partial class frmAddUpdateTestAppointment : Form
    {
        int _LDLApplicationID;
        int _TestAppointmentID;
        clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        public frmAddUpdateTestAppointment(int LDLApplicationID, clsTestType.enTestType TestTypeID,
            int TestAppointmentID = -1, int RetakenTestAppointment = -1)
        {
            InitializeComponent();

            _LDLApplicationID = LDLApplicationID;
            _TestTypeID = TestTypeID;
            _TestAppointmentID = TestAppointmentID;

            ctrlAddUpdateTestAppointment1.LoadData(LDLApplicationID, TestTypeID, TestAppointmentID, RetakenTestAppointment);
        }
    }
}

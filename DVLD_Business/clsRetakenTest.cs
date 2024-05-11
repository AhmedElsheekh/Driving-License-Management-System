using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsRetakenTest : clsApplication
    {
        enum enMode { AddNew = 0, Update = 1}

        enMode _Mode;
        public int TestAppointmentID { get; set; }
        public clsTestAppointment TestAppointment;

        public clsRetakenTest()
        {
            _Mode = enMode.AddNew;
            this.TestAppointmentID = -1;
        }

        clsRetakenTest(int TestAppointmentID, int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, clsApplication.enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
            decimal PaidFees, int CreatedByUserID) : base(ApplicationID, ApplicantPersonID, ApplicationDate,
                ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
        {
            _Mode = enMode.Update;
            this.TestAppointmentID = TestAppointmentID;
            this.TestAppointment = clsTestAppointment.GetTestAppointmentByID(TestAppointmentID);
        }

        //Create
        private bool _AddNew()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees,
                this.CreatedByUserID);

            if (this.ApplicationID != -1)
                return clsRetakenTestData.AddNewRetakenTest(this.ApplicationID, this.TestAppointmentID);
            else
                return false;
        }

        //Read
        public static clsRetakenTest GetRetakenTestApplicationByID(int RetakentTestApplicationID)
        {
            int TestAppointmentID = -1;

            bool IsFound = clsRetakenTestData.GetRetakenTestByID(RetakentTestApplicationID, ref TestAppointmentID);

            if(IsFound)
            {
                clsApplication Application = clsApplication.GetBaseApplicationByID(RetakentTestApplicationID);
                return new clsRetakenTest(TestAppointmentID, Application.ApplicationID, Application.ApplicantPersonID,
                    Application.ApplicationDate, Application.ApplicationTypeID, Application.ApplicationStatus,
                    Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        //Update
        private bool _Update()
        {
            return clsRetakenTestData.UpdateRetakenTest(this.ApplicationID, this.TestAppointmentID);
        }

        //Delete
        public static bool Delete(int RetakenTestApplicationID)
        {
            return clsRetakenTestData.Delete(RetakenTestApplicationID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _Update();
            }

            return false;
        }

    }
}

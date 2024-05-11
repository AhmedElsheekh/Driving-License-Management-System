using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTestAppointment
    {
        enum enMode { AddNew = 0, Update = 1}

        enMode _Mode;
        public int TestAppointmentID { get; set; }
        public clsTestType.enTestType TestTypeID { get; set; }
        public clsTestType TestType;
        public int LDLApplicationID { get; set; }
        public clsLocalDrivingLicenseApplication LDLApplication;
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUser;
        public bool IsLocked { get; set; }

        public clsTestAppointment()
        {
            _Mode = enMode.AddNew;
            this.TestAppointmentID = -1;
            this.TestTypeID = clsTestType.enTestType.VisionTest;
            this.LDLApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.IsLocked = false;
        }

        clsTestAppointment(int TestAppointmentID, clsTestType.enTestType TestTypeID, int LDLApplicationID, DateTime AppointmentDate,
            decimal PaidFees, bool IsLocked)
        {
            _Mode = enMode.Update;
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.TestType = clsTestType.GetTypeTypeByID(TestTypeID);
            this.LDLApplicationID = LDLApplicationID;
            this.LDLApplication = clsLocalDrivingLicenseApplication.GetLDLApplicationByID(LDLApplicationID);
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.IsLocked = IsLocked;
        }

        //Create
        private bool _AddNew()
        {
            this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment((int)this.TestTypeID, this.LDLApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked);

            return (this.TestAppointmentID != -1);
        }

        //Read
        public static clsTestAppointment GetTestAppointmentByID(int TestAppointmentID)
        {
            int TestTypeID = -1, LDLApplicationID = -1, CreatedByUserID = -1;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;
            bool IsLocked = false;

            bool IsFound = clsTestAppointmentData.GetTestAppointmentByID(TestAppointmentID, ref TestTypeID,
                ref LDLApplicationID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked);

            if (IsFound)
                return new clsTestAppointment(TestAppointmentID, (clsTestType.enTestType)TestTypeID, LDLApplicationID, AppointmentDate,
                    PaidFees, IsLocked);
            else
                return null;
        }

        public static clsTestAppointment GetlastTestAppointment(int TestTypeID, int LDLApplicationID)
        {
            int TestAppointmentID = -1, CreatedByUserID = -1;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;
            bool IsLocked = false;

            bool IsFound = clsTestAppointmentData.GetLastTestAppointment(TestTypeID, LDLApplicationID,
                ref TestAppointmentID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked);

            if (IsFound)
                return new clsTestAppointment(TestAppointmentID, (clsTestType.enTestType)TestTypeID, LDLApplicationID, AppointmentDate,
                    PaidFees, IsLocked);
            else
                return null;
        }

        public int GetTestID()
        {
            return clsTestAppointmentData.GetTestID(this.TestAppointmentID);
        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentData.GetAllTestAppointments();
        }

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LDLApplicationID, int TestTypeID)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(LDLApplicationID, TestTypeID);
        }

        public DataTable GetApplicationTestAppointmentsPerTestType(int TestTypeID)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(this.LDLApplicationID, TestTypeID);
        }

        //Update
        private bool _Update()
        {
            return clsTestAppointmentData.UpdateTestAppointment(this.TestAppointmentID, (int)this.TestTypeID,
                this.LDLApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked);
        }

        //Delete
        public static bool Delete(int TestAppointmentID)
        {
            return clsTestAppointmentData.DeleteTestAppointment(TestAppointmentID);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if(_AddNew())
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

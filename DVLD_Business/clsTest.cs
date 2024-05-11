using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTest
    {
        enum enMode { AddNew = 0, Update = 1}

        enMode _Mode;
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public clsTestAppointment TestAppointment;
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUser;

        public clsTest()
        {
            _Mode = enMode.AddNew;
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;
        }

        clsTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            _Mode = enMode.Update;
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestAppointment = clsTestAppointment.GetTestAppointmentByID(TestAppointmentID);
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUser = clsUser.GetUserInfoByUserID(CreatedByUserID);
        }

        //Read
        private bool _AddNew()
        {
            this.TestID = clsTestData.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes,
                this.CreatedByUserID);

            return (this.TestID != -1);
        }

        public static clsTest GetTestByID(int TestID)
        {
            int TestAppointmentID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = "";

            bool IsFound = clsTestData.GetTestByID(TestID, ref TestAppointmentID, ref TestResult, ref Notes,
                ref CreatedByUserID);

            if (IsFound)
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            else
                return null;
        }

        public static DataTable GetAllTests()
        {
            return clsTestData.GetAllTests();
        }

        public static clsTest GetLastTestByPersonTestTypeLicenseClass(int PersonID, clsTestType.enTestType TestTypeID,
            int LicenseClassID)
        {
            int TestID = -1, TestAppointmentID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = "";

            bool IsFound = clsTestData.GetLastTestByPersonTestTypeLicenseClass(PersonID, (int)TestTypeID, LicenseClassID,
                ref TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID);

            if (IsFound)
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            else
                return null;
        }

        //Update
        private bool _Update()
        {
            return clsTestData.UpdateTest(this.TestID, this.TestAppointmentID, this.TestResult, this.Notes,
                this.CreatedByUserID);
        }

        public static bool Delete(int TestID)
        {
            return clsTestData.DeleteTest(TestID);
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

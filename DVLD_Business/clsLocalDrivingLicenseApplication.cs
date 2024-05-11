using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public enum enLDLMode { AddNew = 0, Update = 1}

        public enLDLMode LDLMode;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClass;

        public clsLocalDrivingLicenseApplication()
        {
            LDLMode = enLDLMode.AddNew;
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;
        }

        clsLocalDrivingLicenseApplication(int LDLApplicationID, int LicenseClassID, int ApplicationID,
            int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            clsApplication.enApplicationStatus ApplicationStatus, DateTime LastStatusDate, decimal PaidFees,
            int CreatedByUserID) : base(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
        {
            this.LocalDrivingLicenseApplicationID = LDLApplicationID;
            this.LicenseClassID = LicenseClassID;
            LicenseClass = clsLicenseClass.GetLicenseClassByID(LicenseClassID);
            LDLMode = enLDLMode.Update;
        }

        //Create
        private bool _AddNew()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData.AddNewLDLApplication(this.ApplicationID,
                this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        //Read
        public static clsLocalDrivingLicenseApplication GetLDLApplicationByID(int LDLApplicationID)
        {
            int ApplicationID = 0, LicenseClassID = 0;

            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationByID(LDLApplicationID,
                ref ApplicationID, ref LicenseClassID);

            if(IsFound)
            {
                clsApplication Application = clsApplication.GetBaseApplicationByID(ApplicationID);
                return new clsLocalDrivingLicenseApplication(LDLApplicationID, LicenseClassID, ApplicationID,
                    Application.ApplicantPersonID, Application.ApplicationDate, Application.ApplicationTypeID,
                    Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees,
                    Application.CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        public static clsLocalDrivingLicenseApplication GetLDLApplicationByApplicationID(int ApplicationID)
        {
            int LDLApplicationID = 0, LicenseClassID = 0;

            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationByApplicationID(ApplicationID,
                ref LDLApplicationID, ref LicenseClassID);

            if (IsFound)
            {
                clsApplication Application = clsApplication.GetBaseApplicationByID(ApplicationID);
                return new clsLocalDrivingLicenseApplication(LDLApplicationID, LicenseClassID, ApplicationID,
                    Application.ApplicantPersonID, Application.ApplicationDate, Application.ApplicationTypeID,
                    Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees,
                    Application.CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }

        public static bool DoesPassTestType(int LDLApplicationID, int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(LDLApplicationID, TestTypeID);
        }

        public bool DoesPassTestType(int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(this.LocalDrivingLicenseApplicationID,
                TestTypeID);
        }

        public static bool DoesAttendTestAppointment(int LDLApplicationID, int TestAppointmentID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestAppointment(LDLApplicationID,
                TestAppointmentID);
        }

        public bool DoesAttendTestAppointment(int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestAppointment(this.LocalDrivingLicenseApplicationID,
                TestTypeID);
        }

        public static bool DoesHaveAnActiveTestAppointment(int LDLApplicationID, int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesHaveAnActiveTestAppointment(LDLApplicationID,
                TestTypeID);
        }

        public bool DoesHaveAnActiveTestAppointment(int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesHaveAnActiveTestAppointment(this.LocalDrivingLicenseApplicationID,
                TestTypeID);
        }

        public static byte GetNumberOfPassedTests(int LDLApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.GetNumberOfPassedTests(LDLApplicationID);
        }

        public static bool DoesPassAllTests(int LDLApplicationID)
        {
            return GetNumberOfPassedTests(LDLApplicationID) == 3;
        }

        public int GetNumberOfPassedTests()
        {
            return clsLocalDrivingLicenseApplicationData.GetNumberOfPassedTests(this.LocalDrivingLicenseApplicationID);
        }

        public int TotalTrialsPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest((int)TestTypeID);
        }

        public int GetActiveLicenseID()
        {
            return clsLicense.GetActiveLicenseByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }

        //Update
        private bool _Update()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID,
                this.ApplicationID, this.LicenseClassID);
        }

        //Delete
        public bool Delete()
        {
            bool IsLDLApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;

            IsLDLApplicationDeleted = clsLocalDrivingLicenseApplicationData.Delete(this.LocalDrivingLicenseApplicationID);

            if (!IsLDLApplicationDeleted)
                return false;

            IsBaseApplicationDeleted = base.Delete();
            return IsBaseApplicationDeleted;
        }

        public bool Save()
        {
            base.Mode = (clsApplication.enMode)LDLMode;

            if (!base.Save())
                return false;

            switch(LDLMode)
            {
                case enLDLMode.AddNew:
                    if(_AddNew())
                    {
                        LDLMode = enLDLMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enLDLMode.Update:
                    return _Update();
            }

            return false;
        }

        public int IssueLicenseForTheFirstTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;
            clsDriver Driver = clsDriver.GetDriverByPersonID(this.ApplicantPersonID);

            if(Driver == null)
            {
                Driver = new clsDriver();

                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;
                Driver.CreatedDate = DateTime.Now;

                if(Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    DriverID = -1;
                }
            }
            else
            {
                DriverID = Driver.DriverID;
            }

            clsLicense License = new clsLicense();

            License.ApplicationID = this.ApplicationID;
            License.DriverID = DriverID;
            License.LicenseClassID = this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            int ValidityLength = clsLicenseClass.GetLicenseClassByID(this.LicenseClassID).ValidityLength;
            License.ExpirationDate = DateTime.Now.AddYears(ValidityLength);
            License.Notes = Notes;
            License.PaidFees = clsLicenseClass.GetLicenseClassByID(this.LicenseClassID).ClassFees;
            License.IsActive = true;
            License.IssueReason = clsLicense.enIssueReason.New;
            License.CreatedByUserID = CreatedByUserID;

            if(License.Save())
            {
                this.SetComplete();
                return License.LicenseID;
            }
            else
            {
                return -1;
            }
        }

    }
}

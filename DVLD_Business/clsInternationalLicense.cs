using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsInternationalLicense : clsApplication
    {
        enum enIntMode { AddNew = 0, Update = 1}

        enIntMode _IntMode;
        public int InternationalLicenseID { get; set; }
        public int DriverID { get; set; }
        public clsDriver Driver;
        public int IssuedUsingLocalLicenseID { get; set; }
        public clsLicense IssuedUsinLocalLicense;
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int IntCreatedByUserID { get; set; }
        public clsUser IntCreatedByUser;

        public clsInternationalLicense()
        {
            _IntMode = enIntMode.AddNew;
            this.InternationalLicenseID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.MaxValue;
            this.ExpirationDate = DateTime.MaxValue;
            this.IsActive = false;
            this.IntCreatedByUserID = -1;
        }

        clsInternationalLicense(int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID, int ApplicationID,
            int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            clsApplication.enApplicationStatus ApplicationStatus, DateTime LastStatusDate, decimal PaidFees,
            int AppCreatedByUserID) : base(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                ApplicationStatus, LastStatusDate, PaidFees, AppCreatedByUserID)
        {
            _IntMode = enIntMode.Update;
            this.InternationalLicenseID = InternationalLicenseID;
            this.DriverID = DriverID;
            this.Driver = clsDriver.GetDriverByID(DriverID);
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssuedUsinLocalLicense = clsLicense.GetLicenseByID(IssuedUsingLocalLicenseID);
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.IntCreatedByUserID = CreatedByUserID;
            this.IntCreatedByUser = clsUser.GetUserInfoByUserID(CreatedByUserID);
        }

        //Create
        private bool _AddNew()
        {
            this.InternationalLicenseID = clsInternationalLicenseData.AddNewInternationalLicense(this.ApplicationID,
                this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive,
                this.IntCreatedByUserID);

            return this.InternationalLicenseID != -1;
        }

        //Read1
        public static clsInternationalLicense GetInternationalLicenseByID(int InternationalLicenseID)
        {
            int ApplicationID = 0, DriverID = 0, IssuedUsingLocalLicenseID = 0, IntCreatedByUserID = 0;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = false;

            bool IsFound = clsInternationalLicenseData.GetInternationalLicenseByID(InternationalLicenseID,
                ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate,
                ref IsActive, ref IntCreatedByUserID);

            if (IsFound)
            {
                clsApplication Application = clsApplication.GetBaseApplicationByID(ApplicationID);

                return new clsInternationalLicense(InternationalLicenseID, DriverID, IssuedUsingLocalLicenseID, IssueDate,
                    ExpirationDate, IsActive, IntCreatedByUserID, ApplicationID, Application.ApplicantPersonID,
                    Application.ApplicationDate, Application.ApplicationTypeID, Application.ApplicationStatus,
                    Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID);
            }
            else
                return null;
        }

        //Read2
        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseData.GetAllInternationalLicenses();
        }

        //Read3
        public static DataTable GetDriverInternationlLicenses(int DriverID)
        {
            return clsInternationalLicenseData.GetDriverInternationalLicenses(DriverID);
        }

        public  DataTable GetDriverInternationlLicenses()
        {
            return clsInternationalLicenseData.GetDriverInternationalLicenses(this.DriverID);
        }

        //Read4
        public static int GetActiveInternationalLicenseByDriverID(int DriverID)
        {
            return clsInternationalLicenseData.GetActiveInternationalLicenseByDriverID(DriverID);
        }

        //Update
        private bool _Update()
        {
            return clsInternationalLicenseData.UpdateInternationalLicense(this.InternationalLicenseID, this.ApplicationID,
                this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive,
                this.IntCreatedByUserID);
        }

        public bool Save()
        {
            base.Mode = (clsApplication.enMode)_IntMode;

            if (!base.Save())
                return false;

            switch(_IntMode)
            {
                case enIntMode.AddNew:
                    if(_AddNew())
                    {
                        _IntMode = enIntMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enIntMode.Update:
                    return _Update();
            }

            return false;
        }

    }
}

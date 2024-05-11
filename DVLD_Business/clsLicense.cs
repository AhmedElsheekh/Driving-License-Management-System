using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLicense
    {
        enum enMode { AddNew = 0, Update = 1}
        public enum enIssueReason { New = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4}

        enMode _Mode;
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public clsDriver Driver;
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClass;
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }

        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUser;

        public clsDetainedLicense DetainedInfo;

        public bool IsDetained
        {
            get
            {
                return clsDetainedLicense.IsLicenseDetained(this.LicenseID);
            }
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {
            switch(IssueReason)
            {
                case enIssueReason.New:
                    return "New";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement For Damage";
                case enIssueReason.LostReplacement:
                    return "Replacement For Lost";
                default:
                    return "New";
            }
        }

        public clsLicense()
        {
            _Mode = enMode.AddNew;

            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = false;
            this.IssueReason = enIssueReason.New;
            this.CreatedByUserID = -1;
        }

        clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate,
            DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, enIssueReason IssueReason,
            int CreatedByuserID)
        {
            _Mode = enMode.Update;

            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.Driver = clsDriver.GetDriverByID(DriverID);
            this.LicenseClassID = LicenseClassID;
            this.LicenseClass = clsLicenseClass.GetLicenseClassByID(LicenseClassID);
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUser = clsUser.GetUserInfoByUserID(CreatedByuserID);
            this.DetainedInfo = clsDetainedLicense.GetDetinedLicenseByLicenseID(LicenseID);
        }

        //Create
        private bool _AddNew()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClassID,
                this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (int)this.IssueReason,
                this.CreatedByUserID);

            return this.LicenseID != -1;
        }

        //Read1
        public static clsLicense GetLicenseByID(int LicenseID)
        {
            int ApplicationID = 0, DriverID = 0, LicenseClassID = 0, CreatedByUserID = 0;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0;

            bool IsFound = clsLicenseData.GetLicenseByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason,
                ref CreatedByUserID);

            if (IsFound)
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate,
                    Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            else
                return null;

        }

        //Read2
        public static DataTable GetAllLicenses()
        {
            return clsLicenseData.GetAllLicenses();
        }

        //Read3
        public static DataTable GetAllDriverLicenses(int DriverID)
        {
            return clsLicenseData.GetDriverLicenses(DriverID);
        }

        //Read4
        public static int GetActiveLicenseByPersonID(int PersonID, int LicenseClassID)
        {
            return clsLicenseData.GetActiveLicenseIdByPersonID(PersonID, LicenseClassID);
        }

        //Read5
        public static bool IsLicenseExistsByPersonID(int PersonID, int LicenseClassID)
        {
            return (GetActiveLicenseByPersonID(PersonID, LicenseClassID) != -1);
        }

        //Read6
        public bool IsLicenseExpired()
        {
            return this.ExpirationDate < DateTime.Now;
        }

        //Update1
        private bool _Update()
        {
            return clsLicenseData.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClassID,
                this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (int)this.IssueReason,
                this.CreatedByUserID);
        }

        //Update2
        public bool DeactivateCurrentLicense()
        {
            return clsLicenseData.DeactivateLicense(this.LicenseID);
        }

        //Update3
        public clsLicense Renew(int CreatedByUserID, string Notes)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.Driver.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = 2;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.GetApplicationTypeByID(2).ApplicationFees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
                return null;

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            int ValidityLength = this.LicenseClass.ValidityLength;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(ValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClass.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save())
                return null;

            DeactivateCurrentLicense();

            return NewLicense;

        }

        //Update4
        public clsLicense Replace(int CreatedByUserID, enIssueReason IssueReason)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.Driver.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = IssueReason == enIssueReason.LostReplacement ? 3 : 4; 
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.GetApplicationTypeByID(Application.ApplicationTypeID).ApplicationFees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
                return null;

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = this.IssueDate;

            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = 0;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save())
                return null;

            DeactivateCurrentLicense();

            return NewLicense;

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

        //Create In DetainedLicenses
        public int Detain(decimal FineFees, int CreatedByUserID)
        {
            clsDetainedLicense DetainedLicense = new clsDetainedLicense();

            DetainedLicense.LicenseID = this.LicenseID;
            DetainedLicense.DetainDate = DateTime.Now;
            DetainedLicense.FineFees = FineFees;
            DetainedLicense.CreatedByUserID = CreatedByUserID;
            DetainedLicense.IsReleased = false;

            if (!DetainedLicense.Save())
                return -1;

            return DetainedLicense.DetainID;

        }

        //Create In ReleasedLicenses
        public bool ReleaseIfLicenseDetained(int ReleasedByUserID)
        {
            clsReleasedLicense ReleasedLicense = new clsReleasedLicense();

            ReleasedLicense.ApplicantPersonID = this.Driver.PersonID;
            ReleasedLicense.ApplicationDate = DateTime.Now;
            ReleasedLicense.ApplicationTypeID = 5;
            ReleasedLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            ReleasedLicense.LastStatusDate = DateTime.Now;
            ReleasedLicense.PaidFees = clsApplicationType.GetApplicationTypeByID(5).ApplicationFees;
            ReleasedLicense.CreatedByUserID = ReleasedByUserID;           

            ReleasedLicense.DetainID = this.IsDetained ? this.DetainedInfo.DetainID : -1;
            ReleasedLicense.ReleaseDate = DateTime.Now;
            ReleasedLicense.ReleasedByUserID = ReleasedByUserID;
            
            

            if (ReleasedLicense.DetainID == -1)
                return false;

            return ReleasedLicense.Save();
        }

    }
}

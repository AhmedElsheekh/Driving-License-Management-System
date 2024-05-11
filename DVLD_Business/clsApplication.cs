using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1}
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3}

        public enMode Mode;
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public clsPerson ApplicantPerson;
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationType;
        public enApplicationStatus ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUser;

        public clsApplication()
        {
            Mode = enMode.AddNew;
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
        }

        protected clsApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, 
            int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
            decimal PaidFees, int CreatedByuserID)
        {
            Mode = enMode.Update;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicantPerson = clsPerson.GetPersonByID(ApplicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationType = clsApplicationType.GetApplicationTypeByID(ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByuserID;
            this.CreatedByUser = clsUser.GetUserInfoByUserID(CreatedByuserID);
        }

        //Create
        private bool _AddNew()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees,
                this.CreatedByUserID);

            return (this.ApplicationID != -1);
        }

        //Read
        public static clsApplication GetBaseApplicationByID(int ApplicationID)
        {
            int ApplicantPersonID = -1, ApplicationTypeID = -1, CreatedByUserID = -1;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            decimal PaidFees = 0;
            byte ApplicationStatus = 1;

            bool IsFound = clsApplicationData.GetApplicationByID(ApplicationID, ref ApplicantPersonID,
                ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate,
                ref PaidFees, ref CreatedByUserID);

            if (IsFound)
                return new clsApplication(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                    (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            else
                return null;
        }

        public static int GetActiveApplicationID(int ApplicantPersonID, int ApplicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationID(ApplicantPersonID, ApplicationTypeID);
        }

        public static bool DoesPersonHaveActiveApplicationID(int ApplicantPersonID, int ApplicationTypeID)
        {
            return clsApplicationData.DoesPersonHaveActiveApplication(ApplicantPersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int ApplicantPersonID, int ApplicationTypeID,
            int LicenseClassID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(ApplicantPersonID, ApplicationTypeID,
                LicenseClassID);
        }

        //Update
        private bool _Update()
        {
            return clsApplicationData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID,
                this.ApplicationDate, this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate,
                this.PaidFees, this.CreatedByUserID);
        }

        public bool Cancel()
        {
            return clsApplicationData.UpdateStatus(this.ApplicationID, 2);
        }

        public bool SetComplete()
        {
            return clsApplicationData.UpdateStatus(this.ApplicationID, 3);
        }

        //Delete
        public bool Delete()
        {
            return clsApplicationData.DeleteApplication(this.ApplicationID);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNew())
                    {
                        Mode = enMode.Update;
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

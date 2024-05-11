using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsReleasedLicense : clsApplication
    {
        enum enRMode { AddNew = 0, Update = 1}

        enRMode _RMode;
        public int DetainID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public clsUser ReleasedByUser;


        public clsReleasedLicense()
        {
            _RMode = enRMode.AddNew;

            this.DetainID = -1;
            this.ReleaseDate = DateTime.MaxValue;
            this.ReleasedByUserID = -1;
        }

        clsReleasedLicense(int DetainID, DateTime ReleaseDate, int ReleasedByUserID, int ApplicationID,
            int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            clsApplication.enApplicationStatus ApplicationStatus, DateTime LastStatusDate, decimal PaidFees,
            int CreatedByUserID) : base(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
        {
            _RMode = enRMode.Update;

            this.DetainID = DetainID;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleasedByUser = clsUser.GetUserInfoByUserID(ReleasedByUserID);
        }

        //Create
        private bool _AddNew()
        {
            //this.ApplicationID = clsApplicationData.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate,
            //    this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees,
            //    this.CreatedByUserID);

            return clsReleasedLicenseData.AddNewReleasedLicense(this.DetainID, this.ReleaseDate,
                this.ReleasedByUserID, this.ApplicationID);
        }

        public bool Save()
        {
            base.Mode = (clsApplication.enMode)_RMode;
            if (!base.Save())
                return false;

            switch(_RMode)
            {
                case enRMode.AddNew:
                    if(_AddNew())
                    {
                        _RMode = enRMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enRMode.Update:
                    return true;
            }

            return false;
        }

    }
}

using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsDetainedLicense
    {
        enum enMode { AddNew = 0, Update = 1}

        enMode _Mode;
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUser;
        public bool IsReleased { get; set; }

        public clsDetainedLicense()
        {
            _Mode = enMode.AddNew;

            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
        }

        clsDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID,
            bool IsReleased)
        {
            _Mode = enMode.Update;

            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUser = clsUser.GetUserInfoByUserID(CreatedByUserID);
            this.IsReleased = IsReleased;
        }

        //Create
        private bool _AddNew()
        {
            this.DetainID = clsDetainedLicenseData.AddNewDetainedLicense(this.LicenseID, this.DetainDate, this.FineFees,
                this.CreatedByUserID, this.IsReleased);

            return this.DetainID != -1;
        }

        //Read1
        public static clsDetainedLicense GetDetinedLicenseByID(int DetainID)
        {
            DateTime DetainDate = DateTime.Now;
            int LicenseID = 0, CreatedByUserID = 0;
            decimal FineFees = 0;
            bool IsReleased = false;

            if(clsDetainedLicenseData.GetDetainedLicenseByID(DetainID, ref LicenseID, ref DetainDate, ref FineFees,
                ref CreatedByUserID, ref IsReleased))
            {
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased);
            }
            else
            {
                return null;
            }
        }

        //Read2
        public static clsDetainedLicense GetDetinedLicenseByLicenseID(int LicenseID)
        {
            DateTime DetainDate = DateTime.Now;
            int DetainID = 0, CreatedByUserID = 0;
            decimal FineFees = 0;
            bool IsReleased = false;

            if (clsDetainedLicenseData.GetDetainedLicenseByLicenseID(LicenseID, ref DetainID, ref DetainDate, ref FineFees,
                ref CreatedByUserID, ref IsReleased))
            {
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased);
            }
            else
            {
                return null;
            }
        }

        //Read3
        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicenseData.GetAllDetainedLicenses();
        }

        //Read4
        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicenseData.IsLicenseDetained(LicenseID);
        }

        //Read5
        public static bool IsLicenseReleased(int LicenseID)
        {
            return clsDetainedLicenseData.IsLicenseReleased(LicenseID);
        }

        //Update1
        private bool _Update()
        {
            return clsDetainedLicenseData.UpdateDetainedLicense(this.DetainID, this.LicenseID, this.DetainDate,
                this.FineFees, this.CreatedByUserID, this.IsReleased);
        }

        //Update2
        public bool ReleaseDetainedLicense(int ReleasedByUserID, int ReleaseApplicationID)
        {
            clsReleasedLicense ReleasedLicense = new clsReleasedLicense();

            ReleasedLicense.DetainID = this.DetainID;
            ReleasedLicense.ReleaseDate = DateTime.Now;
            ReleasedLicense.ReleasedByUserID = ReleasedByUserID;
            ReleasedLicense.ApplicationID = ReleaseApplicationID;

            if (!ReleasedLicense.Save())
                return false;

            return true;
        }

        public bool ReleaseDetainedLicense(clsReleasedLicense ReleasedLicense)
        {
            return ReleasedLicense.Save();
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

using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsDriver
    {
        enum enMode { AddNew = 0, Update = 1}

        enMode _Mode;
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public clsPerson Person;
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUser;
        public DateTime CreatedDate { get; set; }


        public clsDriver()
        {
            _Mode = enMode.AddNew;
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;
        }

        clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            _Mode = enMode.Update;
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.Person = clsPerson.GetPersonByID(PersonID);
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUser = clsUser.GetUserInfoByUserID(CreatedByUserID);
            this.CreatedDate = CreatedDate;
        }

        //Create
        private bool _AddNew()
        {
            this.DriverID = clsDriverData.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);

            return (this.DriverID != -1);
        }

        //Read
        public static clsDriver GetDriverByID(int DriverID)
        {
            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriverData.GetDriverByID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }

        public static clsDriver GetDriverByPersonID(int PersonID)
        {
            int DriverID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriverData.GetDriverByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }

        public DataTable GetAllDriverLicenses()
        {
            return clsLicense.GetAllDriverLicenses(this.DriverID);
        }

        //Update
        private bool _Update()
        {
            return clsDriverData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID, this.CreatedDate);
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

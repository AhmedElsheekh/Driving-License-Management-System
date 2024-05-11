using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_Business
{
    public class clsApplicationType
    {
        enum enMode { AddNew = 0, Update = 1}

        enMode _Mode;
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }

        public clsApplicationType()
        {
            this.ApplicationTypeID = -1;
            this.ApplicationTypeTitle = "";
            this.ApplicationFees = 0;
            _Mode = enMode.AddNew;
        }

        public clsApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationFees;
            _Mode = enMode.Update;
        }

        //Create

        //Read
        public static clsApplicationType GetApplicationTypeByID(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            decimal ApplicationFees = 0;

            if(clsApplicationTypeData.GetApplicationTypeByID(ApplicationTypeID, ref ApplicationTypeTitle,
                ref ApplicationFees))
            {
                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypeData.GetAllApplicationTypes();
        }

        //Update
        private bool _Update()
        {
            return clsApplicationTypeData.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle,
                this.ApplicationFees);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    return true;
                case enMode.Update:
                    return _Update();
            }

            return false;
        }

    }
}

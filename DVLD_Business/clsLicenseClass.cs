using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLicenseClass
    {
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinAllowedAge { get; set; }
        public byte ValidityLength { get; set; }
        public decimal ClassFees { get; set; }

        public clsLicenseClass()
        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinAllowedAge = 18;
            this.ValidityLength = 10;
            this.ClassFees = 0;
        }

        clsLicenseClass(int LicenseClassID, string ClassName, string ClassDescription, byte MinAllowedAge,
            byte ValidityLength, decimal ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinAllowedAge = MinAllowedAge;
            this.ValidityLength = ValidityLength;
            this.ClassFees = ClassFees;
        }

        //Create

        //Read
        public static clsLicenseClass GetLicenseClassByID(int LicenseClassID)
        {
            string ClassName = "", ClassDescription = "";
            byte MinAllowedAge = 0, ValidityLenght = 0;
            decimal ClassFees = 0;

            if(clsLicenseClassData.GetLicenseClassByID(LicenseClassID, ref ClassName, ref ClassDescription,
                ref MinAllowedAge, ref ValidityLenght, ref ClassFees))
            {
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinAllowedAge, ValidityLenght,
                    ClassFees);
            }
            else
            {
                return null;
            }
        }

        public static clsLicenseClass GetLicenseClassByName(string ClassName)
        {
            int LicenseClassID = -1;
            string ClassDescription = "";
            byte MinAllowedAge = 0, ValidityLenght = 0;
            decimal ClassFees = 0;

            if (clsLicenseClassData.GetLicenseClassByName(ClassName, ref LicenseClassID, ref ClassDescription,
                ref MinAllowedAge, ref ValidityLenght, ref ClassFees))
            {
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinAllowedAge, ValidityLenght,
                    ClassFees);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }

    }
}

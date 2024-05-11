using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTestType
    {
        enum enMode {AddNew = 0, Update = 1}
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3}

        enMode _Mode;
        public enTestType ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }

        public clsTestType()
        {
            this.ID = enTestType.VisionTest;
            this.Title = "";
            this.Description = "";
            this.Fees = 0;
            _Mode = enMode.AddNew;
        }

        private clsTestType(enTestType TestTypeID, string TestTypeTitle, string TestTypeDescription,
            decimal TestTypeFees)
        {
            this.ID = TestTypeID;
            this.Title = TestTypeTitle;
            this.Description = TestTypeDescription;
            this.Fees = TestTypeFees;
            _Mode = enMode.Update;
        }

        //Read
        public static clsTestType GetTypeTypeByID(enTestType TestTypeID)
        {
            string TestTypeTitle = "", TestTypeDescription = "";
            decimal TestTypeFees = 0;

            bool IsFound = clsTestTypeData.GetTestTypeByID((int)TestTypeID, ref TestTypeTitle, ref TestTypeDescription,
                ref TestTypeFees);

            if (IsFound)
                return new clsTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            else
                return null;

        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();
        }

        //Update
        private bool Update()
        {
            return clsTestTypeData.UpdateTestType((int)this.ID, this.Title, this.Description, this.Fees);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    return true;
                case enMode.Update:
                    return Update();
            }

            return false;
        }

    }
}

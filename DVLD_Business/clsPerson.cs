using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsPerson
    {
        enum enMode { AddNew = 0, Update = 1}

        enMode Mode;
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            }
        }
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public clsCountry Country { get; }
        public string ImagePath { get; set; }

        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";

            Mode = enMode.AddNew;
        }

        clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, byte Gender, string Address, string Phone, 
            string Email, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.Country = clsCountry.GetCountryInfoByID(NationalityCountryID);

            Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName,
                this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.Address, this.Phone,
                this.Email, this.NationalityCountryID, this.ImagePath);

            return (this.PersonID != -1);
        }

        public static clsPerson GetPersonByID(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 0;
            string Address = "", Phone = "", Email = "", ImagePath = "";
            int NationalityCountryID = -1;

            bool IsFound = clsPersonData.GetPersonByID(PersonID, ref NationalNo, ref FirstName,
                ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address,
                ref Phone, ref Email, ref NationalityCountryID, ref ImagePath);

            if (IsFound)
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                    DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }

        public static clsPerson GetPersonByNationalNo(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 0;
            string Address = "", Phone = "", Email = "", ImagePath = "";
            int NationalityCountryID = -1, PersonID = -1;

            bool IsFound = clsPersonData.GetPersonByNationalNo(NationalNo, ref PersonID, ref FirstName,
                ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address,
                ref Phone, ref Email, ref NationalityCountryID, ref ImagePath);

            if (IsFound)
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                    DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        public static bool IsPersonExistsByNationalNo(string NationalNo)
        {
            return clsPersonData.IsPersonExistsByNationalNo(NationalNo);
        }

        private bool _Update()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName,
                this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gender,
                this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
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

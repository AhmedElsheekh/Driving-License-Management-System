using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsUser
    {
        enum enMode { AddNew = 0, Update = 1}

        enMode _Mode;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public clsPerson Person;

        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {
            _Mode = enMode.AddNew;

            this.UserID = -1;
            this.PersonID = -1;
            this.Username = "";
            this.Password = "";
            this.IsActive = false;
        }

        clsUser(int UserID, int PersonID, string Username, string Password, bool IsActive)
        {
            _Mode = enMode.Update;

            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Person = clsPerson.GetPersonByID(PersonID);
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;
        }

        private bool _AddNew()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.Username, this.Password, this.IsActive);

            return this.UserID != -1;
        }

        public static clsUser GetUserInfoByUserID(int UserID)
        {
            string Username = "", Password = "";
            int PersonID = 0;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUserID(UserID, ref PersonID, ref Username, ref Password,
                ref IsActive);

            if (IsFound)
                return new clsUser(UserID, PersonID, Username, Password, IsActive);
            else
                return null;
        }

        public static clsUser GetUserInfoByUsernameAndPassword(string Username, string Password)
        {
            int PersonID = 0, UserID = 0;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUserNameAndPassword(Username, Password, ref UserID, ref PersonID,
                ref IsActive);

            if (IsFound)
                return new clsUser(UserID, PersonID, Username, Password, IsActive);
            else
                return null;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool DoesUserExistByPersonID(int PersonID)
        {
            return clsUserData.DoesUserExistByPersonID(PersonID);
        }

        public static bool IsUserExistsByUsername(string Username)
        {
            return clsUserData.IsUserExiststByUserName(Username);
        }

        private bool _Update()
        {
            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.Username, this.Password, this.IsActive);
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
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

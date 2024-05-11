using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class clsLicenseClassData
    {
        //Create
        
        //Read
        public static bool GetLicenseClassByID(int LiceneClassID, ref string ClassName, ref string ClassDescription,
            ref byte MinAllowedAge, ref byte ValidityLength, ref decimal ClassFees)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select *
                             from LicenseClasses
                             where LicenseClassID = @LicenseClassID;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseClassID", LiceneClassID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    ClassName = (string)Reader["ClassName"];
                    ClassDescription = (string)Reader["ClassDescription"];
                    MinAllowedAge = (byte)Reader["MinimumAllowedAge"];
                    ValidityLength = (byte)Reader["DefaultValidityLength"];
                    ClassFees = (decimal)Reader["ClassFees"];
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }

        public static bool GetLicenseClassByName(string ClassName, ref int LicenseClassID, ref string ClassDescription,
            ref byte MinAllowedAge, ref byte ValidityLength, ref decimal ClassFees)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select *
                             from LicenseClasses
                             where ClassName = @ClassName;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    LicenseClassID = (int)Reader["LicenseClassID"];
                    ClassDescription = (string)Reader["ClassDescription"];
                    MinAllowedAge = (byte)Reader["MinAllowedAge"];
                    ValidityLength = (byte)Reader["ValidityLength"];
                    ClassFees = (decimal)Reader["ClassFees"];
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }

        public static DataTable GetAllLicenseClasses()
        {
            DataTable AllLicenseClasses = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from LicenseClasses";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    AllLicenseClasses.Load(Reader);

                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return AllLicenseClasses;
        }

        //Update
        //Delete
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class clsTestData
    {
        //Create
        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int TestID = -1;


            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"insert into Tests
                             values(@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
                             
                             update TestAppointments
                             set IsLocked = 1
                             where TestAppointmentID = @TestAppointmentID;

                             select Scope_Identity();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            if(string.IsNullOrEmpty(Notes))
                Command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Notes", Notes);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    TestID = ID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return TestID;
        }

        //Read
        public static bool GetTestByID(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes,
            ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select *
                             from Tests
                             where TestID = @TestID;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    TestAppointmentID = (int)Reader["TestAppointmentID"];
                    TestResult = (bool)Reader["TestResult"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];

                    if (Reader["Notes"] != DBNull.Value)
                        Notes = (string)Reader["Notes"];
                    else
                        Notes = "";
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

        public static DataTable GetAllTests()
        {
            DataTable AllTests = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from Tests";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    AllTests.Load(Reader);

                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return AllTests;
        }

        public static bool GetLastTestByPersonTestTypeLicenseClass(int PersonID, int TestTypeID, int LicenseClassID,
            ref int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes,
            ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select top 1 T.*
                        from LocalDrivingLicenseApplications Ld inner join Applications Ap
                        on Ap.ApplicationID = Ld.ApplicationID inner join TestAppointments Ta
                        on Ld.LocalDrivingLicenseApplicationID = Ta.LocalDrivingLicenseApplicationID inner join Tests T
                        on Ta.TestAppointmentID = T.TestAppointmentID
                        where Ap.ApplicantPersonID = @PersonID
                        and Ta.TestTypeID = @TestTypeID
                        and Ld.LicenseClassID = @LicenseClassID
                        order by T.TestAppointmentID desc";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    TestID = (int)Reader["TestID"];
                    TestAppointmentID = (int)Reader["TestAppointmentID"];
                    TestResult = (bool)Reader["TestResult"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];

                    if (Reader["Notes"] != DBNull.Value)
                        Notes = (string)Reader["Notes"];
                    else
                        Notes = "";
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

        //Update
        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult, string Notes,
           int CreatedByUserID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"update Tests
                             set TestAppointmentID = @TestAppointmentID,
                                 TestResult = @TestResult,
                                 Notes = @Notes,
                                 CreatedByUserID = @CreatedByUserID
                             where TestID = @TestID";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID ", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@TestID", TestID);

            if (!string.IsNullOrEmpty(Notes))
                Command.Parameters.AddWithValue("@Notes", Notes);
            else
                Command.Parameters.AddWithValue("@Notes", DBNull.Value);

            try
            {
                Connection.Open();
                RowsAffected = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return RowsAffected > 0;
        }

        //Delete
        public static bool DeleteTest(int TestID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"delete from Tests                           
                             where TestID = @TestID";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                Connection.Open();
                RowsAffected = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return RowsAffected > 0;
        }

    }
}

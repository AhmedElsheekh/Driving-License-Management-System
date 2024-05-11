using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public static class clsLocalDrivingLicenseApplicationData
    {
        //Create
        public static int AddNewLDLApplication(int ApplicationID, int LicenseClassID)
        {
            int LDLApplicationID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"insert into LocalDrivingLicenseApplications
                             values(@ApplicationID, @LicenseClassID);
                             select Scope_Identity();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    LDLApplicationID = ID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return LDLApplicationID;
        }

        //Read
        public static bool GetLocalDrivingLicenseApplicationByID(int LDLApplicationID, ref int ApplicationID,
            ref int LicenseClassID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select *
                             from LocalDrivingLicenseApplications
                             where LocalDrivingLicenseApplicationID = @LDLApplicationID";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    ApplicationID = (int)Reader["ApplicationID"];
                    LicenseClassID = (int)Reader["LicenseClassID"];
   
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

        public static bool GetLocalDrivingLicenseApplicationByApplicationID(int ApplicationID, ref int LDLApplicationID,
              ref int LicenseClassID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select *
                             from LocalDrivingLicenseApplications
                             where ApplicationID = @ApplicationID";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    LDLApplicationID = (int)Reader["LDLApplicationID"];
                    LicenseClassID = (int)Reader["LicenseClassID"];

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

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable AllLDLApplications = new DataTable();


            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from LDLApplicationsView order by ApplicationDate desc";
              

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    AllLDLApplications.Load(Reader);

                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return AllLDLApplications;
        }

        public static bool DoesPassTestType(int LDLApplicationID, int TestTypeID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select top 1 T.TestResult
                            from LocalDrivingLicenseApplications Ld inner join TestAppointments Ta
                            on Ld.LocalDrivingLicenseApplicationID = Ta.LocalDrivingLicenseApplicationID inner join Tests T
                            on Ta.TestAppointmentID = T.TestAppointmentID
                            where Ld.LocalDrivingLicenseApplicationID = @LDLApplicationID
                            and Ta.TestTypeID = @TestTypeID
                            order by Ta.TestAppointmentID desc";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && bool.TryParse(Result.ToString(), out bool Found))
                {
                    IsFound = Found;
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

        public static bool DoesAttendTestAppointment(int LDLApplicationID, int TestTypeID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select Found = 1
                            from Tests T inner join TestAppointments Ta
                            on Ta.TestAppointmentID = T.TestAppointmentID inner join LocalDrivingLicenseApplications L
                            on Ta.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID
                            where Ta.TestTypeID = @TestTypeID
                            and Ta.LocalDrivingLicenseApplicationID = @LDLApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int Found))
                {
                    IsFound = true;
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

        public static byte GetNumberOfPassedTests(int LDLApplicationID)
        {
            byte NumOfPassedTests = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select COUNT(T.TestID)
                            from Tests T inner join TestAppointments Ta
                            on Ta.TestAppointmentID = T.TestAppointmentID inner join LocalDrivingLicenseApplications L
                            on L.LocalDrivingLicenseApplicationID = Ta.LocalDrivingLicenseApplicationID
                            where T.TestResult = 1
                            and Ta.LocalDrivingLicenseApplicationID = @LDLApplicationID";
                        

            SqlCommand Command = new SqlCommand(Query, Connection);
            
            Command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && byte.TryParse(Result.ToString(), out byte Num))
                {
                    NumOfPassedTests = Num;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return NumOfPassedTests;
        }

        public static bool DoesHaveAnActiveTestAppointment(int LDLApplicationID, int TestTypeID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select Found = 1
                            from TestAppointments
                            where LocalDrivingLicenseApplicationID = @LDLApplicationID
                            and TestTypeID = @TestTypeID
                            and IsLocked = 0
                            order by TestAppointmentID desc";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int Found))
                {
                    IsFound = true;
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
        public static bool UpdateLocalDrivingLicenseApplication(int LDLApplicationID, int ApplicationID,
            int LicenseClassID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"update LocalDrivingLicenseApplications
                             set ApplicationID = @ApplicationID,
                                 LicenseClassID = @LicenseClassID
                             where LocalDrivingLicenseApplicationID = @LDLApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            Command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);

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

        public static int TotalTrialsPerTest(int TestTypeID)
        {
            int Trials = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select COUNT(TestTypeID)
                                from TestAppointments
                                where TestTypeID = @TestTypeID
                                and IsLocked = 1";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int Num))
                    Trials = Num;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return Trials;
        }

        //Delete
        public static bool Delete(int LDLApplicationID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"delete from LocalDrivingLicenseApplications                           
                             where LocalDrivingLicenseApplicationID = @LDLApplicationID";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);

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

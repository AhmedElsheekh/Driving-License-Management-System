using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class clsRetakenTestData
    {
        //Create
        public static bool AddNewRetakenTest(int RetakenTestApplicationID, int TestAppointmentID)
        {
            int IsInserted = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"insert into RetakenTests
                             values(@RetakenTestApplicationID, @TestAppointmentID)";
                             
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@RetakenTestApplicationID", RetakenTestApplicationID);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
 
            try
            {
                Connection.Open();
                IsInserted = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return (IsInserted > 0);
        }

        //Read
        public static bool GetRetakenTestByID(int RetakenTestApplicationID, ref int TestAppointmentID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select *
                             from RetakenTests
                             where RetakenTestApplicationID = @RetakenTestApplicationID";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@RetakenTestApplicationID", RetakenTestApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    TestAppointmentID = (int)Reader["TestAppointmentID"];
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
        public static bool UpdateRetakenTest(int RetakenTestApplicationID, int TestAppointmentID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"update RetakenTests
                             set TestAppointmentID = @TestAppointmentID,
                             where RetakenTestApplicationID = @RetakenTestApplicationID";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@RetakenTestApplicationID", RetakenTestApplicationID);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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
        public static bool Delete(int RetakenTestApplicationID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"delete from RetakenTests                          
                             where RetakenTestApplicationID = @RetakenTestApplicationID";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@RetakenTestApplicationID", RetakenTestApplicationID);

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

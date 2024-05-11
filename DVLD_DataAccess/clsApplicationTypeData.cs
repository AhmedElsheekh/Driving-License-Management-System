using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class clsApplicationTypeData
    {
        //Create
        //Read
        public static bool GetApplicationTypeByID(int ApplicationTypeID, ref string ApplicationTypeTitle,
            ref decimal ApplicationFees)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select *
                             from ApplicationTypes
                             where ApplicationTypeID = @ApplicationTypeID;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    ApplicationTypeTitle = (string)Reader["ApplicationTypeTitle"];
                    ApplicationFees = (decimal)Reader["ApplicationFees"];
        
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

        public static DataTable GetAllApplicationTypes()
        {
            DataTable AllApplicationTypes = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from ApplicationTypes order by ApplicationTypeTitle";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    AllApplicationTypes.Load(Reader);

                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return AllApplicationTypes;
        }


        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTypeTitle,
            decimal ApplicationFees)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"update ApplicationTypes
                             set ApplicationTypeTitle = @ApplicationTypeTitle,
                                 ApplicationFees = @ApplicationFees
                             where ApplicationTypeID = @ApplicationTypeID;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            Command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

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

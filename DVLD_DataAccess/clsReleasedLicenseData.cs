using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class clsReleasedLicenseData
    {
        //Create
        public static bool AddNewReleasedLicense(int DetainID, DateTime ReleaseDate, int ReleasedByUserID,
            int ReleaseApplicationID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"insert into ReleasedLicenses
                             values(@DetainID, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID);
                             
                             update DetainedLicenses
                             set IsReleased = 1
                             where DetainID = @DetainID;";
                             
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DetainID", DetainID);
            Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

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

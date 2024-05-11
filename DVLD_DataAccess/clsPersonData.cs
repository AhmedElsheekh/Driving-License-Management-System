using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class clsPersonData
    {
        //Create
        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime BirthDate, byte Gender, string Address, string Phone,
            string Email, int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"insert into People
                            values (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, 
                             @BirthDate, @Gender, @Address, @Phone, @Email, @NationalityCountryID,
                             @ImagePath);
                            select scope_identity();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);

            if (string.IsNullOrWhiteSpace(ThirdName))
                Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);

            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@BirthDate", BirthDate);
            Command.Parameters.AddWithValue("@Gender", Gender);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Phone", Phone);

            if (string.IsNullOrWhiteSpace(Email))
                Command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Email", Email);

            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (string.IsNullOrWhiteSpace(ImagePath))
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if(Result != null && int.TryParse(Result.ToString(), out int Id))
                {
                    PersonID = Id;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return PersonID;
        }

        //Read
        public static bool GetPersonByID(int PersonID, ref string NationalNo, ref string FirstName,
            ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime BirthDate,
            ref byte Gender, ref string Address, ref string Phone, ref string Email, 
            ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select * from People
                             where PersonID = @PersonID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if(reader.Read())
                {
                    IsFound = true;

                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    //ThirdName: allows null in database so we should handle null
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    LastName = (string)reader["LastName"];
                    BirthDate = (DateTime)reader["DateOfBirth"];
                    Gender = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];


                    //Email: allows null in database so we should handle null
                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }

                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    //ImagePath: allows null in database so we should handle null
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }

        public static bool GetPersonByNationalNo(string NationalNo, ref int PersonID, ref string FirstName,
          ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime BirthDate,
          ref byte Gender, ref string Address, ref string Phone, ref string Email,
          ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select * from People
                             where NationalNo = @NationalNo;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    //ThirdName: allows null in database so we should handle null
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    LastName = (string)reader["LastName"];
                    BirthDate = (DateTime)reader["DateOfBirth"];
                    Gender = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];


                    //Email: allows null in database so we should handle null
                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }

                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    //ImagePath: allows null in database so we should handle null
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

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

        public static DataTable GetAllPeople()
        {
            DataTable AllPeople = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                SELECT        People.PersonID,
                              People.NationalNo,
			                  People.FirstName + ' ' + People.SecondName + ' ' + ISNULL(ThirdName, '') + People.LastName as FullName,
			                  People.DateOfBirth,
			                  case
			                      when People.Gendor = 0 then 'Male'
				                  else 'Female'
			                  end as Gender,
			                  People.Address,
			                  People.Phone,
			                  People.Email,
			                  Countries.CountryName,
			                  People.ImagePath
                FROM            People INNER JOIN
                                         Countries ON People.NationalityCountryID = Countries.CountryID;";


            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if(Reader.HasRows)
                {
                    AllPeople.Load(Reader);
                }
                Reader.Close();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return AllPeople;
        }

        public static bool IsPersonExistsByNationalNo(string NationalNo)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select Found = 1 from People
                             where NationalNo = @NationalNo;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if(Result != null)
                {
                    IsFound = true;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }

        //Update
        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime BirthDate, byte Gender, string Address, string Phone,
            string Email, int NationalityCountryID, string ImagePath)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"update People
                             set NationalNo = @NationalNo,
                                 FirstName = @FirstName,
                                 SecondName = @SecondName,
                                 ThirdName = @ThirdName,
                                 LastName = @LastName,
                                 DateOfBirth = @BirthDate,
                                 Gendor = @Gender,
                                 Address = @Address,
                                 Phone = @Phone,
                                 Email = @Email,
                                 NationalityCountryID = @NationalityCountryID,
                                 ImagePath = @ImagePath
                              where PersonID = @PersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);

            if (string.IsNullOrWhiteSpace(ThirdName))
                Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);

            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@BirthDate", BirthDate);
            Command.Parameters.AddWithValue("@Gender", Gender);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Phone", Phone);

            if (string.IsNullOrWhiteSpace(Email))
                Command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Email", Email);

            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (string.IsNullOrWhiteSpace(ImagePath))
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

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

            return (RowsAffected > 0);
        }

        //Delete
        public static bool DeletePerson(int PersonID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"delete People
                             where PersonID = @PersonID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

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

            return (RowsAffected > 0);

        }

    }
}

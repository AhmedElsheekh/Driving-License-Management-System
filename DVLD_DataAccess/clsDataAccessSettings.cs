using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DVLD_DataAccess
{
    public class clsDataAccessSettings
    {
        public static string DbConnectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;

        //public static string ConnectionString = "Server=.;Database=NewDVLD;User Id=sa;Password=sa123456";

        public static string ConnectionString = DbConnectionString;
    }
}

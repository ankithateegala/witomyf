using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using witomyf.API.Interfaces;
using witomyf.API.Models;

namespace witomyf.API.Utilities
{
    public class DBHelper: IDBHelper
    {
        private string connectionString;
        public DBHelper()
        {
            connectionString = @"Server=witomyf-ohio.cdqgdsizulw9.us-east-2.rds.amazonaws.com,1433;Database=witomyf-dev;User Id =admin;Password=adminwitomyfohio;";
        }

        private IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void InsertWitomyf(Witomyf Witomyf)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO WITOMYF (Day, Eat1, Eat2, Eat3, Eat4, Eat5, Eat6, userid)"
                                + " VALUES(@Day, @Eat1, @Eat2, @Eat3, @Eat4, @Eat5, @Eat6, 1)";
                dbConnection.Execute(sQuery, Witomyf);
            }
        }

        public Witomyf GetWitomyf(string day)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT Day, Eat1, Eat2, Eat3, Eat4, Eat5, Eat6 FROM  WITOMYF"
                                + $" WHERE DAY={day}";
                return dbConnection.Query<Witomyf>(sQuery).FirstOrDefault();
            }
        }
    }
}

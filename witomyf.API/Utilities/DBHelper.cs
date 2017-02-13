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
                string updateQuery = "UPDATE WITOMYF SET ";
                if (Witomyf.Eat1 != null) updateQuery += "Eat1 = @Eat1, ";
                if (Witomyf.Eat2 != null) updateQuery += "Eat2 = @Eat2, ";
                if (Witomyf.Eat3 != null) updateQuery += "Eat3 = @Eat3, ";
                if (Witomyf.Eat4 != null) updateQuery += "Eat4 = @Eat4, ";
                if (Witomyf.Eat5 != null) updateQuery += "Eat5 = @Eat5, ";
                if (Witomyf.Eat6 != null) updateQuery += "Eat6 = @Eat6, ";
                updateQuery = updateQuery.Remove(updateQuery.Length - 2); ;
                updateQuery += " WHERE [DAY] = @Day";

                string insertQuery = "INSERT INTO WITOMYF ([DAY], Eat1, Eat2, Eat3, Eat4, Eat5, Eat6, userid)"
                                + " VALUES(@Day, @Eat1, @Eat2, @Eat3, @Eat4, @Eat5, @Eat6, 1)";

                string sQuery = "IF EXISTS (SELECT [DAY] FROM WITOMYF WHERE [DAY] = @Day)" + 
                                updateQuery + 
                                " ELSE " +
                                insertQuery;

                dbConnection.Execute(sQuery, Witomyf);
            }
        }

        public Witomyf GetWitomyf(string day)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT Day, Eat1, Eat2, Eat3, Eat4, Eat5, Eat6 FROM  WITOMYF"
                                + $" WHERE DAY=@day";
                return dbConnection.Query<Witomyf>(sQuery, new { day }).FirstOrDefault();
            }
        }
    }
}

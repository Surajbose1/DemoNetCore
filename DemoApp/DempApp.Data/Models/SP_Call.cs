using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DempApp.Data.Models
{
   public class SP_Call
    {
        private readonly ApplicationDbConnection _db;
        private static string ConnectionString = "";

        public SP_Call(ApplicationDbConnection db)
        {
            _db = db;
            ConnectionString = db.Database.GetDbConnection().ConnectionString;
        }

        public IEnumerable<T> ReturnList<T>(string procedureName)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedureName, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}

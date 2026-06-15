using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using EngineeringToolsCV_1.IRepository;

namespace EngineeringToolsCV_1.Repositories
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            this._connectionString = connectionString;
        }

        //public SqlConnection Create()
        //{
        //   return new SqlConnection(_connectionString);
        //}
    }
}

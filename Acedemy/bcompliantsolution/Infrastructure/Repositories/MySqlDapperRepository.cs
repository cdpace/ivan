using System;
using Infrastructure.Authentication;
using Models;
using MySql.Data.MySqlClient;

namespace Infrastructure.Repositories
{
    public class MySqlDapperRepository<T> : BaseDapperRepository<T> where T : BaseEntity
    {
        public MySqlDapperRepository(string tableName, string connectionString, ISession session) 
            : base(tableName, connectionString, session)
        {
            
        }

        internal override System.Data.IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_connectionString);
            }
        }
    }
}

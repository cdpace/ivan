using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Models;
using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Infrastructure.Repositories
{
    public abstract class BaseDapperRepository<T> : IRepository<T> where T: BaseEntity
    {
        private readonly string _tableName;
        private readonly string _connectionString;

        internal virtual IDbConnection Connection { get; }

        public BaseDapperRepository(string tableName, string connectionString)
        {
            _tableName = tableName;
            this._connectionString = connectionString;
        }

        public async Task Add(T entity)
        {
            using (var connection = Connection)
            {
                connection.Open();
                await connection.InsertAsync(entity);
            }
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

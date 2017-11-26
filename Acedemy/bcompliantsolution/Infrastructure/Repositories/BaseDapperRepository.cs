using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Models;
using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using Infrastructure.Exceptions;
using Infrastructure.Authentication;

namespace Infrastructure.Repositories
{
    public abstract class BaseDapperRepository<T> : IRepository<T> where T: BaseEntity
    {
        private readonly string _tableName;
        private readonly string _connectionString;
        private readonly ISession _session;

        internal virtual IDbConnection Connection { get; }

        public BaseDapperRepository(string tableName, string connectionString, ISession session)
        {
            _tableName = tableName;
            this._connectionString = connectionString;
            _session = session;
        }

        public async Task Add(T entity)
        {
            using (var connection = Connection)
            {
                connection.Open();
                await connection.InsertAsync(entity);
            }
        }

        public async Task Delete(T entity)
        {
            using(var connection = Connection)
            {
                connection.Open();
                await connection.DeleteAsync(entity);
            }
        }

        public async Task DeleteById(long id)
        {
            using(var connection = Connection)
            {
                connection.Open();

                //Get Entity and delete
                var entity = await FindById(id);
                if (entity != null)
                {
                    await connection.DeleteAsync(entity);
                }
                else
                    throw new ObjectNotFoundException("", Guid.NewGuid());

            }
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

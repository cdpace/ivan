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
                    throw new ObjectNotFoundException($"{typeof(T).Name} not found.", _session.CorrelationId);

            }
        }

        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            using(var connection = Connection)
            {
                connection.Open();

                return await connection.GetAllAsync<T>();
            }
        }

        public async Task<T> FindById(long id)
        {
            using(var connection = Connection)
            {
                connection.Open();

                var entity = await connection.GetAsync<T>(id);

                if(entity == null){
                    throw new ObjectNotFoundException($"{typeof(T).Name} not found.", _session.CorrelationId);
                }

                return entity;
            }
        }

        public async Task Update(T entity)
        {
            using(var connection = Connection)
            {
                connection.Open();
                await connection.UpdateAsync(entity);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Models;
using MySql.Data;

namespace Infrastructure.Repositories
{
    public abstract class BaseMySqlRepository<T> : IRepository<T> where T: BaseEntity
    {
        private readonly string _tableName;

        //internal IDbConnection Connection { get; }

        public BaseMySqlRepository(string tableName)
        {
            _tableName = tableName;

        }

        public Task Add(T entity)
        {
            throw new NotImplementedException();
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

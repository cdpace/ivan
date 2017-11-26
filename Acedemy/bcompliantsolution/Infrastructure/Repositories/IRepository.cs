using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task DeleteById(long id);
        Task<T> FindById(long id);
        Task<IEnumerable<T>> FindAll();
        Task<IEnumerable<T>> Find(string query, object parameters);
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Websites.Data.Common
{
    public interface IDbRepository<T> where T : class, BaseEntity
    {
        Task<List<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task<T> Delete(int id);

        IQueryable<T> All();
    }
}

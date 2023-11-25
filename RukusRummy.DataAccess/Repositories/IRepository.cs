using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RukusRummy.DataAccess.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> GetAsync(Guid id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task UpdateAsync(TEntity entity);
        
        Task DeleteAsync(Guid id);
    }
}
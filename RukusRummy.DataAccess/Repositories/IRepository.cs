using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RukusRummy.DataAccess.Entities;

namespace RukusRummy.DataAccess.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> GetAsync(Guid id);

        Task<List<TEntity>> GetRangeAsync(params Guid[] ids);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task UpdateAsync(TEntity entity);
        
        Task DeleteAsync(Guid id);
    }
}
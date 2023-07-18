using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RukusRummy.BusinessLogic.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<Guid> CreateAsync(TEntity entity);

        Task<TEntity> GetAsync(Guid id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task UpdateAsync(TEntity entity);
        
        Task Delete(Guid id);
    }
}
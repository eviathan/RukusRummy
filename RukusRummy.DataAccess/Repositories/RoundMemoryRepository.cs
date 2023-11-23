using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RukusRummy.DataAccess.Models;

namespace RukusRummy.DataAccess.Repositories
{
    public class RoundMemoryRepository : IRepository<Round>
    {
        private List<Round> _rounds { get; set; }

        public RoundMemoryRepository()
        {
            _rounds = new List<Round>();     
        }

        public async Task<Guid> CreateAsync(Round entity)
        {
            _rounds.Add(entity);
            return await Task.FromResult<Guid>(entity.Id);
        }

        public async Task DeleteAsync(Guid id)
        {
            var round = _rounds.FirstOrDefault(round => round.Id == id);

            if(round == null)
                throw new ArgumentOutOfRangeException($"Could not find round with id: {id}");

            _rounds.Remove(round);            
            await Task.Delay(10);
        }

        public async Task<Round> GetAsync(Guid id)
        {
            var round = _rounds.FirstOrDefault(round => round.Id == id);

            if(round == null)
                throw new ArgumentOutOfRangeException($"Could not find round with id: {id}");

            return await Task.FromResult(round);
        }

        public async Task<IEnumerable<Round>> GetAllAsync()
        {
            return await Task.FromResult(_rounds);
        }

        public async Task UpdateAsync(Round entity)
        {
            var index = _rounds.IndexOf(entity);

            if(index == -1)
                throw new ArgumentOutOfRangeException($"Could not find round");

            _rounds[index] = entity;
            await Task.Delay(10);
        }
    }
}
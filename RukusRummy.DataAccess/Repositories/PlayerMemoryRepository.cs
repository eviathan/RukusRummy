using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RukusRummy.DataAccess.Models;

namespace RukusRummy.DataAccess.Repositories
{
    public class PlayerMemoryRepository : IRepository<Player>
    {
        private List<Player> _player { get; set; } = new List<Player>();

        public async Task<Guid> CreateAsync(Player entity)
        {
            _player.Add(entity);
            return await Task.FromResult<Guid>(entity.Id);
        }

        public async Task DeleteAsync(Guid id)
        {
            var player = _player.FirstOrDefault(player => player.Id == id);

            if(player == null)
                throw new ArgumentOutOfRangeException($"Could not find player with id: {id}");

            _player.Remove(player);            
            await Task.Delay(10);
        }

        public async Task<Player> GetAsync(Guid id)
        {
            var player = _player.FirstOrDefault(player => player.Id == id);

            if(player == null)
                throw new ArgumentOutOfRangeException($"Could not find player with id: {id}");

            return await Task.FromResult(player);
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await Task.FromResult(_player);
        }

        public async Task UpdateAsync(Player entity)
        {
            var index = _player.IndexOf(entity);

            if(index == -1)
                throw new ArgumentOutOfRangeException($"Could not find player");

            _player[index] = entity;
            await Task.Delay(10);
        }
    }
}
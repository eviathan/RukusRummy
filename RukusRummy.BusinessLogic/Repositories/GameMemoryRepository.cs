using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RukusRummy.BusinessLogic.Models;

namespace RukusRummy.BusinessLogic.Repositories
{
    // NOTE: This will ultimately be replaced with a repo that stores the games in a database
    public class GameMemoryRepository : IRepository<Game>
    {
        private List<Game> _games { get; set; } = new List<Game>
        {
            // TODO: REMOVE THIS ITS JUST FOR TESTING
            // NOTE: MOVE TO SEEDING AND ONLY IN DEV IF WE WANT TO KEEP IT
            new Game {
                Id = Guid.Empty,
                Name = "Test Room",
                Deck = Guid.Empty,
                AutoReveal = true,
            }
        };

        public async Task<Guid> CreateAsync(Game entity)
        {
            _games.Add(entity);
            return await Task.FromResult<Guid>(entity.Id);
        }      

        public async Task<Game> GetAsync(Guid id)
        {
            var game = _games.FirstOrDefault(game => game.Id == id);

            if(game == null)
                throw new ArgumentOutOfRangeException($"Could not find game with id: {id}");

            return await Task.FromResult(game);
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await Task.FromResult(_games);
        }

        public async Task UpdateAsync(Game entity)
        {
            var index = _games.IndexOf(entity);

            if(index == -1)
                throw new ArgumentOutOfRangeException($"Could not find game");

            _games[index] = entity;
            await Task.Delay(10);
        }

        public async Task DeleteAsync(Guid id)
        {
            var game = _games.FirstOrDefault(game => game.Id == id);

            if(game == null)
                throw new ArgumentOutOfRangeException($"Could not find game with id: {id}");

            _games.Remove(game);            
            await Task.Delay(10);
        }
    }
}
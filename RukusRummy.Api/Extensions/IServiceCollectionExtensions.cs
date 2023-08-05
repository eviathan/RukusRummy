using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RukusRummy.BusinessLogic.Models;
using RukusRummy.BusinessLogic.Repositories;
using RukusRummy.BusinessLogic.Services;

namespace RukusRummy.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<GameService>();
            serviceCollection.AddSingleton<DeckService>();
            serviceCollection.AddSingleton<PlayerService>();

            serviceCollection.AddSingleton<IRepository<Game>, GameMemoryRepository>();
            serviceCollection.AddSingleton<IRepository<Deck>, DeckMemoryRepository>();
            serviceCollection.AddSingleton<IRepository<Player>, PlayerMemoryRepository>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RukusRummy.BusinessLogic;
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
            serviceCollection.AddSingleton<IRepository<Round>, RoundMemoryRepository>();

            serviceCollection.ConfigureAuth();
        }


        private static void ConfigureAuth(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", options => 
                {
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.Cookie.Domain = "localhost";
                    options.Cookie.Path = "/";
                });
        }
    }
}
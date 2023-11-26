using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RukusRummy.BusinessLogic.Services;
using RukusRummy.DataAccess;
using RukusRummy.DataAccess.Entities;
using RukusRummy.DataAccess.Repositories;

namespace RukusRummy.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.ConfigureDatabase();

            serviceCollection.AddScoped<GameService>();
            serviceCollection.AddScoped<DeckService>();
            serviceCollection.AddScoped<PlayerService>();

            serviceCollection.AddScoped<IRepository<Game>, GameRepository>();
            serviceCollection.AddScoped<IRepository<Deck>, DeckRepository>();
            serviceCollection.AddScoped<IRepository<Player>, PlayerRepository>();
            serviceCollection.AddScoped<IRepository<Round>, RoundRepository>();
            serviceCollection.AddScoped<IRepository<Vote>, VoteRepository>();

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

        private static void ConfigureDatabase(this IServiceCollection serviceCollection)
        {
            // TODO: Swap this out for SQL if need be
            serviceCollection.AddDbContext<RukusRummyDbContext>(options => 
                options.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=Password123!;Include Error Detail=true;")
            );
        }
    }
}
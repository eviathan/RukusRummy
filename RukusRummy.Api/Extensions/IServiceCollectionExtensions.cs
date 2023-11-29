using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RukusRummy.BusinessLogic.Models;
using RukusRummy.BusinessLogic.Services;
using RukusRummy.DataAccess;
using RukusRummy.DataAccess.Entities;
using RukusRummy.DataAccess.Repositories;
using Microsoft.AspNetCore.Http;

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

        public static IServiceCollection SetupAccessManagement(this IServiceCollection services)        
        {
            services.AddScoped<IPlayer>(ctx =>
            {
                var httpContext = ctx.GetRequiredService<IHttpContextAccessor>();
                var playerId = httpContext?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (playerId == null || !Guid.TryParse(playerId, out Guid id))
                {
                    return new LoggedOutPlayer();
                }

                try
                {
                    return new AuthenticatedPlayer(ctx.GetRequiredService<PlayerService>(), id);
                }
                catch (InvalidOperationException ex)
                {
                    httpContext?.HttpContext?.Response.Redirect("/");
                    return new LoggedOutPlayer();
                }
            });

            return services;
        }
    }
}
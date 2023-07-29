using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using RukusRummy.Api.Extensions;
using RukusRummy.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddServices();

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();


if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger(c => {
        //change the path to include /api
        c.RouteTemplate = "/api/swagger/{documentName}/swagger.json";
    });

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
    // specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        //Notice the lack of / making it relative
        c.SwaggerEndpoint("swagger/v1/swagger.json", "My API V1");
        //This is the reverse proxy address
        c.RoutePrefix = "api";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHub<GameHub>("/gamehub");

app.MapControllers();

app.Run("http://*:5001");

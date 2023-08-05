using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using RukusRummy.Api.Extensions;
using RukusRummy.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CORSPolicy", policy  =>
        {
            policy
                .WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader();
        }
    );
});

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
app.UseCors("CORSPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHub<GameHub>("/gamehub");

app.MapControllers();

// app.Run("http://*:5001");
app.Run("http://localhost:5001");

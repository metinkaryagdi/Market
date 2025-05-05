using Application.Features.Queries.UserQueries;
using Application.Mapping;
using Domain.Interfaces;
using Microsoft.OpenApi.Models;
using Persistance.Context;
using Persistance.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// CORS servislerini ekleyin
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Herhangi bir kaynağa izin verir
              .AllowAnyMethod()  // Herhangi bir HTTP metoduna izin verir
              .AllowAnyHeader();  // Herhangi bir header'a izin verir
    });
});

// Add services to the container.
builder.Services.AddDbContext<MarketContext>();

// MediatR için assembly kaydını yapın
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUserByIdQuery).Assembly));

// AutoMapper profil dosyalarını ekleyin
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddAutoMapper(typeof(ProductProfile));

// Repositories ekleyin
builder.Services.AddRepositories();

// Controllers'ları ekleyin
builder.Services.AddControllers();

// Swagger için gerekli yapılandırmalar
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "MyApi", Version = "v1" });
});

var app = builder.Build();

// CORS politikasını uygulayın
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "MyApi v1");
        x.RoutePrefix = string.Empty;  // Swagger UI'yi otomatik olarak açmak için
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

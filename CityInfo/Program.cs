using AutoMapper;
using CityInfo.Models;
using CityInfo.Repositories;
using CityInfo.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new CityInfo.MappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


var formatSettings = builder.Configuration.GetSection("ExternalApiSettings").Get<ExternalApiSettings>();
builder.Services.Configure<ExternalApiSettings>(builder.Configuration.GetSection("ExternalApiSettings"));

var conex = builder.Configuration.GetConnectionString("DbConnection");

// Registro del Contexto de datos como Servicio
builder.Services.AddDbContext<SerbadTestContext>(options =>
   options.UseSqlServer(conex));

builder.Services.AddHttpClient();
builder.Services.AddHttpClient("NewsApi", client =>
{
    client.BaseAddress = new Uri(formatSettings.NewsApi.BaseUrl);
});

builder.Services.AddHttpClient("OpenWeather", client =>
{
    client.BaseAddress = new Uri(formatSettings.OpenWeather.BaseUrl);
});

builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IHistoryService, HistorySservice>();
builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options
              .AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


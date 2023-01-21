﻿using CityInfo.Models;
using CityInfo.Services.NewsService;
using CityInfo.Services.WeatherService;
using CityInfo.Services.CountryService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var formatSettings = builder.Configuration.GetSection("ExternalApiSettings").Get<ExternalApiSettings>();
builder.Services.Configure<ExternalApiSettings>(builder.Configuration.GetSection("ExternalApiSettings"));

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


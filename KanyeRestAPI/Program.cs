using KanyeRestAPI.Refit;
using KanyeRestAPI.Service;
using KanyeRestAPI.Service.Interface;
using Microsoft.OpenApi.Models;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "Api do Kanye West",
        Description = "Api que gera falas aleatórias do Kanye West",
        Contact = new OpenApiContact
        {
            Name = "Foqsz",
            Email = "foqsgt09@gmail.com",
            Url = new Uri("https://foqsz.github.io/"),
        }
    });
    s.EnableAnnotations();
});

builder.Services.AddScoped<IKanyeRestService, KanyeRestService>();  

builder.Services.AddRefitClient<IKanyeRestRefit>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri("https://api.kanye.rest/");
});

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

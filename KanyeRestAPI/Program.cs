using KanyeRestAPI.Refit;
using KanyeRestAPI.Service;
using KanyeRestAPI.Service.Interface;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

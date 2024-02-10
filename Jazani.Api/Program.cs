using Jazani.Application.Admins.Dtos.AreaTypes.Profiles;
using Jazani.Application.Admins.Services;
using Jazani.Application.Admins.Services.Implementations;
using Jazani.Infrastructure.Cores.Contexts;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Infrastructure
builder.Services.AddInfrastructureServices(builder.Configuration);


// Application
builder.Services.AddTransient<IAreaTypeService, AreaTypeService>();


// Automapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<AreaTypeProfile>();
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


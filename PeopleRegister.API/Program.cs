using Microsoft.EntityFrameworkCore;
using PeopleRegister;
using PeopleRegister.API.AutoMapper;
using PeopleRegister.Contracts.Repository;
using PeopleRegister.Contracts.Service;
using PeopleRegister.Data.Repository;
using PeopleRegister.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddScoped<IPhoneService, PhoneService>();
builder.Services.AddScoped<IPhoneRepository, PhoneRepository>();



ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
IConfiguration configuration = configurationBuilder.AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(configuration["ConnectionStrings:MiConectionDB"])
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging();
});

builder.Services.AddAutoMapper(typeof(MappingConfig));



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//modificacion de Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
            {
                app.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
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

//para Cors
app.UseCors("NuevaPolitica");

app.Run();

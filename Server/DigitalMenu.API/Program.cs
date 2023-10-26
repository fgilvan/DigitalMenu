using DigitalMenu.Application.Common.Automapper;
using DigitalMenu.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments(xmlPath);
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "DigitalMenu",
            Description = "Simples API em .NET 7",
            Version = "v1",
            Contact = new OpenApiContact()
            {
                Name = "Gilvan Jacó Filho",
                Url = new Uri("https://github.com/fgilvan"),
            }
        });
});

builder.Services.AddHealthChecks();
builder.Services.AddMvc();
builder.Services.AddInfrastructServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using goapp.application.Configuration;
using goapp.application.Data;
using goapp.application.dto;
using goapp.infrastructure.Data;
using goapp.webApi.Router;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IGoAppDbContext, GoAppDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("AppGoConnection")));
builder.Services.Configure<EncryptionSettings>(
builder.Configuration.GetSection("EncryptionSettings"));
builder.Services.AddMediatR(typeof(Result));

var originsAlloweds = builder.Configuration.GetValue<string>("OriginsAlloweds")!.Split(",");
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(polity =>
    {
        polity.WithOrigins(originsAlloweds).AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty; // Hace que Swagger sea accesible desde la raíz (opcional)
    });
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapLogin();
app.MapUser();
app.MapShippingQuote();
app.MapDestination();

app.Run();

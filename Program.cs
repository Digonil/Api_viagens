using GerenciamentoViagens.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ViagensConnection");

builder.Services.AddDbContext<ViagensContext>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddCors(opts => 
{
   opts.AddPolicy(MyAllowSpecificOrigins, builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();



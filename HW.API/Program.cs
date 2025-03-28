using HW.Application;
using HW.Jwt;
using HW.Persistence;
using HW.Persistence.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddJwtAuth(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
using Amazon.S3;
using HW.API.Filters;
using HW.API.Middlewares;
using HW.Application;
using HW.Jwt;
using HW.Persistence;
using HW.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAWSService<IAmazonS3>();

builder.Services.AddControllers();

builder.Services
    .AddDatabase(builder.Configuration)
    .AddServices(builder.Configuration)
    .AddJwtAuth(builder.Configuration);
builder.Services.AddScoped<CanChangeAccountFilter>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "HiringWokers API",
        Version = "v1"
    });

    config.EnableAnnotations();
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactOrigin", builder =>
        builder.WithOrigins("http://localhost:5173")
               .AllowCredentials()
               .AllowAnyMethod()
               .AllowAnyHeader());
});
var app = builder.Build();

app.UseCors("AllowReactOrigin");
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}


app.MapControllers();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
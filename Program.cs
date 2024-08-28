using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.interfaces;
using Tunify_Platform.Repositories.Services;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddControllers();
//string connectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<TunifyDbContext>(optionsx => optionsx.UseSqlServer(connectionStringVar));
// Configure JSON options to handle object cycles
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;




builder.Services.AddDbContext<TunifyDbContext>(optionsX => optionsX.UseSqlServer(ConnectionString));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<TunifyDbContext>();

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    .AddEntityFrameworkStores<TunifyDbContext>()
//    .AddSignInManager<SignInManager<ApplicationUser>>();



//builder.Services.AddTransient<IEmployee, EmployeeService>();
builder.Services.AddScoped<Iuser, UserServices>();
builder.Services.AddScoped<ISong, SongServices>();
builder.Services.AddScoped<Iplaylist, PlayListServices>();
builder.Services.AddScoped<Iartist, ArtistServices>();
builder.Services.AddScoped<IAuthentication, AuthenticationService>();
builder.Services.AddScoped<JwtService>();

builder.Services.AddAuthentication(
              options =>
              {
                  options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              }
              ).AddJwtBearer(
              options =>
              {
                  options.TokenValidationParameters = JwtService.ValidateToken(builder.Configuration);
              });


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Tunify API",
        Version = "v1",
        Description = "API for managing playlists, songs, and artists in the Tunify Platform"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Please enter user token below."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

});
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();


app.UseSwagger(
             options =>
             {
                 options.RouteTemplate = "api/{documentName}/swagger.json";
             }
);


app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/api/v1/swagger.json", "Tunify API v1");
    options.RoutePrefix = "";
});
app.MapControllers();




app.MapGet("/", () => "Hello World!");

app.Run();


using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Tunify API",
        Version = "v1",
        Description = "API for managing playlists, songs, and artists in the Tunify Platform"
    });
});
var app = builder.Build();

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


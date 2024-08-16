using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Tunify_Platform.Data;
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
//builder.Services.AddTransient<IEmployee, EmployeeService>();
builder.Services.AddScoped<Iuser, UserServices>();
builder.Services.AddScoped<ISong, SongServices>();
builder.Services.AddScoped<Iplaylist, PlayListServices>();
builder.Services.AddScoped<Iartist, ArtistServices>();

var app = builder.Build();
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();


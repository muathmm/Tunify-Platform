using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Repositories.interfaces;
using Tunify_Platform.Repositories.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
string connectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TunifyDbContext>(optionsx => optionsx.UseSqlServer(connectionStringVar));
//builder.Services.AddTransient<IEmployee, EmployeeService>();
builder.Services.AddScoped<Iuser, UserServices>();
builder.Services.AddScoped<ISong, SongServices>();
builder.Services.AddScoped<Iplaylist, PlayListServices>();
builder.Services.AddScoped<Iartist, ArtistServices>();

var app = builder.Build();
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();


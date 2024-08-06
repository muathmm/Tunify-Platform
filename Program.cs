using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;

var builder = WebApplication.CreateBuilder(args);

string connectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TunifyDbContext>(optionsx => optionsx.UseSqlServer(connectionStringVar));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();


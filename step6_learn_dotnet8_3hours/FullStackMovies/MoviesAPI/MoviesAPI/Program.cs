using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Endpoints;

//factory pattern
var builder = WebApplication.CreateBuilder(args);

//Register DB Context Service (inject dependency services away from here)
//DI to do: Registering the DbContext as service in app services collection configured with the db connection string
// (gets conn string dotnet user-sercerts or .json or env var ...)
var connString = builder.Configuration.GetConnectionString("MoviesDbCS");
builder.Services.AddDbContext<MovieContext>(options => options.UseSqlServer(connString));

//this line is an example of builder pattern != factory pattern
var app = builder.Build(); //build after configuer dont configure after build✅

app.DbMigrate(); //user extension methos

app.MapGet("/", () => "Hello World!");

app.MapMoviesEndpoints(); //user extension method


app.Run();
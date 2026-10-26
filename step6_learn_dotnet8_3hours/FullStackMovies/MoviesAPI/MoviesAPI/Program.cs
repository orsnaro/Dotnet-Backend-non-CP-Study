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
var app = builder.Build();

//Resolution of DB context service
//create temp DI scope to use/Resolve the ALREADY registered db context service MovieContext (manual DI and resolution)
await using (var scope = app.Services.CreateAsyncScope()){ //you can use CreateScope() also

    //prepare a provider that will get us the service we registered before!
    var services = scope.ServiceProvider;

    try{
        //resloution: resolve the serivce (inject dependenct into HERE )
        var dbContext = services.GetRequiredService<MovieContext>();

        //use the service after you resolved/got it

        //this will work fine with either CreateAsyncScope() or CreateScope()
        await dbContext.Database.MigrateAsync();

    } catch (Exception ex) {
        Console.Error.WriteLine(ex.ToString());
        throw;
    }
}



app.MapGet("/", () => "Hello World!");
app.MapMoviesEndpoints();


app.Run();
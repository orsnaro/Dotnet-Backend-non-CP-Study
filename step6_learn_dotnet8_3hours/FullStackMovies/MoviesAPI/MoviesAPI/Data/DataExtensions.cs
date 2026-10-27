using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Data;

public static class DataExtensions
{
    //Resolution of DB context service
    //creates temp DI scope to use/Resolve the ALREADY registered db context service MovieContext (manual DI and resolution)
    public static async void DbMigrate(this WebApplication app)
    {
        await using (var scope = app.Services.CreateAsyncScope())
        {

            //prepare a provider that will get us the service we registered before!
            var serviceProvider = scope.ServiceProvider;

            try
            {
                //resloution: resolve the serivce (inject dependenct into HERE )
                //GetService() can return null but GetRequiredService<>() raises exception if service not found(fail fast) !
                var dbContext = serviceProvider.GetRequiredService<MovieContext>();

                //use the service after you resolved/got it
                //this will work fine with either CreateAsyncScope() or CreateScope()
                await dbContext.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw;
            }
        }
    }
}

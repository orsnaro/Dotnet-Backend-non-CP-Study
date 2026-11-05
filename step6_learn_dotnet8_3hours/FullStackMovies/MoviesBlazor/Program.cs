using MoviesBlazor.Clients;
using MoviesBlazor.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();


//get the api base url variable i.e.(address) from env variable or appsettings.json file
string movieAPIURL = builder.Configuration["MoviesAPIURL"] ?? throw new Exception("Movies API URL is not set");

//DI the MoviesClient with right base addr  urin to app services
builder.Services.AddHttpClient<MoviesClient>(client => client.BaseAddress = new Uri(movieAPIURL));
builder.Services.AddHttpClient<GenresClient>(client => client.BaseAddress = new Uri(movieAPIURL));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();

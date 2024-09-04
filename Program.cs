using Microsoft.Extensions.DependencyInjection;
using RecordOfTasks.Components;
using RecordOfTasks.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register the DatabaseService with the correct connection string
var connectionString = "Data Source=Data/mydatabase.db";
builder.Services.AddScoped<DatabaseService>(provider => new DatabaseService(connectionString));

var app = builder.Build();

// Initialize the database when the application starts
using (var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<DatabaseService>();
    await initializer.InitializeDatabaseAsync();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

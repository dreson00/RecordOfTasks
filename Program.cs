using Microsoft.Extensions.DependencyInjection;
using RecordOfTasks.Components;
using RecordOfTasks.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register the DatabaseService with the correct connection string

// Databáze by měla v solution struktuře být jako projekt zvlášť vedle samotné webové aplikace.

// Connection string patří do appsettings.json, aby šel kdykoliv změnit v tomhle konfiguračním souboru.
// Doporučuji vyhledat dokumentaci k použití appsettings.json
var connectionString = "Data Source=Data/mydatabase.db";

// Celé řešení databáze je zbytečně překomplikované, když jde použít Entity Framework (EF), který je jednoduší na použití a hlavně nativní.
// Databáze z EF se pak přidává vlastní metodou, která vypadá nějak jako AddDbContext podle použité knihovny.
builder.Services.AddScoped<DatabaseService>(provider => new DatabaseService(connectionString));

var app = builder.Build();

// Initialize the database when the application starts
using (var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<DatabaseService>();

    // Inicializace databáze by se měla udělat pomocí migrace.
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

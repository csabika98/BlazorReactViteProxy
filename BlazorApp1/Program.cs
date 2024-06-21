using BlazorApp1.Components;


var options = new WebApplicationOptions
{
    // Set the content root to the parent of the current directory since you're in ClientApp
    ContentRootPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..")),
    // Set the web root to the wwwroot directory located in the parent directory
    WebRootPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "wwwroot")),
    Args = args
};

var builder = WebApplication.CreateBuilder(options);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
// Ensure static files are being served
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Log the actual paths being used to verify they are correct
//Console.WriteLine($"Content Root Path: {app.Environment.ContentRootPath}");
Console.WriteLine($"Web Root Path: {app.Environment.WebRootPath}");

app.Run();
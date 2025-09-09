// budowa
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();
//

// konfiguracja
app.UseStaticFiles();
app.MapDefaultControllerRoute();
//

//app.MapGet("/", () => "Hello World!");

app.Run();

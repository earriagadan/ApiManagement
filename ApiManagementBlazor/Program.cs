using ApiManagementBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<ListarMicroserviciosService>();
builder.Services.AddScoped<ListarMicroserviciosService>();

builder.Services.AddSingleton<ListarGTWService>();
builder.Services.AddScoped<ListarGTWService>();

builder.Services.AddSingleton<DetalleMicroservicioService>();
builder.Services.AddScoped<DetalleMicroservicioService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

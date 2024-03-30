using ApplicationGestionFonciers.API.config;
using ApplicationGestionFonciers.API.context;
using ApplicationGestionFonciers.API.Services;

var builder = WebApplication.CreateBuilder(args);

var build = new ConfigurationBuilder();
build.AddJsonFile("appsettings.json");
var settings=build.Build();

builder.Services.Configure<DbContextSettings>(settings);
builder.Services.AddScoped<IDbContextGestion, DbContextGestion>();
builder.Services.AddScoped<IUtilisateurService , UtilisateurService>();


builder.Services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddCors(option =>
{
    option.AddPolicy("MyPolicy", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();

    });
    
});



builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseCors("MyPolicy");

app.UseRouting();


app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();


app.Run();

using WhatsAppTriviaApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(40);
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpClient();
builder.Services.AddScoped<TriviaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSession();

app.MapControllers();

app.Run();

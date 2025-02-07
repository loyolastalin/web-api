var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string _environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
builder.Configuration.AddJsonFile("appsettings.json", true)
                    .AddJsonFile($"appsettings.{_environmentName}.json", true)
                    .AddJsonFile("/app/configmap/appsettings.configmap.json", true, true)
                    .AddJsonFile("/app/secrets/appsettings.secrets.json", true, true)
                    // Override configuration by environment, using like Logging:Level or Logging__Level
                    .AddEnvironmentVariables();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

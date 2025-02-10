// using Prometheus;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddOpenTelemetry()
    .WithMetrics(static metrics =>
    {
        metrics
            .AddMeter("Microsoft.AspNetCore.Hosting")
            .AddMeter("Microsoft.AspNetCore.Server.Kestrel")
            .AddMeter("Microsoft.AspNetCore.Diagnostics")
            .AddMeter("Microsoft.AspNetCore.Http.Connections")
              .AddMeter("Microsoft.AspNetCore.Diagnostics")
            .AddMeter("Microsoft.AspNetCore.RateLimiting")
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("MyAspNetCoreApp"))
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddPrometheusExporter();  // ✅ Correct way to add Prometheus Exporter
    });

var app = builder.Build();

//var counter = Metrics.CreateCounter("api_requests_total", "Total API requests");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseMetricServer();

// //adding metrics related to HTTP
// app.UseHttpMetrics(options =>
// {
//     options.AddCustomLabel("host", context => context.Request.Host.Host);
// });

app.UseOpenTelemetryPrometheusScrapingEndpoint();

app.MapGet("/", () =>
{
   // counter.Inc();
    return "Hello World!";
});
app.UseAuthorization();

app.MapControllers();


app.Run();

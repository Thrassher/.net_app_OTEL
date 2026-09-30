using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

var serviceName =
    Environment.GetEnvironmentVariable("OTEL_SERVICE_NAME")
    ?? "dotnet-test-app";

builder.Services.AddHttpClient();

builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource =>
        resource.AddService(serviceName))

    // =========================
    // TRACING
    // =========================
    .WithTracing(tracing =>
    {
        tracing
            // Incoming ASP.NET Core HTTP requests
            .AddAspNetCoreInstrumentation()

            // Outgoing HttpClient requests
            .AddHttpClientInstrumentation()

            // TEMPORARY: print spans to container logs
            .AddConsoleExporter()

            // Send spans to CodeXray through OTLP
            .AddOtlpExporter();
    })

    // =========================
    // METRICS
    // =========================
    .WithMetrics(metrics =>
    {
        metrics
            // ASP.NET Core metrics
            .AddAspNetCoreInstrumentation()

            // HttpClient metrics
            .AddHttpClientInstrumentation()

            // .NET runtime metrics
            .AddRuntimeInstrumentation()

            // Send metrics to CodeXray through OTLP
            .AddOtlpExporter();
    });

var app = builder.Build();

// =========================
// BASIC ENDPOINT
// =========================

app.MapGet("/", () =>
    "DotNetOtelQA is running");

// =========================
// HEALTH ENDPOINT
// =========================

app.MapGet("/health", () =>
    Results.Ok(new { status = "healthy" }));

// =========================
// SLOW REQUEST
// =========================

app.MapGet("/slow", async () =>
{
    await Task.Delay(5000);

    return "Slow request completed";
});

// =========================
// ERROR REQUEST
// =========================

app.MapGet("/error", () =>
{
    throw new Exception("Simulated application error");
});

// =========================
// OUTBOUND HTTP REQUEST
// =========================

app.MapGet("/outbound", async (
    IHttpClientFactory factory) =>
{
    var client = factory.CreateClient();

    var response = await client.GetAsync(
        "https://example.com");

    return Results.Ok(new
    {
        status = (int)response.StatusCode
    });
});

app.Run();

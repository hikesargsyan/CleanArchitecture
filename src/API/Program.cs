
using App.API.Infrastructure;
using App.Application;
using App.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddApplicationServices();
builder.AddInfrastructureServices();
builder.AddWebServices();

var app = builder.Build();

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseExceptionHandler(options => { });

app.MapDefaultEndpoints();
app.MapEndpoints();

app.Run();

public partial class Program
{
}

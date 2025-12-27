using Practice.DesignPattern.Structural.Adapter;
using Practice.DesignPattern.Structural.Bridge.Pattern;
using Practice.DesignPattern.Structural.Decorator.Normal;
using Practice.DesignPattern.Structural.Decorator.Pattern;
using Practice.DesignPattern.Structural.Facade;
using Practice.DesignPattern.Structural.Facade.Normal;
using Practice.DesignPattern.Structural.Facade.Pattern;
using Practice.DesignPattern.Structural.Flyweight.Pattern;
using Practice.DesignPattern.Structural.Proxy;
using Practice.DesignPattern.Structural.Proxy.Normal;
using Practice.DesignPattern.Structural.Proxy.Pattern;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Thêm Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//DI Adapter Pattern
builder.Services.AddSingleton<IReportData, ReportDataService>();
builder.Services.AddSingleton<IReportDataOverview, ReportDataAdapter>();

//DI Bridge Pattern
builder.Services.AddSingleton<DeviceAction>();

//DI Decorator Pattern
builder.Services.AddSingleton<IReportDataV2, ReportDataV2>();
builder.Services.AddSingleton<Practice.DesignPattern.Structural.Decorator.IReportData>(provider =>
{
    Practice.DesignPattern.Structural.Decorator.IReportData baseService = new Practice.DesignPattern.Structural.Decorator.ReportDataService();

    // Decorator: Caching -> Retry -> Logging
    baseService = new ReportDataCacheDecorator(baseService);
    baseService = new ReportDataRetryDecorator(baseService);
    baseService = new ReportDataCatchDecorator(baseService);

    return baseService;
});
//DI Facde Pattern
builder.Services.AddSingleton<ISmartHouse, SmartHouse>();
builder.Services.AddSingleton<ISmartHouseFacade, SHouseFacade>();

//DI Flyweight Pattern
builder.Services.AddSingleton<GachFlyweightFactory>();
//DI Proxy Pattern
builder.Services.AddSingleton<IService, RealService>();
//builder.Services.AddSingleton<RealService>();
//builder.Services.AddSingleton<IService, ServiceProxy>();

// Logging for decorators (built-in)
builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger(opt =>
{
    opt.RouteTemplate = "/api/structural" + "/swagger/{documentName}/swagger.json";
});
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "/api/structural".TrimStart('/') + "/swagger";
    c.SwaggerEndpoint("/api/structural" + "/swagger/v1/swagger.json", "API v1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

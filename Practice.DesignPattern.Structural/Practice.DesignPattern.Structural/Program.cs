using Practice.DesignPattern.Structural.Adapter;
using Practice.DesignPattern.Structural.Bridge.Pattern;
using Practice.DesignPattern.Structural.Decorator.Normal;
using Practice.DesignPattern.Structural.Decorator.Pattern;
using Practice.DesignPattern.Structural.Facade.Contract;
using Practice.DesignPattern.Structural.Facade.Data;
using Practice.DesignPattern.Structural.Flyweight.DTO;
using Practice.DesignPattern.Structural.Proxy.Contracts;

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
builder.Services.AddSingleton<IInventoryService, InventoryService>();
builder.Services.AddSingleton<INotificationService, NotificationService>();
builder.Services.AddSingleton<IPaymentService, PaymentService>();
builder.Services.AddSingleton<IShippingService, ShippingService>();
//DI Flyweight Pattern
builder.Services.AddSingleton<BuildingFlyweightFactory>();
//DI Proxy Pattern
builder.Services.AddSingleton<Practice.DesignPattern.Structural.Proxy.Contracts.IOrderService, Practice.DesignPattern.Structural.Proxy.Contracts.OrderService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<OrderServiceProxy>();
builder.Services.AddTransient<IOrderServiceProxy>(provider =>
{
    IOrderServiceProxy service = provider.GetRequiredService<OrderServiceProxy>();
    service = new AuthorizationOrderServiceProxy(service,
             provider.GetRequiredService<IHttpContextAccessor>());
    service = new LoggingOrderServiceProxy(service,
             provider.GetRequiredService<ILogger<LoggingOrderServiceProxy>>());
    service = new RetryOrderServiceProxy(service);
    return service;
});

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

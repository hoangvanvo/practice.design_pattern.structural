using Practice.DesignPattern.Structural.BigDemo.Contracts;
using Practice.DesignPattern.Structural.BigDemo.Data.Facade;
using Practice.DesignPattern.Structural.BigDemo.Data.Factory;
using Practice.DesignPattern.Structural.BigDemo.Data.Resolver;
using Practice.DesignPattern.Structural.BigDemo.Infrastructure;
using Practice.DesignPattern.Structural.Bridge.DesignPattern;
using Practice.DesignPattern.Structural.Facade.Contract;
using Practice.DesignPattern.Structural.Facade.Data;
using Practice.DesignPattern.Structural.Proxy.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Thêm Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI Bridge Pattern
builder.Services.AddSingleton<LoggerFactory>();
builder.Services.AddSingleton<PaymentFactory>();
//DI Decorator Pattern
builder.Services.AddSingleton<Practice.DesignPattern.Structural.Decorator.Basic.IOrderService, Practice.DesignPattern.Structural.Decorator.Basic.OrderService>();
builder.Services.AddSingleton<Practice.DesignPattern.Structural.Decorator.DesignPattern.IOrderService, Practice.DesignPattern.Structural.Decorator.DesignPattern.OrderService>();
//DI Facde Pattern
builder.Services.AddSingleton<IInventoryService, InventoryService>();
builder.Services.AddSingleton<INotificationService, NotificationService>();
builder.Services.AddSingleton<IPaymentService, PaymentService>();
builder.Services.AddSingleton<IShippingService, ShippingService>();
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

//DI FOR BIG DEMO
// Infrastructure
builder.Services.AddSingleton<StripeClient>();
builder.Services.AddSingleton<PaypalClient>();
builder.Services.AddSingleton<Practice.DesignPattern.Structural.BigDemo.Infrastructure.RateLimiter>();
// Factories (register each concrete factory)
builder.Services.AddTransient<StripeFactory>();
builder.Services.AddTransient<PaypalFactory>();
// Register the factories as the interface so resolver can get all
builder.Services.AddTransient<IPaymentProviderFactory>(sp => sp.GetRequiredService<StripeFactory>());
builder.Services.AddTransient<IPaymentProviderFactory>(sp => sp.GetRequiredService<PaypalFactory>());
// Register resolver and facade
builder.Services.AddSingleton<PaymentFactoryResolver>();
builder.Services.AddScoped<PaymentFacade>();
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

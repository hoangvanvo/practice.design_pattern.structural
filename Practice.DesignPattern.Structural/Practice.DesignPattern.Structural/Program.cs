using Practice.DesignPattern.Structural.Bridge.DesignPattern;

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

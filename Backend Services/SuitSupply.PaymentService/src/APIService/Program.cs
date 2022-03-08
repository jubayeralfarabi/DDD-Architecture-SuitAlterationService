using SuitSupply.Infrastructure.ServiceBus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationInsightsTelemetry();

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
builder.Services.Configure<BusSettings>(configuration.GetSection("BusSettings"));
builder.Services.AddScoped<IBusMessagePublisher, BusMessagePublisher>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

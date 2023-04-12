using CdcApi;
using EventBus.Kafka.Abstraction;
using EventBus.Kafka.KafkaHandlers;
using Microsoft.EntityFrameworkCore;
using Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};Encrypt=False;TrustServerCertificate=False;";
builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddKafkaConsumer<string, CdcMessageHandler>(
                        KafkaSettings.Topics.ContractsTopicName,
                        KafkaSettings.Groups.GroupId);

//builder.Services.AddHostedService<Worker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

using Amazon.SQS;
using Sqs.Api.Messaging;
using Sqs.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<QueueSettings>(builder.Configuration.GetSection(nameof(QueueSettings)));
builder.Services.AddSingleton<IAmazonSQS, AmazonSQSClient>();
builder.Services.AddSingleton<ISqsMessager, SqsMessager>();

builder.Services.AddScoped<MessageService>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();

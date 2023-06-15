using Amazon.SQS;
using Sqs.Consumer.Configs;
using Sqs.Consumor.Console;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.Configure<QueueSettings>(builder.Configuration.GetSection(nameof(QueueSettings)));

builder.Services.AddSingleton<IAmazonSQS, AmazonSQSClient>();
builder.Services.AddHostedService<QueueConsumerService>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); 

app.Run();

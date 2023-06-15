using Amazon.SQS;
using Amazon.SQS.Model;
using MediatR;
using Microsoft.Extensions.Options;
using Sqs.Consumer.Configs;
using Sqs.Consumer.Models;
using System.Text.Json;

namespace Sqs.Consumor.Console
{
    public class QueueConsumerService : BackgroundService
    {
        private readonly IAmazonSQS _sqs;
        private readonly IOptions<QueueSettings> _queueSettings;
        private readonly IMediator _mediator;
        private readonly ILogger<QueueConsumerService> _logger;
        private string? _queueUrl;

        public QueueConsumerService(IAmazonSQS sqs, IOptions<QueueSettings> queueSettings, IMediator mediator, ILogger<QueueConsumerService> logger)
        {
            _sqs = sqs;
            _queueSettings = queueSettings;
            _mediator = mediator;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var receiveMessageRequest = new ReceiveMessageRequest
            {
                QueueUrl = await GetQueueUrlAsync(stoppingToken),
                AttributeNames = new List<string> { "All" },
                MessageAttributeNames = new List<string> { "All" },
                MaxNumberOfMessages = 1
            };

            while (!stoppingToken.IsCancellationRequested)
            {
                var response = await _sqs.ReceiveMessageAsync(receiveMessageRequest, stoppingToken);
                foreach (var message in response.Messages)
                {
                    var messageType = message.MessageAttributes["MessageType"].StringValue;
                    var type = Type.GetType($"Sqs.Consumer.Models.Messages.{messageType}");
                    if(type is null)
                    {
                        _logger.LogWarning("Message type unknown {messageType}", messageType);
                        continue;
                    }

                    var typedMessage = (ISqsMessage) JsonSerializer.Deserialize(message.Body, type)!;

                    try
                    {
                        await _mediator.Send(typedMessage, stoppingToken);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Message failed");
                        continue;
                    }

                    await _sqs.DeleteMessageAsync(_queueUrl, message.ReceiptHandle, stoppingToken);
                }
            }
        }

        private async Task<string> GetQueueUrlAsync(CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_queueUrl))
            {
                GetQueueUrlResponse queueUrlResponse = await _sqs.GetQueueUrlAsync(_queueSettings.Value.Name, cancellationToken);
                _queueUrl = queueUrlResponse.QueueUrl;
            }

            return _queueUrl;
        }
    }
}

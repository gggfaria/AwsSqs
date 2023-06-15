using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;
using Sqs.Consumer.Configs;
using Sqs.Consumer.Models.Messages;
using System.Text.Json;

namespace Sqs.Consumor.Console
{
    public class QueueConsumerService : BackgroundService
    {
        private readonly IAmazonSQS _sqs;
        private readonly IOptions<QueueSettings> _queueSettings;
        private string? _queueUrl;

        public QueueConsumerService(IAmazonSQS sqs, IOptions<QueueSettings> queueSettings)
        {
            _sqs = sqs;
            _queueSettings = queueSettings;
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
                    switch (messageType)
                    {
                        case nameof(CreateMessage):
                            var created = JsonSerializer.Deserialize<CreateMessage>(message.Body);

                            break;
                        case nameof(DeleteMessage):

                            break;
                        case nameof(UpdateMessage):

                            break;

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

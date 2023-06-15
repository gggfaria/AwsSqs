using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;
using System.Collections;
using System.Text.Json;

namespace Sqs.Api.Messaging
{
    public class SqsMessager : ISqsMessager
    {
        readonly IAmazonSQS _amazonSQS;
        readonly IOptions<QueueSettings> _queueSettings;
        private string? _queueUrl;


        public SqsMessager(IAmazonSQS amazonSQS, IOptions<QueueSettings> queueSettings)
        {
            _amazonSQS = amazonSQS;
            _queueSettings = queueSettings;
        }

        public async Task<SendMessageResponse> SendMessageAsync<T>(T message, CancellationToken cancellationToken = default)
        {
            var sendMessageRequest = new SendMessageRequest
            {
                QueueUrl = await GetQueueUrlAsync(cancellationToken),
                MessageBody = JsonSerializer.Serialize(message),
                MessageAttributes = new Dictionary<string, MessageAttributeValue>
                {
                    {
                        "MessageType", new MessageAttributeValue
                        {
                            DataType = "String",
                            StringValue = typeof(T).Name
                        }
                    }
                }
            };

            return await _amazonSQS.SendMessageAsync(sendMessageRequest, cancellationToken);
        }

        private async Task<string> GetQueueUrlAsync(CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_queueUrl))
            {
                GetQueueUrlResponse queueUrlResponse = await _amazonSQS.GetQueueUrlAsync(_queueSettings.Value.Name, cancellationToken);
                _queueUrl = queueUrlResponse.QueueUrl;
            }

            return _queueUrl;
        }
    }
}

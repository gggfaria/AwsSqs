using Amazon.SQS.Model;

namespace Sqs.Api.Messaging
{
    public interface ISqsMessager
    {
        Task<SendMessageResponse> SendMessageAsync<T>(T message, CancellationToken cancellationToken = default);
    }
}

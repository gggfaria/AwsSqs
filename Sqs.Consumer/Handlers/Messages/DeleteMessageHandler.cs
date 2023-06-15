
using MediatR;
using Sqs.Consumer.Models.Messages;

namespace Sqs.Consumer.Handlers.Messages
{
    public class DeleteMessageHandler : IRequestHandler<DeleteMessage>
    {
        public Task Handle(DeleteMessage request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

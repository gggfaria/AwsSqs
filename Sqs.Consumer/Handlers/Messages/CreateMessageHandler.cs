using MediatR;
using Sqs.Consumer.Models.Messages;

namespace Sqs.Consumer.Handlers.Messages
{
    public class CreateMessageHandler : IRequestHandler<CreateMessage>
    {
        public Task Handle(CreateMessage request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

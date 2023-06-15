using MediatR;
using Sqs.Consumer.Models.Messages;

namespace Sqs.Consumer.Handlers.Messages
{
    public class UpdateMessageHandler : IRequestHandler<UpdateMessage>
    {
        public Task Handle(UpdateMessage request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

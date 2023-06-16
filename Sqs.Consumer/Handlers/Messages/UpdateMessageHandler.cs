using MediatR;
using Sqs.Consumer.Models.Messages;

namespace Sqs.Consumer.Handlers.Messages
{
    public class UpdateMessageHandler : IRequestHandler<UpdateMessage>
    {
        private readonly ILogger<UpdateMessageHandler> _logger;
        public UpdateMessageHandler(ILogger<UpdateMessageHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UpdateMessage request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(request.MessageText);
            return Unit.Task;
        }
    }
}

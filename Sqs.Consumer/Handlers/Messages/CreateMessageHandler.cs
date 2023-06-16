using MediatR;
using Sqs.Consumer.Models.Messages;

namespace Sqs.Consumer.Handlers.Messages
{
    public class CreateMessageHandler : IRequestHandler<CreateMessage>
    {
        private readonly ILogger<CreateMessageHandler> _logger;
        public CreateMessageHandler(ILogger<CreateMessageHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(CreateMessage request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(request.MessageText);
            return Unit.Task;
        }
    }
}

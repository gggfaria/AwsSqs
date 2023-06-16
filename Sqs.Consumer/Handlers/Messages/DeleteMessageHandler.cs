
using MediatR;
using Sqs.Consumer.Models.Messages;

namespace Sqs.Consumer.Handlers.Messages
{
    public class DeleteMessageHandler : IRequestHandler<DeleteMessage>
    {
        private readonly ILogger<DeleteMessageHandler> _logger;
        public DeleteMessageHandler(ILogger<DeleteMessageHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DeleteMessage request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(request.Id.ToString());
            return Unit.Task;
        }
    }
}

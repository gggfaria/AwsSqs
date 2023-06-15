using MediatR;

namespace Sqs.Consumer.Models.Messages
{
    public class CreateMessage : IRequest
    {
        public Guid Id { get; set; }
        public string MessageText { get; set; }
    }
}

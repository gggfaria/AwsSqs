using MediatR;

namespace Sqs.Consumer.Models.Messages
{
    public class UpdateMessage: ISqsMessage
    {
        public Guid Id { get; set; }
        public string MessageText { get; set; }
    }
}

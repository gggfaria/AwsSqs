using MediatR;

namespace Sqs.Consumer.Models.Messages
{
    public class DeleteMessage: ISqsMessage
    {
        public Guid Id { get; set; }

    }
}

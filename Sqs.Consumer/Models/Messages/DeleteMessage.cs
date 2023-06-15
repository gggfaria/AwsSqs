using MediatR;

namespace Sqs.Consumer.Models.Messages
{
    public class DeleteMessage: IRequest
    {
        public Guid Id { get; set; }

    }
}

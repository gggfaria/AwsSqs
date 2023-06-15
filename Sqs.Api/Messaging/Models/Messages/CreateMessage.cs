namespace Sqs.Api.Messaging.Models.Messages
{
    public class CreateMessage
    {
        public Guid Id { get; set; }
        public string MessageText { get; set; }
    }
}

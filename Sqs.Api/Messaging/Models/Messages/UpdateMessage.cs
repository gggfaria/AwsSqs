namespace Sqs.Api.Messaging.Models.Messages
{
    public class UpdateMessage
    {
        public Guid Id { get; set; }
        public string MessageText { get; set; }
    }
}

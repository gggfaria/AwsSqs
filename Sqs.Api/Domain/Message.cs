namespace Sqs.Api.Domain
{
    public class Message
    {
        public Guid Id { get; set; }
        public string MessageText { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        public bool IsValid()
        {
            return true;
        }
    }
}

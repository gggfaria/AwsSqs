namespace Sqs.Api.DTOs.Request
{
    public class MessageCreateDto
    {
        public Guid Id { get; set; }
        public string MessageText { get; set; }
    }
}

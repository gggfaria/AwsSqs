namespace Sqs.Api.DTOs.Request
{
    public class MessageUpdateDto
    {
        public Guid Id { get; set; }
        public string MessageText { get; set; }
    }
}

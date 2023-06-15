using Sqs.Api.Domain;
using Sqs.Api.Messaging;
using Sqs.Api.Messaging.Mapping;

namespace Sqs.Api.Services
{
    public class MessageService
    {
        private readonly ISqsMessager _sqsMessager;

        public MessageService(ISqsMessager sqsMessager)
        {
            _sqsMessager = sqsMessager;
        }

        public async Task SendMessage(Message message)
        {
            if (message.IsValid())
            {
                await _sqsMessager.SendMessageAsync(message.ToCreate());
            }
        }

        public async Task UpdateMessage(Message message)
        {
            if (message.IsValid())
            {
                await _sqsMessager.SendMessageAsync(message.ToUpdate());
            }
        }

        public async Task DeleteMessage(Guid id)
        {

            await _sqsMessager.SendMessageAsync(MappingMessages.ToDelete(id));
        }

    }
}

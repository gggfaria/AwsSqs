using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Sqs.Api.Domain;
using Sqs.Api.Messaging.Models.Messages;

namespace Sqs.Api.Messaging.Mapping
{
    public static class MappingMessages
    {
        public static UpdateMessage ToCreate(this Message message) => new()
        {
            Id = message.Id,
            MessageText = message.MessageText
        };

        public static UpdateMessage ToUpdate(this Message message) => new()
        {
            Id = message.Id,
            MessageText = message.MessageText
        };


        public static DeleteMessage ToDelete(Guid id) => new()
        {
            Id = id,
        };

    }
}

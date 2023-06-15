using AutoMapper;
using Sqs.Api.Domain;
using Sqs.Api.DTOs.Request;

namespace Sqs.Api.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageCreateDto, Message>();
        }
    }
}

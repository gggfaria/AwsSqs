using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sqs.Api.Domain;
using Sqs.Api.DTOs.Request;
using Sqs.Api.Services;

namespace Sqs.Api.Controllers
{

    [ApiController]
    public class MessageController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly MessageService _messageService;

        public MessageController(IMapper mapper, MessageService messageService)
        {
            _mapper = mapper;
            _messageService = messageService;
        }

        [HttpPost("message")]
        public async Task<IActionResult> Create([FromBody] MessageCreateDto request)
        {
            var message = _mapper.Map<Message>(request);
            await _messageService.SendMessage(message);

            return Ok(message);

        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlumniPortal.Application.Features.AlumniEventFeatures.Commands;
using AlumniPortal.Application.Features.AlumniEventFeatures.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AlumniPortal.Application.Implementation;
using AlumniPortal.Application.Contract;

namespace AlumniPortal.Controllers
{
    [ApiController]
    [Route("api/AlumniEvent")]
    public class AlumniEventController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IImageConverterService _imageConverterService;

        public AlumniEventController(IMediator mediator, IImageConverterService imageConverterService)
        {
            _mediator = mediator;
            _imageConverterService = imageConverterService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAlumniEventCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllAlumniEventQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _mediator.Send(new GetAlumniEventByIdQuery { Id = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _mediator.Send(new DeleteAlumniEventByIdCommand { Id = id }));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, UpdateAlumniEventCommand command)
        {
            if (id != command.Id.ToString())
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("compress")]
        public async Task<IActionResult> Convert(string imageUri)
        {
            var response = await _imageConverterService.ConvertAsync(imageUri);
            return Ok(response.ToString());
        }
    }
}

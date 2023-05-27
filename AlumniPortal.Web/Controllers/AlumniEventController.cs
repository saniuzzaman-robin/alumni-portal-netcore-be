using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlumniPortal.Application.Features.AlumniEventFeatures.Commands;
using AlumniPortal.Application.Features.AlumniEventFeatures.Queries;

namespace AlumniPortal.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/AlumniEvent")]
    public class AlumniEventController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        public async Task<IActionResult> Create(CreateAlumniEventCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllAlumniEventQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await Mediator.Send(new GetAlumniEventByIdQuery { Id = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await Mediator.Send(new DeleteAlumniEventByIdCommand { Id = id }));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, UpdateAlumniEventCommand command)
        {
            if (id != command.Id.ToString())
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}

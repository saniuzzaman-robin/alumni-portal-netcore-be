using AlumniPortal.Application.Repositories;
using AlumniPortal.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AlumniEventsController : ControllerBase
{
    private readonly IAlumniEventRepository _alumniEventRepository;

    public AlumniEventsController(IAlumniEventRepository alumniEventRepository)
    {
        _alumniEventRepository = alumniEventRepository;
    }

    [HttpGet("{id}")]
    public IActionResult GetAlumniEventById(string id)
    {
        AlumniEvent alumniEvent = _alumniEventRepository.GetByIdAsync(id).Result;
        if (alumniEvent == null)
            return NotFound();

        return Ok(alumniEvent);
    }

    [HttpPost]
    public IActionResult CreateAlumniEvent(AlumniEvent alumniEvent)
    {
        _alumniEventRepository.CreateAsync(alumniEvent);
        return CreatedAtAction(nameof(GetAlumniEventById), new { id = alumniEvent.Id }, alumniEvent);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAlumniEvent(string id, AlumniEvent updatedAlumniEvent)
    {
        AlumniEvent alumniEvent = _alumniEventRepository.GetByIdAsync(id).Result;
        if (alumniEvent == null)
            return NotFound();

        updatedAlumniEvent.Id = alumniEvent.Id;
        _alumniEventRepository.UpdateAsync(updatedAlumniEvent);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAlumniEvent(string id)
    {
        AlumniEvent alumniEvent = _alumniEventRepository.GetByIdAsync(id).Result;
        if (alumniEvent == null)
            return NotFound();

        _alumniEventRepository.DeleteAsync(id);

        return NoContent();
    }
}

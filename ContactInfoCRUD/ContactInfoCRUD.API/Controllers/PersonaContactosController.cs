using Microsoft.AspNetCore.Mvc;
using MediatR;
using ContactInfoCRUD.Application.Command;
using ContactInfoCRUD.Application.Querys;

[Route("api/[controller]")]
[ApiController]
public class PersonaContactosController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonaContactosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{personaId}")]
    public async Task<IActionResult> GetAllContactosByPersonaId(int personaId)
    {
        var query = new GetAllContactosByPersonaIdQuery(personaId);
        var contactos = await _mediator.Send(query);
        return Ok(contactos);
    }

    [HttpGet("contacto/{id}")]
    public async Task<IActionResult> GetContactoById(int id)
    {
        var query = new GetContactoByIdQuery(id);
        var contacto = await _mediator.Send(query);
        if (contacto == null)
        {
            return NotFound();
        }
        return Ok(contacto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateContacto([FromBody] CrearPersonaContactoCommand command)
    {
        var contactoId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetContactoById), new { id = contactoId }, contactoId);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContacto(int id, [FromBody] ActualizarPersonaContactoCommand command)
    {
        command.PersonaContactoId = id;
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContacto(int id)
    {
        var command = new EliminarPersonaContactoCommand { PersonaContactoId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

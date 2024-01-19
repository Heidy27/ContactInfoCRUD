using Microsoft.AspNetCore.Mvc;
using MediatR;
using ContactInfoCRUD.Application.Command;
using ContactInfoCRUD.Application.Querys;

[Route("api/[controller]")]
[ApiController]
public class PersonaContactosController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<PersonaContactosController> _logger;


    public PersonaContactosController(IMediator mediator, ILogger<PersonaContactosController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet("{personaId}")]
    public async Task<ActionResult> GetAllContactosByPersonaId(int personaId)
    {
        try
        {
            var query = new GetAllContactosByPersonaIdQuery(personaId);
            var contactos = await _mediator.Send(query);
            return Ok(contactos);
        }
        catch (Exception ex)
        {
            // Log the exception details to help with debugging
            _logger.LogError(ex, "An error occurred while processing the request.");

            // Return a more detailed error message
            return StatusCode(500, $"Ocurrio un error: {ex.Message}");
        }
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

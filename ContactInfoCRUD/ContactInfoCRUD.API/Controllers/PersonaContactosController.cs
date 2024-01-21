using Microsoft.AspNetCore.Mvc;
using MediatR;
using ContactInfoCRUD.Application.Command;
using ContactInfoCRUD.Application.Querys;
using System.Net;

namespace ContactInfoCRUD.API.Controllers;

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
            _logger.LogError(ex, "Se produjo un error al procesar la solicitud.");

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
        try
        {
            command.PersonaContactoId = id;
            await _mediator.Send(command);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar el contacto.");
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContacto(int id)
    {
        var command = new EliminarPersonaContactoCommand { PersonaContactoId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

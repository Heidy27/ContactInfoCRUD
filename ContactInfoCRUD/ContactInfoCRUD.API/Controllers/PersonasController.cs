using Microsoft.AspNetCore.Mvc;
using MediatR;
using ContactInfoCRUD.Application.Command;
using ContactInfoCRUD.Application.Querys;

namespace ContactInfoCRUD.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonasController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetPersonasQuery();
        var personas = await _mediator.Send(query);
        return Ok(personas);
    }

    [HttpGet("{cedula}")]
    public async Task<IActionResult> GetByCedula(string cedula)
    {
        var query = new GetPersonaByCedulaQuery(cedula);
        var persona = await _mediator.Send(query);
        if (persona == null)
        {
            return NotFound();
        }
        return Ok(persona);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GetPersonaCommand command)
    {
        try
        {
            var personaId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetByCedula), new { cedula = command.Cedula }, new { personaId });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PutPersonaCommand command)
    {
        command.PersonaId = id;
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeletePersonaCommand { PersonaId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
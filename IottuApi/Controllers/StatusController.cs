using IottuBusiness;
using IottuModel;
using Microsoft.AspNetCore.Mvc;

namespace IottuApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController
(
    StatusService statusService
) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var status = statusService.GetStatus();
        return status.Count == 0 ? NoContent() : Ok(status);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var status = statusService.GetStatusById(id);
        return status == null ? NotFound() : Ok(status);
    }

    [HttpPost]
    public IActionResult Post([FromBody] StatusMotoModel status)
    {
        if (string.IsNullOrWhiteSpace(status.Descricao))
            return BadRequest("Descrição é obrigatória.");

        var createdStatus = statusService.Create(status);
        return CreatedAtAction(nameof(Get), new { id = createdStatus.Id }, createdStatus);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] StatusMotoModel status)
    {
        if (status == null)
            return BadRequest("Status inválido.");

        status.Id = id;

        if (!statusService.Update(status))
            return NotFound();

        return Ok(status);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return statusService.Delete(id) ? NoContent() : NotFound();
    }
}
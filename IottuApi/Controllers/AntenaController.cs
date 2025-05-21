using IottuBusiness;
using IottuModel;
using Microsoft.AspNetCore.Mvc;

namespace IottuApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AntenaController(AntenaService antenaService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var antenas = antenaService.GetAntenas();
        return antenas.Count == 0 ? NoContent() : Ok(antenas);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var antena = antenaService.GetAntenaById(id);
        return antena == null ? NotFound() : Ok(antena);
    }

    [HttpPost]
    public IActionResult Post([FromBody] AntenaModel antena)
    {
        if (string.IsNullOrWhiteSpace(antena.Codigo))
            return BadRequest("Código é obrigatório.");

        var createdAntena = antenaService.Create(antena);
        return CreatedAtAction(nameof(Get), new { id = createdAntena.Id }, createdAntena);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AntenaModel antena)
    {
        if (antena == null)
            return BadRequest("Antena inválida.");

        antena.Id = id;

        if (!antenaService.Update(antena))
            return NotFound();

        return Ok(antena);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return antenaService.Delete(id) ? NoContent() : NotFound();
    }
}

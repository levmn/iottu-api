using IottuBusiness;
using IottuModel;
using Microsoft.AspNetCore.Mvc;

namespace IottuApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatioController(PatioService patioService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var patios = patioService.GetPatios();
        return patios.Count == 0 ? NoContent() : Ok(patios);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var patio = patioService.GetPatioById(id);
        return patio == null ? NotFound() : Ok(patio);
    }

    [HttpPost]
    public IActionResult Post([FromBody] PatioModel patio)
    {
        if (string.IsNullOrWhiteSpace(patio.Cep))
            return BadRequest("CEP é obrigatório.");

        if (patio.Capacidade <= 0)
            return BadRequest("Capacidade deve ser maior que zero.");

        var createdPatio = patioService.Create(patio);
        return CreatedAtAction(nameof(Get), new { id = createdPatio.Id }, createdPatio);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PatioModel patio)
    {
        if (patio == null)
            return BadRequest("Pátio inválido.");

        patio.Id = id;

        if (!patioService.Update(patio))
            return NotFound();

        return Ok(patio);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return patioService.Delete(id) ? NoContent() : NotFound();
    }
}

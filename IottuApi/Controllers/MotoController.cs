using IottuBusiness;
using IottuModel;
using Microsoft.AspNetCore.Mvc;

namespace IottuApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MotoController
(
    MotoService motoService
) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var motos = motoService.GetMotos();
        return motos.Count == 0 ? NoContent() : Ok(motos);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var moto = motoService.GetMotoById(id);
        return moto == null ? NotFound() : Ok(moto);
    }

    [HttpPost]
    public IActionResult Post([FromBody] MotoModel moto)
    {
        if (moto.StatusId == 0)
            return BadRequest("Status é obrigatório.");
        var createdMoto = motoService.Create(moto);
        return CreatedAtAction(nameof(Get), new { id = createdMoto.Id }, createdMoto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] MotoModel moto)
    {
        if (moto == null)
            return BadRequest("Moto inválida.");

        if (moto.StatusId == 0)
            return BadRequest("Status é obrigatório.");

        moto.Id = id;

        if (!motoService.Update(moto))
            return NotFound();

        return Ok(moto);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return motoService.Delete(id) ? NoContent() : NotFound();
    }
}
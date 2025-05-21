using IottuBusiness;
using IottuModel;
using Microsoft.AspNetCore.Mvc;

namespace IottuApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagController(TagService tagService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var tags = tagService.GetTags();
        return tags.Count == 0 ? NoContent() : Ok(tags);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var tag = tagService.GetTagById(id);
        return tag == null ? NotFound() : Ok(tag);
    }

    [HttpPost]
    public IActionResult Post([FromBody] TagModel tag)
    {
        if (string.IsNullOrWhiteSpace(tag.CodigoRFID))
            return BadRequest("Código RFID é obrigatório.");

        var createdTag = tagService.Create(tag);
        return CreatedAtAction(nameof(Get), new { id = createdTag.Id }, createdTag);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TagModel tag)
    {
        if (tag == null)
            return BadRequest("Tag inválida.");

        tag.Id = id;

        if (!tagService.Update(tag))
            return NotFound();

        return Ok(tag);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return tagService.Delete(id) ? NoContent() : NotFound();
    }
}

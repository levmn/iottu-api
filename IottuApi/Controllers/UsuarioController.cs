using IottuBusiness;
using IottuModel;
using Microsoft.AspNetCore.Mvc;

namespace IottuApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController(UsuarioService usuarioService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var usuarios = usuarioService.GetUsuarios();
        return usuarios.Count == 0 ? NoContent() : Ok(usuarios);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var usuario = usuarioService.GetUsuarioById(id);
        return usuario == null ? NotFound() : Ok(usuario);
    }

    [HttpPost]
    public IActionResult Post([FromBody] UsuarioModel usuario)
    {
        if (string.IsNullOrWhiteSpace(usuario.Nome))
            return BadRequest("Nome é obrigatório.");

        var createdUsuario = usuarioService.Create(usuario);
        return CreatedAtAction(nameof(Get), new { id = createdUsuario.Id }, createdUsuario);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UsuarioModel usuario)
    {
        if (usuario == null) return BadRequest("Usuário inválido.");
        usuario.Id = id;
        return usuarioService.Update(usuario) ? Ok(usuario) : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) =>
        usuarioService.Delete(id) ? NoContent() : NotFound();
}

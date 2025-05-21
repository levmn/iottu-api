using IottuModel;
using IottuData;
using System.Collections.Generic;
using System.Linq;

namespace IottuBusiness;

public class UsuarioService
{
    private readonly AppDbContext _context;

    public UsuarioService(AppDbContext context)
    {
        _context = context;
    }

    public List<UsuarioModel> GetUsuarios() =>
        _context.Usuario.ToList();

    public UsuarioModel? GetUsuarioById(int id) =>
        _context.Usuario.FirstOrDefault(u => u.Id == id);

    public UsuarioModel Create(UsuarioModel usuario)
    {
        Console.WriteLine("Criando usuário no banco Oracle...");
        _context.Usuario.Add(usuario);
        _context.SaveChanges();
        return usuario;
    }

    public bool Update(UsuarioModel usuario)
    {
        var existingUsuario = _context.Usuario.Find(usuario.Id);
        if (existingUsuario == null) return false;

        existingUsuario.Nome = usuario.Nome;
        existingUsuario.Email = usuario.Email;
        existingUsuario.Senha = usuario.Senha;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var usuario = _context.Usuario.Find(id);
        if (usuario == null) return false;

        _context.Usuario.Remove(usuario);
        _context.SaveChanges();
        return true;
    }
}

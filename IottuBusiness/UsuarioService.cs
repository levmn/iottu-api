using IottuModel;

namespace IottuBusiness;

public class UsuarioService
{
    private static readonly List<UsuarioModel> _usuarios = new();
    private static int _nextId = 1;

    public List<UsuarioModel> GetUsuarios() => _usuarios;
    public UsuarioModel? GetUsuarioById(int id) => _usuarios.FirstOrDefault(u => u.Id == id);

    public UsuarioModel Create(UsuarioModel usuario)
    {
        usuario.Id = _nextId++;
        _usuarios.Add(usuario);
        return usuario;
    }

    public bool Update(UsuarioModel usuario)
    {
        var existingUsuario = GetUsuarioById(usuario.Id);
        if (existingUsuario == null) return false;

        existingUsuario.Nome = usuario.Nome;
        existingUsuario.Email = usuario.Email;
        existingUsuario.Senha = usuario.Senha;

        return true;
    }

    public bool Delete(int id)
    {
        var usuario = GetUsuarioById(id);
        if (usuario == null) return false;

        _usuarios.Remove(usuario);
        return true;
    }
}

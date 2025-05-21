using IottuModel;
using IottuData;
using System.Collections.Generic;
using System.Linq;

namespace IottuBusiness;

public class PatioService
{
    private readonly AppDbContext _context;

    public PatioService(AppDbContext context)
    {
        _context = context;
    }

    public List<PatioModel> GetPatios() =>
        _context.Patio.ToList();

    public PatioModel? GetPatioById(int id) =>
        _context.Patio.FirstOrDefault(p => p.Id == id);

    public PatioModel Create(PatioModel patio)
    {
        Console.WriteLine("Criando pátio no banco Oracle...");
        _context.Patio.Add(patio);
        _context.SaveChanges();
        return patio;
    }

    public bool Update(PatioModel patio)
    {
        var existingPatio = _context.Patio.Find(patio.Id);
        if (existingPatio == null) return false;

        existingPatio.Cep = patio.Cep;
        existingPatio.Numero = patio.Numero;
        existingPatio.Cidade = patio.Cidade;
        existingPatio.Estado = patio.Estado;
        existingPatio.Capacidade = patio.Capacidade;
        existingPatio.ResponsavelId = patio.ResponsavelId;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var patio = _context.Patio.Find(id);
        if (patio == null) return false;

        _context.Patio.Remove(patio);
        _context.SaveChanges();
        return true;
    }
}

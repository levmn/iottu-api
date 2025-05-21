using IottuModel;
using IottuData;
using System.Collections.Generic;
using System.Linq;

namespace IottuBusiness;

public class AntenaService
{
    private readonly AppDbContext _context;

    public AntenaService(AppDbContext context)
    {
        _context = context;
    }

    public List<AntenaModel> GetAntenas() =>
        _context.Antena.ToList();

    public AntenaModel? GetAntenaById(int id) =>
        _context.Antena.FirstOrDefault(a => a.Id == id);

    public AntenaModel Create(AntenaModel antena)
    {
        Console.WriteLine("Criando antena no banco Oracle...");
        _context.Antena.Add(antena);
        _context.SaveChanges();
        return antena;
    }

    public bool Update(AntenaModel antena)
    {
        var existingAntena = _context.Antena.Find(antena.Id);
        if (existingAntena == null) return false;

        existingAntena.Codigo = antena.Codigo;
        existingAntena.Latitude = antena.Latitude;
        existingAntena.Longitude = antena.Longitude;
        existingAntena.PatioId = antena.PatioId;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var antena = _context.Antena.Find(id);
        if (antena == null) return false;

        _context.Antena.Remove(antena);
        _context.SaveChanges();
        return true;
    }
}

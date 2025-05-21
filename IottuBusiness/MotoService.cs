using IottuModel;
using IottuData;
using System.Collections.Generic;
using System.Linq;

namespace IottuBusiness;

public class MotoService
{
    private readonly AppDbContext _context;

    public MotoService(AppDbContext context)
    {
        _context = context;
    }

    public List<MotoModel> GetMotos() =>
        _context.Moto.ToList();

    public MotoModel? GetMotoById(int id) =>
        _context.Moto.FirstOrDefault(m => m.Id == id);

    public MotoModel Create(MotoModel moto)
    {
        Console.WriteLine("Criando moto no banco Oracle...");
        _context.Moto.Add(moto);
        _context.SaveChanges();
        return moto;
    }

    public bool Update(MotoModel moto)
    {
        var existingMoto = _context.Moto.Find(moto.Id);
        if (existingMoto == null) return false;

        existingMoto.Placa = moto.Placa;
        existingMoto.Chassi = moto.Chassi;
        existingMoto.NumeroMotor = moto.NumeroMotor;
        existingMoto.Modelo = moto.Modelo;
        existingMoto.Status = moto.Status;
        existingMoto.TagId = moto.TagId;
        existingMoto.PatioId = moto.PatioId;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var moto = _context.Moto.Find(id);
        if (moto == null) return false;

        _context.Moto.Remove(moto);
        _context.SaveChanges();
        return true;
    }
}

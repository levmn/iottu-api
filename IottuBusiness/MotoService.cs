using IottuModel;
using System.Collections.Generic;
using System.Linq;

namespace IottuBusiness;

public class MotoService
{
    private static readonly List<MotoModel> _motos = new();
    private static int _nextId = 1;

    public List<MotoModel> GetMotos() => _motos;
    public MotoModel? GetMotoById(int id) => _motos.FirstOrDefault(m => m.Id == id);

    public MotoModel Create(MotoModel moto)
    {
        moto.Id = _nextId++;
        _motos.Add(moto);
        return moto;
    }

    public bool Update(MotoModel moto)
    {
        var existingMoto = GetMotoById(moto.Id);
        if (existingMoto == null) return false;

        existingMoto.Placa = moto.Placa;
        existingMoto.Chassi = moto.Chassi;
        existingMoto.NumeroMotor = moto.NumeroMotor;
        existingMoto.Modelo = moto.Modelo;
        existingMoto.Status = moto.Status;
        existingMoto.TagId = moto.TagId;
        existingMoto.PatioId = moto.PatioId;

        return true;
    }

    public bool Delete(int id)
    {
        var moto = GetMotoById(id);
        if (moto == null) return false;

        _motos.Remove(moto);
        return true;
    }
}

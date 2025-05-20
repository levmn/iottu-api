using IottuModel;

namespace IottuBusiness;

public class PatioService
{
    private static readonly List<PatioModel> _patios = new();
    private static int _nextId = 1;

    public List<PatioModel> GetPatios() => _patios;

    public PatioModel? GetPatioById(int id) => _patios.FirstOrDefault(p => p.Id == id);

    public PatioModel Create(PatioModel patio)
    {
        patio.Id = _nextId++;
        _patios.Add(patio);
        return patio;
    }

    public bool Update(PatioModel patio)
    {
        var existingPatio = GetPatioById(patio.Id);
        if (existingPatio == null) return false;

        existingPatio.Cep = patio.Cep;
        existingPatio.Numero = patio.Numero;
        existingPatio.Cidade = patio.Cidade;
        existingPatio.Estado = patio.Estado;
        existingPatio.Capacidade = patio.Capacidade;
        existingPatio.ResponsavelId = patio.ResponsavelId;
        existingPatio.Responsavel = patio.Responsavel;
        existingPatio.Motos = patio.Motos;
        existingPatio.Antenas = patio.Antenas;

        return true;
    }

    public bool Delete(int id)
    {
        var patio = GetPatioById(id);
        if (patio == null) return false;

        _patios.Remove(patio);
        return true;
    }
}

using IottuModel;

namespace IottuBusiness;

public class AntenaService
{
    private static readonly List<AntenaModel> _antenas = new();
    private static int _nextId = 1;

    public List<AntenaModel> GetAntenas() => _antenas;

    public AntenaModel? GetAntenaById(int id) => _antenas.FirstOrDefault(a => a.Id == id);

    public AntenaModel Create(AntenaModel antena)
    {
        antena.Id = _nextId++;
        _antenas.Add(antena);
        return antena;
    }

    public bool Update(AntenaModel antena)
    {
        var existingAntena = GetAntenaById(antena.Id);
        if (existingAntena == null) return false;

        existingAntena.Codigo = antena.Codigo;
        existingAntena.Latitude = antena.Latitude;
        existingAntena.Longitude = antena.Longitude;
        existingAntena.PatioId = antena.PatioId;

        return true;
    }

    public bool Delete(int id)
    {
        var antena = GetAntenaById(id);
        if (antena == null) return false;

        _antenas.Remove(antena);
        return true;
    }

}
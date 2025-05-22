using IottuModel;
using IottuData;
using System.Collections.Generic;
using System.Linq;

namespace IottuBusiness;

public class StatusService
{
    private readonly AppDbContext _context;

    public StatusService(AppDbContext context)
    {
        _context = context;
    }

    public List<StatusMotoModel> GetStatus() =>
        _context.Status.ToList();

    public StatusMotoModel? GetStatusById(int id) =>
        _context.Status.FirstOrDefault(s => s.Id == id);

    public StatusMotoModel Create(StatusMotoModel status)
    {
        Console.WriteLine("Criando status no banco Oracle...");
        _context.Status.Add(status);
        _context.SaveChanges();
        return status;
    }

    public bool Update(StatusMotoModel status)
    {
        var existingStatus = _context.Status.Find(status.Id);
        if (existingStatus == null) return false;

        existingStatus.Descricao = status.Descricao;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var status = _context.Status.Find(id);
        if (status == null) return false;

        _context.Status.Remove(status);
        _context.SaveChanges();
        return true;
    }
}
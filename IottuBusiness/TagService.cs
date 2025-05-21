using IottuModel;
using IottuData;
using System.Collections.Generic;
using System.Linq;

namespace IottuBusiness;

public class TagService
{
    private readonly AppDbContext _context;

    public TagService(AppDbContext context)
    {
        _context = context;
    }

    public List<TagModel> GetTags() =>
        _context.Tag.ToList();

    public TagModel? GetTagById(int id) =>
        _context.Tag.FirstOrDefault(t => t.Id == id);

    public TagModel Create(TagModel tag)
    {
        Console.WriteLine("Criando tag no banco Oracle...");
        _context.Tag.Add(tag);
        _context.SaveChanges();
        return tag;
    }

    public bool Update(TagModel tag)
    {
        var existingTag = _context.Tag.Find(tag.Id);
        if (existingTag == null) return false;

        existingTag.CodigoRFID = tag.CodigoRFID;
        existingTag.SSIDWifi = tag.SSIDWifi;
        existingTag.Latitude = tag.Latitude;
        existingTag.Longitude = tag.Longitude;
        existingTag.DataHora = tag.DataHora;
        existingTag.AntenaId = tag.AntenaId;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var tag = _context.Tag.Find(id);
        if (tag == null) return false;

        _context.Tag.Remove(tag);
        _context.SaveChanges();
        return true;
    }
}

using IottuModel;

namespace IottuBusiness;

public class TagService
{
    private static readonly List<TagModel> _tags = new();
    private static int _nextId = 1;

    public List<TagModel> GetTags() => _tags;

    public TagModel? GetTagById(int id) => _tags.FirstOrDefault(t => t.Id == id);

    public TagModel Create(TagModel tag)
    {
        tag.Id = _nextId++;
        _tags.Add(tag);
        return tag;
    }

    public bool Update(TagModel tag)
    {
        var existingTag = GetTagById(tag.Id);
        if (existingTag == null) return false;

        existingTag.CodigoRFID = tag.CodigoRFID;
        existingTag.SSIDWifi = tag.SSIDWifi;
        existingTag.Latitude = tag.Latitude;
        existingTag.Longitude = tag.Longitude;
        existingTag.DataHora = tag.DataHora;
        existingTag.MotoId = tag.MotoId;

        return true;
    }

    public bool Delete(int id)
    {
        var tag = GetTagById(id);
        if (tag == null) return false;

        _tags.Remove(tag);
        return true;
    }
}

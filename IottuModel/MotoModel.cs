using IottuModel;

public class MotoModel
{
    public int Id { get; set; }
    public string Placa { get; set; } = string.Empty;
    public string Chassi { get; set; } = string.Empty;
    public string NumeroMotor { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public required string Status { get; set; }

    public int TagId { get; set; }
    public TagModel? Tag { get; set; }

    public int PatioId { get; set; }
    public PatioModel? Patio { get; set; }
}

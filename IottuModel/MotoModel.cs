namespace IottuModel

{
    public class MotoModel
    {
        public int Id { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Chassi { get; set; } = string.Empty;
        public string NumeroMotor { get; set; } = string.Empty;
        public required string Modelo { get; set; } = string.Empty;

        public int StatusId { get; set; }
        public StatusMotoModel Status { get; set; } = null!;

        public int TagId { get; set; }
        public TagModel Tag { get; set; } = null!;

        public int PatioId { get; set; }
        public PatioModel Patio { get; set; } = null!;
    }
}

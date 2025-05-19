namespace IottuModel
{
    public class AntenaModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public required double Latitude { get; set; }
        public required double Longitude { get; set; }

        public int PatioId { get; set; }
        public PatioModel Patio { get; set; } = null!;
    }
}

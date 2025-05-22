using IottuModel;

namespace IottuModel

{
    public class TagModel
    {
        public int Id { get; set; }
        public required string CodigoRFID { get; set; }
        public required string SSIDWifi { get; set; }
        public required double Latitude { get; set; }
        public required double Longitude { get; set; }
        public required DateTime DataHora { get; set; }

        public MotoModel? Moto { get; set; }

        public int AntenaId { get; set; }
        public AntenaModel? Antena { get; set; }
    }
}

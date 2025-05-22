namespace IottuModel
{
    public class StatusMotoModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;

        public ICollection<MotoModel>? Motos { get; set; }
    }
}

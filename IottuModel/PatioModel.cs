namespace IottuModel

{
    public class PatioModel
    {
        public int Id { get; set; }
        public string Cep { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public int Capacidade { get; set; }

        public int? ResponsavelId { get; set; }
        public UsuarioModel? Responsavel { get; set; }

        public ICollection<MotoModel>? Motos { get; set; }
        public ICollection<AntenaModel>? Antenas { get; set; }
    }
}

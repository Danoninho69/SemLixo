namespace LixoMelhor.Models
{
    public class CaminhaoModel
    {
        public int Id { get; set; }
        public string? Placa { get; set; }
        public bool Ativo { get; set; } = true;
        public bool Novo { get; set; } = true;
    }
}

namespace BackendLearningHub.Modelos;

public class Aula
{
    public int Id { get; set; }
    public int UnidadeId { get; set; }
    public int TopicoId { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Resumo { get; set; } = string.Empty;
    public string TempoEstimado { get; set; } = "30 min";
    public string Nivel { get; set; } = "Basico";
    public string VideoUrl { get; set; } = string.Empty;
    public bool Publicada { get; set; } = true;
    public List<Usuario> Usuarios { get; set; } = [];
}

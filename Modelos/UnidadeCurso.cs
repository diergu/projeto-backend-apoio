namespace BackendLearningHub.Modelos;

public class UnidadeCurso
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Topico> Topicos { get; set; } = [];
}

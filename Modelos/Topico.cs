namespace BackendLearningHub.Modelos;

public class Topico
{
    public int Id { get; set; }
    public int UnidadeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Aula> Aulas { get; set; } = [];
}

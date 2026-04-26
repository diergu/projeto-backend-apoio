namespace BackendLearningHub.Modelos;

public class Usuario
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Perfil { get; set; } = "Student";
    public List<Aula> AulasConcluidas { get; set; } = [];
    
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public HashSet<int> IdsAulasConcluidas => AulasConcluidas.Select(a => a.Id).ToHashSet();
}

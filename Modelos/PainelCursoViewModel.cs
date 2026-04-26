namespace BackendLearningHub.Modelos;

public class PainelCursoViewModel
{
    public List<UnidadeCurso> Unidades { get; set; } = [];
    public HashSet<int> IdsAulasConcluidas { get; set; } = [];
    public int AulasPublicadas { get; set; }
    public int PercentualConclusao { get; set; }
}

using BackendLearningHub.Dados;
using BackendLearningHub.Modelos;
using Microsoft.EntityFrameworkCore;

namespace BackendLearningHub.Servicos;

public class RepositorioAprendizado
{
    private readonly AppDbContext _context;

    public RepositorioAprendizado(AppDbContext context)
    {
        _context = context;
    }

    public List<UnidadeCurso> ObterUnidades(bool includeUnpublished = false)
    {
        var query = _context.UnidadesCursos
            .Include(u => u.Topicos)
            .ThenInclude(t => t.Aulas)
            .AsNoTracking()
            .ToList();

        // Filtra aulas publicadas na memória ou direto na query se suportado
        foreach (var unidade in query)
        {
            foreach (var topico in unidade.Topicos)
            {
                if (!includeUnpublished)
                {
                    topico.Aulas = topico.Aulas.Where(a => a.Publicada).ToList();
                }
            }
        }
        return query;
    }

    public List<Aula> ObterAulas(bool includeUnpublished = false)
    {
        return _context.Aulas
            .AsNoTracking()
            .Where(aula => includeUnpublished || aula.Publicada)
            .ToList();
    }

    public Usuario? ValidarUsuario(string email, string password)
    {
        return _context.Usuarios
            .FirstOrDefault(user => user.Email == email && user.Password == password);
    }

    public Usuario? ObterUsuarioPorEmail(string email)
    {
        return _context.Usuarios
            .Include(u => u.AulasConcluidas)
            .FirstOrDefault(user => user.Email == email);
    }

    public void AlternarProgresso(string email, int aulaId)
    {
        var user = _context.Usuarios
            .Include(u => u.AulasConcluidas)
            .FirstOrDefault(u => u.Email == email);

        var aula = _context.Aulas.FirstOrDefault(a => a.Id == aulaId);

        if (user is null || aula is null)
        {
            return;
        }

        var concluiu = user.AulasConcluidas.Any(a => a.Id == aulaId);
        if (concluiu)
        {
            user.AulasConcluidas.RemoveAll(a => a.Id == aulaId);
        }
        else
        {
            user.AulasConcluidas.Add(aula);
        }
        _context.SaveChanges();
    }

    public Aula AdicionarAula(Aula aula)
    {
        var topico = _context.Topicos.FirstOrDefault(t => t.Id == aula.TopicoId);
        if (topico != null)
        {
            aula.UnidadeId = topico.UnidadeId;
        }

        _context.Aulas.Add(aula);
        _context.SaveChanges();
        return aula;
    }

    public void AlternarPublicacao(int aulaId)
    {
        var aula = _context.Aulas.FirstOrDefault(item => item.Id == aulaId);
        if (aula is not null)
        {
            aula.Publicada = !aula.Publicada;
            _context.SaveChanges();
        }
    }
}

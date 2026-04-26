using BackendLearningHub.Modelos;
using Microsoft.EntityFrameworkCore;

namespace BackendLearningHub.Dados;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.EnsureCreated();

        try { context.Database.ExecuteSqlRaw("DROP DATABASE IF EXISTS learninghubdb;"); } catch {}
        try { context.Database.ExecuteSqlRaw("DROP DATABASE IF EXISTS escoladb;"); } catch {}
        try { context.Database.ExecuteSqlRaw("DROP DATABASE IF EXISTS escolafundamental;"); } catch {}
        try { context.Database.ExecuteSqlRaw("DROP DATABASE IF EXISTS escoladbfinal;"); } catch {}
        try { context.Database.ExecuteSqlRaw("DROP DATABASE IF EXISTS escoladbfinal2;"); } catch {}

        if (context.Usuarios.Any())
        {
            return;
        }

        var admin = new Usuario { Name = "Professor Admin", Email = "professor@escola.com", Password = "admin123", Perfil = "Admin" };
        var aluno = new Usuario { Name = "Aluno Ensino Fundamental", Email = "aluno@escola.com", Password = "aluno123", Perfil = "Student" };
        context.Usuarios.AddRange(admin, aluno);

        var disciplina1 = new UnidadeCurso
        {
            Name = "Matemática",
            Description = "Aulas focadas em frações, operações básicas e geometria inicial.",
            Topicos =
            [
                new Topico
                {
                    Name = "Unidade 1 - Frações",
                    Description = "Entendendo as frações no dia a dia e operações básicas.",
                    Aulas =
                    [
                        new Aula { Titulo = "O que são Frações?", Resumo = "Aprenda o conceito básico de frações usando pizzas e exemplos reais.", Nivel = "Básico", TempoEstimado = "15 min", VideoUrl = "https://www.youtube.com/watch?v=3Qy01oHwEGo" },
                        new Aula { Titulo = "Soma e Subtração de Frações", Resumo = "Como somar e subtrair frações com o mesmo denominador.", Nivel = "Básico", TempoEstimado = "20 min", VideoUrl = "https://www.youtube.com/watch?v=4y-5L-7B03c" }
                    ]
                },
                new Topico
                {
                    Name = "Unidade 2 - Geometria Básica",
                    Description = "Conhecendo as formas e espaços.",
                    Aulas =
                    [
                        new Aula { Titulo = "Polígonos e seus lados", Resumo = "Identificando triângulos, quadrados e pentágonos.", Nivel = "Básico", TempoEstimado = "18 min", VideoUrl = "https://www.youtube.com/watch?v=Kz6qP-KqSNE" }
                    ]
                }
            ]
        };

        var disciplina2 = new UnidadeCurso
        {
            Name = "Ciências",
            Description = "Explorando o planeta, os ecossistemas e o universo.",
            Topicos =
            [
                new Topico
                {
                    Name = "Unidade 1 - O Sistema Solar",
                    Description = "Planetas, estrelas e nosso lugar no espaço.",
                    Aulas =
                    [
                        new Aula { Titulo = "Conhecendo os Planetas", Resumo = "Quais são os planetas do sistema solar e suas características.", Nivel = "Básico", TempoEstimado = "25 min", VideoUrl = "https://www.youtube.com/watch?v=libKVRa01L8" }
                    ]
                },
                new Topico
                {
                    Name = "Unidade 2 - Ecossistemas",
                    Description = "Biomas e relações ecológicas na Terra.",
                    Aulas =
                    [
                        new Aula { Titulo = "Cadeia Alimentar", Resumo = "Produtores, consumidores e decompositores.", Nivel = "Básico", TempoEstimado = "20 min", VideoUrl = "https://www.youtube.com/watch?v=E-yq7O6g87g" },
                        new Aula { Titulo = "A Importância da Água", Resumo = "O ciclo da água e a preservação ambiental.", Nivel = "Básico", TempoEstimado = "15 min", VideoUrl = "https://www.youtube.com/watch?v=vJ0z8Gg1y2A" }
                    ]
                }
            ]
        };

        context.UnidadesCursos.AddRange(disciplina1, disciplina2);
        context.SaveChanges();
    }
}

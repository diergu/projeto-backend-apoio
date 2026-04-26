# Sistema de Apoio Escolar

Projeto acadêmico desenvolvido em ASP.NET Core MVC para gerenciamento e acompanhamento de aulas do ensino fundamental.

A plataforma permite que estudantes acessem materiais de disciplinas como Matemática e Ciências. O administrador (Professor) pode cadastrar novas disciplinas, organizar tópicos e disponibilizar links de videoaulas para guiar o aprendizado dos alunos.

## Funcionalidades

- Autenticação e controle de acesso via Cookies
- Perfil de Aluno (Visualização de disciplinas e aulas)
- Perfil de Administrador/Professor (CRUD completo do conteúdo)
- Listagem de unidades de curso, tópicos e aulas
- Acesso fácil aos links das videoaulas

## Estrutura do Projeto (MVC)

O sistema segue o padrão arquitetural MVC:
- **Modelos (Models):** Representam as entidades de negócio como `Usuario`, `Aula`, `Topico` e `UnidadeCurso`.
- **Controladores (Controllers):** Gerenciam o fluxo de informações e as regras de navegação.
- **Visões (Views):** Construídas em Razor Pages (HTML/CSS) para exibir a interface ao usuário final.

## Tecnologias Utilizadas

- C#
- ASP.NET Core MVC
- Entity Framework Core
- MySQL (Persistência de Dados)
- Razor / HTML / CSS

## Usuários de Teste

O sistema já é inicializado com os seguintes usuários no banco de dados para testes:

**Administrador (Professor):**
```text
email: professor@escola.com
senha: admin123
```

**Aluno:**
```text
email: aluno@escola.com
senha: aluno123
```

## Como executar o projeto

Certifique-se de que o servidor MySQL está rodando na sua máquina e configure as credenciais no arquivo `appsettings.json` se necessário.

1. Abra o terminal na pasta do projeto.
2. Execute o comando:
```powershell
dotnet run
```
3. Acesse o link gerado no terminal através do seu navegador.

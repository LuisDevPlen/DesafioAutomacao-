using ProjetoAecTeste.Models;

namespace ProjetoAecTeste.Repositorios.Interfaces
{
    // Interface para o repositório de Curso
    public interface ICursoRepository
    {
        // Método para salvar uma lista de cursos no banco de dados
        Task<CursoModel> SalvarCursos(CursoModel curso);

    }
}



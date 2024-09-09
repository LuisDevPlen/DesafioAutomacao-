using ProjetoAecTeste.Models;
using ProjetoAecTeste.Models.CursoModelDTO;

namespace ProjetoAecTeste.Services.Interfaces
{
    public interface  ICursoService
    {
        Task<CursoModel> SalvarCursos(CursoModelDTO curso);
    }
}

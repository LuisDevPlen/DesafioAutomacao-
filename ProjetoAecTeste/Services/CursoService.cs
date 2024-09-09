using ProjetoAecTeste.Models;
using ProjetoAecTeste.Models.CursoModelDTO;
using ProjetoAecTeste.Repositorios.Interfaces;
using ProjetoAecTeste.Services.Interfaces;

namespace ProjetoAecTeste.Services
{

    public class CursoService : ICursoService
        {
            private readonly ICursoRepository _cursoRepository;

            public CursoService(ICursoRepository contatoRepository)
            {
                _cursoRepository = contatoRepository;
            }
  
        public async Task<CursoModel> SalvarCursos(CursoModelDTO curso)
        {
           
                if (curso == null)
                {
                    throw new Exception("Nenhum Objeto Enviado!");
                }

                

                CursoModel item = new CursoModel();
                item.Professor = curso.Professor;
                item.CargaHoraria = curso.CargaHoraria;
                item.Titulo = curso.Titulo;
                item.Descricao = curso.Descricao;
          
            await _cursoRepository.SalvarCursos(item);

          

            // Validações
            if (item.Id == 0)
            {
                throw new InvalidOperationException("O ID do curso não foi gerado.");
            }
            if (item.Professor.Equals(""))
            {
                throw new InvalidOperationException("O Professor do curso não foi gerado.");
            }

            if (item.CargaHoraria.Equals(""))
            {
                throw new InvalidOperationException("A Carga Horaria do curso não foi gerado.");
            }

            if (item.Titulo.Equals(""))
            {
                throw new InvalidOperationException("O Titulo do curso não foi gerado.");
            }

            if (item.Descricao.Equals(""))
            {
                throw new InvalidOperationException("A Descricao do curso não foi gerado.");
            }


            return item;

            }
        }
    }




using ProjetoAecTeste.Data;
using ProjetoAecTeste.Models;
using ProjetoAecTeste.Repositorios.Interfaces;

public class CursoRepository : ICursoRepository
{
    private readonly AluraSearchDbContext _context;


    public CursoRepository(AluraSearchDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    // Método assíncrono que salva um curso no banco de dados.
    public async Task<CursoModel> SalvarCursos(CursoModel curso)
    {
    
            await _context.Curso.AddAsync(curso);
            await _context.SaveChangesAsync();

          
            return curso;
        }
       
    }


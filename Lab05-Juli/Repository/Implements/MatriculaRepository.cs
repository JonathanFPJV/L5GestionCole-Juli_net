using Lab05_Juli.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab05_Juli.Repository.Implements;

public class MatriculaRepository: GenericRepository<Matricula>, IMatriculaRepository
{
    private readonly GestioncoleContext _context;

    public MatriculaRepository(GestioncoleContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Curso?> GetCursoConEstudiantesAsync(int idCurso)
    {
        return await _context.Cursos
            .Include(c => c.Matriculas)
            .ThenInclude(m => m.IdEstudianteNavigation)
            .FirstOrDefaultAsync(c => c.IdCurso == idCurso);
    }

}
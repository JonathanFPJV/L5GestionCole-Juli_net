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
    
    public async Task RegistrarEstudianteConCursosAsync(
        Estudiante estudiante,
        IEnumerable<int> cursosIds,
        string semestre)
    {
        // 1. Agregar el estudiante
        await _context.Estudiantes.AddAsync(estudiante);

        // 2. Preparar las matrículas
        var matriculas = cursosIds.Select(idCurso => new Matricula
        {
            IdEstudiante = estudiante.IdEstudiante,
            IdCurso = idCurso,
            Semestre = semestre
        });

        await _context.Matriculas.AddRangeAsync(matriculas);
        
    }

}
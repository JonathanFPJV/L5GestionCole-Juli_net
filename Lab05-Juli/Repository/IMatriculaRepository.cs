using Lab05_Juli.Models;

namespace Lab05_Juli.Repository;

public interface IMatriculaRepository
{
    
    Task<Curso?> GetCursoConEstudiantesAsync(int idCurso);
    Task RegistrarEstudianteConCursosAsync(
        Estudiante estudiante,
        IEnumerable<int> cursosIds,
        string semestre);
}
using Lab05_Juli.DTOs;

namespace Lab05_Juli.Service;

public interface IMatriculaService
: IGenericService<MatriculaDto, MatriculaCreateDto, MatriculaUpdateDto>
{
    Task<CursoConEstudiantesDto?> GetEstudiantesByCursoAsync(int idCurso);
}
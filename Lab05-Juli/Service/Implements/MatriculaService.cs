using AutoMapper;
using Lab05_Juli.DTOs;
using Lab05_Juli.Models;
using Lab05_Juli.UnitOfWork;

namespace Lab05_Juli.Service.Implements;

public class MatriculaService:
    GenericService<Matricula, MatriculaDto, MatriculaCreateDto,MatriculaUpdateDto>,
    IMatriculaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MatriculaService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<CursoConEstudiantesDto?> GetEstudiantesByCursoAsync(int idCurso)
    {
        var curso = await _unitOfWork.Matriculas.GetCursoConEstudiantesAsync(idCurso);

        if (curso == null)
            return null;

        return _mapper.Map<CursoConEstudiantesDto>(curso);
    }
    public async Task<EstudianteDto> RegistrarEstudianteConCursosAsync(RegistrarEstudianteConCursosDto dto)
    {
        // 1. Mapear DTO a entidad Estudiante
        var estudiante = _mapper.Map<Estudiante>(dto);

        // 2. Registrar estudiante en el contexto
        await _unitOfWork.Repository<Estudiante>().AddAsync(estudiante);

        // 3. Crear matrículas para cada curso en la lista
        foreach (var cursoId in dto.CursosIds)
        {
            var matricula = new Matricula
            {
                IdEstudiante = estudiante.IdEstudiante,
                IdCurso = cursoId,
                Semestre = dto.Semestre
            };

            await _unitOfWork.Repository<Matricula>().AddAsync(matricula);
        }

        // 4. Guardar cambios
        await _unitOfWork.Complete();

        // 5. Retornar DTO de estudiante registrado
        return _mapper.Map<EstudianteDto>(estudiante);
    }

}
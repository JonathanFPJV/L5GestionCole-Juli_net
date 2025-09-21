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

}
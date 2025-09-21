using AutoMapper;
using Lab05_Juli.DTOs;
using Lab05_Juli.Models;
using Lab05_Juli.UnitOfWork;

namespace Lab05_Juli.Service.Implements;

public class CursoService :
    GenericService<Curso, CursoDto, CursoCreateDto, CursoUpdateDto>,
    ICursoService
{
    public CursoService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        
    }
}

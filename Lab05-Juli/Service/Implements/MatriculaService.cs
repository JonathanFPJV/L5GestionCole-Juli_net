using AutoMapper;
using Lab05_Juli.DTOs;
using Lab05_Juli.Models;
using Lab05_Juli.UnitOfWork;

namespace Lab05_Juli.Service.Implements;

public class MatriculaService:
    GenericService<Matricula, MatriculaDto, MatriculaCreateDto,MatriculaUpdateDto>,
    IMatriculaService
{
    public MatriculaService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        
    }
}
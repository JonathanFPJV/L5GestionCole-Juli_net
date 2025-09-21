using AutoMapper;
using Lab05_Juli.DTOs;
using Lab05_Juli.Models;
using Lab05_Juli.UnitOfWork;

namespace Lab05_Juli.Service.Implements;

public class EvaluacionService :
    GenericService<Evaluacione, EvaluacionDto, EvaluacionCreateDto, EvaluacionUpdateDto>,
    IEvaluacionService
{
    public EvaluacionService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        
    }
}
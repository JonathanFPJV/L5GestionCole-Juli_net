using AutoMapper;
using Lab05_Juli.DTOs;
using Lab05_Juli.Models;
using Lab05_Juli.UnitOfWork;

namespace Lab05_Juli.Service.Implements;

public class MateriaService:
    GenericService<Materia, MateriaDto, MateriaCreateDto, MateriaUpdateDto>,
    IMateriaService
{
    public MateriaService(IUnitOfWork unitOfWork, IMapper mapper)
    : base(unitOfWork, mapper)
    {
        
    }
}
using AutoMapper;
using Lab05_Juli.DTOs;
using Lab05_Juli.Models;
using Lab05_Juli.UnitOfWork;

namespace Lab05_Juli.Service.Implements;

public class ProfesorService:
    GenericService<Profesore, ProfesorDto, ProfesorCreateDto, ProfesorUpdateDto>,
    IProfesorService
{
    public ProfesorService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        
    }
}
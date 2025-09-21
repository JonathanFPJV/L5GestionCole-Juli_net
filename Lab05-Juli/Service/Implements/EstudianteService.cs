using AutoMapper;
using Lab05_Juli.DTOs;
using Lab05_Juli.Models;
using Lab05_Juli.UnitOfWork;

namespace Lab05_Juli.Service.Implements;

public class EstudianteService : 
    GenericService<Estudiante, EstudianteDto, EstudianteCreateDto, EstudianteUpdateDto>, 
    IEstudianteService
{
    public EstudianteService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
    }

}
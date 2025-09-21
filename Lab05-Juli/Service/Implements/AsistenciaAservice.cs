using AutoMapper;
using Lab05_Juli.DTOs;
using Lab05_Juli.Models;
using Lab05_Juli.UnitOfWork;

namespace Lab05_Juli.Service.Implements;

public class AsistenciaAservice :
    GenericService<Asistencia, AsistenciaDto, AsistenciaCreateDto, AsistenciaUpdateDto>,
    IAsistenciaService
{
    public AsistenciaAservice(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
    }
}
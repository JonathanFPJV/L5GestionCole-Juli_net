using AutoMapper;
using Lab05_Juli.DTOs;
using Lab05_Juli.Models;

namespace Lab05_Juli.AtoMaper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Estudiante, EstudianteDto>().ReverseMap();
        CreateMap<EstudianteCreateDto, Estudiante>().ReverseMap();
        CreateMap<EstudianteUpdateDto, Estudiante>().ReverseMap();
        //aisstencia
        CreateMap<Asistencia, AsistenciaDto>().ReverseMap();
        // Asistencia
        CreateMap<Asistencia, AsistenciaDto>().ReverseMap();
        CreateMap<AsistenciaCreateDto, Asistencia>().ReverseMap();  
        CreateMap<AsistenciaUpdateDto, Asistencia>().ReverseMap(); 
        // Curso
        CreateMap<Curso, CursoDto>().ReverseMap();
        CreateMap<CursoCreateDto, Curso>().ReverseMap();
        CreateMap<CursoUpdateDto, Curso>().ReverseMap();
        // Evaluacion
        CreateMap<Evaluacione, EvaluacionDto>().ReverseMap();
        CreateMap<EvaluacionCreateDto, Evaluacione>().ReverseMap();
        CreateMap<EvaluacionUpdateDto, Evaluacione>().ReverseMap();
        //Materia
        CreateMap<Materia, MateriaDto>().ReverseMap();
        CreateMap<Materia, MateriaCreateDto>().ReverseMap();
        CreateMap<Materia, MateriaUpdateDto>().ReverseMap();
        // Matricula
        CreateMap<Matricula, MatriculaDto>().ReverseMap();
        CreateMap<Matricula, MatriculaCreateDto>().ReverseMap();
        CreateMap<Matricula, MatriculaUpdateDto>().ReverseMap();
        //Profesor
        CreateMap<Profesore, ProfesorDto>().ReverseMap();
        CreateMap<ProfesorCreateDto, Profesore>().ReverseMap();
        CreateMap<ProfesorUpdateDto, Profesore>().ReverseMap();
        // Estudiante -> EstudianteCursoDto
        CreateMap<Estudiante, EstudianteCursoDto>();

        // Curso -> CursoConEstudiantesDto
        CreateMap<Curso, CursoConEstudiantesDto>()
            .ForMember(dest => dest.Estudiantes,
                opt => opt.MapFrom(src =>
                    src.Matriculas.Select(m => m.IdEstudianteNavigation)));
    }
}
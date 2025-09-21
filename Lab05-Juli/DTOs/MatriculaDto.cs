namespace Lab05_Juli.DTOs;

public class MatriculaDto
{
    public int IdMatricula { get; set; }
    public int? IdEstudiante { get; set; }
    public int? IdCurso { get; set; }
    public string? Semestre { get; set; }
}

// DTO para creación
public class MatriculaCreateDto
{
    public int? IdEstudiante { get; set; }
    public int? IdCurso { get; set; }
    public string? Semestre { get; set; }
}

// DTO para actualización
public class MatriculaUpdateDto
{
    public int IdMatricula { get; set; }
    public int? IdEstudiante { get; set; }
    public int? IdCurso { get; set; }
    public string? Semestre { get; set; }
}

public class EstudianteCursoDto
{
    public int IdEstudiante { get; set; }
    public string Nombre { get; set; } = null!;
    public int Edad { get; set; }
    public string? Correo { get; set; }
}

public class CursoConEstudiantesDto
{
    public int IdCurso { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public int Creditos { get; set; }

    public List<EstudianteCursoDto> Estudiantes { get; set; } = new();
}
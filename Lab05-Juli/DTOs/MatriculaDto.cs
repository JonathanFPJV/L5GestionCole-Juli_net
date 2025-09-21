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
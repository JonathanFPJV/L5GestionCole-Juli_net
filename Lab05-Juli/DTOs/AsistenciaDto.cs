namespace Lab05_Juli.DTOs;

// DTO de Lectura
public class AsistenciaDto
{
    public int IdAsistencia { get; set; }
    public int? IdEstudiante { get; set; }
    public int? IdCurso { get; set; }
    public DateOnly? Fecha { get; set; }
    public string? Estado { get; set; }

    
}

// DTO de Creación
public class AsistenciaCreateDto
{
    public int IdEstudiante { get; set; }
    public int IdCurso { get; set; }
    public DateOnly Fecha { get; set; }
    public string Estado { get; set; } = null!;
}

// DTO de Actualización
public class AsistenciaUpdateDto
{
    public DateOnly? Fecha { get; set; }
    public string? Estado { get; set; }
}
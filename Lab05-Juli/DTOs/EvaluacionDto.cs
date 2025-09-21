namespace Lab05_Juli.DTOs;

// DTO de Lectura
public class EvaluacionDto
{
    public int IdEvaluacion { get; set; }
    public int? IdEstudiante { get; set; }
    public int? IdCurso { get; set; }
    public decimal? Calificacion { get; set; }
    public DateOnly? Fecha { get; set; }
}

// DTO de Creación
public class EvaluacionCreateDto
{
    public int IdEstudiante { get; set; }
    public int IdCurso { get; set; }
    public decimal Calificacion { get; set; }
    public DateOnly Fecha { get; set; }
}

// DTO de Actualización
public class EvaluacionUpdateDto
{
    public int IdEvaluacion { get; set; }
    public decimal? Calificacion { get; set; }
    public DateOnly? Fecha { get; set; }
}
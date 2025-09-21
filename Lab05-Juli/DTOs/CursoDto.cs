namespace Lab05_Juli.DTOs;

public class CursoDto
{
    public int IdCurso { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public int Creditos { get; set; }
}

// DTO de creación
public class CursoCreateDto
{
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public int Creditos { get; set; }
}

// DTO de actualización
public class CursoUpdateDto
{
    public int IdCurso { get; set; }   // Necesario para identificar el registro
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public int Creditos { get; set; }
}
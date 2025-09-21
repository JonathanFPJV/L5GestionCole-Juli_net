namespace Lab05_Juli.DTOs;

public class ProfesorDto
{
    public int IdProfesor { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Especialidad { get; set; }
    public string? Correo { get; set; }
}

// DTO de Creación
public class ProfesorCreateDto
{
    public string Nombre { get; set; } = null!;
    public string? Especialidad { get; set; }
    public string? Correo { get; set; }
}

// DTO de Actualización
public class ProfesorUpdateDto
{
    public int IdProfesor { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Especialidad { get; set; }
    public string? Correo { get; set; }
}
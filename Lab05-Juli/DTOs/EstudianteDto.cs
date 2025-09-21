namespace Lab05_Juli.DTOs;

public class EstudianteDto
{
    public int IdEstudiante { get; set; }
    public string Nombre { get; set; } = null!;
    public int Edad { get; set; }
    public string? Correo { get; set; }
}

public class EstudianteCreateDto
{
    public string Nombre { get; set; } = null!;
    public int Edad { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Correo { get; set; }
}

public class EstudianteUpdateDto
{
    public int IdEstudiante { get; set; }
    public string Nombre { get; set; } = null!;
    public int Edad { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Correo { get; set; }
}
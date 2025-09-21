namespace Lab05_Juli.DTOs;

public class MateriaDto
{
    public int IdMateria { get; set; }
    public int? IdCurso { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
}

public class MateriaCreateDto
{
    public int? IdCurso { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
}

public class MateriaUpdateDto
{
    public int IdMateria { get; set; }
    public int? IdCurso { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
}
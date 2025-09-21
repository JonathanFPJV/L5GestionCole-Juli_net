using Lab05_Juli.DTOs;
using Lab05_Juli.Service;
using Microsoft.AspNetCore.Mvc;

namespace Lab05_Juli.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatriculaController: ControllerBase
{
    private readonly IMatriculaService _service;

    public MatriculaController(IMatriculaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MatriculaCreateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdMatricula }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] MatriculaUpdateDto dto)
    {
        if (id != dto.IdMatricula) return BadRequest();

        var success = await _service.UpdateAsync(dto);
        if (!success) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        if (!success) return NotFound();

        return NoContent();
    }
    
    [HttpGet("curso/{idCurso}/estudiantes")]
    public async Task<ActionResult<CursoConEstudiantesDto>> GetEstudiantesByCurso(int idCurso)
    {
        var cursoConEstudiantes = await _service.GetEstudiantesByCursoAsync(idCurso);

        if (cursoConEstudiantes == null)
            return NotFound(new { message = $"No se encontró el curso con id {idCurso}" });

        return Ok(cursoConEstudiantes);
    }

}
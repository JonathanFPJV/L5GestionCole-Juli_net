using Lab05_Juli.DTOs;
using Lab05_Juli.Service;
using Microsoft.AspNetCore.Mvc;

namespace Lab05_Juli.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AsistenciaController: Controller
{
    private readonly IAsistenciaService _service;

    public AsistenciaController(IAsistenciaService service)
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
    public async Task<IActionResult> Create([FromBody] AsistenciaCreateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdAsistencia }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] AsistenciaUpdateDto dto)
    {
        // Aseguramos que se actualice el id correcto
        if (dto == null) return BadRequest();

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
}
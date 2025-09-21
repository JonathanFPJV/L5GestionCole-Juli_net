using Lab05_Juli.DTOs;
using Lab05_Juli.Models;
using Lab05_Juli.Service;
using Lab05_Juli.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Lab05_Juli.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstudianteController: ControllerBase
{
    private readonly IEstudianteService _service;

    public EstudianteController(IEstudianteService service)
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
    public async Task<IActionResult> Create([FromBody] EstudianteCreateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdEstudiante }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EstudianteUpdateDto dto)
    {
        if (id != dto.IdEstudiante) return BadRequest();

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
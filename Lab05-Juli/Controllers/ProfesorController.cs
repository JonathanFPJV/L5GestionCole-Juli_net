using Lab05_Juli.DTOs;
using Lab05_Juli.Service;
using Microsoft.AspNetCore.Mvc;

namespace Lab05_Juli.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfesorController: ControllerBase
{
    private readonly IProfesorService _service;

    public ProfesorController(IProfesorService service)
    {
        _service = service;
    }

    // GET: api/Profesor
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    // GET: api/Profesor/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    // POST: api/Profesor
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProfesorCreateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.IdProfesor }, result);
    }

    // PUT: api/Profesor/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProfesorUpdateDto dto)
    {
        if (id != dto.IdProfesor) return BadRequest();

        var success = await _service.UpdateAsync(dto);
        if (!success) return NotFound();

        return NoContent();
    }

    // DELETE: api/Profesor/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        if (!success) return NotFound();

        return NoContent();
    }
}
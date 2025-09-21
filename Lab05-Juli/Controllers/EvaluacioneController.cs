using Lab05_Juli.DTOs;
using Lab05_Juli.Service;
using Microsoft.AspNetCore.Mvc;

namespace Lab05_Juli.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EvaluacioneController: ControllerBase
{
    private readonly IEvaluacionService _evaluacionService;

    public EvaluacioneController(IEvaluacionService evaluacionService)
    {
        _evaluacionService = evaluacionService;
    }

    // GET: api/Evaluaciones
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EvaluacionDto>>> GetAll()
    {
        var evaluaciones = await _evaluacionService.GetAllAsync();
        return Ok(evaluaciones);
    }

    // GET: api/Evaluaciones/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<EvaluacionDto>> GetById(int id)
    {
        var evaluacion = await _evaluacionService.GetByIdAsync(id);
        if (evaluacion == null)
            return NotFound();

        return Ok(evaluacion);
    }

    // POST: api/Evaluaciones
    [HttpPost]
    public async Task<ActionResult<EvaluacionDto>> Create(EvaluacionCreateDto dto)
    {
        var created = await _evaluacionService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.IdEvaluacion }, created);
    }

    // PUT: api/Evaluaciones/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EvaluacionUpdateDto dto)
    {
        if (id != dto.IdEvaluacion)
            return BadRequest("El ID del parámetro no coincide con el del objeto.");

        var updated = await _evaluacionService.UpdateAsync(dto);
        if (!updated)
            return NotFound();

        return NoContent();
    }

    // DELETE: api/Evaluaciones/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _evaluacionService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
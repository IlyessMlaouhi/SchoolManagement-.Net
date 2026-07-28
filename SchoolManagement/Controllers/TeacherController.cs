using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Dtos;
using SchoolManagement.Services.Interfaces;

namespace SchoolManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeacherDto>>> GetAll()
    {
        return Ok(await _teacherService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TeacherDto>> GetById(int id)
    {
        var teacher = await _teacherService.GetByIdAsync(id);
        return teacher is null ? NotFound() : Ok(teacher);
    }

    [HttpPost]
    public async Task<ActionResult<TeacherDto>> Create(CreateTeacherDto dto)
    {
        var created = await _teacherService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTeacherDto dto)
    {
        var updated = await _teacherService.UpdateAsync(id, dto);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _teacherService.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
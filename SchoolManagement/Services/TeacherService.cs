using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Dtos;
using SchoolManagement.Models;
using SchoolManagement.Services.Interfaces;

namespace SchoolManagement.Services;

public class TeacherService : ITeacherService
{
    private readonly AppDbContext _context;

    public TeacherService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TeacherDto>> GetAllAsync()
    {
        return await _context.Teachers
            .Select(t => new TeacherDto(t.Id, t.FirstName, t.LastName, t.Email))
            .ToListAsync();
    }

    public async Task<TeacherDto?> GetByIdAsync(int id)
    {
        var teacher = await _context.Teachers.FindAsync(id);
        return teacher is null
            ? null
            : new TeacherDto(teacher.Id, teacher.FirstName, teacher.LastName, teacher.Email);
    }

    public async Task<TeacherDto> CreateAsync(CreateTeacherDto dto)
    {
        var teacher = new Teacher
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        };

        _context.Teachers.Add(teacher);
        await _context.SaveChangesAsync();

        return new TeacherDto(teacher.Id, teacher.FirstName, teacher.LastName, teacher.Email);
    }

    public async Task<bool> UpdateAsync(int id, UpdateTeacherDto dto)
    {
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher is null) return false;

        teacher.FirstName = dto.FirstName;
        teacher.LastName = dto.LastName;
        teacher.Email = dto.Email;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher is null) return false;

        _context.Teachers.Remove(teacher);
        await _context.SaveChangesAsync();
        return true;
    }
}
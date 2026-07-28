using SchoolManagement.Dtos;

namespace SchoolManagement.Services.Interfaces;

public interface ITeacherService
{
    Task<IEnumerable<TeacherDto>> GetAllAsync();
    Task<TeacherDto?> GetByIdAsync(int id);
    Task<TeacherDto> CreateAsync(CreateTeacherDto dto);
    Task<bool> UpdateAsync(int id, UpdateTeacherDto dto);
    Task<bool> DeleteAsync(int id);
}
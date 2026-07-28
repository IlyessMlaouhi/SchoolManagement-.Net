namespace SchoolManagement.Dtos;


public record TeacherDto(int Id, string FirstName, string LastName, string Email);

public record CreateTeacherDto(string FirstName, string LastName, string Email);

public record UpdateTeacherDto(string FirstName, string LastName, string Email);
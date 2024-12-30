using LectorNet.Domain.Models.Common;

namespace LectorNet.Domain.Models.Users;

public class User : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    
    public int? ReadingStatistics { get; set; }
    
    public string? PhoneNumber { get; set; }

    public string? City { get; set; }
    
    public UserRole Role { get; set; } = UserRole.RegularUser;
}
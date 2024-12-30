using Ardalis.SmartEnum;

namespace LectorNet.Domain.Models.Users;

public class UserRole(string name, int value) : SmartEnum<UserRole>(name, value)
{
    public static readonly UserRole RegularUser = new(nameof(RegularUser),0);
    public static readonly UserRole Admin = new(nameof(Admin),1);
}
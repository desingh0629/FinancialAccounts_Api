using FinancialAccounts.Model.Entities;

namespace FinancialAccounts.Interfases
{
    public interface IRoleInterface
    {
        Task<Role> GetRoleAsync(Guid roleId);
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<Role> CreateRoleAsync(Role role);
        Task UpdateRoleAsync(Guid roleId, Role role);
        Task DeleteRoleAsync(Guid roleId);
    }
}

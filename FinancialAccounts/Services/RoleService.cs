using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Data;
using FinancialAccounts.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialAccounts.Services
{
    public class RoleService : IRoleInterface
    {
        private readonly ApplicationDbContext _context;

        public RoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Role> GetRoleAsync(Guid roleId) => await _context.Roles.FindAsync(roleId);

        public async Task<IEnumerable<Role>> GetRolesAsync() => await _context.Roles.ToListAsync();

        public async Task<Role> CreateRoleAsync(Role role)
        {
            Role rol = new();
            rol.RoleId = Guid.NewGuid();
            rol.BusinessUnitId = rol.RoleId;
            rol.CreatedId = rol.RoleId;
            rol.UpdatedId = rol.RoleId;
            rol.CreatedDate = DateTime.Now;
            rol.UpdatedDate = DateTime.Now;
            rol.Name = role.Name;
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task UpdateRoleAsync(Guid roleId, Role role)
        {
            var existingRole = await _context.Roles.FindAsync(roleId);
            if (existingRole != null)
            {
                existingRole.Name = role.Name;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteRoleAsync(Guid roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using FinancialAccounts.DTOs;
using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Data;
using FinancialAccounts.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace FinancialAccounts.Services
{
    public class AccountGroupService : IAccountGroupInterface
    {
        private readonly ApplicationDbContext _context;

        public AccountGroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AccountGroup> GetGroupAsync(Guid groupId)
        {
            return await _context.AccountGroups.FindAsync(groupId);
        }

        public async Task<IEnumerable<AccountGroup>> GetGroupsAsync()
        {
            return await _context.AccountGroups.ToListAsync();
        }

        public async Task<ServiceResponse> CreateGroupAsync(AccountGroup group)
        {
            _context.AccountGroups.Add(group);
            await _context.SaveChangesAsync();
            return new ServiceResponse(true, "Account Group Created Successfully.");

        }

        public async Task<ServiceResponse> UpdateGroupAsync(Guid groupId, AccountGroup group)
        {
            var existingGroup = await _context.AccountGroups.FindAsync(groupId);
            if (existingGroup != null)
            {
                existingGroup.GroupName = group.GroupName;
                existingGroup.ParentGroupId = group.ParentGroupId;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
            return new ServiceResponse(true, "Account Group Updated Successfully.");

        }

        public async Task<ServiceResponse> DeleteGroupAsync(Guid groupId)
        {
            var group = await _context.AccountGroups.FindAsync(groupId);
            if (group != null)
            {
                _context.AccountGroups.Remove(group);
                await _context.SaveChangesAsync();
            }
            return new ServiceResponse(true, "Account Group Deleted Successfully.");
        }
    }
}

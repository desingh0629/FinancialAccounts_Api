using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Data;
using FinancialAccounts.Model.Entities;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.EntityFrameworkCore;

namespace FinancialAccounts.Services
{
    public class CostCenterService : ICostCenterInterface
    {
        private readonly ApplicationDbContext _context;

        public CostCenterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CostCenter> GetCostCenterAsync(Guid centerId)
        {
            return await _context.CostCenters.FindAsync(centerId);
        }

        public async Task<IEnumerable<CostCenter>> GetCostCentersAsync()
        {
            return await _context.CostCenters.ToListAsync();
        }

        public async Task<CostCenter> CreateCostCenterAsync(CostCenter costCenter)
        {
            _context.CostCenters.Add(costCenter);
            await _context.SaveChangesAsync();
            return costCenter;
        }

        public async Task UpdateCostCenterAsync(Guid centerId, CostCenter costCenter)
        {
            var existingCostCenter = await _context.CostCenters.FindAsync(centerId);
            if (existingCostCenter != null)
            {
                existingCostCenter.Name = costCenter.Name;
                existingCostCenter.ChartOfAccountId = costCenter.ChartOfAccountId;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCostCenterAsync(Guid centerId)
        {
            var costCenter = await _context.CostCenters.FindAsync(centerId);
            if (costCenter != null)
            {
                _context.CostCenters.Remove(costCenter);
                await _context.SaveChangesAsync();
            }
        }
    }
}

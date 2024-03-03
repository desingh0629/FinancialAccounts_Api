using FinancialAccounts.Model.Entities;

namespace FinancialAccounts.Interfases
{
    public interface ICostCenterInterface
    {
        Task<CostCenter> GetCostCenterAsync(Guid centerId);
        Task<IEnumerable<CostCenter>> GetCostCentersAsync();
        Task<CostCenter> CreateCostCenterAsync(CostCenter costCenter);
        Task UpdateCostCenterAsync(Guid centerId, CostCenter costCenter);
        Task DeleteCostCenterAsync(Guid centerId);
    }
}

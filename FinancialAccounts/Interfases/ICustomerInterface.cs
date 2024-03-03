using FinancialAccounts.Model.Entities;

namespace FinancialAccounts.Interfases
{
    public interface ICustomerInterface
    {
        Task<Customer> GetCustomerAsync(Guid customerId);
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Guid customerId, Customer customer);
        Task DeleteCustomerAsync(Guid customerId);
    }
}

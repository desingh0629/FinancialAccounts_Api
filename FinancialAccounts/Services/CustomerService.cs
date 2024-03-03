using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Data;
using FinancialAccounts.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialAccounts.Services
{
    public class CustomerService : ICustomerInterface
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerAsync(Guid customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task UpdateCustomerAsync(Guid customerId, Customer customer)
        {
            var existingCustomer = await _context.Customers.FindAsync(customerId);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.ContactNumber = customer.ContactNumber;
                existingCustomer.Email = customer.Email;
                existingCustomer.BillingAddress = customer.BillingAddress;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCustomerAsync(Guid customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using FinancialAccounts.Model.Entities;

namespace FinancialAccounts.Interfases
{
    public interface IProductInterface
    {
        Task<Product> GetProductAsync(Guid productId);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> CreateProductAsync(Product product);
        Task UpdateProductAsync(Guid productId, Product product);
        Task DeleteProductAsync(Guid productId);
    }
}

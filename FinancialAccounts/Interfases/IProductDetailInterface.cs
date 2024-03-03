using FinancialAccounts.Model.Entities;

namespace FinancialAccounts.Interfases
{
    public interface IProductDetailInterface
    {
        Task<ProductDetails> GetProductDetailsAsync(Guid productDetailId);
        Task<IEnumerable<ProductDetails>> GetProductDetailsByProductIdAsync(Guid productId);
        Task<ProductDetails> CreateProductDetailsAsync(ProductDetails productDetails);
        Task UpdateProductDetailsAsync(Guid productDetailId, ProductDetails productDetails);
        Task DeleteProductDetailsAsync(Guid productDetailId);
    }
}

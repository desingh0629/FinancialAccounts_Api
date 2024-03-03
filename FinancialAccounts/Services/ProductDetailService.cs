using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Data;
using FinancialAccounts.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialAccounts.Services
{
    public class ProductDetailService : IProductDetailInterface
    {
        private readonly ApplicationDbContext _context;

        public ProductDetailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDetails> GetProductDetailsAsync(Guid productDetailId)
        {
            return await _context.ProductDetails.FindAsync(productDetailId);
        }

        public async Task<IEnumerable<ProductDetails>> GetProductDetailsByProductIdAsync(Guid productId)
        {
            return await _context.ProductDetails.Where(pd => pd.ProductId == productId).ToListAsync();
        }

        public async Task<ProductDetails> CreateProductDetailsAsync(ProductDetails productDetails)
        {
            _context.ProductDetails.Add(productDetails);
            await _context.SaveChangesAsync();
            return productDetails;
        }

        public async Task UpdateProductDetailsAsync(Guid productDetailId, ProductDetails productDetails)
        {
            var existingProductDetails = await _context.ProductDetails.FindAsync(productDetailId);
            if (existingProductDetails != null)
            {
                existingProductDetails.Name = productDetails.Name;
                existingProductDetails.Description = productDetails.Description;
                existingProductDetails.UnitPrice = productDetails.UnitPrice;
                // Update other properties as needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProductDetailsAsync(Guid productDetailId)
        {
            var productDetails = await _context.ProductDetails.FindAsync(productDetailId);
            if (productDetails != null)
            {
                _context.ProductDetails.Remove(productDetails);
                await _context.SaveChangesAsync();
            }
        }
    }
}

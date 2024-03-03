using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Entities;
using FinancialAccounts.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialAccounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailInterface _productDetailsService;

        public ProductDetailsController(IProductDetailInterface productDetailsService)
        {
            _productDetailsService = productDetailsService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetails>> GetProductDetails(Guid id)
        {
            var productDetails = await _productDetailsService.GetProductDetailsAsync(id);
            if (productDetails == null)
            {
                return NotFound();
            }
            return productDetails;
        }

        [HttpGet("product/{productId}")]
        public async Task<ActionResult<IEnumerable<ProductDetails>>> GetProductDetailsByProductId(Guid productId)
        {
            var productDetails = await _productDetailsService.GetProductDetailsByProductIdAsync(productId);
            return Ok(productDetails);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDetails>> CreateProductDetails(ProductDetails productDetails)
        {
            var createdProductDetails = await _productDetailsService.CreateProductDetailsAsync(productDetails);
            return CreatedAtAction(nameof(GetProductDetails), new { id = createdProductDetails.ProductDetailId }, createdProductDetails);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductDetails(Guid id, ProductDetails productDetails)
        {
            await _productDetailsService.UpdateProductDetailsAsync(id, productDetails);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetails(Guid id)
        {
            await _productDetailsService.DeleteProductDetailsAsync(id);
            return NoContent();
        }
    }
}

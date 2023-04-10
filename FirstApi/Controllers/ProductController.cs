using FirstApi.Data.DAL;
using FirstApi.Dtos.ProductDtos;
using FirstApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{

    public class ProductController : BaseController
    {
        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _appDbContext.Products.ToList();
            return StatusCode(200, products);
            //return Ok(new {Code=1001,products});
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetOne(int id)

        {
            Product product = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return StatusCode(StatusCodes.Status404NotFound);

            return Ok(product);
        }
        [HttpPost]
        public IActionResult AddProduct(ProductCreateDto productCreateDto)
        {
            Product newProduct = new()
            {
                Name = productCreateDto.Name,
                SalePrice = productCreateDto.SalePrice,
                CostPrice = productCreateDto.CostPrice,

            };
            _appDbContext.Products.Add(newProduct);
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, newProduct);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteProduct(int id)
        {
            var product = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            _appDbContext.Products.Remove(product);
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        { 
        var existProduct =_appDbContext.Products.FirstOrDefault(p=>p.Id==id);
            if (existProduct == null) return NotFound();
            existProduct.Name = productUpdateDto.Name;
            existProduct.SalePrice= productUpdateDto.SalePrice;
            existProduct.CostPrice= productUpdateDto.CostPrice;
            existProduct.IsActive = productUpdateDto.IsActive;
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPatch]
        public IActionResult ChangeStatus(bool IsActive,Product product)
        {
            var existProduct = _appDbContext.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existProduct == null) return NotFound();
            existProduct.IsActive = IsActive;
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent);

        }

    }

}

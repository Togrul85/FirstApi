using FirstApi.Data.DAL;
using FirstApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
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
            Product product =_appDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return StatusCode(StatusCodes.Status404NotFound);
          
            return Ok(product);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
        _appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created,product);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteProduct(int id) 
        {
            var product = _appDbContext.Products.FirstOrDefault(p=>p.Id == id);
            if (product==null) return NotFound();
            _appDbContext.Products.Remove(product);
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent);
            
        }

        [HttpPut]
        public IActionResult UpdateProduct( int id,Product product)
        { 
        var existProduct =_appDbContext.Products.FirstOrDefault(p=>p.Id==product.Id);
            if (existProduct == null) return NotFound();
            existProduct.Name =product.Name;
            existProduct.SalePrice=product.SalePrice;
            existProduct.CostPrice=product.CostPrice;
            existProduct.IsActive =product.IsActive;
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

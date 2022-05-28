using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    //We need to give it the API controller attribute and Route. 
    //adding the api/ is optional but conventional
    [ApiController]
    [Route("api/[controller]")]

    //since this is a controller, you need to derive from ControllerBase, if it shows error,
    //click on command + . and select using for the base.
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        //inject storecontext into productscontroller
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;


        }

        //Action definition Public methods on a controller
        //Couple of methods/ couple of endpoints and both will be httpget
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) 
        {
            return Ok(await _repo.GetProductByIdAsync(id));   
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands() 
        {
            return Ok(await _repo.GetProductBrandsAsync());   
        }
        
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes() 
        {
            return Ok(await _repo.GetProductTypesAsync());   
        }
    }
}
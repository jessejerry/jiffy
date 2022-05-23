using Core.Entities;
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

        //inject storecontext into productscontroller
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        //Action definition Public methods on a controller
        //Couple of methods/ couple of endpoints and both will be httpget
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) 
        {

            return await _context.Products.FindAsync(id);
        }
        
    }
}
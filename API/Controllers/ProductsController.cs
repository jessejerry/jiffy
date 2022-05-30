using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
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
        
        private readonly IGenericRepository<Product> __productsRepo;
        private readonly IGenericRepository<ProductBrand> __productBrandRepo;
        private readonly IGenericRepository<ProductType> __productTypeRepo;
        private readonly IMapper _mapper;

        //inject storecontext into productscontroller
        public ProductsController(IGenericRepository<Product> productsRepo, 
        IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> 
        productTypeRepo, IMapper mapper)
        {
            _mapper = mapper;
            __productTypeRepo = productTypeRepo;
            __productBrandRepo = productBrandRepo;
            __productsRepo = productsRepo;

        }

        //Action definition Public methods on a controller
        //Couple of methods/ couple of endpoints and both will be httpget
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {

            var spec = new ProductsWithTypesAndBrandsSpecification();

            var products = await __productsRepo.ListAsync(spec);

            return Ok(_mapper
                .Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id) 
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await __productsRepo.GetEntityWithSpec(spec); 

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands() 
        {
            return Ok(await __productBrandRepo.ListAllAsync());   
        }
        
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes() 
        {
            return Ok(await __productTypeRepo.ListAllAsync());   
        }
    }
}
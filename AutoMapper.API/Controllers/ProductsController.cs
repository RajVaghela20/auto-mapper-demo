using AutoMapper.API.Dtos;
using AutoMapper.Core.DTOs;
using AutoMapper.Core.models;
using AutoMapper.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapper.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> AddProduct([FromBody] AddProductDto addproductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _mapper.Map<Product>(addproductDto);
            await _productService.AddProduct(addproductDto);

            var createdProductDto = _mapper.Map<ProductDto>(product);
            return Ok(createdProductDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(long id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto updateproductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = _mapper.Map<Product>(updateproductDto);
            try
            {
                await _productService.UpdateProduct(updateproductDto);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            try
            {
                await _productService.DeleteProduct(id);
            }
            catch (Exception)
            {

                return NotFound();
            }
            return NoContent();
        }
    }
}

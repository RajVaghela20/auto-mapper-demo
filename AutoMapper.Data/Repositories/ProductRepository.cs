using AutoMapper.API.Dtos;
using AutoMapper.Core.DTOs;
using AutoMapper.Core.Interfaces;
using AutoMapper.Core.models;
using AutoMapper.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
          var products =  await _context.Products.ToListAsync();
          var productDto = _mapper.Map<List<ProductDto>>(products);
          return productDto;
        }
        public async Task<ProductDto> GetProductById(long id)
        {
           var productModel =  await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
           var productDto = _mapper.Map<ProductDto>(productModel);
           return productDto;
        }
        public async Task<ProductDto> AddProduct(AddProductDto product)
        {
            var productModel = _mapper.Map<Product>(product);
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();

            var productDto = _mapper.Map<ProductDto>(productModel);
            return productDto;
        }
        public async Task UpdateProduct(UpdateProductDto product)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                _mapper.Map(product, existingProduct);
                await _context.SaveChangesAsync();
            }
            //_context.Entry(product).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

        }
        public async Task DeleteProduct(long id)
        {

            var productDelete = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (productDelete != null)
            {
                _context.Products.Remove(productDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}

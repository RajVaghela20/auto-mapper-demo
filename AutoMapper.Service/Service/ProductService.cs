using AutoMapper.API.Dtos;
using AutoMapper.Core.DTOs;
using AutoMapper.Core.Interfaces;
using AutoMapper.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
          return  await _productRepository.GetAllProducts();
        }
        public async Task<ProductDto> GetProductById(long id)
        {
           return await _productRepository.GetProductById(id);
        }
        public async Task AddProduct(AddProductDto product)
        {
            await _productRepository.AddProduct(product);
        }
        public async Task UpdateProduct(UpdateProductDto product)
        {
           await _productRepository.UpdateProduct(product);
        }
        public async Task DeleteProduct(long id)
        {
            await _productRepository.DeleteProduct(id);
        }    

    }
}

using AutoMapper.API.Dtos;
using AutoMapper.Core.DTOs;
using AutoMapper.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Service
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProductById(long id);
        Task AddProduct(AddProductDto product);
        Task UpdateProduct(UpdateProductDto product);
        Task DeleteProduct(long id);
    }
}

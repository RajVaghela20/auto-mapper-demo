using AutoMapper.API.Dtos;
using AutoMapper.Core.DTOs;
using AutoMapper.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Core.Mapping
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<AddProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}

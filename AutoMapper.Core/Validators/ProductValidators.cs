using AutoMapper.API.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Core.Validators
{
    public class ProductValidators : AbstractValidator<ProductDto>
    {
        public ProductValidators()
        {
            RuleFor(productDto => productDto.Name).NotEmpty().MaximumLength(50).MaximumLength(3);
            RuleFor(productDto => productDto.Description).MaximumLength(100);
        }
    }
}

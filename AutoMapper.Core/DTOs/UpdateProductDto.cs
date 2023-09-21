using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Core.DTOs
{
    public class UpdateProductDto
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

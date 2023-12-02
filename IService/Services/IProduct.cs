using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventory.DTO;

namespace inventory.IServiceCategory.Services
{
    public interface IProduct
    {
        public Task<ProductDto> Create(ProductDTO objDto);
        public Task<ProductDto> Update(ProductDTO objDto);
        public Task<int> Delete(int id);
        public Task<ProductDto> Get(int id);
        public Task<IEnumerable<ProductDto>> GetAll();
    }
}
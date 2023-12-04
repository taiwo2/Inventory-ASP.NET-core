using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventory.DTO;

namespace inventory.IService.Services
{
    public interface IProduct
    {
        public Task<ProductDto> Create(ProductDto objDto);
        public Task<ProductDto> Update(ProductDto objDto);
        public Task<int> Delete(int id);
        public Task<ProductDto> Get(int id);
        public Task<IEnumerable<ProductDto>> GetAll();
    }
}
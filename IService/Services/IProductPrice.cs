using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventory.DTO;

namespace inventory.IService.Services
{
    public interface IProductPrice
    {
        public Task<ProductPriceDto> Create(ProductPriceDto objDTO);
        public Task<ProductPriceDto> Update(ProductPriceDto objDTO);
        public Task<int> Delete(int id);
        public Task<ProductPriceDto> Get(int id);
        public Task<IEnumerable<ProductPriceDto>> GetAll(int? id=null);
    }
}
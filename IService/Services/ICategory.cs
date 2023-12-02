using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventory.DTO;

namespace inventory.IServiceCategory.Services
{
    public interface ICategory
    {
        public Task<CategoryDto> Create(CategoryDTO objDto);
        public Task<CategoryDto>  Update(CategoryDTO  objDto);
        public Task<int> Delete(int id);
        public Task<CategoryDto> Get(int id);
        public Task<IEnumerable<CategoryDto>> GetAll();
    }
}
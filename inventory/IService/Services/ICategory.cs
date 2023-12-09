using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using inventory.DTO;


namespace inventory.IService.Services
{
    public interface ICategory
    {
        public Task<CategoryDto> Create(CategoryDto objDto);
        public Task<CategoryDto>  Update(CategoryDto  objDto);
        public Task<int> Delete(int id);
        public Task<CategoryDto> Get(int id);
        public Task<IEnumerable<CategoryDto>> GetAll();
    }
}
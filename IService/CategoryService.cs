using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using inventory.Data;
using inventory.Model;
using inventory.DTO;
using AutoMapper;
using inventory.IService.Services;

namespace inventory.IService
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoryService(ApplicationDbContext db, IMapper mapper)

        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Create(CategoryDto objDto)

        {
            var obj= _mapper.Map<CategoryDto,Category>(objDto);
            obj.CreatedDate = DateTime.Now;
            // var items =  _db.categories.Add(category);
            _db.Categories.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Category,CategoryDto>(obj);
            //  return _mapper.Map<catategory,CategoryDTO>(items.entity)
            // Category catategory = new Category
            // {
            //     Name = objDTO.Name,
            //     Id = objDTO.Id,
            //     CreatedDate = DateTime.Now()
            // };

            // _db.categories.Add(catategory);
            // _db,SaveChanges();

            // return CategoryDTO()
            // {

            //     Id = catategory.Id,
            //     Name = catategory.Name,
            // }
        }

        public async Task<int> Delete(int id)
        {
            var obj =  await _db.Categories.FirstOrDefaultAsync(u => u.Id== id);
            if (obj!=null)
            {
                 _db.Categories.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<CategoryDto> Get(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(u => u.Id== id);
            if (obj!=null)
            {
                return _mapper.Map<Category,CategoryDto>(obj);
            }
            return new CategoryDto();
        }
        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>,IEnumerable<CategoryDto>>(_db.Categories);
        }
        
        public async Task<CategoryDto> Update(CategoryDto  objDTO)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(u => u.Id== objDTO.Id);
            if (obj!=null)
            {
                obj.Name= objDTO.Name;
                _db.Categories.Update(obj);
                await _db.SaveChangesAsync();
                return _mapper.Map<Category,CategoryDto>(obj);
            }
            return objDTO;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using inventory.Data;
using inventory.Model;
using inventory.IServiceCategory.Services;
using inventory.DTO;
using AutoMapper;

namespace inventory.IServiceCategory
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

        public async Task<CategoryDTO> Create(CategoryDTO objDTO)

        {
            var obj= _mapper.Map<CategoryDTO,Category>(objDTO);
            obj.CreatedDate = DateTime.Now;
            // var items =  _db.categories.Add(category);
            _db.Categories.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Category,CategoryDTO>(obj);
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
        public async Task<CategoryDTO> Get(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(u => u.Id== id);
            if (obj!=null)
            {
                return _mapper.Map<Category,CategoryDTO>(obj);
            }
            return new CategoryDTO();
        }
        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>,IEnumerable<CategoryDTO>>(_db.Categories);
        }
        
        public async Task<CategoryDTO> Update(CategoryDTO  objDTO)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(u => u.Id== objDTO.Id);
            if (obj!=null)
            {
                obj.Name= objDTO.Name;
                _db.Categories.Update(obj);
                await _db.SaveChangesAsync();
                return _mapper.Map<Category,CategoryDTO>(obj);
            }
            return objDTO;
        }
    }
}

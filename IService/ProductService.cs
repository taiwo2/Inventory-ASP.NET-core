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
    public class ProductService : IProduct
    {
        // private readonly ApplicationDbContext _db;
        // private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> Create(ProductDto objDto)
        {
            var obj = _mapper.Map<ProductDto, Product>(objDto);
           var addedObj =  _db.Products.Add(obj);
            await _db.SaveChangesAsync();

           return _mapper.Map<Product, ProductDto>(addedObj.Entity);
        }
        public async Task<int> Delete(int id)
        {
            var obj = await _db.Products.FirstOrDefaultAsync(u => u.Id==id);
            if (obj!=null)
            {
                _db.Products.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<ProductDto> Get(int id)
        {
            var obj = await _db.Products.Include(u => u.Category).FirstOrDefaultAsync(u => u.Id==id);
            if (obj!=null)
            {
               return _mapper.Map<Product, ProductDto>(obj);
            }
            return new ProductDto();
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(_db.Products.Include(u => u.Category));
        }

        public async Task<ProductDto> Update(ProductDto objDTO)
        {
            var objFromDb = await _db.Products.FirstOrDefaultAsync(u => u.Id==objDTO.Id);
            if (objFromDb!=null)
            {
                objFromDb.Name=objDTO.Name;
                objFromDb.Description = objDTO.Description;
                objFromDb.ImageUrl = objDTO.ImageUrl;
                objFromDb.CategoryId = objDTO.CategoryId;
                objFromDb.Color= objDTO.Color;
                objFromDb.ShopFavorites = objDTO.ShopFavorites;
                objFromDb.CustomerFavorites = objDTO.CustomerFavorites;
                _db.Products.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Product, ProductDto>(objFromDb);
            }
            return objDTO;

        }

    }
}
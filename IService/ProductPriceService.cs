using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using inventory.Data;
using inventory.Model;
using inventory.DTO;
using AutoMapper;
using inventory.IService.Services;

namespace inventory.IService
{
    public class ProductPriceService : IProductPrice
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductPriceRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductPriceDto> Create(ProductPriceDto objDTO)
        {
            var obj = _mapper.Map<ProductPriceDTO, ProductPrice>(objDTO);
           
           var addedObj =  _db.ProductPrices.Add(obj);
            await _db.SaveChangesAsync();

           return _mapper.Map<ProductPrice, ProductPriceDto>(addedObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.ProductPrices.FirstOrDefaultAsync(u => u.Id==id);
            if (obj!=null)
            {
                _db.ProductPrices.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<ProductPriceDto> Get(int id)
        {
            var obj = await _db.ProductPrices.FirstOrDefaultAsync(u => u.Id==id);
            if (obj!=null)
            {
               return _mapper.Map<ProductPrice, ProductPriceDto>(obj);
            }
            return new ProductPriceDto();
        }

        public async Task<IEnumerable<ProductPriceDto>> GetAll(int? id =null)
        {
            if (id!=null && id>0)
            {
                return _mapper.Map<IEnumerable<ProductPrice>, IEnumerable<ProductPriceDTO>>
                    (_db.ProductPrices.Where(u=>u.ProductId==id));
            }
            else
            {
                return _mapper.Map<IEnumerable<ProductPrice>, IEnumerable<ProductPriceDto>>(_db.ProductPrices);
            }
        }

        public async Task<ProductPriceDto> Update(ProductPriceDto objDTO)
        {
            var objFromDb = await _db.ProductPrices.FirstOrDefaultAsync(u => u.Id==objDTO.Id);
            if (objFromDb!=null)
            {
                objFromDb.Price = objDTO.Price;
                objFromDb.Size = objDTO.Size;
                objFromDb.ProductId= objDTO.ProductId;
                _db.ProductPrices.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<ProductPrice, ProductPriceDto>(objFromDb);
            }
            return objDTO;

        }
    }
}
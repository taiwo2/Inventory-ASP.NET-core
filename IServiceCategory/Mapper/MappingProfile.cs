using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using inventory.Model;
using inventory.DTO;
// using inventory.IServiceCategory;
// using inventory.IServiceCategory.Services;

namespace inventory.IServiceCategory.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }

    }
}
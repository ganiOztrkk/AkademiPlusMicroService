using AkademiPlusMicroService.Catalog.Dtos.CategoryDtos;
using AkademiPlusMicroService.Catalog.Dtos.ProductDtos;
using AkademiPlusMicroService.Catalog.Models;
using AutoMapper;

namespace AkademiPlusMicroService.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}

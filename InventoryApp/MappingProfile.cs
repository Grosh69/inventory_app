using AutoMapper;
using InventoryApp.DTOs;
using InventoryApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();

        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();

        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
    }
}